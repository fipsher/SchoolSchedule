namespace SchoolScheduleManager.DesktopUI
{
    partial class GetScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetShcedule = new System.Windows.Forms.Button();
            this.lblTeachGroupRoomContainer = new System.Windows.Forms.Label();
            this.cmbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.lblDayOfWeek = new System.Windows.Forms.Label();
            this.dgvLesson = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LessonNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTeachGroupRoomContainer = new System.Windows.Forms.ComboBox();
            this.rbtnRoom = new System.Windows.Forms.RadioButton();
            this.rbtnGroup = new System.Windows.Forms.RadioButton();
            this.rbtnTeacher = new System.Windows.Forms.RadioButton();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLesson)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetShcedule
            // 
            this.btnGetShcedule.Location = new System.Drawing.Point(12, 232);
            this.btnGetShcedule.Name = "btnGetShcedule";
            this.btnGetShcedule.Size = new System.Drawing.Size(129, 23);
            this.btnGetShcedule.TabIndex = 18;
            this.btnGetShcedule.Text = "Get shcedule";
            this.btnGetShcedule.UseVisualStyleBackColor = true;
            this.btnGetShcedule.Click += new System.EventHandler(this.btnGetSchedule_Click);
            // 
            // lblTeachGroupRoomContainer
            // 
            this.lblTeachGroupRoomContainer.AutoSize = true;
            this.lblTeachGroupRoomContainer.Location = new System.Drawing.Point(-3, 122);
            this.lblTeachGroupRoomContainer.Name = "lblTeachGroupRoomContainer";
            this.lblTeachGroupRoomContainer.Size = new System.Drawing.Size(50, 13);
            this.lblTeachGroupRoomContainer.TabIndex = 17;
            this.lblTeachGroupRoomContainer.Text = "Teacher:";
            // 
            // cmbDayOfWeek
            // 
            this.cmbDayOfWeek.FormattingEnabled = true;
            this.cmbDayOfWeek.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbDayOfWeek.Location = new System.Drawing.Point(70, 92);
            this.cmbDayOfWeek.Name = "cmbDayOfWeek";
            this.cmbDayOfWeek.Size = new System.Drawing.Size(192, 21);
            this.cmbDayOfWeek.TabIndex = 16;
            // 
            // lblDayOfWeek
            // 
            this.lblDayOfWeek.AutoSize = true;
            this.lblDayOfWeek.Location = new System.Drawing.Point(-3, 95);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(67, 13);
            this.lblDayOfWeek.TabIndex = 15;
            this.lblDayOfWeek.Text = "Day of week";
            // 
            // dgvLesson
            // 
            this.dgvLesson.AllowUserToAddRows = false;
            this.dgvLesson.AllowUserToDeleteRows = false;
            this.dgvLesson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLesson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.RoomNumber,
            this.Group,
            this.Teacher,
            this.Subject,
            this.Year,
            this.Semester,
            this.DayOfWeek,
            this.LessonNumber});
            this.dgvLesson.Location = new System.Drawing.Point(268, 12);
            this.dgvLesson.Name = "dgvLesson";
            this.dgvLesson.ReadOnly = true;
            this.dgvLesson.Size = new System.Drawing.Size(691, 319);
            this.dgvLesson.TabIndex = 14;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 41;
            // 
            // RoomNumber
            // 
            this.RoomNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RoomNumber.HeaderText = "Room";
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.ReadOnly = true;
            this.RoomNumber.Width = 60;
            // 
            // Group
            // 
            this.Group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            this.Group.Width = 61;
            // 
            // Teacher
            // 
            this.Teacher.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Teacher.HeaderText = "Teacher";
            this.Teacher.Name = "Teacher";
            this.Teacher.ReadOnly = true;
            this.Teacher.Width = 72;
            // 
            // Subject
            // 
            this.Subject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.Width = 68;
            // 
            // Year
            // 
            this.Year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 54;
            // 
            // Semester
            // 
            this.Semester.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Semester.HeaderText = "Semester";
            this.Semester.Name = "Semester";
            this.Semester.ReadOnly = true;
            this.Semester.Width = 76;
            // 
            // DayOfWeek
            // 
            this.DayOfWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DayOfWeek.HeaderText = "DayOfWeek";
            this.DayOfWeek.Name = "DayOfWeek";
            this.DayOfWeek.ReadOnly = true;
            this.DayOfWeek.Width = 91;
            // 
            // LessonNumber
            // 
            this.LessonNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.LessonNumber.HeaderText = "LessonNumber";
            this.LessonNumber.Name = "LessonNumber";
            this.LessonNumber.ReadOnly = true;
            this.LessonNumber.Width = 103;
            // 
            // cmbTeachGroupRoomContainer
            // 
            this.cmbTeachGroupRoomContainer.FormattingEnabled = true;
            this.cmbTeachGroupRoomContainer.Location = new System.Drawing.Point(70, 119);
            this.cmbTeachGroupRoomContainer.Name = "cmbTeachGroupRoomContainer";
            this.cmbTeachGroupRoomContainer.Size = new System.Drawing.Size(192, 21);
            this.cmbTeachGroupRoomContainer.TabIndex = 13;
            // 
            // rbtnRoom
            // 
            this.rbtnRoom.AutoSize = true;
            this.rbtnRoom.Location = new System.Drawing.Point(12, 58);
            this.rbtnRoom.Name = "rbtnRoom";
            this.rbtnRoom.Size = new System.Drawing.Size(60, 17);
            this.rbtnRoom.TabIndex = 12;
            this.rbtnRoom.Text = "Room\'s";
            this.rbtnRoom.UseVisualStyleBackColor = true;
            this.rbtnRoom.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // rbtnGroup
            // 
            this.rbtnGroup.AutoSize = true;
            this.rbtnGroup.Location = new System.Drawing.Point(12, 35);
            this.rbtnGroup.Name = "rbtnGroup";
            this.rbtnGroup.Size = new System.Drawing.Size(61, 17);
            this.rbtnGroup.TabIndex = 11;
            this.rbtnGroup.Text = "Group\'s";
            this.rbtnGroup.UseVisualStyleBackColor = true;
            this.rbtnGroup.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // rbtnTeacher
            // 
            this.rbtnTeacher.AutoSize = true;
            this.rbtnTeacher.Checked = true;
            this.rbtnTeacher.Location = new System.Drawing.Point(12, 12);
            this.rbtnTeacher.Name = "rbtnTeacher";
            this.rbtnTeacher.Size = new System.Drawing.Size(72, 17);
            this.rbtnTeacher.TabIndex = 10;
            this.rbtnTeacher.TabStop = true;
            this.rbtnTeacher.Text = "Teacher\'s";
            this.rbtnTeacher.UseVisualStyleBackColor = true;
            this.rbtnTeacher.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // cmbSemester
            // 
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbSemester.Location = new System.Drawing.Point(70, 147);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(192, 21);
            this.cmbSemester.TabIndex = 19;
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(-3, 150);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(54, 13);
            this.lblSemester.TabIndex = 20;
            this.lblSemester.Text = "Semester:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(-3, 180);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 22;
            this.lblYear.Text = "Year:";
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(70, 177);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(192, 20);
            this.tbYear.TabIndex = 23;
            // 
            // GetScheduleForm
            // 
            this.AcceptButton = this.btnGetShcedule;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 337);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.btnGetShcedule);
            this.Controls.Add(this.lblTeachGroupRoomContainer);
            this.Controls.Add(this.cmbDayOfWeek);
            this.Controls.Add(this.lblDayOfWeek);
            this.Controls.Add(this.dgvLesson);
            this.Controls.Add(this.cmbTeachGroupRoomContainer);
            this.Controls.Add(this.rbtnRoom);
            this.Controls.Add(this.rbtnGroup);
            this.Controls.Add(this.rbtnTeacher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetScheduleForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLesson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetShcedule;
        private System.Windows.Forms.Label lblTeachGroupRoomContainer;
        private System.Windows.Forms.ComboBox cmbDayOfWeek;
        private System.Windows.Forms.Label lblDayOfWeek;
        private System.Windows.Forms.DataGridView dgvLesson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayOfWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn LessonNumber;
        private System.Windows.Forms.ComboBox cmbTeachGroupRoomContainer;
        private System.Windows.Forms.RadioButton rbtnRoom;
        private System.Windows.Forms.RadioButton rbtnGroup;
        private System.Windows.Forms.RadioButton rbtnTeacher;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox tbYear;
    }
}