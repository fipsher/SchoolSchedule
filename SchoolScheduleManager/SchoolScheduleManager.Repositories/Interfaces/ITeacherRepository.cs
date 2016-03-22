using SchoolScheduleManager.Entities;
using System.Collections.Generic;

namespace SchoolScheduleManager.Repositories.Interfaces
{
    interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAll();

        string Add(Teacher teacher);

    }
}
