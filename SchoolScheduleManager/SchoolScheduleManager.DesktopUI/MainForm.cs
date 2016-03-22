using SchoolScheduleManager.DesktopUI.Forms;
using SchoolScheduleManager.DesktopUI.Forms.RemoveForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolScheduleManager.DesktopUI
{
    public partial class MainForm : Form
    {
        private readonly string connectionString;

        public MainForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["SchoolScheduleConnString"].ConnectionString;
        }
        private void getScheduleButton_Click(object sender, EventArgs e)
        {
            GetScheduleForm getScheduleForm = new GetScheduleForm();
            getScheduleForm.ShowDialog();
        }

        private void btnInputLesson_Click(object sender, EventArgs e)
        {
            InputLessonForm inputLessonForm = new InputLessonForm();
            inputLessonForm.ShowDialog();
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            AddTeacherForm addTeacherForm = new AddTeacherForm();
            addTeacherForm.ShowDialog();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            AddGroupForm addGroupForm = new AddGroupForm();
            addGroupForm.ShowDialog();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            AddRoomForm addRoomForm = new AddRoomForm();
            addRoomForm.ShowDialog();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            AddSubjectForm addSubjectForm = new AddSubjectForm();
            addSubjectForm.ShowDialog();
        }

        private void ShowRemoveDialog(Entities.EntityVariant entityVariant)
        {
            RemoveForm remRorm = new RemoveForm(entityVariant);
            remRorm.ShowDialog();
        }

        private void rtnRemoveTeacher_Click(object sender, EventArgs e)
        {
            ShowRemoveDialog(Entities.EntityVariant.Teacher);
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            ShowRemoveDialog(Entities.EntityVariant.Group);

        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            ShowRemoveDialog(Entities.EntityVariant.Room);

        }

        private void btnRemoveSubject_Click(object sender, EventArgs e)
        {
            ShowRemoveDialog(Entities.EntityVariant.Subject);

        }

        private void btnRemoveLesson_Click(object sender, EventArgs e)
        {
            RemoveLessonForm removeLessonForm = new RemoveLessonForm(connectionString);
            try
            {
                removeLessonForm.Show();
            }
            catch
            {

            }
        }
    }
}
