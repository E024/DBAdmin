namespace DBAdmin
{
    partial class frmDBAdmin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBAdmin));
            this.CB_userType = new System.Windows.Forms.ComboBox();
            this.txtDBPwd = new System.Windows.Forms.TextBox();
            this.txtDBLoginId = new System.Windows.Forms.TextBox();
            this.txtServerAddres = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCloseDb = new System.Windows.Forms.Button();
            this.btnRest = new System.Windows.Forms.Button();
            this.CB_DBList = new System.Windows.Forms.ComboBox();
            this.btnConn = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.dgvDate = new System.Windows.Forms.DataGridView();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBBackUpName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCMD = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.执行RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.粘贴VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.撤消ZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还原YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.将命令另存为SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用手册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnlView = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbView = new System.Windows.Forms.CheckBox();
            this.chkSelectRun = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlView.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(41, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 12);
            label1.TabIndex = 31;
            label1.Text = "身份认证";
            // 
            // CB_userType
            // 
            this.CB_userType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_userType.FormattingEnabled = true;
            this.CB_userType.Items.AddRange(new object[] {
            "Windows 身份认证",
            "SQL Server 身份认证"});
            this.CB_userType.Location = new System.Drawing.Point(100, 20);
            this.CB_userType.Name = "CB_userType";
            this.CB_userType.Size = new System.Drawing.Size(232, 20);
            this.CB_userType.TabIndex = 0;
            this.CB_userType.SelectedIndexChanged += new System.EventHandler(this.CB_userType_SelectedIndexChanged_1);
            // 
            // txtDBPwd
            // 
            this.txtDBPwd.Location = new System.Drawing.Point(100, 100);
            this.txtDBPwd.Name = "txtDBPwd";
            this.txtDBPwd.PasswordChar = '*';
            this.txtDBPwd.Size = new System.Drawing.Size(232, 21);
            this.txtDBPwd.TabIndex = 3;
            // 
            // txtDBLoginId
            // 
            this.txtDBLoginId.Location = new System.Drawing.Point(100, 73);
            this.txtDBLoginId.Name = "txtDBLoginId";
            this.txtDBLoginId.Size = new System.Drawing.Size(232, 21);
            this.txtDBLoginId.TabIndex = 2;
            this.txtDBLoginId.Text = "sa";
            // 
            // txtServerAddres
            // 
            this.txtServerAddres.Location = new System.Drawing.Point(100, 46);
            this.txtServerAddres.Name = "txtServerAddres";
            this.txtServerAddres.Size = new System.Drawing.Size(232, 21);
            this.txtServerAddres.TabIndex = 1;
            this.txtServerAddres.Text = "127.0.0.1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "服务器地址";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "密码";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "用户名";
            // 
            // btnBackUp
            // 
            this.btnBackUp.Enabled = false;
            this.btnBackUp.Location = new System.Drawing.Point(257, 18);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(75, 23);
            this.btnBackUp.TabIndex = 11;
            this.btnBackUp.Text = "备份 &B";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(257, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "附加 &A";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCloseDb
            // 
            this.btnCloseDb.Enabled = false;
            this.btnCloseDb.Location = new System.Drawing.Point(236, 153);
            this.btnCloseDb.Name = "btnCloseDb";
            this.btnCloseDb.Size = new System.Drawing.Size(75, 23);
            this.btnCloseDb.TabIndex = 7;
            this.btnCloseDb.Text = "分离 &S";
            this.btnCloseDb.UseVisualStyleBackColor = true;
            this.btnCloseDb.Click += new System.EventHandler(this.btnCloseDb_Click);
            // 
            // btnRest
            // 
            this.btnRest.Enabled = false;
            this.btnRest.Location = new System.Drawing.Point(147, 153);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(75, 23);
            this.btnRest.TabIndex = 6;
            this.btnRest.Text = "还原 &R";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // CB_DBList
            // 
            this.CB_DBList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DBList.Enabled = false;
            this.CB_DBList.FormattingEnabled = true;
            this.CB_DBList.Location = new System.Drawing.Point(100, 127);
            this.CB_DBList.Name = "CB_DBList";
            this.CB_DBList.Size = new System.Drawing.Size(232, 20);
            this.CB_DBList.TabIndex = 4;
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(58, 153);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 5;
            this.btnConn.Text = "连接 &C";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(203, 153);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "执行 &F5";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(84, 155);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 16);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "&T-SQL";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(143, 156);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.Text = "&MS-DOS";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // dgvDate
            // 
            this.dgvDate.AllowUserToAddRows = false;
            this.dgvDate.AllowUserToDeleteRows = false;
            this.dgvDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDate.Location = new System.Drawing.Point(6, 186);
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            this.dgvDate.RowTemplate.Height = 23;
            this.dgvDate.Size = new System.Drawing.Size(360, 120);
            this.dgvDate.TabIndex = 17;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(100, 22);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(141, 21);
            this.txtDBName.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtServerAddres);
            this.groupBox1.Controls.Add(this.btnCloseDb);
            this.groupBox1.Controls.Add(this.txtDBLoginId);
            this.groupBox1.Controls.Add(this.btnRest);
            this.groupBox1.Controls.Add(this.txtDBPwd);
            this.groupBox1.Controls.Add(this.btnConn);
            this.groupBox1.Controls.Add(this.CB_userType);
            this.groupBox1.Controls.Add(this.CB_DBList);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 189);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "数据库";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDBName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 56);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "数据库名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "数据库备份名";
            // 
            // txtDBBackUpName
            // 
            this.txtDBBackUpName.Location = new System.Drawing.Point(100, 20);
            this.txtDBBackUpName.Name = "txtDBBackUpName";
            this.txtDBBackUpName.Size = new System.Drawing.Size(141, 21);
            this.txtDBBackUpName.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtDBBackUpName);
            this.groupBox3.Controls.Add(this.btnBackUp);
            this.groupBox3.Location = new System.Drawing.Point(12, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 55);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            // 
            // txtCMD
            // 
            this.txtCMD.ContextMenuStrip = this.contextMenuStrip2;
            this.txtCMD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCMD.HideSelection = false;
            this.txtCMD.Location = new System.Drawing.Point(6, 20);
            this.txtCMD.Name = "txtCMD";
            this.txtCMD.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtCMD.Size = new System.Drawing.Size(360, 127);
            this.txtCMD.TabIndex = 12;
            this.txtCMD.Text = "";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.执行RToolStripMenuItem,
            this.toolStripSeparator2,
            this.粘贴VToolStripMenuItem,
            this.复制CToolStripMenuItem,
            this.剪切XToolStripMenuItem,
            this.全选AToolStripMenuItem,
            this.清空LToolStripMenuItem,
            this.toolStripSeparator1,
            this.撤消ZToolStripMenuItem,
            this.还原YToolStripMenuItem,
            this.toolStripSeparator3,
            this.将命令另存为SToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(161, 220);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // 执行RToolStripMenuItem
            // 
            this.执行RToolStripMenuItem.Name = "执行RToolStripMenuItem";
            this.执行RToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.执行RToolStripMenuItem.Text = "执行(&R)";
            this.执行RToolStripMenuItem.Click += new System.EventHandler(this.执行RToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // 粘贴VToolStripMenuItem
            // 
            this.粘贴VToolStripMenuItem.Name = "粘贴VToolStripMenuItem";
            this.粘贴VToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.粘贴VToolStripMenuItem.Text = "粘贴(&V)";
            this.粘贴VToolStripMenuItem.Click += new System.EventHandler(this.粘贴VToolStripMenuItem_Click);
            // 
            // 复制CToolStripMenuItem
            // 
            this.复制CToolStripMenuItem.Name = "复制CToolStripMenuItem";
            this.复制CToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.复制CToolStripMenuItem.Text = "复制(&C)";
            this.复制CToolStripMenuItem.Click += new System.EventHandler(this.复制CToolStripMenuItem_Click);
            // 
            // 剪切XToolStripMenuItem
            // 
            this.剪切XToolStripMenuItem.Name = "剪切XToolStripMenuItem";
            this.剪切XToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.剪切XToolStripMenuItem.Text = "剪切(&X)";
            this.剪切XToolStripMenuItem.Click += new System.EventHandler(this.剪切XToolStripMenuItem_Click);
            // 
            // 全选AToolStripMenuItem
            // 
            this.全选AToolStripMenuItem.Name = "全选AToolStripMenuItem";
            this.全选AToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.全选AToolStripMenuItem.Text = "全选(&A)";
            this.全选AToolStripMenuItem.Click += new System.EventHandler(this.全选AToolStripMenuItem_Click);
            // 
            // 清空LToolStripMenuItem
            // 
            this.清空LToolStripMenuItem.Name = "清空LToolStripMenuItem";
            this.清空LToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.清空LToolStripMenuItem.Text = "清空(&L)";
            this.清空LToolStripMenuItem.Click += new System.EventHandler(this.清空LToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 撤消ZToolStripMenuItem
            // 
            this.撤消ZToolStripMenuItem.Name = "撤消ZToolStripMenuItem";
            this.撤消ZToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.撤消ZToolStripMenuItem.Text = "撤消(&Z)";
            this.撤消ZToolStripMenuItem.Click += new System.EventHandler(this.撤消ZToolStripMenuItem_Click);
            // 
            // 还原YToolStripMenuItem
            // 
            this.还原YToolStripMenuItem.Name = "还原YToolStripMenuItem";
            this.还原YToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.还原YToolStripMenuItem.Text = "还原(&Y)";
            this.还原YToolStripMenuItem.Click += new System.EventHandler(this.还原YToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // 将命令另存为SToolStripMenuItem
            // 
            this.将命令另存为SToolStripMenuItem.Name = "将命令另存为SToolStripMenuItem";
            this.将命令另存为SToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.将命令另存为SToolStripMenuItem.Text = "将命令另存为(&S)";
            this.将命令另存为SToolStripMenuItem.Click += new System.EventHandler(this.将SQL命令另存为SToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.导出ToolStripMenuItem.Text = "退出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.文件ToolStripMenuItem.Text = "文件&F";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出EToolStripMenuItem.Text = "退出&E";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem,
            this.使用手册ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.关于ToolStripMenuItem.Text = "帮助&H";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于我们ToolStripMenuItem.Text = "关于我们&A";
            this.关于我们ToolStripMenuItem.Click += new System.EventHandler(this.关于我们ToolStripMenuItem_Click);
            // 
            // 使用手册ToolStripMenuItem
            // 
            this.使用手册ToolStripMenuItem.Name = "使用手册ToolStripMenuItem";
            this.使用手册ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.使用手册ToolStripMenuItem.Text = "使用手册&S";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 24);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem1});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.文件FToolStripMenuItem.Text = "文件&F";
            // 
            // 退出EToolStripMenuItem1
            // 
            this.退出EToolStripMenuItem1.Name = "退出EToolStripMenuItem1";
            this.退出EToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.退出EToolStripMenuItem1.Text = "退出&E";
            this.退出EToolStripMenuItem1.Click += new System.EventHandler(this.退出EToolStripMenuItem1_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.帮助HToolStripMenuItem.Text = "帮助&H";
            this.帮助HToolStripMenuItem.Click += new System.EventHandler(this.帮助HToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "数据库管理工具";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnlView);
            this.groupBox4.Controls.Add(this.ckbView);
            this.groupBox4.Controls.Add(this.chkSelectRun);
            this.groupBox4.Controls.Add(this.txtCMD);
            this.groupBox4.Controls.Add(this.dgvDate);
            this.groupBox4.Controls.Add(this.btnOk);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Location = new System.Drawing.Point(386, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(372, 312);
            this.groupBox4.TabIndex = 50;
            this.groupBox4.TabStop = false;
            // 
            // pnlView
            // 
            this.pnlView.Controls.Add(this.groupBox5);
            this.pnlView.Location = new System.Drawing.Point(6, 186);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(360, 125);
            this.pnlView.TabIndex = 19;
            this.pnlView.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(3, -2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(354, 119);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(116, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "预览中。。。";
            // 
            // ckbView
            // 
            this.ckbView.AutoSize = true;
            this.ckbView.Location = new System.Drawing.Point(288, 157);
            this.ckbView.Name = "ckbView";
            this.ckbView.Size = new System.Drawing.Size(78, 16);
            this.ckbView.TabIndex = 18;
            this.ckbView.Text = "&V启用预览";
            this.ckbView.UseVisualStyleBackColor = true;
            this.ckbView.CheckedChanged += new System.EventHandler(this.ckbView_CheckedChanged);
            // 
            // chkSelectRun
            // 
            this.chkSelectRun.AutoSize = true;
            this.chkSelectRun.Location = new System.Drawing.Point(6, 156);
            this.chkSelectRun.Name = "chkSelectRun";
            this.chkSelectRun.Size = new System.Drawing.Size(72, 16);
            this.chkSelectRun.TabIndex = 13;
            this.chkSelectRun.Text = "选定执行";
            this.chkSelectRun.UseVisualStyleBackColor = true;
            // 
            // frmDBAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(770, 350);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmDBAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS-SQL数据库管理工具";
            this.Load += new System.EventHandler(this.frmDBAdmin_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDBAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.pnlView.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_userType;
        private System.Windows.Forms.TextBox txtDBPwd;
        private System.Windows.Forms.TextBox txtDBLoginId;
        private System.Windows.Forms.TextBox txtServerAddres;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCloseDb;
        private System.Windows.Forms.Button btnRest;
        private System.Windows.Forms.ComboBox CB_DBList;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DataGridView dgvDate;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDBBackUpName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtCMD;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用手册ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 粘贴VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤消ZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还原YToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox chkSelectRun;
        private System.Windows.Forms.ToolStripMenuItem 执行RToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 全选AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空LToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckbView;
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem 将命令另存为SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

