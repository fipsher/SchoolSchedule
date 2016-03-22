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
    public partial class AddTeacherForm : Form
    {
        #region Private Fields region

        private SqlTeacherRepository teacherRepository;
        #endregion

        #region Constructors region

        public AddTeacherForm()
        {
            InitializeComponent();
            teacherRepository = new SqlTeacherRepository();
        }
        #endregion

        #region Controls Events region

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text != string.Empty && tbSurname.Text != string.Empty)
            {
                string name = tbName.Text;
                string surName = tbSurname.Text;

                Teacher teacherToAdd = new Teacher() { Name = name, Surname = surName };

                string msgString = teacherRepository.Add(teacherToAdd);

                MessageBox.Show(msgString);
            }
        }
        #endregion
    }
}
