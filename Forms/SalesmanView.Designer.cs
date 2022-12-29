namespace projectMIS.Forms
{
    partial class SalesmanView
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
            this.TXT_NAME = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Owner = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Phone = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Address = new MetroFramework.Controls.MetroTextBox();
            this.TXT_BUDGET = new MetroFramework.Controls.MetroTextBox();
            this.TXT_EMAIL = new MetroFramework.Controls.MetroTextBox();
            this.TXT_Notes = new System.Windows.Forms.RichTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.projectDataSet = new projectMIS.projectDataSet();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordersTableAdapter = new projectMIS.projectDataSetTableAdapters.OrdersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TXT_NAME
            // 
            this.TXT_NAME.Location = new System.Drawing.Point(12, 44);
            this.TXT_NAME.Name = "TXT_NAME";
            this.TXT_NAME.Size = new System.Drawing.Size(154, 23);
            this.TXT_NAME.TabIndex = 0;
            // 
            // TXT_Owner
            // 
            this.TXT_Owner.Location = new System.Drawing.Point(240, 44);
            this.TXT_Owner.Name = "TXT_Owner";
            this.TXT_Owner.Size = new System.Drawing.Size(154, 23);
            this.TXT_Owner.TabIndex = 3;
            // 
            // TXT_Phone
            // 
            this.TXT_Phone.Location = new System.Drawing.Point(240, 115);
            this.TXT_Phone.Name = "TXT_Phone";
            this.TXT_Phone.Size = new System.Drawing.Size(154, 23);
            this.TXT_Phone.TabIndex = 7;
            // 
            // TXT_Address
            // 
            this.TXT_Address.Location = new System.Drawing.Point(12, 115);
            this.TXT_Address.Name = "TXT_Address";
            this.TXT_Address.Size = new System.Drawing.Size(154, 23);
            this.TXT_Address.TabIndex = 9;
            // 
            // TXT_BUDGET
            // 
            this.TXT_BUDGET.ForeColor = System.Drawing.Color.LightGray;
            this.TXT_BUDGET.Location = new System.Drawing.Point(12, 187);
            this.TXT_BUDGET.Name = "TXT_BUDGET";
            this.TXT_BUDGET.Size = new System.Drawing.Size(154, 23);
            this.TXT_BUDGET.TabIndex = 10;
            // 
            // TXT_EMAIL
            // 
            this.TXT_EMAIL.ForeColor = System.Drawing.Color.LightGray;
            this.TXT_EMAIL.Location = new System.Drawing.Point(240, 187);
            this.TXT_EMAIL.Name = "TXT_EMAIL";
            this.TXT_EMAIL.Size = new System.Drawing.Size(154, 23);
            this.TXT_EMAIL.TabIndex = 12;
            // 
            // TXT_Notes
            // 
            this.TXT_Notes.BackColor = System.Drawing.Color.LightGray;
            this.TXT_Notes.Location = new System.Drawing.Point(12, 252);
            this.TXT_Notes.Name = "TXT_Notes";
            this.TXT_Notes.Size = new System.Drawing.Size(382, 96);
            this.TXT_Notes.TabIndex = 14;
            this.TXT_Notes.Text = "";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(152, 364);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 16;
            this.metroButton1.Text = "Submit";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(237, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Corporate Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(12, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Corporate Budget";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(238, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Corporate Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(9, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Corporate Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(238, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Corporate Owner";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightGray;
            this.label6.Location = new System.Drawing.Point(9, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Corporate Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightGray;
            this.label7.Location = new System.Drawing.Point(12, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Additional Information";
            // 
            // projectDataSet
            // 
            this.projectDataSet.DataSetName = "projectDataSet";
            this.projectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "Orders";
            this.ordersBindingSource.DataSource = this.projectDataSet;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // SalesmanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(407, 411);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.TXT_Notes);
            this.Controls.Add(this.TXT_EMAIL);
            this.Controls.Add(this.TXT_BUDGET);
            this.Controls.Add(this.TXT_Address);
            this.Controls.Add(this.TXT_Phone);
            this.Controls.Add(this.TXT_Owner);
            this.Controls.Add(this.TXT_NAME);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "SalesmanView";
            this.Text = "Salesman View";
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TXT_NAME;
        private MetroFramework.Controls.MetroTextBox TXT_Owner;
        private MetroFramework.Controls.MetroTextBox TXT_Phone;
        private MetroFramework.Controls.MetroTextBox TXT_Address;
        private MetroFramework.Controls.MetroTextBox TXT_BUDGET;
        private MetroFramework.Controls.MetroTextBox TXT_EMAIL;
        private System.Windows.Forms.RichTextBox TXT_Notes;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private projectDataSet projectDataSet;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private projectDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter;
    }
}