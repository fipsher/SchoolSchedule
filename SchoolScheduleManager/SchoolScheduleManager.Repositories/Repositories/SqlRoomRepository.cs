using SchoolScheduleManager.Entities;
using SchoolScheduleManager.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace SchoolScheduleManager.Repositories.Repositories
{
    public class SqlRoomRepository : SqlBaseRepository, IRoomRepository
    {
        #region Queries region

        private const string GetAllRoomsQuery = @"SELECT [Id]
		                                                ,[Number]
                                                FROM [dbo].[tblRoom]
                                                WHERE [Deleted] = 0;";


        private const string GetAvailableQuery = @"SELECT t1.Id, t1.Number
                                                    FROM (SELECT e.Id
	                                                    FROM [dbo].[tblLesson] as l
	                                                    INNER JOIN [dbo].[tblRoom] as e
	                                                    ON e.Id = l.RoomId
	                                                    WHERE  (l.DayOfWeek = @dayOfWeek
			                                                    AND l.Year = @year
			                                                    AND l.LessonNumber = @lessNumb
			                                                    AND l.Semester = @semester
			                                                    AND l.Deleted = 0)) as v
                                                    RIGHT OUTER JOIN [dbo].[tblRoom] as t1
                                                    ON t1.Id = v.Id
                                                    WHERE v.Id IS NULL
                                                    ORDER BY t1.Id";
        private const string AddRoomQuery = "spAddRoom";
        #endregion

        #region IRoomRepository region
        public IEnumerable<Room> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GetAllRoomsQuery, connection))
                {
                    command.CommandType = CommandType.Text;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Room> roomList = new List<Room>();
                        while (reader.Read())
                        {
                            Room tempRoom = new Room();
                            tempRoom.Id = (int)reader["Id"];
                            tempRoom.RoomNumber = (int)reader["Number"];
                            roomList.Add(tempRoom);
                        }
                        return roomList;
                    }
                }
            }
        }

        public string Add(Room room)
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
                        command.CommandText = AddRoomQuery;

                        #region sqlParams creating region      
                        SqlParameter sqlRoomNumber = new SqlParameter("@roomNumber", room.RoomNumber);
                        SqlParameter sqlOutParam = new SqlParameter("@result", 0);
                        sqlOutParam.Direction = ParameterDirection.Output;
                        #endregion

                        #region sqlParams adding to command region
                        command.Parameters.Add(sqlRoomNumber);
                        command.Parameters.Add(sqlOutParam);
                        #endregion

                        command.ExecuteNonQuery();
                        string msgString = string.Empty;
                        switch (int.Parse(sqlOutParam.Value.ToString()))
                        {
                            case 1:
                                {
                                    msgString = "There has already exists such room";
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

        public IEnumerable<Room> GetAvailable(int year, int semester, int dayOfWeek, int lessonNumb)
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
                        List<Room> roomList = new List<Room>();
                        while (reader.Read())
                        {
                            Room tempRoom = new Room();
                            tempRoom.Id = (int)reader["Id"];
                            tempRoom.RoomNumber = (int)reader["Number"];
                            roomList.Add(tempRoom);
                        }
                        return roomList;
                    }
                }
            }
        }
    }
}
