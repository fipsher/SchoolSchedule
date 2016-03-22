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

namespace SchoolScheduleManager.DesktopUI.Forms
{
    public partial class InputLessonForm : Form
    {
        #region Private Fields region
        private SqlTeacherRepository teacherRepository;
        private SqlRoomRepository roomRepository;
        private SqlGroupRepositoty groupRepository;
        private SqlSubjectRepository subjectRepository;
        private SqlLessonRepository lessonRepository;

        private List<Subject> subjects;
        private List<Room> rooms;
        private List<Teacher> teachers;
        private List<Group> groups;
        #endregion

        #region Constructors region
        public InputLessonForm()
        {
            InitializeComponent();

            teacherRepository = new SqlTeacherRepository();
            roomRepository = new SqlRoomRepository();
            groupRepository = new SqlGroupRepositoty();
            subjectRepository = new SqlSubjectRepository();


            fillComboBoxes();
            fillStartData();
        }
        #endregion

        #region Private Methods region
        private void fillComboBoxes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SchoolScheduleConnString"].ConnectionString;
            lessonRepository = new SqlLessonRepository(connectionString);

            
            teachers = teacherRepository.GetAll().ToList();
            cmbTeach.Items.AddRange(teachers.ToArray());

            rooms = roomRepository.GetAll().ToList();
            cmbRoom.Items.AddRange(rooms.ToArray());

            groups = groupRepository.GetAll().ToList();
            cmbGroup.Items.AddRange(groups.ToArray());

            subjects = subjectRepository.GetAll().ToList();
            cmbSubject.Items.AddRange(subjects.ToArray());

        }
       
        private void fillStartData()
        {
            DateTime dateTime = DateTime.Now;

            tbYear.Text = dateTime.Year.ToString();
            cmbDayOfWeek.SelectedIndex = (int)(dateTime.DayOfWeek + 6) % 7;
            if (dateTime.Month >=7 )
            {
                cmbSemester.SelectedIndex = 0;
            }
            else
            {
                cmbSemester.SelectedIndex = 1;

            }
        }

        private bool isСorrectOfInputData()
        {
            int temp;
            if (int.TryParse(tbYear.Text, out temp) && int.TryParse(tbLessonNumber.Text, out temp))
            {
                return true;
            }
            return false;
        }

        private Lesson getFilledLesson()
        {
            int dayOfWeek = cmbDayOfWeek.SelectedIndex + 1;
            int year = int.Parse(tbYear.Text);
            int semester = int.Parse(cmbSemester.SelectedItem.ToString());
            int lessonNumber = int.Parse(tbLessonNumber.Text);



            Lesson lesson = new Lesson();
            lesson.CurrentGroup = groups[cmbGroup.SelectedIndex];
            lesson.CurrentRoom = rooms[cmbRoom.SelectedIndex];
            lesson.CurrentSubject = subjects[cmbSubject.SelectedIndex];
            lesson.CurrentTeacher = teachers[cmbTeach.SelectedIndex];
            lesson.DayOfWeek = dayOfWeek;
            lesson.LessonNumber = lessonNumber;
            lesson.Semester = semester;
            lesson.Year = year;

            return lesson;


        }

        
        #endregion

        #region Controls Events region
        private void btnAddLesson_Click(object sender, EventArgs e)
        {
            if (isСorrectOfInputData())
            {
                if (cmbGroup.SelectedIndex >= 0 && cmbRoom.SelectedIndex >= 0 && cmbTeach.SelectedIndex >= 0 && cmbSubject.SelectedIndex >= 0)
                {
                    Lesson lesson = getFilledLesson();
                    string message = lessonRepository.InputLesson(lesson);
                    MessageBox.Show(message);
                }
            }
        }

        private void btnGetGroup_Click(object sender, EventArgs e)
        {
            if (isСorrectOfInputData())
            {
                int dayOfWeek = cmbDayOfWeek.SelectedIndex + 1;
                int year = int.Parse(tbYear.Text);
                int semester = int.Parse(cmbSemester.SelectedItem.ToString());
                int lessonNumber = int.Parse(tbLessonNumber.Text);

                List<Group> availabGroups = groupRepository.GetAvailable(year, semester, dayOfWeek, lessonNumber).ToList();
                StringBuilder strToRichTb = new StringBuilder();

                for (int i = 0; i < availabGroups.Count; i++)
                {
                    strToRichTb.Append(availabGroups[i]);
                    strToRichTb.Append("\n");
                }
                richTextBox1.Text = strToRichTb.ToString();
            }
        }

        private void btnGetRoom_Click(object sender, EventArgs e)
        {
            if (isСorrectOfInputData())
            {
                int dayOfWeek = cmbDayOfWeek.SelectedIndex + 1;
                int year = int.Parse(tbYear.Text);
                int semester = int.Parse(cmbSemester.SelectedItem.ToString());
                int lessonNumber = int.Parse(tbLessonNumber.Text);

                List<Room> availabRooms = roomRepository.GetAvailable(year, semester, dayOfWeek, lessonNumber).ToList();
                StringBuilder strToRichTb = new StringBuilder();

                for (int i = 0; i < availabRooms.Count; i++)
                {
                    strToRichTb.Append(availabRooms[i]);
                    strToRichTb.Append("\n");
                }
                richTextBox1.Text = strToRichTb.ToString();
            }
        }


        private void btnGetTeacher_Click(object sender, EventArgs e)
        {
            if (isСorrectOfInputData())
            {
                int dayOfWeek = cmbDayOfWeek.SelectedIndex + 1;
                int year = int.Parse(tbYear.Text);
                int semester = int.Parse(cmbSemester.SelectedItem.ToString());
                int lessonNumber = int.Parse(tbLessonNumber.Text);

                List<Teacher> availabTeach = teacherRepository.GetAvailable(year, semester, dayOfWeek, lessonNumber).ToList();
                StringBuilder strToRichTb = new StringBuilder();

                for (int i = 0; i < availabTeach.Count; i++)
                {
                    strToRichTb.Append(availabTeach[i]);
                    strToRichTb.Append("\n");
                }
                richTextBox1.Text = strToRichTb.ToString();
            }
        }
        #endregion

    }
}
