namespace AutoBackup
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StripItemAddWatch = new System.Windows.Forms.ToolStripMenuItem();
            this.StripItemRemoveWatch = new System.Windows.Forms.ToolStripMenuItem();
            this.StripItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.StripItemStopWatch = new System.Windows.Forms.ToolStripMenuItem();
            this.StripItemOpenBackupFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.StripItemReBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.dgrdTaskList = new System.Windows.Forms.DataGridView();
            this.watchingFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backupFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colIncludeSubdir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.watchStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chbAuto = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdTaskList)).BeginInit();
            this.NotifyIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripItemAddWatch,
            this.StripItemRemoveWatch,
            this.StripItemStart,
            this.StripItemStopWatch,
            this.StripItemOpenBackupFolder,
            this.StripItemReBackup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StripItemAddWatch
            // 
            this.StripItemAddWatch.Name = "StripItemAddWatch";
            this.StripItemAddWatch.Size = new System.Drawing.Size(68, 21);
            this.StripItemAddWatch.Text = "添加监视";
            this.StripItemAddWatch.Click += new System.EventHandler(this.AddWatchingDirectory);
            // 
            // StripItemRemoveWatch
            // 
            this.StripItemRemoveWatch.Name = "StripItemRemoveWatch";
            this.StripItemRemoveWatch.Size = new System.Drawing.Size(68, 21);
            this.StripItemRemoveWatch.Text = "删除监视";
            this.StripItemRemoveWatch.Click += new System.EventHandler(this.RemoveWatch);
            // 
            // StripItemStart
            // 
            this.StripItemStart.Name = "StripItemStart";
            this.StripItemStart.Size = new System.Drawing.Size(68, 21);
            this.StripItemStart.Text = "开始监视";
            this.StripItemStart.Click += new System.EventHandler(this.StartWatch);
            // 
            // StripItemStopWatch
            // 
            this.StripItemStopWatch.Name = "StripItemStopWatch";
            this.StripItemStopWatch.Size = new System.Drawing.Size(68, 21);
            this.StripItemStopWatch.Text = "停止监视";
            this.StripItemStopWatch.Click += new System.EventHandler(this.StopWatch);
            // 
            // StripItemOpenBackupFolder
            // 
            this.StripItemOpenBackupFolder.Name = "StripItemOpenBackupFolder";
            this.StripItemOpenBackupFolder.Size = new System.Drawing.Size(92, 21);
            this.StripItemOpenBackupFolder.Text = "打开备份目录";
            this.StripItemOpenBackupFolder.Click += new System.EventHandler(this.OpenBackupFolder);
            // 
            // StripItemReBackup
            // 
            this.StripItemReBackup.Name = "StripItemReBackup";
            this.StripItemReBackup.Size = new System.Drawing.Size(68, 21);
            this.StripItemReBackup.Text = "恢复文件";
            this.StripItemReBackup.Click += new System.EventHandler(this.Rebackup);
            // 
            // dgrdTaskList
            // 
            this.dgrdTaskList.AllowUserToAddRows = false;
            this.dgrdTaskList.AllowUserToDeleteRows = false;
            this.dgrdTaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdTaskList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.watchingFolder,
            this.backupFolder,
            this.colAction,
            this.colIncludeSubdir,
            this.watchStatus});
            this.dgrdTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdTaskList.Location = new System.Drawing.Point(0, 25);
            this.dgrdTaskList.MultiSelect = false;
            this.dgrdTaskList.Name = "dgrdTaskList";
            this.dgrdTaskList.RowTemplate.Height = 23;
            this.dgrdTaskList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdTaskList.Size = new System.Drawing.Size(603, 182);
            this.dgrdTaskList.TabIndex = 1;
            this.dgrdTaskList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgrdTaskList_EditingControlShowing);
            this.dgrdTaskList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdTaskList_CellContentClick);
            // 
            // watchingFolder
            // 
            this.watchingFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.watchingFolder.FillWeight = 149.2386F;
            this.watchingFolder.HeaderText = "监控目录";
            this.watchingFolder.Name = "watchingFolder";
            this.watchingFolder.ReadOnly = true;
            // 
            // backupFolder
            // 
            this.backupFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.backupFolder.HeaderText = "备份目录";
            this.backupFolder.Name = "backupFolder";
            this.backupFolder.ReadOnly = true;
            // 
            // colAction
            // 
            this.colAction.HeaderText = "变更类型";
            this.colAction.Name = "colAction";
            // 
            // colIncludeSubdir
            // 
            this.colIncludeSubdir.HeaderText = "包括子目录";
            this.colIncludeSubdir.Name = "colIncludeSubdir";
            this.colIncludeSubdir.Width = 80;
            // 
            // watchStatus
            // 
            this.watchStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.watchStatus.FillWeight = 50.76142F;
            this.watchStatus.HeaderText = "状态";
            this.watchStatus.Name = "watchStatus";
            this.watchStatus.ReadOnly = true;
            this.watchStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.NotifyIconContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "文件自动备份程序";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowWindow);
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.NotifyIconContextMenu.Name = "NotifyIconContextMenu";
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "退出程序";
            // 
            // chbAuto
            // 
            this.chbAuto.AccessibleDescription = "";
            this.chbAuto.AutoSize = true;
            this.chbAuto.Location = new System.Drawing.Point(444, 5);
            this.chbAuto.Name = "chbAuto";
            this.chbAuto.Size = new System.Drawing.Size(72, 16);
            this.chbAuto.TabIndex = 2;
            this.chbAuto.Text = "自动模式";
            this.chbAuto.UseVisualStyleBackColor = true;
            this.chbAuto.Click += new System.EventHandler(this.AutoMode);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 207);
            this.Controls.Add(this.chbAuto);
            this.Controls.Add(this.dgrdTaskList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件自动备份";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdTaskList)).EndInit();
            this.NotifyIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StripItemAddWatch;
        private System.Windows.Forms.ToolStripMenuItem StripItemStart;
        private System.Windows.Forms.DataGridView dgrdTaskList;
        private System.Windows.Forms.ToolStripMenuItem StripItemStopWatch;
        private System.Windows.Forms.ToolStripMenuItem StripItemRemoveWatch;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem StripItemOpenBackupFolder;
        private System.Windows.Forms.ToolStripMenuItem StripItemReBackup;
        private System.Windows.Forms.DataGridViewTextBoxColumn watchingFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn backupFolder;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAction;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIncludeSubdir;
        private System.Windows.Forms.DataGridViewTextBoxColumn watchStatus;
        private System.Windows.Forms.CheckBox chbAuto;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

