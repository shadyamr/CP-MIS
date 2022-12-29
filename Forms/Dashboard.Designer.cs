
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
            this.unavail = new System.Windows.Forms.Label();
            this.Produc = new System.Windows.Forms.Label();
            this.Unavailable = new System.Windows.Forms.Label();
            this.Products = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.firedtxt = new System.Windows.Forms.Label();
            this.employeestxt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.projectDataSet = new projectMIS.projectDataSet();
            this.salariesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salariesTableAdapter = new projectMIS.projectDataSetTableAdapters.SalariesTableAdapter();
            this.gauge = new System.Windows.Forms.Integration.ElementHost();
            this.gauge1 = new LiveCharts.Wpf.Gauge();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(687, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(152)))), ((int)(((byte)(120)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.LabelCompletedOrders);
            this.panel1.Controls.Add(this.LabelOrders);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 94);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "completed";
            // 
            // LabelCompletedOrders
            // 
            this.LabelCompletedOrders.AutoSize = true;
            this.LabelCompletedOrders.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCompletedOrders.Location = new System.Drawing.Point(108, 71);
            this.LabelCompletedOrders.Name = "LabelCompletedOrders";
            this.LabelCompletedOrders.Size = new System.Drawing.Size(54, 18);
            this.LabelCompletedOrders.TabIndex = 0;
            this.LabelCompletedOrders.Text = "Done";
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
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(152)))), ((int)(((byte)(120)))));
            this.panel2.Controls.Add(this.unavail);
            this.panel2.Controls.Add(this.Produc);
            this.panel2.Controls.Add(this.Unavailable);
            this.panel2.Controls.Add(this.Products);
            this.panel2.Location = new System.Drawing.Point(174, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 94);
            this.panel2.TabIndex = 1;
            // 
            // unavail
            // 
            this.unavail.AutoSize = true;
            this.unavail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unavail.Location = new System.Drawing.Point(100, 70);
            this.unavail.Name = "unavail";
            this.unavail.Size = new System.Drawing.Size(68, 19);
            this.unavail.TabIndex = 3;
            this.unavail.Text = "unavail";
            // 
            // Produc
            // 
            this.Produc.AutoSize = true;
            this.Produc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Produc.Location = new System.Drawing.Point(100, 19);
            this.Produc.Name = "Produc";
            this.Produc.Size = new System.Drawing.Size(65, 19);
            this.Produc.TabIndex = 2;
            this.Produc.Text = "Produc";
            // 
            // Unavailable
            // 
            this.Unavailable.AutoSize = true;
            this.Unavailable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unavailable.Location = new System.Drawing.Point(0, 52);
            this.Unavailable.Name = "Unavailable";
            this.Unavailable.Size = new System.Drawing.Size(105, 19);
            this.Unavailable.TabIndex = 1;
            this.Unavailable.Text = "Unavailable";
            // 
            // Products
            // 
            this.Products.AutoSize = true;
            this.Products.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Products.Location = new System.Drawing.Point(3, 5);
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(94, 23);
            this.Products.TabIndex = 0;
            this.Products.Text = "Products";
            this.Products.Click += new System.EventHandler(this.Products_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(152)))), ((int)(((byte)(120)))));
            this.panel3.Controls.Add(this.firedtxt);
            this.panel3.Controls.Add(this.employeestxt);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(345, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 94);
            this.panel3.TabIndex = 2;
            // 
            // firedtxt
            // 
            this.firedtxt.AutoSize = true;
            this.firedtxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firedtxt.Location = new System.Drawing.Point(100, 70);
            this.firedtxt.Name = "firedtxt";
            this.firedtxt.Size = new System.Drawing.Size(68, 19);
            this.firedtxt.TabIndex = 3;
            this.firedtxt.Text = "unavail";
            // 
            // employeestxt
            // 
            this.employeestxt.AutoSize = true;
            this.employeestxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeestxt.Location = new System.Drawing.Point(97, 28);
            this.employeestxt.Name = "employeestxt";
            this.employeestxt.Size = new System.Drawing.Size(65, 19);
            this.employeestxt.TabIndex = 2;
            this.employeestxt.Text = "Produc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Fired";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Employees";
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
            // gauge
            // 
            this.gauge.Location = new System.Drawing.Point(13, 107);
            this.gauge.Name = "gauge";
            this.gauge.Size = new System.Drawing.Size(430, 271);
            this.gauge.TabIndex = 2;
            this.gauge.Text = "elementHost1";
            this.gauge.Child = this.gauge1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(152)))), ((int)(((byte)(120)))));
            this.label12.Location = new System.Drawing.Point(148, 355);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "Target Orders";
            this.label12.Click += new System.EventHandler(this.Products_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(687, 402);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.gauge);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Dashboard";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabelCompletedOrders;
        private System.Windows.Forms.Label LabelOrders;
        private System.Windows.Forms.Label label2;
        private projectDataSet projectDataSet;
        private System.Windows.Forms.BindingSource salariesBindingSource;
        private projectDataSetTableAdapters.SalariesTableAdapter salariesTableAdapter;
        private System.Windows.Forms.Label unavail;
        private System.Windows.Forms.Label Produc;
        private System.Windows.Forms.Label Unavailable;
        private System.Windows.Forms.Label Products;
        private System.Windows.Forms.Label firedtxt;
        private System.Windows.Forms.Label employeestxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Integration.ElementHost gauge;
        private LiveCharts.Wpf.Gauge gauge1;
        private System.Windows.Forms.Label label12;
    }
}