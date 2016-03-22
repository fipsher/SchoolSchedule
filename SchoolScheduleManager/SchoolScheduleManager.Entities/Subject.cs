namespace SchoolScheduleManager.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

        public override string ToString()
        {
            return SubjectName;
        }
    }
}
