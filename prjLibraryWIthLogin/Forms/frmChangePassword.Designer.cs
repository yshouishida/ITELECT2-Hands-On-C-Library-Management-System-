namespace prjLibraryWIthLogin.Forms
{
    partial class frmChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReEnterPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.checkBoxPwd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current Password:";
            // 
            // txtCurrentPwd
            // 
            this.txtCurrentPwd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPwd.Location = new System.Drawing.Point(16, 110);
            this.txtCurrentPwd.Name = "txtCurrentPwd";
            this.txtCurrentPwd.Size = new System.Drawing.Size(356, 29);
            this.txtCurrentPwd.TabIndex = 0;
            this.txtCurrentPwd.UseSystemPasswordChar = true;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPwd.Location = new System.Drawing.Point(16, 167);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(356, 29);
            this.txtNewPwd.TabIndex = 1;
            this.txtNewPwd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "New Password:";
            // 
            // txtReEnterPwd
            // 
            this.txtReEnterPwd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReEnterPwd.Location = new System.Drawing.Point(16, 229);
            this.txtReEnterPwd.Name = "txtReEnterPwd";
            this.txtReEnterPwd.Size = new System.Drawing.Size(356, 29);
            this.txtReEnterPwd.TabIndex = 2;
            this.txtReEnterPwd.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Re-enter Password";
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePwd.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePwd.Location = new System.Drawing.Point(16, 291);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(356, 55);
            this.btnChangePwd.TabIndex = 4;
            this.btnChangePwd.Text = "Change";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // checkBoxPwd
            // 
            this.checkBoxPwd.AutoSize = true;
            this.checkBoxPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPwd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPwd.Location = new System.Drawing.Point(16, 264);
            this.checkBoxPwd.Name = "checkBoxPwd";
            this.checkBoxPwd.Size = new System.Drawing.Size(118, 21);
            this.checkBoxPwd.TabIndex = 3;
            this.checkBoxPwd.Text = "Show Password";
            this.checkBoxPwd.UseVisualStyleBackColor = true;
            this.checkBoxPwd.CheckedChanged += new System.EventHandler(this.checkBoxPwd_CheckedChanged);
            // 
            // frmChangePassword
            // 
            this.AcceptButton = this.btnChangePwd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 358);
            this.Controls.Add(this.checkBoxPwd);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.txtReEnterPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCurrentPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReEnterPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.CheckBox checkBoxPwd;
    }
}