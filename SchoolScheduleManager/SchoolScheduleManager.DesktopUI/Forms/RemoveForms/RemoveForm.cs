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
    public partial class RemoveForm : Form
    {
        #region Private Fields region
        private SqlBaseRepository baseRepository;
        private EntityVariant entityVariant;

        private List<Teacher> teacherList;
        private List<Room> roomList;
        private List<Group> groupList;
        private List<Subject> subjectList;

        private int identifier;

        #endregion

        #region Constructors region
        public RemoveForm(EntityVariant variant)
        {
            InitializeComponent();
            lblTechGroupRoomSubj.Text = variant.ToString();
            entityVariant = variant;
            fillComboBox();

        }

        #endregion

        #region private Methods region
        /// <summary>
        /// Fills comboBoxes with all entityVariant(Teahcher room etc)
        /// </summary>
        private void fillComboBox()
        {
            cmbTechGroupRoomSubj.Items.Clear();
            switch (entityVariant)
            {
                case EntityVariant.Teacher:
                    {
                        baseRepository = new SqlTeacherRepository();

                        // IP: ознака непродуманого ООП-дизайну  - метод "GetAll" (і йому подібні) слід винести або в окремий інтерфейс, або внести в базовий клас (що теж не буде найкращим варіантом)
                        // наприклад, винести метод "GetAll" в спільний для усіх потрібних класів інтерфейс і, відповідно, використовувати інтерфейсні посилання замість класових
                        teacherList = ((SqlTeacherRepository)baseRepository).GetAll().ToList();
                        
                        cmbTechGroupRoomSubj.Items.AddRange(teacherList.ToArray());
                    }
                    break;
                case EntityVariant.Group:
                    {
                        baseRepository = new SqlGroupRepositoty();
                        groupList = ((SqlGroupRepositoty)baseRepository).GetAll().ToList();
                        cmbTechGroupRoomSubj.Items.AddRange(groupList.ToArray());
                    }
                    break;
                case EntityVariant.Room:
                    {
                        baseRepository = new SqlRoomRepository();
                        roomList = ((SqlRoomRepository)baseRepository).GetAll().ToList();
                        cmbTechGroupRoomSubj.Items.AddRange(roomList.ToArray());
                    }
                    break;
                case EntityVariant.Subject:
                    {
                        baseRepository = new SqlSubjectRepository();
                        subjectList = ((SqlSubjectRepository)baseRepository).GetAll().ToList();
                        cmbTechGroupRoomSubj.Items.AddRange(subjectList.ToArray());
                    }
                    break;
                default:
                    {
                        throw new Exception("There are no implementation for such EntityVariant");
                    }
            }
            
        }
        #endregion

        #region Controls events region
        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (identifier >= 0)
            {
                baseRepository.Remove(identifier, entityVariant);
                cmbTechGroupRoomSubj.Items.Clear();
                fillComboBox();
                cmbTechGroupRoomSubj.Text = string.Empty;
            }
        }

        private void cmbTechGroupRoomSubj_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (entityVariant)
            {
                case EntityVariant.Teacher:
                    {
                        identifier = teacherList[cmbTechGroupRoomSubj.SelectedIndex].Id;
                    }
                    break;
                case EntityVariant.Group:
                    {
                        identifier = groupList[cmbTechGroupRoomSubj.SelectedIndex].Id;
                    }
                    break;
                case EntityVariant.Room:
                    {
                        identifier = roomList[cmbTechGroupRoomSubj.SelectedIndex].RoomNumber;
                    }
                    break;
                default:
                    {
                        identifier = subjectList[cmbTechGroupRoomSubj.SelectedIndex].Id;
                    }
                    break;
            }
        }

        #endregion
    }
}
