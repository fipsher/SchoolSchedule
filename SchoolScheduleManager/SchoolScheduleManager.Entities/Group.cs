namespace SchoolScheduleManager.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public override string ToString()
        {
            return GroupName;
        }
    }
}
