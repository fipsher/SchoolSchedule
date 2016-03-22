namespace SchoolScheduleManager.DesktopUI
{
    partial class MainForm
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
            this.getScheduleButton = new System.Windows.Forms.Button();
            this.btnInputLesson = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.rtnRemoveTeacher = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.btnRemoveSubject = new System.Windows.Forms.Button();
            this.btnRemoveLesson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getScheduleButton
            // 
            this.getScheduleButton.Location = new System.Drawing.Point(12, 12);
            this.getScheduleButton.Name = "getScheduleButton";
            this.getScheduleButton.Size = new System.Drawing.Size(122, 23);
            this.getScheduleButton.TabIndex = 0;
            this.getScheduleButton.Text = "Get schedule";
            this.getScheduleButton.UseVisualStyleBackColor = true;
            this.getScheduleButton.Click += new System.EventHandler(this.getScheduleButton_Click);
            // 
            // btnInputLesson
            // 
            this.btnInputLesson.Location = new System.Drawing.Point(12, 79);
            this.btnInputLesson.Name = "btnInputLesson";
            this.btnInputLesson.Size = new System.Drawing.Size(122, 23);
            this.btnInputLesson.TabIndex = 1;
            this.btnInputLesson.Text = "Input lesson";
            this.btnInputLesson.UseVisualStyleBackColor = true;
            this.btnInputLesson.Click += new System.EventHandler(this.btnInputLesson_Click);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(12, 144);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(122, 23);
            this.btnAddTeacher.TabIndex = 2;
            this.btnAddTeacher.Text = "Add teacher";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(12, 173);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(122, 23);
            this.btnAddGroup.TabIndex = 3;
            this.btnAddGroup.Text = "Add group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(12, 202);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(122, 23);
            this.btnAddRoom.TabIndex = 4;
            this.btnAddRoom.Text = "Add room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(12, 231);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(122, 23);
            this.btnAddSubject.TabIndex = 5;
            this.btnAddSubject.Text = "Add subject";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // rtnRemoveTeacher
            // 
            this.rtnRemoveTeacher.Location = new System.Drawing.Point(140, 144);
            this.rtnRemoveTeacher.Name = "rtnRemoveTeacher";
            this.rtnRemoveTeacher.Size = new System.Drawing.Size(122, 23);
            this.rtnRemoveTeacher.TabIndex = 6;
            this.rtnRemoveTeacher.Text = "Remove teacher";
            this.rtnRemoveTeacher.UseVisualStyleBackColor = true;
            this.rtnRemoveTeacher.Click += new System.EventHandler(this.rtnRemoveTeacher_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Location = new System.Drawing.Point(140, 173);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(122, 23);
            this.btnRemoveGroup.TabIndex = 7;
            this.btnRemoveGroup.Text = "Remove group";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Location = new System.Drawing.Point(140, 202);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(122, 23);
            this.btnRemoveRoom.TabIndex = 8;
            this.btnRemoveRoom.Text = "Remove room";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            this.btnRemoveRoom.Click += new System.EventHandler(this.btnRemoveRoom_Click);
            // 
            // btnRemoveSubject
            // 
            this.btnRemoveSubject.Location = new System.Drawing.Point(140, 231);
            this.btnRemoveSubject.Name = "btnRemoveSubject";
            this.btnRemoveSubject.Size = new System.Drawing.Size(122, 23);
            this.btnRemoveSubject.TabIndex = 9;
            this.btnRemoveSubject.Text = "Remove subject";
            this.btnRemoveSubject.UseVisualStyleBackColor = true;
            this.btnRemoveSubject.Click += new System.EventHandler(this.btnRemoveSubject_Click);
            // 
            // btnRemoveLesson
            // 
            this.btnRemoveLesson.Location = new System.Drawing.Point(140, 79);
            this.btnRemoveLesson.Name = "btnRemoveLesson";
            this.btnRemoveLesson.Size = new System.Drawing.Size(122, 23);
            this.btnRemoveLesson.TabIndex = 10;
            this.btnRemoveLesson.Text = "Remove lesson";
            this.btnRemoveLesson.UseVisualStyleBackColor = true;
            this.btnRemoveLesson.Click += new System.EventHandler(this.btnRemoveLesson_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnRemoveLesson);
            this.Controls.Add(this.btnRemoveSubject);
            this.Controls.Add(this.btnRemoveRoom);
            this.Controls.Add(this.btnRemoveGroup);
            this.Controls.Add(this.rtnRemoveTeacher);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.btnAddTeacher);
            this.Controls.Add(this.btnInputLesson);
            this.Controls.Add(this.getScheduleButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School schedule manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button getScheduleButton;
        private System.Windows.Forms.Button btnInputLesson;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button rtnRemoveTeacher;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.Button btnRemoveRoom;
        private System.Windows.Forms.Button btnRemoveSubject;
        private System.Windows.Forms.Button btnRemoveLesson;
    }
}

