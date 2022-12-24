
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.ID_Number = new System.Windows.Forms.TextBox();
            this.grd_Employees = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Employees)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(168, 387);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(125, 34);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login!";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ID_Number
            // 
            this.ID_Number.Location = new System.Drawing.Point(115, 24);
            this.ID_Number.Name = "ID_Number";
            this.ID_Number.Size = new System.Drawing.Size(238, 20);
            this.ID_Number.TabIndex = 3;
            // 
            // grd_Employees
            // 
            this.grd_Employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Employees.Location = new System.Drawing.Point(18, 50);
            this.grd_Employees.Name = "grd_Employees";
            this.grd_Employees.Size = new System.Drawing.Size(440, 331);
            this.grd_Employees.TabIndex = 4;
            this.grd_Employees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Employees_CellContentClick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 450);
            this.Controls.Add(this.grd_Employees);
            this.Controls.Add(this.ID_Number);
            this.Controls.Add(this.LoginButton);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Employees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox ID_Number;
        private System.Windows.Forms.DataGridView grd_Employees;
    }
}

