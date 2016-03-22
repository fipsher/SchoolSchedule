using SchoolScheduleManager.Entities;
using SchoolScheduleManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace SchoolScheduleManager.Repositories.Repositories
{
    public class SqlLessonRepository : ILessonRepository
    {
        #region Private Fields region
        private readonly string _connectionString;
        #endregion

        #region Queries region
        private const string inputLessonQuery = "spInputLesson";

        private const string removeLessonQuery = "spRemoveLesson";

        private const string getAllLessonsQuery = @"SELECT l.Id as 'Id'
			                                            , g.Id as 'GroupId'
			                                            , g.Name as 'GroupName'
			                                            , t.Id as 'TeacherId'
			                                            , t.Name as 'TeacherName'
			                                            , t.Surname as 'TeacherSurName'
			                                            , s.Id as 'SubjectId'
			                                            , s.Name as 'SubjectName'
			                                            , r.Id as 'RoomId'
			                                            , r.Number as 'RoomNumber'
			                                            , l.Year as 'Year'
			                                            , l.LessonNumber as 'LessonNumber'
			                                            , l.DayOfWeek as 'DayOfWeek'
			                                            , l.Semester as 'Semester'
		                                            FROM[dbo].[tblLesson] as l
		                                            INNER JOIN[dbo].[tblTeacher] as t
		                                            ON l.TeacherId = t.Id
		                                            INNER JOIN[dbo].[tblGroup] as g
		                                            ON g.Id = l.GroupId
		                                            INNER JOIN[dbo].[tblRoom] as r
		                                            ON r.Id = l.RoomId
		                                            INNER JOIN[dbo].[tblSubject] as s
		                                            ON s.Id = l.SubjectId
		                                            WHERE l.Deleted = 0
		                                            AND g.Deleted = 0
		                                            AND s.Deleted = 0
		                                            AND r.Deleted = 0
		                                            AND t.Deleted = 0
		                                            AND l.Deleted = 0
		                                            ORDER BY l.DayOfWeek, l.LessonNumber;";
        #endregion

        #region Constructors region
        public SqlLessonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region ILessonRepository region

        /// <summary>
        /// Add lesson to Database
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public string InputLesson(Lesson lesson)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = inputLessonQuery;

                        #region sqlParams creating region
                        SqlParameter sqlTeacherId = new SqlParameter("@teacherId", lesson.CurrentTeacher.Id);
                        SqlParameter sqlGroupId = new SqlParameter("@groupId", lesson.CurrentGroup.Id);
                        SqlParameter sqlRoomId = new SqlParameter("@roomId", lesson.CurrentRoom.Id);
                        SqlParameter sqlSubjectId = new SqlParameter("@SubjectId", lesson.CurrentSubject.Id);
                        SqlParameter sqlYear = new SqlParameter("@year", lesson.Year);
                        SqlParameter sqlSemesterId = new SqlParameter("@semester", lesson.Semester);
                        SqlParameter sqlDayOfWeek = new SqlParameter("@dayOfWeek", lesson.DayOfWeek);
                        SqlParameter sqlLessonNumber = new SqlParameter("@lessonNumber", lesson.LessonNumber);
                        SqlParameter sqlOutParam = new SqlParameter("@result", 0);
                        sqlOutParam.Direction = ParameterDirection.Output;


                        #endregion

                        #region sqlParams adding to command region

                        command.Parameters.Add(sqlTeacherId);
                        command.Parameters.Add(sqlGroupId);
                        command.Parameters.Add(sqlRoomId);
                        command.Parameters.Add(sqlSubjectId);
                        command.Parameters.Add(sqlYear);
                        command.Parameters.Add(sqlSemesterId);
                        command.Parameters.Add(sqlDayOfWeek);
                        command.Parameters.Add(sqlLessonNumber);
                        command.Parameters.Add(sqlOutParam);
                        #endregion

                        command.ExecuteNonQuery();
                        string msgString = "";
                        switch (int.Parse(sqlOutParam.Value.ToString()))
                        {
                            case 1:
                                {
                                    msgString = "This group already has a lesson at that time";
                                }
                                break;
                            case 2:
                                {
                                    msgString = "This teacher already has a lesson at that time";
                                }
                                break;
                            case 3:
                                {
                                    msgString = "This room already has a lesson at that time";
                                }
                                break;

                            case 0:
                                {
                                    msgString = "Succesfully added";
                                }
                                break;
                        }
                        scope.Complete();
                        return msgString;
                    }
                }
            }
        }
        
        /// <summary>
        /// Get all lessons
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Lesson> GetAllLessons()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;

                    command.CommandText = getAllLessonsQuery;
                    command.Connection = connection;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Lesson> lessonList = new List<Lesson>();
                        while (reader.Read())
                        {
                            Lesson tempLesson = new Lesson();
                            tempLesson.Id = (int)reader["Id"];
                            tempLesson.CurrentGroup = new Group() { Id = (int)reader["GroupId"], GroupName = (string)reader["GroupName"] };
                            tempLesson.CurrentTeacher = new Teacher() { Id = 1, Name = (string)reader["TeacherName"], Surname = (string)reader["TeacherSurName"] };
                            tempLesson.CurrentRoom = new Room() { Id = (int)reader["RoomId"], RoomNumber = (int)reader["RoomNumber"] };
                            tempLesson.Year = (int)reader["Year"];
                            tempLesson.Semester = (int)reader["Semester"];
                            tempLesson.DayOfWeek = (int)reader["DayOfWeek"];
                            tempLesson.CurrentSubject = new Subject() { Id = (int)reader["SubjectId"], SubjectName = (string)reader["SubjectName"] };
                            tempLesson.LessonNumber = (int)reader["LessonNumber"];

                            lessonList.Add(tempLesson);
                        }
                        return lessonList;
                    }
                }
            }
        }

        /// <summary>
        /// Romove lesson by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;

                        command.CommandText = removeLessonQuery;

                        SqlParameter sqlId = new SqlParameter("@id", id);
                        SqlParameter sqlResult = new SqlParameter("@result", SqlDbType.Int);
                        sqlResult.Direction = ParameterDirection.Output;

                        command.Parameters.Add(sqlId);
                        command.Parameters.Add(sqlResult);

                        command.ExecuteNonQuery();
                        scope.Complete();
                        return (int)sqlResult.Value;
                    }
                }
            }
        }
        #endregion
    }
}
