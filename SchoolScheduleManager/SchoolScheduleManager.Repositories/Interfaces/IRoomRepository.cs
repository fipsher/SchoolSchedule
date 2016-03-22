using SchoolScheduleManager.Entities;
using System.Collections.Generic;

namespace SchoolScheduleManager.Repositories.Interfaces
{
    interface IRoomRepository
    {
        IEnumerable<Room> GetAll();

        string Add(Room room);
    }
}
