using SchoolScheduleManager.Entities;
using SchoolScheduleManager.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace SchoolScheduleManager.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        #region Queries region

        private const string spGetUserByLoginQuery = "spGetUserByLogin";

        #endregion

        #region Private Fields region

        private readonly string _connectionString;

        #endregion

        #region Constructors region

        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region IUserRepository region

        public User GetUserByLogin(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spGetUserByLoginQuery;
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        User user = null;
                        if (reader.Read())
                        {
                            user = new User();
                            user.Id = (int)reader["Id"];
                            user.FirstName = (string)reader["FirstName"];
                            user.Surname = (string)reader["Surname"];
                            user.Login = (string)reader["Login"];
                            user.Disabled = (bool)reader["Disabled"];
                        }
                        return user;
                    }
                }
            }
        }

        #endregion
    }
}
