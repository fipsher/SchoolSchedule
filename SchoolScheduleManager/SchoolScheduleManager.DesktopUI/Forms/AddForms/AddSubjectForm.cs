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
    public partial class AddSubjectForm : Form
    {
        #region Private Fields region

        private SqlSubjectRepository subjectRepository;
        #endregion

        #region Constructors region

        public AddSubjectForm()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SchoolScheduleConnString"].ConnectionString;
            subjectRepository = new SqlSubjectRepository();
            InitializeComponent();
        }
        #endregion

        #region Controls Events region

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbSubjectName.Text != string.Empty)
            {
                string subjectName = tbSubjectName.Text;
                Subject subject = new Subject() { SubjectName = subjectName };

                string msgString = subjectRepository.Add(subject);

                MessageBox.Show(msgString);
            }
            
        }
        #endregion
    }
}
