using SchoolScheduleManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScheduleManager.DesktopUI
{
    public class CurrentUser
    {
        #region Private Fields
        private static User currentUser;
        #endregion

        #region Constructors region
        public static void Initialize(User user)
        {
            if (currentUser != null)
            {
                throw new InvalidOperationException("Current user has already been specified");
            }
            currentUser = user;
        }
        #endregion

        #region Properties region
        public static int Id
        {
            get
            {
                return currentUser.Id;
            }
        }

        public static string FirstName
        {
            get
            {
                return currentUser.FirstName;
            }
        }

        public static string Surname
        {
            get
            {
                return currentUser.Surname;
            }
        }

        public static string Login
        {
            get
            {
                return currentUser.Login;
            }
        }
        #endregion
    }
}
