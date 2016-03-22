namespace SchoolScheduleManager.DesktopUI.Forms
{
    partial class InputLessonForm
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
            this.tbYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.lblDayOfWeek = new System.Windows.Forms.Label();
            this.cmbTeach = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.tbLessonNumber = new System.Windows.Forms.TextBox();
            this.lblLessonNumber = new System.Windows.Forms.Label();
            this.btnAddLesson = new System.Windows.Forms.Button();
            this.btnGetGroup = new System.Windows.Forms.Button();
            this.btnGetRoom = new System.Windows.Forms.Button();
            this.btnGetTeacher = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(97, 12);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(192, 20);
            this.tbYear.TabIndex = 31;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(9, 15);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 30;
            this.lblYear.Text = "Year:";
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(9, 39);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(54, 13);
            this.lblSemester.TabIndex = 29;
            this.lblSemester.Text = "Semester:";
            // 
            // cmbSemester
            // 
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbSemester.Location = new System.Drawing.Point(97, 38);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(192, 21);
            this.cmbSemester.TabIndex = 28;
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(9, 122);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(50, 13);
            this.lblTeacher.TabIndex = 27;
            this.lblTeacher.Text = "Teacher:";
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
            this.cmbDayOfWeek.Location = new System.Drawing.Point(97, 65);
            this.cmbDayOfWeek.Name = "cmbDayOfWeek";
            this.cmbDayOfWeek.Size = new System.Drawing.Size(192, 21);
            this.cmbDayOfWeek.TabIndex = 26;
            // 
            // lblDayOfWeek
            // 
            this.lblDayOfWeek.AutoSize = true;
            this.lblDayOfWeek.Location = new System.Drawing.Point(9, 68);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(67, 13);
            this.lblDayOfWeek.TabIndex = 25;
            this.lblDayOfWeek.Text = "Day of week";
            // 
            // cmbTeach
            // 
            this.cmbTeach.FormattingEnabled = true;
            this.cmbTeach.Location = new System.Drawing.Point(97, 119);
            this.cmbTeach.Name = "cmbTeach";
            this.cmbTeach.Size = new System.Drawing.Size(192, 21);
            this.cmbTeach.TabIndex = 24;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(9, 149);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(36, 13);
            this.lblGroup.TabIndex = 33;
            this.lblGroup.Text = "Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(97, 146);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(192, 21);
            this.cmbGroup.TabIndex = 32;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(9, 176);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 35;
            this.lblSubject.Text = "Subject";
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(97, 173);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(192, 21);
            this.cmbSubject.TabIndex = 34;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(9, 203);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(38, 13);
            this.lblRoom.TabIndex = 37;
            this.lblRoom.Text = "Room:";
            // 
            // cmbRoom
            // 
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(97, 200);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(192, 21);
            this.cmbRoom.TabIndex = 36;
            // 
            // tbLessonNumber
            // 
            this.tbLessonNumber.Location = new System.Drawing.Point(97, 93);
            this.tbLessonNumber.Name = "tbLessonNumber";
            this.tbLessonNumber.Size = new System.Drawing.Size(192, 20);
            this.tbLessonNumber.TabIndex = 39;
            // 
            // lblLessonNumber
            // 
            this.lblLessonNumber.AutoSize = true;
            this.lblLessonNumber.Location = new System.Drawing.Point(9, 96);
            this.lblLessonNumber.Name = "lblLessonNumber";
            this.lblLessonNumber.Size = new System.Drawing.Size(79, 13);
            this.lblLessonNumber.TabIndex = 38;
            this.lblLessonNumber.Text = "Lesson number";
            // 
            // btnAddLesson
            // 
            this.btnAddLesson.Location = new System.Drawing.Point(295, 12);
            this.btnAddLesson.Name = "btnAddLesson";
            this.btnAddLesson.Size = new System.Drawing.Size(75, 209);
            this.btnAddLesson.TabIndex = 40;
            this.btnAddLesson.Text = "Add lesson";
            this.btnAddLesson.UseVisualStyleBackColor = true;
            this.btnAddLesson.Click += new System.EventHandler(this.btnAddLesson_Click);
            // 
            // btnGetGroup
            // 
            this.btnGetGroup.Location = new System.Drawing.Point(12, 253);
            this.btnGetGroup.Name = "btnGetGroup";
            this.btnGetGroup.Size = new System.Drawing.Size(118, 23);
            this.btnGetGroup.TabIndex = 41;
            this.btnGetGroup.Text = "Get available group";
            this.btnGetGroup.UseVisualStyleBackColor = true;
            this.btnGetGroup.Click += new System.EventHandler(this.btnGetGroup_Click);
            // 
            // btnGetRoom
            // 
            this.btnGetRoom.Location = new System.Drawing.Point(12, 293);
            this.btnGetRoom.Name = "btnGetRoom";
            this.btnGetRoom.Size = new System.Drawing.Size(118, 23);
            this.btnGetRoom.TabIndex = 42;
            this.btnGetRoom.Text = "Get available room";
            this.btnGetRoom.UseVisualStyleBackColor = true;
            this.btnGetRoom.Click += new System.EventHandler(this.btnGetRoom_Click);
            // 
            // btnGetTeacher
            // 
            this.btnGetTeacher.Location = new System.Drawing.Point(12, 334);
            this.btnGetTeacher.Name = "btnGetTeacher";
            this.btnGetTeacher.Size = new System.Drawing.Size(118, 23);
            this.btnGetTeacher.TabIndex = 43;
            this.btnGetTeacher.Text = "Get available teacher";
            this.btnGetTeacher.UseVisualStyleBackColor = true;
            this.btnGetTeacher.Click += new System.EventHandler(this.btnGetTeacher_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(178, 253);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(192, 104);
            this.richTextBox1.TabIndex = 44;
            this.richTextBox1.Text = "";
            // 
            // InputLessonForm
            // 
            this.AcceptButton = this.btnAddLesson;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 369);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnGetTeacher);
            this.Controls.Add(this.btnGetRoom);
            this.Controls.Add(this.btnGetGroup);
            this.Controls.Add(this.btnAddLesson);
            this.Controls.Add(this.tbLessonNumber);
            this.Controls.Add(this.lblLessonNumber);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.lblTeacher);
            this.Controls.Add(this.cmbDayOfWeek);
            this.Controls.Add(this.lblDayOfWeek);
            this.Controls.Add(this.cmbTeach);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputLessonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Lesson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.ComboBox cmbDayOfWeek;
        private System.Windows.Forms.Label lblDayOfWeek;
        private System.Windows.Forms.ComboBox cmbTeach;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.TextBox tbLessonNumber;
        private System.Windows.Forms.Label lblLessonNumber;
        private System.Windows.Forms.Button btnAddLesson;
        private System.Windows.Forms.Button btnGetGroup;
        private System.Windows.Forms.Button btnGetRoom;
        private System.Windows.Forms.Button btnGetTeacher;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}