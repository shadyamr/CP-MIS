
namespace projectMIS
{
    partial class CustomerGUI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SearchGRD = new System.Windows.Forms.DataGridView();
            this.SearchTXT = new System.Windows.Forms.TextBox();
            this.SearchLBL = new System.Windows.Forms.Label();
            this.SearchBTN = new System.Windows.Forms.Button();
            this.projectDataSet = new projectMIS.projectDataSet();
            this.feedbackBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feedbackTableAdapter = new projectMIS.projectDataSetTableAdapters.feedbackTableAdapter();
            this.TXT_CompanyName = new MetroFramework.Controls.MetroTextBox();
            this.TXT_ContactName = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Address = new MetroFramework.Controls.MetroTextBox();
            this.TXT_City = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Region = new MetroFramework.Controls.MetroTextBox();
            this.TXT_PostalCode = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Country = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Phone = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.SearchGRD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedbackBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchGRD
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.SearchGRD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SearchGRD.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.SearchGRD.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.SearchGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SearchGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SearchGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SearchGRD.DefaultCellStyle = dataGridViewCellStyle3;
            this.SearchGRD.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SearchGRD.Location = new System.Drawing.Point(15, 38);
            this.SearchGRD.Name = "SearchGRD";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SearchGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.SearchGRD.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.SearchGRD.Size = new System.Drawing.Size(663, 119);
            this.SearchGRD.TabIndex = 0;
            // 
            // SearchTXT
            // 
            this.SearchTXT.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.SearchTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTXT.Location = new System.Drawing.Point(81, 12);
            this.SearchTXT.Multiline = true;
            this.SearchTXT.Name = "SearchTXT";
            this.SearchTXT.Size = new System.Drawing.Size(492, 20);
            this.SearchTXT.TabIndex = 1;
            // 
            // SearchLBL
            // 
            this.SearchLBL.AutoSize = true;
            this.SearchLBL.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLBL.Location = new System.Drawing.Point(12, 14);
            this.SearchLBL.Name = "SearchLBL";
            this.SearchLBL.Size = new System.Drawing.Size(51, 18);
            this.SearchLBL.TabIndex = 2;
            this.SearchLBL.Text = "Name";
            // 
            // SearchBTN
            // 
            this.SearchBTN.FlatAppearance.BorderSize = 3;
            this.SearchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBTN.Location = new System.Drawing.Point(579, 4);
            this.SearchBTN.Name = "SearchBTN";
            this.SearchBTN.Size = new System.Drawing.Size(75, 28);
            this.SearchBTN.TabIndex = 3;
            this.SearchBTN.Text = "Search";
            this.SearchBTN.UseVisualStyleBackColor = true;
            this.SearchBTN.Click += new System.EventHandler(this.SearchBTN_Click);
            // 
            // projectDataSet
            // 
            this.projectDataSet.DataSetName = "projectDataSet";
            this.projectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // feedbackBindingSource
            // 
            this.feedbackBindingSource.DataMember = "feedback";
            this.feedbackBindingSource.DataSource = this.projectDataSet;
            // 
            // feedbackTableAdapter
            // 
            this.feedbackTableAdapter.ClearBeforeFill = true;
            // 
            // TXT_CompanyName
            // 
            this.TXT_CompanyName.Location = new System.Drawing.Point(38, 184);
            this.TXT_CompanyName.Name = "TXT_CompanyName";
            this.TXT_CompanyName.Size = new System.Drawing.Size(224, 23);
            this.TXT_CompanyName.TabIndex = 4;
            this.TXT_CompanyName.Text = "CompanyName";
            this.TXT_CompanyName.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // TXT_ContactName
            // 
            this.TXT_ContactName.Location = new System.Drawing.Point(430, 184);
            this.TXT_ContactName.Name = "TXT_ContactName";
            this.TXT_ContactName.Size = new System.Drawing.Size(224, 23);
            this.TXT_ContactName.TabIndex = 4;
            this.TXT_ContactName.Text = "ContactName";
            this.TXT_ContactName.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // TXT_Address
            // 
            this.TXT_Address.Location = new System.Drawing.Point(38, 221);
            this.TXT_Address.Name = "TXT_Address";
            this.TXT_Address.Size = new System.Drawing.Size(224, 23);
            this.TXT_Address.TabIndex = 4;
            this.TXT_Address.Text = "Address";
            this.TXT_Address.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // TXT_City
            // 
            this.TXT_City.Location = new System.Drawing.Point(430, 221);
            this.TXT_City.Name = "TXT_City";
            this.TXT_City.Size = new System.Drawing.Size(224, 23);
            this.TXT_City.TabIndex = 4;
            this.TXT_City.Text = "City";
            this.TXT_City.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // TXT_Region
            // 
            this.TXT_Region.Location = new System.Drawing.Point(38, 259);
            this.TXT_Region.Name = "TXT_Region";
            this.TXT_Region.Size = new System.Drawing.Size(224, 23);
            this.TXT_Region.TabIndex = 4;
            this.TXT_Region.Text = "Region";
            this.TXT_Region.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // TXT_PostalCode
            // 
            this.TXT_PostalCode.Location = new System.Drawing.Point(430, 259);
            this.TXT_PostalCode.Name = "TXT_PostalCode";
            this.TXT_PostalCode.Size = new System.Drawing.Size(224, 23);
            this.TXT_PostalCode.TabIndex = 4;
            this.TXT_PostalCode.Text = "PostalCode";
            this.TXT_PostalCode.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // TXT_Country
            // 
            this.TXT_Country.Location = new System.Drawing.Point(38, 298);
            this.TXT_Country.Name = "TXT_Country";
            this.TXT_Country.Size = new System.Drawing.Size(224, 23);
            this.TXT_Country.TabIndex = 4;
            this.TXT_Country.Text = "Country";
            this.TXT_Country.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // TXT_Phone
            // 
            this.TXT_Phone.Location = new System.Drawing.Point(430, 298);
            this.TXT_Phone.Name = "TXT_Phone";
            this.TXT_Phone.Size = new System.Drawing.Size(224, 23);
            this.TXT_Phone.TabIndex = 4;
            this.TXT_Phone.Text = "Phone";
            this.TXT_Phone.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(269, 348);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(156, 23);
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Add Customer";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // CustomerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(687, 402);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.TXT_Phone);
            this.Controls.Add(this.TXT_Country);
            this.Controls.Add(this.TXT_PostalCode);
            this.Controls.Add(this.TXT_Region);
            this.Controls.Add(this.TXT_City);
            this.Controls.Add(this.TXT_Address);
            this.Controls.Add(this.TXT_ContactName);
            this.Controls.Add(this.TXT_CompanyName);
            this.Controls.Add(this.SearchBTN);
            this.Controls.Add(this.SearchLBL);
            this.Controls.Add(this.SearchTXT);
            this.Controls.Add(this.SearchGRD);
            this.Name = "CustomerGUI";
            this.Text = "CustomerGUI";
            this.Load += new System.EventHandler(this.CustomerGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SearchGRD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedbackBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SearchGRD;
        private System.Windows.Forms.TextBox SearchTXT;
        private System.Windows.Forms.Label SearchLBL;
        private System.Windows.Forms.Button SearchBTN;
        private projectDataSet projectDataSet;
        private System.Windows.Forms.BindingSource feedbackBindingSource;
        private projectDataSetTableAdapters.feedbackTableAdapter feedbackTableAdapter;
        private MetroFramework.Controls.MetroTextBox TXT_CompanyName;
        private MetroFramework.Controls.MetroTextBox TXT_ContactName;
        private MetroFramework.Controls.MetroTextBox TXT_Address;
        private MetroFramework.Controls.MetroTextBox TXT_City;
        private MetroFramework.Controls.MetroTextBox TXT_Region;
        private MetroFramework.Controls.MetroTextBox TXT_PostalCode;
        private MetroFramework.Controls.MetroTextBox TXT_Country;
        private MetroFramework.Controls.MetroTextBox TXT_Phone;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}