using SchoolScheduleManager.Entities;
using System.Collections.Generic;

namespace SchoolScheduleManager.Repositories.Interfaces
{
    interface IBaseRepository
    {
        IEnumerable<Lesson> GetSchedule(int Id, int dayOfWeek, int year, int semester, EntityVariant entityvariant);      
    }
}
