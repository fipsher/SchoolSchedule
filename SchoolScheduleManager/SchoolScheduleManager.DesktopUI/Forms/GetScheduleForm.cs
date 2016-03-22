using SchoolScheduleManager.Entities;
using SchoolScheduleManager.Repositories.Repositories;
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
    public partial class GetScheduleForm : Form
    {
        #region Private Fields region
        private static string connectionString = ConfigurationManager.ConnectionStrings["SchoolScheduleConnString"].ConnectionString;
        private List<Lesson> schedule;
        private List<Room> roomList;
        private List<Teacher> teachersList;
        private List<Group> groupList;
        #endregion

        #region Constructors region
        public GetScheduleForm()
        {
            InitializeComponent();

            cmbTeachGroupRoomContainer.Items.Clear();
            SqlTeacherRepository teacherRepository = new SqlTeacherRepository();
            teachersList = teacherRepository.GetAll().ToList();

            SqlRoomRepository roomRepository = new SqlRoomRepository();
            roomList = roomRepository.GetAll().ToList();

            SqlGroupRepositoty groupRepository = new SqlGroupRepositoty();
            groupList = groupRepository.GetAll().ToList();

            cmbTeachGroupRoomContainer.Items.AddRange(teachersList.ToArray<Teacher>());
        }
        #endregion

        #region Private Methods region
        private List<Lesson> getSchedule(Func<int, int, int, int, EntityVariant, IEnumerable<Lesson>> scheduleFunc, EntityVariant scheduleVariant)
        {
            int dayOfWeek = cmbDayOfWeek.SelectedIndex + 1;
            int year = int.Parse(tbYear.Text);

            int semester = int.Parse(cmbSemester.SelectedItem.ToString());
            
            int index = cmbTeachGroupRoomContainer.SelectedIndex;
            int id;

            switch (scheduleVariant)
            {
                case EntityVariant.Teacher:
                    {
                        id = teachersList[index].Id;
                    }
                    break;
                case EntityVariant.Group:
                    {
                        id = groupList[index].Id;
                    }
                    break;
                case EntityVariant.Room:
                    {
                        id = roomList[index].Id;
                    }
                    break;
                default:
                    {
                        throw new Exception("Wrong entity variant");
                    }
            }
            return scheduleFunc(id, dayOfWeek, year, semester, scheduleVariant).ToList();
        }
        /// <summary>
        /// If it's possible to get Schedule it gets it
        /// </summary>
        private void tryToGetSchedule()
        {
            schedule = new List<Lesson>();
            dgvLesson.Rows.Clear();
            if (checkFieldsOccupacy())
            {
                SqlBaseRepository sqlBase;
                EntityVariant scheduleVariant;
                if (rbtnTeacher.Checked)
                {
                    sqlBase = new SqlTeacherRepository();
                    scheduleVariant = EntityVariant.Teacher;
                }
                else
                {
                    if (rbtnGroup.Checked)
                    {
                        sqlBase = new SqlGroupRepositoty();
                        scheduleVariant = EntityVariant.Group;
                    }
                    else
                    {
                        sqlBase = new SqlRoomRepository();
                        scheduleVariant = EntityVariant.Room;
                    }
                }

                schedule = getSchedule(sqlBase.GetSchedule, scheduleVariant);
                if (schedule.Count == 0)
                {
                    MessageBox.Show("There are no lessons founded with such criteria", "");
                }
            }


            for (int i = 0; i < schedule.Count; i++)
            {
                addLessonToGrid(schedule[i]);
            }
        }

        private bool checkFieldsOccupacy()
        {
            int tempYear;
            if (cmbDayOfWeek.SelectedIndex >= 0 && cmbTeachGroupRoomContainer.SelectedIndex >= 0 && cmbSemester.SelectedItem != null && int.TryParse(tbYear.Text, out tempYear))
            {
                return true;
            }
            return false;
        }

        private void addLessonToGrid(Lesson lesson)
        {
            Day dayOfWeek = (Day)(lesson.DayOfWeek - 1);
            DataGridViewRow dgvRow = new DataGridViewRow();
            dgvRow.CreateCells(dgvLesson);



            dgvRow.Cells[0].Value = lesson.Id;
            dgvRow.Cells[1].Value = lesson.CurrentRoom.RoomNumber;
            dgvRow.Cells[2].Value = lesson.CurrentGroup.GroupName;
            dgvRow.Cells[3].Value = String.Format("{0} \t {1} ", lesson.CurrentTeacher.Name, lesson.CurrentTeacher.Surname);
            dgvRow.Cells[4].Value = lesson.CurrentSubject.SubjectName;
            dgvRow.Cells[5].Value = lesson.Year;
            dgvRow.Cells[6].Value = lesson.Semester;
            dgvRow.Cells[7].Value = dayOfWeek;
            dgvRow.Cells[8].Value = lesson.LessonNumber;

            dgvLesson.Rows.Add(dgvRow);
        }
        #endregion

        #region Controls Events region
        private void btnGetSchedule_Click(object sender, EventArgs e)
        {
            tryToGetSchedule();
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            dgvLesson.Rows.Clear();

            if (rbtnTeacher.Checked == true)
            {
                cmbTeachGroupRoomContainer.Items.Clear();
                lblTeachGroupRoomContainer.Text = "Teacher";
                cmbTeachGroupRoomContainer.Items.AddRange(teachersList.ToArray<Teacher>());
            }

            if (rbtnRoom.Checked == true)
            {
                cmbTeachGroupRoomContainer.Items.Clear();
                lblTeachGroupRoomContainer.Text = "Room:";
                cmbTeachGroupRoomContainer.Items.AddRange(roomList.ToArray<Room>());
            }

            if (rbtnGroup.Checked == true)
            {
                cmbTeachGroupRoomContainer.Items.Clear();
                lblTeachGroupRoomContainer.Text = "Group:";
                cmbTeachGroupRoomContainer.Items.AddRange(groupList.ToArray<Group>());
            }
        }
        #endregion
    }
}
