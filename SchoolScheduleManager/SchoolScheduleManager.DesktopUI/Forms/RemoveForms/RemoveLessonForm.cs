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

namespace SchoolScheduleManager.DesktopUI.Forms.RemoveForms
{
    public partial class RemoveLessonForm : Form
    {
        #region Private Fields region
        private readonly SqlLessonRepository lessonRepository;
        private List<Lesson> lessons;

        #endregion

        #region Constructors region
        public RemoveLessonForm(string connectionString)
        {
            InitializeComponent();
            lessonRepository = new SqlLessonRepository(connectionString);
            fillDgv();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Fills DataDridView(dgv)
        /// </summary>
        private void fillDgv()
        {
            lessons = lessonRepository.GetAllLessons().ToList();

            for (int i = 0; i < lessons.Count; i++)
            {
                addLessonToDgv(lessons[i]);
            }
        }
        /// <summary>
        /// Add 1 lesson to dgv
        /// </summary>
        /// <param name="lesson"></param>
        private void addLessonToDgv(Lesson lesson)
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
        private void dgvLesson_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            for (int i = 0; i < dgvLesson.SelectedRows.Count; i++)
            {
                int lessonId = (int)dgvLesson.Rows[i].Cells["Id"].Value;
                int result = lessonRepository.Remove(lessonId);
                if (result != 0)
                {
                    MessageBox.Show("Some troubles occured");
                    break;
                }
            }

        }

        private void dgvLesson_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvLesson.Rows.Clear();
            fillDgv();
        }
        #endregion
    }
}
