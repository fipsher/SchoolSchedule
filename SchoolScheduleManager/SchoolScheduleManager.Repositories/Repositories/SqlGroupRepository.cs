using SchoolScheduleManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SchoolScheduleManager.Repositories.Interfaces;
using System.Transactions;

namespace SchoolScheduleManager.Repositories.Repositories
{
    public class SqlGroupRepositoty : SqlBaseRepository, IGroupRepository
    {
        #region Queries region

        private const string GetAllGroupsQuery = @"SELECT g.[Id]
		                                                    ,[Name]
                                                    FROM [dbo].[tblGroup] as g
                                                    WHERE [Deleted] = 0;";

        private const string GetAvailableQuery = @"SELECT DISTINCT t1.Id, t1.Name
                                                    FROM (SELECT  DISTINCT e.Id, e.Name, l.Deleted
	                                                    FROM [dbo].[tblLesson] as l
	                                                    INNER JOIN [dbo].[tblGroup] as e
	                                                    ON e.Id = l.GroupId
	                                                    WHERE  (l.DayOfWeek = @dayOfWeek
			                                                    AND l.Year = @year
			                                                    AND l.LessonNumber = @lessNumb
			                                                    AND l.Semester = @semester
			                                                    AND l.Deleted = 0)) as v
                                                    RIGHT OUTER JOIN [dbo].[tblGroup] as t1
                                                    ON t1.Id = v.Id
                                                    WHERE v.Id IS NULL
                                                    ORDER BY t1.Id";
                                                            

        private const string AddGroupQuery = "spAddGroup";
        private const string RemoveGroupQuery = "spRemoveGroup";
        #endregion

        #region IGroupRepository
        public IEnumerable<Group> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GetAllGroupsQuery, connection))
                {
                    command.CommandType = CommandType.Text;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Group> groupList = new List<Group>();
                        while (reader.Read())
                        {
                            Group tempGroup = new Group();
                            tempGroup.Id = (int)reader["Id"];
                            tempGroup.GroupName = (string)reader["Name"];
                            groupList.Add(tempGroup);
                        }
                        return groupList;
                    }
                }
            }
        }

        public string Add(Group group)
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
                        command.CommandText = AddGroupQuery;

                        #region sqlParams creating region      
                        SqlParameter sqlName = new SqlParameter("@name", group.GroupName);
                        SqlParameter sqlOutParam = new SqlParameter("@result", 0);
                        sqlOutParam.Direction = ParameterDirection.Output;
                        #endregion

                        #region sqlParams adding to command region
                        command.Parameters.Add(sqlName);
                        command.Parameters.Add(sqlOutParam);
                        #endregion

                        command.ExecuteNonQuery();
                        string msgString = string.Empty;
                        switch (int.Parse(sqlOutParam.Value.ToString()))
                        {
                            case 1:
                                {
                                    msgString = "There has already exists such group";
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

        public IEnumerable<Group> GetAvailable(int year, int semester, int dayOfWeek, int lessonNumb)
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
                        List<Group> groupList = new List<Group>();
                        while (reader.Read())
                        {
                            Group tempGroup = new Group();
                            tempGroup.Id = (int)reader["Id"];
                            tempGroup.GroupName = (string)reader["Name"];
                            groupList.Add(tempGroup);
                        }
                        return groupList;
                    }
                }
            }
        }
    }
}
