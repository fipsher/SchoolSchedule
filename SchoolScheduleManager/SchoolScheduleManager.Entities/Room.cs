namespace SchoolScheduleManager.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }

        public override string ToString()
        {
            return string.Format("{0}  room", RoomNumber);
        }
    }
}
