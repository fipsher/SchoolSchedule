using System;

namespace SchoolScheduleManager.Entities
{
    public class Lesson
    {

        private int _dayOfWeek;


        public int Id { get; set; }
        public Group CurrentGroup { get; set; }
        public Teacher CurrentTeacher { get; set; }
        public Subject CurrentSubject { get; set; }
        public Room CurrentRoom { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        public int DayOfWeek
        {
            get
            {

                return _dayOfWeek;
            }

            set
            {
                if (value > 7 || value < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _dayOfWeek = value;
            }
        }
        public int LessonNumber { get; set; }
    }
}
