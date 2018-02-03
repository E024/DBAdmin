/////////////////////////////////////////
/////使用事件加委托加以优化系统更佳！
/////20100401
////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace DBAdmin
{
    public partial class frmDBAdmin : Form
    {
        public frmDBAdmin()
        {
            InitializeComponent();
        }
        private string sqlconstr = "";
        public bool specialty = true;
        private void btnConn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtServerAddres.Text))
            {
                MessageBox.Show("服务器名不能为空", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txtDBLoginId.Enabled == true)
            {
                if (string.IsNullOrEmpty(this.txtDBLoginId.Text))
                {
                    MessageBox.Show("用户名不能为空", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //数据库服务器名或ip地址
            sqlconstr = "Data Source=" + this.txtServerAddres.Text + ";";
            //身份认证模式
            if (this.txtDBLoginId.Enabled == true)//sqlserver模式
            {
                sqlconstr += "UID=" + this.txtDBLoginId.Text + ";Password=" + this.txtDBPwd.Text + ";";
            }
            else//windows模式
            {
                sqlconstr += "Integrated Security=SSPI;";
            }
            SqlHelper.SQLCONSTR = sqlconstr;
            if (SqlHelper.Open(null) == true)
            {
                MessageBox.Show("连接成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnCloseDb.Enabled = true;
                CB_DBList.Enabled = true;
                this.btnRest.Enabled = true;
                this.btnAdd.Enabled = true;
                this.btnBackUp.Enabled = true;
                FillCB();
            }
            else
            {
                this.btnCloseDb.Enabled = false;
                CB_DBList.Enabled = false;
                this.btnRest.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnBackUp.Enabled = false;
                SqlHelper.SQLCONSTR = string.Empty;
                return;
            }
        }
        private DataSet ds;
        private View views;
        /// <summary>
        /// 将数据名填充下接列表
        /// </summary>
        private void FillCB()
        {
            DataSet ds = GetAllDatabase();
            //CB_DBList.d
            CB_DBList.DataSource = ds.Tables[0];
            CB_DBList.DisplayMember = "DATABASE_NAME";
        }
        /// <summary>
        /// 获得服务器所有数据库
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllDatabase()
        {
            DataSet ds = null;
            SqlHelper.RunProc("sp_databases", ref ds);
            return ds;
        }

        private void CB_userType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_userType.SelectedIndex == 0)
            {
                this.txtDBLoginId.Enabled = false;
            }
            else
            {
                this.txtDBLoginId.Enabled = true;
            }
        }

        private void CB_userType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.CB_userType.SelectedIndex == 0)
            {
                this.txtDBLoginId.Enabled = false;
                this.txtDBPwd.Enabled = false;
                this.txtServerAddres.Text = "localhost";
            }
            else
            {
                this.txtDBLoginId.Enabled = true;
                this.txtDBPwd.Enabled = true;
                this.txtServerAddres.Text = "127.0.0.1";
            }
        }

        private void frmDBAdmin_Load(object sender, EventArgs e)
        {
            //393,382
            if (specialty)
            {
                this.CB_userType.SelectedIndex = 0;
                CreateFile();
            }
            else
            {
                this.Width = 393;
                this.CB_userType.SelectedIndex = 0;
                CreateFile();
            }
            //if (!(File.Exists("InstallProcedure.cmd") && File.Exists("killspid.dat")))
            //{
            //    MessageBox.Show("系统文件被破坏，程序无法正常运行！请与作者联系！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Application.Exit();
            //}
            //StartSqlServer("net start mssqlserver");
            //string times = "数据库备份(" + DateTime.Today.Year + "年" + DateTime.Today.Month + "月" + DateTime.Today.Day + "日)";
            this.txtDBBackUpName.Text = "数据库备份(" + DateTime.Today.Year + "年" + DateTime.Today.Month + "月" + DateTime.Today.Day + "日)";
        }

        /// <summary>
        /// 附加数据库
        /// </summary>
        /// <param name="DbName"></param>
        /// <param name="path_Mdf"></param>
        /// <param name="path_Ldf"></param>
        /// <returns></returns>
        public bool AddDataBase(string DbName, string path_Mdf, string path_Ldf)
        {
            bool flag = false;
            try
            {
                SqlConnection connection = new SqlConnection(sqlconstr);
                connection.Open();
                new SqlCommand("IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + DbName + "')begin\tEXEC sp_detach_db " + DbName + " end  EXEC sp_attach_db @dbname = N'" + DbName + "',@filename1 = N'" + path_Mdf + "',@filename2 = N'" + path_Ldf + "'", connection).ExecuteNonQuery();
                connection.Close();
                flag = true;
            }
            catch
            {
                MessageBox.Show("附加数据库失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return flag;
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="doscmd"></param>
        private void StartSqlServer(string doscmd)
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName("sqlservr");
                int index = 0;
                while (index < processesByName.Length)
                {
                    Process process1 = processesByName[index];
                    return;
                }
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine(doscmd);
                process.StandardInput.WriteLine("exit");
                Thread.Sleep(0x4e20);
                processesByName = Process.GetProcessesByName("sqlservr");
                for (index = 0; index < processesByName.Length; index++)
                {
                    Process process2 = processesByName[index];
                }
            }
            catch
            {

                Process[] processesByName = Process.GetProcessesByName("mssql$sqlexpress");
                int index = 0;
                while (index < processesByName.Length)
                {
                    Process process1 = processesByName[index];
                    return;
                }
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine(doscmd);
                process.StandardInput.WriteLine("exit");
                Thread.Sleep(0x4e20);
                bool flag = true;
                processesByName = Process.GetProcessesByName("mssql$sqlexpress");
                for (index = 0; index < processesByName.Length; index++)
                {
                    Process process2 = processesByName[index];
                    flag = false;
                }
                if (flag)
                {
                    MessageBox.Show("无法启动SQL服务！，您确认您的电脑已经安装了MS-SQL?", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StartSQL(string cmddos)
        {
            ProcessStartInfo psi = new ProcessStartInfo("net ", " " + cmddos);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCMD.Text.Trim()))
            {
                if (this.radioButton2.Checked)
                {
                    if (this.txtCMD.Text.Trim().ToLower().Equals("cmd.exe") || this.txtCMD.Text.Trim().ToLower().Equals("cmd") || this.txtCMD.Text.Trim().ToLower().Equals("dos"))
                    {
                        ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                        psi.CreateNoWindow = false;
                        psi.UseShellExecute = true;
                        Process.Start(psi);

                    }
                    else if (this.txtCMD.Text.Trim().ToLower().Equals("exit"))
                    {
                        Application.Exit();
                    }
                    try
                    {
                        CMDDOS();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                }
                else
                {
                    if (this.txtCMD.Text.Trim().Length > 6)
                    {
                        if (!this.chkSelectRun.Checked)//选定执行(不执行选定)
                        {
                            try
                            {
                                string sql = "use " + this.CB_DBList.Text.Trim() + ";" + this.txtCMD.Text;
                                string temp = this.txtCMD.Text;
                                temp = temp.Substring(0, 6).ToLower();
                                if (temp.Equals("select") || this.txtCMD.Text.Substring(0, 4).ToLower().Equals("exec"))
                                {
                                    DataSet ds = new DataSet();
                                    SqlHelper.FillDataSet(sql, ds);
                                    this.dgvDate.DataSource = ds.Tables[0];
                                    this.ds = ds;
                                    if (this.ckbView.Checked)
                                    {
                                        views.Fill(ds);
                                    }
                                }
                                else
                                {
                                    SqlConnection conn = new SqlConnection(sqlconstr);
                                    conn.Open();
                                    int res = new SqlCommand(sql, conn).ExecuteNonQuery();
                                    conn.Close();
                                    if (res > 0)
                                    {
                                        MessageBox.Show("操作成功！\n" + res + "行受影响。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    else
                                    {
                                        MessageBox.Show("操作失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Equals("ConnectionString 属性尚未初始化。"))
                                {
                                    MessageBox.Show("请确保与服务器连接成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                return;
                            }
                        }
                        else//选定执行结束
                        {
                            try
                            {
                                string sql = "use " + this.CB_DBList.Text.Trim() + ";" + this.txtCMD.SelectedText;
                                string temp = this.txtCMD.Text;
                                temp = temp.Substring(0, 6).ToLower();
                                if (temp.Equals("select") || this.txtCMD.Text.Substring(0, 4).ToLower().Equals("exec"))
                                {
                                    DataSet ds = new DataSet();
                                    SqlHelper.FillDataSet(sql, ds);
                                    this.dgvDate.DataSource = ds.Tables[0];
                                    this.ds = ds;
                                    if (this.ckbView.Checked)
                                    {
                                        views.Fill(ds);
                                    }
                                    this.txtCMD.SelectAll();
                                }
                                else
                                {
                                    SqlConnection conn = new SqlConnection(sqlconstr);
                                    conn.Open();
                                    int res = new SqlCommand(sql, conn).ExecuteNonQuery();
                                    conn.Close();
                                    if (res > 0)
                                    {
                                        MessageBox.Show("操作成功！\n" + res + "行受影响。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    else
                                    {
                                        MessageBox.Show("操作失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Equals("ConnectionString 属性尚未初始化。"))
                                {
                                    MessageBox.Show("请确保与服务器连接成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (ex.Message.Equals("无法找到表 0。"))
                                {
                                    MessageBox.Show("您选择了“选择执行”，请选择命令文本后再执行！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtDBName.Text.Trim()))
            {
                bool isFile = false;
                string dbdate = "";
                string dblog = "";
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "请选择要附加数据主文件";
                ofd.Filter = "主数据文件|*.mdf";
                ofd.ShowDialog();
                if (!ofd.FileName.Equals(""))
                {
                    dbdate = ofd.FileName;
                    isFile = true;
                }
                if (isFile)
                {
                    OpenFileDialog ofds = new OpenFileDialog();
                    ofds.Title = "请选择要附加数据日志文件";
                    ofds.Filter = "日志文件|*.ldf";
                    ofds.ShowDialog();
                    if (!ofds.FileName.Equals(""))
                    {
                        dblog = ofds.FileName;
                    }
                }
                if (AddDataBase(this.txtDBName.Text.Trim(), dbdate, dblog))
                {
                    MessageBox.Show("附加成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillCB();

                }
            }
            else
            {
                MessageBox.Show("请先填写要附加的数据库名！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDBName.Focus();
                return;
            }
        }

        /// <summary>
        /// 分离
        /// </summary>
        /// <param name="DbName"></param>
        /// <returns></returns>
        public bool SeverDataBase(string DbName)
        {
            bool flag = false;
            try
            {
                SqlConnection connection = new SqlConnection(sqlconstr);
                connection.Open();
                new SqlCommand("EXEC sp_detach_db " + DbName, connection).ExecuteNonQuery();
                connection.Close();
                flag = true;
            }
            catch (Exception em)
            {
                MessageBox.Show("分离数据库失败" + em.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            return flag;
        }

        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="DBName"></param>
        /// <param name="BackupPath_name"></param>
        /// <returns></returns>
        public bool ReplaceDataBase(string DBName, string BackupPath_name)
        {
            bool flag = false;
            try
            {
                SqlConnection connection = new SqlConnection(sqlconstr);
                connection.Open();
                new SqlCommand("use master;restore database " + DBName + " From disk = '" + BackupPath_name + "' with replace;", connection).ExecuteNonQuery();
                connection.Close();
                flag = true;
            }
            catch (Exception em)
            {
                MessageBox.Show("还原数据库失败" + em.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            return flag;
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="DbName"></param>
        /// <param name="BackupPath_name"></param>
        /// <returns></returns>
        public bool BackupDataBase(string DbName, string BackupPath_name)
        {
            bool flag = false;
            try
            {
                SqlConnection connection = new SqlConnection(sqlconstr);
                connection.Open();
                new SqlCommand("use master;backup database " + DbName + " to disk = '" + BackupPath_name + "'", connection).ExecuteNonQuery();
                connection.Close();
                flag = true;
            }
            catch
            {
                MessageBox.Show("备份数据库失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            return flag;
        }

        /// <summary>
        /// 分离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseDb_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要对数据库  " + this.CB_DBList.Text + "  执行分离操作吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                string dbname = this.CB_DBList.Text.Trim();
                if (dbname.Equals("master") || dbname.Equals("model") || dbname.Equals("msdb") || dbname.Equals("tempdb"))
                {
                    MessageBox.Show("系统数据库不能分离！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (SeverDataBase(dbname))
                {
                    MessageBox.Show("分离成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillCB();
                }
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtDBBackUpName.Text.Trim()))
            {
                MessageBox.Show("请输入要备份数据库的名称！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择要备份数据库的地址";
            fbd.ShowNewFolderButton = true;
            fbd.ShowDialog(this);
            string parth = fbd.SelectedPath;
            if (string.IsNullOrEmpty(parth))//用户取消
            {
                return;
            }
            parth += "\\" + this.txtDBBackUpName.Text + ".dat";
            if (BackupDataBase(this.CB_DBList.Text.Trim(), parth))
            {
                MessageBox.Show("备份成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要对数据库  " + this.CB_DBList.Text + "  执行还原操作吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                //try
                //{
                //Process p = new Process();
                //p.StartInfo.FileName = Application.StartupPath + @"\InstallProcedure.cmd";
                //p.Start();
                //p.Dispose();
                //p.Close();
                //SqlConnection connection = new SqlConnection(sqlconstr);
                //connection.Open();
                //new SqlCommand("exec killspid");
                //connection.Close();
                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Title = "选择还原文件";
                //ofd.Filter = "备份文件|*.dat";
                //ofd.ShowDialog();
                //if (ofd.SafeFileName.Equals(""))
                //{
                //    return;
                //}
                //if (ReplaceDataBase(this.CB_DBList.Text.Trim(), ofd.FileName))
                //{
                //    MessageBox.Show("还原成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

              
                Process p = new Process();
                p.StartInfo.FileName = Application.StartupPath + @"\InstallProcedure.cmd";
                p.Start();
                SqlConnection connection = new SqlConnection(sqlconstr);
                connection.Open();
                new SqlCommand("exec killspid");
                connection.Close();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "选择还原文件";
                ofd.Filter = "备份文件|*.dat";
                ofd.ShowDialog();
                if (ofd.SafeFileName.Equals(""))
                {
                    return;
                }
                if (ReplaceDataBase(this.CB_DBList.Text.Trim(), ofd.FileName))
                {
                    MessageBox.Show("还原成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //finally
                //{
   
                //}
            }
        }


        /// <summary>
        /// 创建系统所须文件
        /// </summary>
        private static void CreateFile()
        {
            string dat = DBAdmin.Properties.Resources.aa1;
            using (FileStream fs = new FileStream(Application.StartupPath + @"\xy.sql", FileMode.Create))
            {

            }
            using (StreamWriter sw = new StreamWriter("xy.sql"))
            {
                sw.Write(dat);
            }
            string bat = DBAdmin.Properties.Resources.aa;
            using (FileStream fs = new FileStream(Application.StartupPath + @"\InstallProcedure.cmd", FileMode.Create))
            {

            }
            using (StreamWriter sw = new StreamWriter("InstallProcedure.cmd"))
            {
                sw.Write(bat);
            }
        }
        //public static bool FilePicDelete(string path)
        //{
        //    bool ret = false; System.IO.FileInfo file = new System.IO.FileInfo(path); if (file.Exists)//文件是否存在，存在则执行删除 
        //    { file.Delete(); ret = true; } return ret;
        //}
        private void CMDDOS()
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c " + this.txtCMD.Text);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog(this);
        }

        private void 退出EToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //鼠标双击事件
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        #region 右键
        private void 粘贴VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtCMD.Paste();
        }

        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtCMD.Copy();
        }

        private void 剪切XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtCMD.Cut();
        }

        private void 撤消ZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtCMD.Undo();
        }

        private void 还原YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtCMD.Redo();
        }

        private void 执行RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOk_Click(sender, e);
        }
        private void 全选AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtCMD.SelectAll();
        }

        private void 清空LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtCMD.Clear();
        }
        #endregion
        #region 自定义功能键
        /// <summary>
        /// 自定义快捷功能键
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref   Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnOk_Click(null, null);
            }
            else if (keyData == Keys.F1)
            {
                this.txtCMD.Text = "exec sp_tables";
                this.radioButton1.Checked = true;
                this.txtCMD.Focus();
                this.txtCMD.SelectAll();
            }
            else if (keyData == Keys.F2)
            {
                this.txtCMD.Text = "select * from ";
                this.radioButton1.Checked = true;
                this.txtCMD.Focus();
                this.txtCMD.SelectAll();
            }
            else if (keyData == Keys.F3)
            {
                this.txtCMD.Text = "delete ";
                this.radioButton1.Checked = true;
                this.txtCMD.Focus();
                this.txtCMD.SelectAll();
            }
            else if (keyData == Keys.F4)
            {
                this.txtCMD.Text = "insert into [tableName] values( ";
                this.radioButton1.Checked = true;
                this.txtCMD.Focus();
                this.txtCMD.SelectAll();
            }
            else if (keyData == Keys.F6)
            {
                this.txtCMD.Text = "net start mssqlserver";
                this.radioButton2.Checked = true;
                this.txtCMD.Focus();
                this.txtCMD.SelectAll();
            }
            else if (keyData == Keys.F7)
            {
                this.txtCMD.Text = "net start mssql$sqlexpress";
                this.txtCMD.Focus();
                this.radioButton2.Checked = true;
                this.txtCMD.SelectAll();
            }
            return base.ProcessCmdKey(ref   msg, keyData);
        }

        #endregion

        private void ckbView_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbView.Checked && SqlHelper.isView)
            {
                View view = new View(this.ds);
                SqlHelper.isView = false;
                this.views = view;
                view.fdbadmin = this;
                this.dgvDate.Visible = false;
                this.pnlView.Visible = true;
                view.Show();
            }
            else
            {
                views.CloseMe();
                this.dgvDate.Visible = true;
                this.pnlView.Visible = false;
            }
        }
        public void ChangCkbView()
        {
            this.ckbView.Checked = false;
        }

        private void 将SQL命令另存为SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt|SQL命令文件|*.sql";
            sfd.FileName = "*.txt";
            sfd.ShowDialog(this);
            if (sfd.FileName.Length > 5)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    this.txtCMD.SaveFile(fs, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (this.txtCMD.Text.Trim().Equals(""))
            {
                将命令另存为SToolStripMenuItem.Enabled = false;
            }
            else
            {
                将命令另存为SToolStripMenuItem.Enabled = true;
            }
        }

        private void frmDBAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(Application.StartupPath + "\\InstallProcedure.cmd"); if (file.Exists) { file.Delete(); }
            System.IO.FileInfo files = new System.IO.FileInfo(Application.StartupPath + "\\xy.sql"); if (files.Exists) { files.Delete(); }
        }

    }
}
