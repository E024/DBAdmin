namespace DBAdmin
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.dgvDate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDate
            // 
            this.dgvDate.AllowUserToAddRows = false;
            this.dgvDate.AllowUserToDeleteRows = false;
            this.dgvDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDate.Location = new System.Drawing.Point(0, 0);
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            this.dgvDate.RowTemplate.Height = 23;
            this.dgvDate.Size = new System.Drawing.Size(589, 442);
            this.dgvDate.TabIndex = 0;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 442);
            this.Controls.Add(this.dgvDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "View";
            this.ShowInTaskbar = false;
            this.Text = "MS-SQL数据库管理工具 --> 查询结果";
            this.Load += new System.EventHandler(this.View_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.View_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDate;
    }
}