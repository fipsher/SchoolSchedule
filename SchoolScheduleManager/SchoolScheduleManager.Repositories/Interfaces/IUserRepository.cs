using SchoolScheduleManager.Entities;

namespace SchoolScheduleManager.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByLogin(string login, string password);
    }
}
