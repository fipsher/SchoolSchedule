using SchoolScheduleManager.Entities;
using System.Collections.Generic;

namespace SchoolScheduleManager.Repositories.Interfaces
{
    interface ILessonRepository
    {
        string InputLesson(Lesson lesson);

        int Remove(int id);

        IEnumerable<Lesson> GetAllLessons();

    }
}
