
namespace projectMIS
{
    partial class Employees
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.projectDataSet = new projectMIS.projectDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchTXT = new System.Windows.Forms.TextBox();
            this.SearchLBL = new System.Windows.Forms.Label();
            this.SearchBTN = new System.Windows.Forms.Button();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.TXT_FirstName = new MetroFramework.Controls.MetroTextBox();
            this.TXT_LastName = new MetroFramework.Controls.MetroTextBox();
            this.TXT_MobilePhone = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Notes = new MetroFramework.Controls.MetroTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.TXT_password = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // projectDataSet
            // 
            this.projectDataSet.DataSetName = "projectDataSet";
            this.projectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = ".........";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(685, 161);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SearchTXT
            // 
            this.SearchTXT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchTXT.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.SearchTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTXT.Location = new System.Drawing.Point(76, 15);
            this.SearchTXT.Multiline = true;
            this.SearchTXT.Name = "SearchTXT";
            this.SearchTXT.Size = new System.Drawing.Size(492, 20);
            this.SearchTXT.TabIndex = 2;
            // 
            // SearchLBL
            // 
            this.SearchLBL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchLBL.AutoSize = true;
            this.SearchLBL.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLBL.Location = new System.Drawing.Point(12, 17);
            this.SearchLBL.Name = "SearchLBL";
            this.SearchLBL.Size = new System.Drawing.Size(26, 18);
            this.SearchLBL.TabIndex = 3;
            this.SearchLBL.Text = "ID";
            // 
            // SearchBTN
            // 
            this.SearchBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchBTN.FlatAppearance.BorderSize = 3;
            this.SearchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBTN.Location = new System.Drawing.Point(600, 12);
            this.SearchBTN.Name = "SearchBTN";
            this.SearchBTN.Size = new System.Drawing.Size(75, 28);
            this.SearchBTN.TabIndex = 4;
            this.SearchBTN.Text = "Search";
            this.SearchBTN.UseVisualStyleBackColor = true;
            this.SearchBTN.Click += new System.EventHandler(this.SearchBTN_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(289, 337);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(106, 23);
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Add Employee";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // TXT_FirstName
            // 
            this.TXT_FirstName.Location = new System.Drawing.Point(76, 227);
            this.TXT_FirstName.Name = "TXT_FirstName";
            this.TXT_FirstName.Size = new System.Drawing.Size(114, 23);
            this.TXT_FirstName.TabIndex = 6;
            this.TXT_FirstName.Text = "FirstName";
            // 
            // TXT_LastName
            // 
            this.TXT_LastName.Location = new System.Drawing.Point(76, 269);
            this.TXT_LastName.Name = "TXT_LastName";
            this.TXT_LastName.Size = new System.Drawing.Size(114, 23);
            this.TXT_LastName.TabIndex = 6;
            this.TXT_LastName.Text = "LastName";
            // 
            // TXT_MobilePhone
            // 
            this.TXT_MobilePhone.Location = new System.Drawing.Point(511, 227);
            this.TXT_MobilePhone.Name = "TXT_MobilePhone";
            this.TXT_MobilePhone.Size = new System.Drawing.Size(114, 23);
            this.TXT_MobilePhone.TabIndex = 6;
            this.TXT_MobilePhone.Text = "MobilePhone";
            // 
            // TXT_Notes
            // 
            this.TXT_Notes.Location = new System.Drawing.Point(511, 269);
            this.TXT_Notes.Name = "TXT_Notes";
            this.TXT_Notes.Size = new System.Drawing.Size(114, 23);
            this.TXT_Notes.TabIndex = 6;
            this.TXT_Notes.Text = "Notes";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(289, 337);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(106, 23);
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "Add Employee";
            this.metroButton2.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(76, 269);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(114, 23);
            this.metroTextBox1.TabIndex = 6;
            this.metroTextBox1.Text = "LastName";
            this.metroTextBox1.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // TXT_password
            // 
            this.TXT_password.Location = new System.Drawing.Point(289, 291);
            this.TXT_password.Name = "TXT_password";
            this.TXT_password.Size = new System.Drawing.Size(106, 23);
            this.TXT_password.TabIndex = 6;
            this.TXT_password.Text = "123456";
            this.TXT_password.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(687, 402);
            this.Controls.Add(this.TXT_Notes);
            this.Controls.Add(this.TXT_MobilePhone);
            this.Controls.Add(this.TXT_password);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.TXT_LastName);
            this.Controls.Add(this.TXT_FirstName);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.SearchBTN);
            this.Controls.Add(this.SearchLBL);
            this.Controls.Add(this.SearchTXT);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Employees";
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.Employees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private projectDataSet projectDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox SearchTXT;
        private System.Windows.Forms.Label SearchLBL;
        private System.Windows.Forms.Button SearchBTN;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox TXT_FirstName;
        private MetroFramework.Controls.MetroTextBox TXT_LastName;
        private MetroFramework.Controls.MetroTextBox TXT_MobilePhone;
        private MetroFramework.Controls.MetroTextBox TXT_Notes;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroTextBox TXT_password;
    }
}