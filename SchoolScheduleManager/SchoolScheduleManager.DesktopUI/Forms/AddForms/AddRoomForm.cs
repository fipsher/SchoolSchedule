using SchoolScheduleManager.Entities;
using SchoolScheduleManager.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolScheduleManager.DesktopUI.Forms
{
    public partial class AddRoomForm : Form
    {
        #region Private Fields region
        private SqlRoomRepository roomRepository;
        #endregion

        #region Constructors region
        public AddRoomForm()
        {
            roomRepository = new SqlRoomRepository();
            InitializeComponent();
        }

        #endregion

        #region Controls Events region
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbRoomNumber.Text != string.Empty)
            {
                int roomNumber;
                if (int.TryParse(tbRoomNumber.Text, out roomNumber))
                {
                    Room room = new Room() { RoomNumber = roomNumber };

                    string msgString = roomRepository.Add(room);

                    MessageBox.Show(msgString);
                }
            }
        }

        #endregion
    }
}
