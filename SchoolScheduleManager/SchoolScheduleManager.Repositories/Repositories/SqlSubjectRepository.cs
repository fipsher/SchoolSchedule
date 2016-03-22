using System;
using System.Collections.Generic;
using SchoolScheduleManager.Entities;
using SchoolScheduleManager.Repositories.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace SchoolScheduleManager.Repositories.Repositories
{
    public class SqlSubjectRepository :SqlBaseRepository, ISubjectRepository
    {
        #region Queries region
        private const string GetAllSubjectsQuery = @"SELECT [Id]
                                                            ,[Name] as SubjectName
                                                    FROM [dbo].[tblSubject]
                                                    WHERE [Deleted] = 0;";

        private const string AddSubjectQuery = "spAddSubject";
        #endregion

        #region ISubjectRepository region

        public IEnumerable<Subject> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GetAllSubjectsQuery, connection))
                {
                    command.CommandType = CommandType.Text;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Subject> subjectList = new List<Subject>();
                        while (reader.Read())
                        {
                            Subject tempSubject = new Subject();
                            tempSubject.Id = (int)reader["Id"];
                            tempSubject.SubjectName = (string)reader["SubjectName"];
                            subjectList.Add(tempSubject);
                        }
                        return subjectList;
                    }
                }
            }
        }

        public string Add(Subject subject)
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
                        command.CommandText = AddSubjectQuery;

                        #region sqlParams creating region      
                        SqlParameter sqlSubjectName = new SqlParameter("@subjectName", subject.SubjectName);
                        SqlParameter sqlOutParam = new SqlParameter("@result", 0);
                        sqlOutParam.Direction = ParameterDirection.Output;
                        #endregion

                        #region sqlParams adding to command region
                        command.Parameters.Add(sqlSubjectName);
                        command.Parameters.Add(sqlOutParam);
                        #endregion

                        command.ExecuteNonQuery();
                        string msgString = string.Empty;
                        switch (int.Parse(sqlOutParam.Value.ToString()))
                        {
                            case 1:
                                {
                                    msgString = "There has already exists such subject ";
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
    }
}
