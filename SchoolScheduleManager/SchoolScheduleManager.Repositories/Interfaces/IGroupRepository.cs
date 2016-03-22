using SchoolScheduleManager.Entities;
using System.Collections.Generic;

namespace SchoolScheduleManager.Repositories.Interfaces
{
    interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        string Add(Group group);
    }
}
