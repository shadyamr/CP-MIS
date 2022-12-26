
namespace projectMIS
{
    partial class AdminCP
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.projectDataSet = new projectMIS.projectDataSet();
            this.auditsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.auditsTableAdapter = new projectMIS.projectDataSetTableAdapters.AuditsTableAdapter();
            this.auditIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionMadeOnIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionMakerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 434);
            this.panel1.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.auditIDDataGridViewTextBoxColumn,
            this.actionMadeOnIDDataGridViewTextBoxColumn,
            this.actionMakerIDDataGridViewTextBoxColumn,
            this.actionDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.actionDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.auditsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(226, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(642, 422);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // projectDataSet
            // 
            this.projectDataSet.DataSetName = "projectDataSet";
            this.projectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // auditsBindingSource
            // 
            this.auditsBindingSource.DataMember = "Audits";
            this.auditsBindingSource.DataSource = this.projectDataSet;
            // 
            // auditsTableAdapter
            // 
            this.auditsTableAdapter.ClearBeforeFill = true;
            // 
            // auditIDDataGridViewTextBoxColumn
            // 
            this.auditIDDataGridViewTextBoxColumn.DataPropertyName = "Audit_ID";
            this.auditIDDataGridViewTextBoxColumn.HeaderText = "Audit_ID";
            this.auditIDDataGridViewTextBoxColumn.Name = "auditIDDataGridViewTextBoxColumn";
            this.auditIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actionMadeOnIDDataGridViewTextBoxColumn
            // 
            this.actionMadeOnIDDataGridViewTextBoxColumn.DataPropertyName = "Action_Made_On_ID";
            this.actionMadeOnIDDataGridViewTextBoxColumn.HeaderText = "Action_Made_On_ID";
            this.actionMadeOnIDDataGridViewTextBoxColumn.Name = "actionMadeOnIDDataGridViewTextBoxColumn";
            // 
            // actionMakerIDDataGridViewTextBoxColumn
            // 
            this.actionMakerIDDataGridViewTextBoxColumn.DataPropertyName = "Action_Maker_ID";
            this.actionMakerIDDataGridViewTextBoxColumn.HeaderText = "Action_Maker_ID";
            this.actionMakerIDDataGridViewTextBoxColumn.Name = "actionMakerIDDataGridViewTextBoxColumn";
            // 
            // actionDataGridViewTextBoxColumn
            // 
            this.actionDataGridViewTextBoxColumn.DataPropertyName = "Action";
            this.actionDataGridViewTextBoxColumn.HeaderText = "Action";
            this.actionDataGridViewTextBoxColumn.Name = "actionDataGridViewTextBoxColumn";
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            // 
            // actionDateDataGridViewTextBoxColumn
            // 
            this.actionDateDataGridViewTextBoxColumn.DataPropertyName = "Action_Date";
            this.actionDateDataGridViewTextBoxColumn.HeaderText = "Action_Date";
            this.actionDateDataGridViewTextBoxColumn.Name = "actionDateDataGridViewTextBoxColumn";
            // 
            // AdminCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 434);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "AdminCP";
            this.Text = "Admin Control Panel";
            this.Load += new System.EventHandler(this.AdminCP_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private projectDataSet projectDataSet;
        private System.Windows.Forms.BindingSource auditsBindingSource;
        private projectDataSetTableAdapters.AuditsTableAdapter auditsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionMadeOnIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionMakerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionDateDataGridViewTextBoxColumn;
    }
}