using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolScheduleManager.Repositories.Repositories;
using SchoolScheduleManager.Entities;

namespace SchoolScheduleManager.DesktopUI.Forms
{
    public partial class AddGroupForm : Form
    {
        #region Private Fields region
        private SqlGroupRepositoty groupRepository;

        #endregion

        #region Constructors region
        public AddGroupForm()
        {
            groupRepository = new SqlGroupRepositoty();
            InitializeComponent();
        }

        #endregion

        #region Controls Events region
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbGroupName.Text != string.Empty)
            {
                string groupName = tbGroupName.Text;
                Group group = new Group() { GroupName = groupName };

                string msgString = groupRepository.Add(group);

                MessageBox.Show(msgString);
            }
        }

        #endregion
    }
}
