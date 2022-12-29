
namespace projectMIS
{
    partial class Login
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
            this.Loginbtn = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.TXTPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Loginbtn
            // 
            this.Loginbtn.Location = new System.Drawing.Point(141, 318);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(134, 51);
            this.Loginbtn.TabIndex = 0;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = true;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.LightGray;
            this.txtUsername.Location = new System.Drawing.Point(107, 136);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(192, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // TXTPassword
            // 
            this.TXTPassword.BackColor = System.Drawing.Color.LightGray;
            this.TXTPassword.Location = new System.Drawing.Point(107, 222);
            this.TXTPassword.Name = "TXTPassword";
            this.TXTPassword.Size = new System.Drawing.Size(192, 20);
            this.TXTPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(182)))), ((int)(((byte)(92)))));
            this.label1.Location = new System.Drawing.Point(165, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(182)))), ((int)(((byte)(92)))));
            this.label2.Location = new System.Drawing.Point(159, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.Loginbtn);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox TXTPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}