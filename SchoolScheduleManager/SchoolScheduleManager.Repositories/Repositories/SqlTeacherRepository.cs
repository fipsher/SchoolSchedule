using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SchoolScheduleManager.Repositories.Interfaces;
using SchoolScheduleManager.Entities;
using System.Transactions;


namespace SchoolScheduleManager.Repositories.Repositories
{
    public class SqlTeacherRepository : SqlBaseRepository, ITeacherRepository
    {
        #region Queries region
        private const string GetAllTeachersQuery = @"SELECT [Id]
                                                            ,[Name]
                                                            ,[SurName]
                                                    FROM [dbo].[tblTeacher] 
                                                    WHERE [Deleted] = 0;";

        private const string GetAvailableQuery = @"SELECT t1.Id, t1.Name, t1.Surname
                                                    FROM (SELECT e.Id
	                                                    FROM [dbo].[tblLesson] as l
	                                                    INNER JOIN [dbo].[tblTeacher] as e
	                                                    ON e.Id = l.TeacherId
	                                                    WHERE  (l.DayOfWeek = @dayOfWeek
			                                                    AND l.Year = @year
			                                                    AND l.LessonNumber = @lessNumb
			                                                    AND l.Semester = @semester
			                                                    AND l.Deleted = 0)) as v
                                                    RIGHT OUTER JOIN [dbo].[tblTeacher] as t1
                                                    ON t1.Id = v.Id
                                                    WHERE v.Id IS NULL
                                                    ORDER BY t1.Id";


        private const string AddTeacherQuery = "spAddTeacher";

        private const string RemoveTeacherQuery = "spRemoveTeacher";

        #endregion        

        #region ITeacherRepository region
        public IEnumerable<Teacher> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GetAllTeachersQuery, connection))
                {
                    command.CommandType = CommandType.Text;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Teacher> teacherList = new List<Teacher>();
                        while (reader.Read())
                        {
                            Teacher tempTeacher = new Teacher();
                            tempTeacher.Id = (int)reader["Id"];
                            tempTeacher.Name = (string)reader["Name"];
                            tempTeacher.Surname = (string)reader["SurName"];
                            teacherList.Add(tempTeacher);
                        }
                        return teacherList;
                    }
                }
            }
        }

        public string Add(Teacher teacher)
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
                        command.CommandText = AddTeacherQuery;

                        #region sqlParams creating region      
                        SqlParameter sqlName = new SqlParameter("@name", teacher.Name);
                        SqlParameter sqlSurname = new SqlParameter("@surName", teacher.Surname);
                        SqlParameter sqlOutParam = new SqlParameter("@result", 0);
                        sqlOutParam.Direction = ParameterDirection.Output;
                        #endregion

                        #region sqlParams adding to command region
                        command.Parameters.Add(sqlName);
                        command.Parameters.Add(sqlSurname);
                        command.Parameters.Add(sqlOutParam);
                        #endregion

                        command.ExecuteNonQuery();
                        string msgString = string.Empty;
                        switch (int.Parse(sqlOutParam.Value.ToString()))
                        {
                            case 1:
                                {
                                    msgString = "Some troubles occured";
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


        #endregion

        public IEnumerable<Teacher> GetAvailable(int year, int semester, int dayOfWeek, int lessonNumb)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GetAvailableQuery, connection))
                {
                    command.CommandType = CommandType.Text;

                    SqlParameter sqlYear = new SqlParameter("@year", year);
                    SqlParameter sqlSemester = new SqlParameter("@semester", semester);
                    SqlParameter sqlDayOfWeek = new SqlParameter("@dayOfWeek", dayOfWeek);
                    SqlParameter sqlLessNumb = new SqlParameter("@lessNumb", lessonNumb);

                    command.Parameters.Add(sqlYear);
                    command.Parameters.Add(sqlSemester);
                    command.Parameters.Add(sqlDayOfWeek);
                    command.Parameters.Add(sqlLessNumb);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Teacher> teacherList = new List<Teacher>();
                        while (reader.Read())
                        {
                            Teacher tempTeacher = new Teacher();
                            tempTeacher.Id = (int)reader["Id"];
                            tempTeacher.Name = (string)reader["Name"];
                            tempTeacher.Surname = (string)reader["SurName"];
                            teacherList.Add(tempTeacher);
                        }
                        return teacherList;
                    }
                }
            }
        }
    }
}
