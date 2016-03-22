using SchoolScheduleManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolScheduleManager.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace SchoolScheduleManager.Repositories.Repositories
{
    
    public abstract class SqlBaseRepository:IBaseRepository
    {
        #region Protected Fields
        protected readonly string _connectionString = ConfigurationManager.ConnectionStrings["SchoolScheduleConnString"].ConnectionString;
        #endregion

        #region Queries region

            private const string GetScheduleQuery = @"SELECT l.Id as 'Id'
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
                                                        WHERE {0} = {1} AND @dayOfWeek = l.[DayOfWeek]
                                                        AND @year = l.[Year]
                                                        AND @semester = l.Semester
                                                        AND l.Deleted = 0
                                                        AND g.Deleted = 0
                                                        AND s.Deleted = 0
                                                        AND r.Deleted = 0
                                                        AND t.Deleted = 0;";

        private const string RemoveTeacherQuery = "spRemoveTeacher";
        private const string RemoveRoomQuery = "spRemoveRoom";
        private const string RemoveGroupQuery = "spRemoveGroup";
        private const string RemoveSubjectQuery = "spRemoveSubject";

        #endregion

        #region IBaseRepository region
        public virtual IEnumerable<Lesson> GetSchedule(int Id, int dayOfWeek, int year, int semester, EntityVariant entityVariant)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    string sqlSomeEntityParamName;
                    string sqlSomeTableColunmnName;

                    #region Switch entityVariant
                    switch (entityVariant)
                    {
                        case EntityVariant.Teacher:
                            {
                                sqlSomeEntityParamName = "@teacherId";
                                sqlSomeTableColunmnName = "t.Id";
                            }
                            break;
                        case EntityVariant.Group:
                            {
                                sqlSomeEntityParamName = "@groupId";
                                sqlSomeTableColunmnName = "g.Id";
                            }
                            break;
                        case EntityVariant.Room:
                            {
                                sqlSomeEntityParamName = "@roomId";
                                sqlSomeTableColunmnName = "r.Id";
                            }
                            break;
                        case EntityVariant.Subject:
                            {
                                throw new Exception("Method are not implementedfor EntityVariant.Subject");
                            }

                        default:
                            {
                                throw new Exception("Invalid input data");
                            }                     
                    }
                    #endregion

                    SqlParameter sqlTeacherId = new SqlParameter(sqlSomeEntityParamName, Id);

                    SqlParameter sqlDayOfWeek = new SqlParameter("@dayOfWeek", dayOfWeek);
                    SqlParameter sqlYear = new SqlParameter("@year", year);
                    SqlParameter sqlSemester = new SqlParameter("@semester", semester);

                    command.Parameters.Add(sqlDayOfWeek);
                    command.Parameters.Add(sqlTeacherId);
                    command.Parameters.Add(sqlYear);
                    command.Parameters.Add(sqlSemester);

                    string completedGetScheduleQuery = String.Format(GetScheduleQuery, sqlSomeEntityParamName ,sqlSomeTableColunmnName);
                    command.CommandText = completedGetScheduleQuery;
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
                            tempLesson.Year = year;
                            tempLesson.Semester = (int)reader["Semester"];
                            tempLesson.DayOfWeek = dayOfWeek;
                            tempLesson.CurrentSubject = new Subject() { Id = (int)reader["SubjectId"], SubjectName = (string)reader["SubjectName"] };
                            tempLesson.LessonNumber = (int)reader["LessonNumber"];

                            lessonList.Add(tempLesson);
                        }
                        return lessonList;
                    }
                }
            }
        }

        public void Remove(int Id, EntityVariant entityVariant)
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
                        string query;

                        #region Switch entityVariant
                        switch (entityVariant)
                        {
                            case EntityVariant.Teacher:
                                {
                                    query = RemoveTeacherQuery;

                                }
                                break;
                            case EntityVariant.Group:
                                {
                                    query = RemoveGroupQuery;

                                }
                                break;
                            case EntityVariant.Room:
                                {
                                    query = RemoveRoomQuery;
                                }
                                break;
                            case EntityVariant.Subject:
                                {
                                    query = RemoveSubjectQuery;
                                }
                                break;
                            default:
                                {
                                    throw new Exception("Invalid input data");
                                }
                        }
                        #endregion

                        command.CommandText = query;

                        SqlParameter sqlId = new SqlParameter("@id", Id);
                        command.Parameters.Add(sqlId);

                        command.ExecuteNonQuery();
                        scope.Complete();
                    }
                }
            }
        }
        #endregion
    }
}
