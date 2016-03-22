using SchoolScheduleManager.Entities;
using SchoolScheduleManager.Interfaces;
using SchoolScheduleManager.Repositories;
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
    public partial class LoginForm : Form
    {
        #region Private Fields region
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructors
        public LoginForm()
        {
            _userRepository = new SqlUserRepository(ConfigurationManager.ConnectionStrings["SchoolScheduleConnString"].ConnectionString);

            InitializeComponent();
        }
        #endregion

        #region Controls Events region

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = Encryptor.MD5Hash(txtPassword.Text);
            User user = _userRepository.GetUserByLogin(login, password);
            if (user == null)
            {
                MessageBox.Show(this, "Invalid user name or password", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CurrentUser.Initialize(user);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion
    }
}
