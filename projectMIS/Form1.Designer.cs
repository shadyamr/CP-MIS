
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
            this.label1 = new System.Windows.Forms.Label();
            this.Passwordlabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.ID_Number = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // Passwordlabel
            // 
            this.Passwordlabel.AutoSize = true;
            this.Passwordlabel.Location = new System.Drawing.Point(42, 95);
            this.Passwordlabel.Name = "Passwordlabel";
            this.Passwordlabel.Size = new System.Drawing.Size(53, 13);
            this.Passwordlabel.TabIndex = 1;
            this.Passwordlabel.Text = "password";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(166, 325);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(125, 34);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login!";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ID_Number
            // 
            this.ID_Number.Location = new System.Drawing.Point(140, 43);
            this.ID_Number.Name = "ID_Number";
            this.ID_Number.Size = new System.Drawing.Size(238, 20);
            this.ID_Number.TabIndex = 3;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(140, 92);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(238, 20);
            this.Password.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 450);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.ID_Number);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.Passwordlabel);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Passwordlabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox ID_Number;
        private System.Windows.Forms.TextBox Password;
    }
}

