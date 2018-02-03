using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBAdmin
{
    public partial class View : Form
    {
        public View(DataSet dss)
        {
            InitializeComponent();
            this.ds = dss;
        }
        public DataSet ds;
        public frmDBAdmin fdbadmin;
        public void View_Load(object sender, EventArgs e)
        {
            Fill(ds);
        }

        public void Fill(DataSet ds)
        {
            try
            {
                this.dgvDate.DataSource = ds.Tables[0];
            }
            catch (Exception em)
            {
                //MessageBox.Show(em.Message,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
        }

        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlHelper.isView = true;
            fdbadmin.ChangCkbView();
        }
        public void CloseMe()
        {
            this.Close();
        }
        public void HH()
        {
            MessageBox.Show("Test");
        }
    }
}
