
namespace projectMIS
{
    partial class Dashboard
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.LabelCompletedOrders = new System.Windows.Forms.Label();
            this.LabelOrders = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.projectDataSet = new projectMIS.projectDataSet();
            this.salariesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salariesTableAdapter = new projectMIS.projectDataSetTableAdapters.SalariesTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(687, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.LabelCompletedOrders);
            this.panel1.Controls.Add(this.LabelOrders);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 94);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "completed";
            this.label5.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // LabelCompletedOrders
            // 
            this.LabelCompletedOrders.AutoSize = true;
            this.LabelCompletedOrders.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCompletedOrders.Location = new System.Drawing.Point(100, 71);
            this.LabelCompletedOrders.Name = "LabelCompletedOrders";
            this.LabelCompletedOrders.Size = new System.Drawing.Size(54, 18);
            this.LabelCompletedOrders.TabIndex = 0;
            this.LabelCompletedOrders.Text = "Done";
            this.LabelCompletedOrders.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // LabelOrders
            // 
            this.LabelOrders.AutoSize = true;
            this.LabelOrders.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOrders.Location = new System.Drawing.Point(99, 19);
            this.LabelOrders.Name = "LabelOrders";
            this.LabelOrders.Size = new System.Drawing.Size(63, 19);
            this.LabelOrders.TabIndex = 0;
            this.LabelOrders.Text = "Orders";
            this.LabelOrders.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "completed";
            this.label2.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orders";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Indigo;
            this.panel2.Location = new System.Drawing.Point(174, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 94);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel3.Location = new System.Drawing.Point(345, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 94);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Indigo;
            this.panel4.Location = new System.Drawing.Point(516, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(168, 94);
            this.panel4.TabIndex = 3;
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(449, 107);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(235, 254);
            this.pieChart1.TabIndex = 1;
            this.pieChart1.Text = "pieChart1";
            this.pieChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.pieChart1_ChildChanged);
            // 
            // projectDataSet
            // 
            this.projectDataSet.DataSetName = "projectDataSet";
            this.projectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salariesBindingSource
            // 
            this.salariesBindingSource.DataMember = "Salaries";
            this.salariesBindingSource.DataSource = this.projectDataSet;
            // 
            // salariesTableAdapter
            // 
            this.salariesTableAdapter.ClearBeforeFill = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(687, 402);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Dashboard";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabelCompletedOrders;
        private System.Windows.Forms.Label LabelOrders;
        private System.Windows.Forms.Label label2;
        private projectDataSet projectDataSet;
        private System.Windows.Forms.BindingSource salariesBindingSource;
        private projectDataSetTableAdapters.SalariesTableAdapter salariesTableAdapter;
    }
}