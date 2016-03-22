using SchoolScheduleManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleManager.Repositories.Interfaces
{
    interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();

        string Add(Subject subject);
    }
}
