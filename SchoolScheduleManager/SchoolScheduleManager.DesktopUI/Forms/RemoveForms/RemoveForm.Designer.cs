namespace SchoolScheduleManager.DesktopUI.Forms.RemoveForms
{
    partial class RemoveForm
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.cmbTechGroupRoomSubj = new System.Windows.Forms.ComboBox();
            this.lblTechGroupRoomSubj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(174, 107);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cmbTechGroupRoomSubj
            // 
            this.cmbTechGroupRoomSubj.FormattingEnabled = true;
            this.cmbTechGroupRoomSubj.Location = new System.Drawing.Point(76, 61);
            this.cmbTechGroupRoomSubj.Name = "cmbTechGroupRoomSubj";
            this.cmbTechGroupRoomSubj.Size = new System.Drawing.Size(173, 21);
            this.cmbTechGroupRoomSubj.TabIndex = 1;
            this.cmbTechGroupRoomSubj.SelectedIndexChanged += new System.EventHandler(this.cmbTechGroupRoomSubj_SelectedIndexChanged);
            // 
            // lblTechGroupRoomSubj
            // 
            this.lblTechGroupRoomSubj.AutoSize = true;
            this.lblTechGroupRoomSubj.Location = new System.Drawing.Point(13, 64);
            this.lblTechGroupRoomSubj.Name = "lblTechGroupRoomSubj";
            this.lblTechGroupRoomSubj.Size = new System.Drawing.Size(52, 13);
            this.lblTechGroupRoomSubj.TabIndex = 2;
            this.lblTechGroupRoomSubj.Text = "Teachers";
            // 
            // RemoveForm
            // 
            this.AcceptButton = this.btnRemove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 152);
            this.Controls.Add(this.lblTechGroupRoomSubj);
            this.Controls.Add(this.cmbTechGroupRoomSubj);
            this.Controls.Add(this.btnRemove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RemoveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoveTeacherForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cmbTechGroupRoomSubj;
        private System.Windows.Forms.Label lblTechGroupRoomSubj;
    }
}