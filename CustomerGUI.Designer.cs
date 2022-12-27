
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
            this.SearchGRD = new System.Windows.Forms.DataGridView();
            this.SearchTXT = new System.Windows.Forms.TextBox();
            this.SearchLBL = new System.Windows.Forms.Label();
            this.SearchBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SearchGRD)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchGRD
            // 
            this.SearchGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchGRD.Location = new System.Drawing.Point(12, 71);
            this.SearchGRD.Name = "SearchGRD";
            this.SearchGRD.Size = new System.Drawing.Size(663, 319);
            this.SearchGRD.TabIndex = 0;
            // 
            // SearchTXT
            // 
            this.SearchTXT.Location = new System.Drawing.Point(69, 30);
            this.SearchTXT.Name = "SearchTXT";
            this.SearchTXT.Size = new System.Drawing.Size(492, 20);
            this.SearchTXT.TabIndex = 1;
            // 
            // SearchLBL
            // 
            this.SearchLBL.AutoSize = true;
            this.SearchLBL.Location = new System.Drawing.Point(28, 33);
            this.SearchLBL.Name = "SearchLBL";
            this.SearchLBL.Size = new System.Drawing.Size(35, 13);
            this.SearchLBL.TabIndex = 2;
            this.SearchLBL.Text = "Name";
            // 
            // SearchBTN
            // 
            this.SearchBTN.Location = new System.Drawing.Point(567, 30);
            this.SearchBTN.Name = "SearchBTN";
            this.SearchBTN.Size = new System.Drawing.Size(75, 23);
            this.SearchBTN.TabIndex = 3;
            this.SearchBTN.Text = "Search";
            this.SearchBTN.UseVisualStyleBackColor = true;
            this.SearchBTN.Click += new System.EventHandler(this.SearchBTN_Click);
            // 
            // CustomerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 402);
            this.Controls.Add(this.SearchBTN);
            this.Controls.Add(this.SearchLBL);
            this.Controls.Add(this.SearchTXT);
            this.Controls.Add(this.SearchGRD);
            this.Name = "CustomerGUI";
            this.Text = "CustomerGUI";
            ((System.ComponentModel.ISupportInitialize)(this.SearchGRD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SearchGRD;
        private System.Windows.Forms.TextBox SearchTXT;
        private System.Windows.Forms.Label SearchLBL;
        private System.Windows.Forms.Button SearchBTN;
    }
}