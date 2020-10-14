using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AutoBackup.Core;
using AutoBackup.Serialization;
using Microsoft.Win32;

namespace AutoBackup
{
    public partial class MainForm : Form
    {
        private List<XWXFileSystemWatcher> watcherList;//用户保存程序运行期间的监视项
        FolderBrowserDialog FBD;
        IRecord recorder=null;
        int _selectedRowIndex = -1;
        SerializationHandler serializationHandler;
        AutoModeHandler autoMode;
        const int IDX_WATCHINGDIR   = 0;//监视目录列索引号
        const int IDX_BACKUPDIR     = 1;//备份目录列索引号
        const int IDX_CHANGETYPE    = 2;//变更类型列索引号
        const int IDX_SUBDIR        = 3;//是否包含子目录列索引号
        const int IDX_STATUS        = 4;//监视状态列索引号
        public MainForm(string arg)
        {
            InitializeComponent();
          

            watcherList = new List<XWXFileSystemWatcher>();
            serializationHandler = new SerializationHandler();
            FBD = new FolderBrowserDialog();
            recorder = ModuleFactory.GetRecordModule();
            autoMode = new AutoModeHandler();
            this.NotifyIconContextMenu.Items[0].Click   += delegate { System.Environment.Exit(0); };//点击小图标退出按钮退出应用程序
            this.FormClosing                            += new FormClosingEventHandler(MainForm_FormClosing);
            this.OnWatchSettingChanged                  += new SettingChangedHandler(HandleWatchSettingChanged);
            if (arg == "-automode")//如果包含-autoload参数，则自动加载之前的监视项记录
            {
                LoadWatches();
                this.WindowState = FormWindowState.Minimized;//自动模式下最小化
            }
            toolTip1.SetToolTip(chbAuto, "开机自动运行并恢复以往监视记录");
            chbAuto.Checked = autoMode.IsAutoModeON;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 600000;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        bool filedelete = false;
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (filedelete)
            {
                return;
            }
            filedelete = true;
            foreach (var item in watcherList)
            {
                GetAllFiles(item.BackupFolder); 
            }
            filedelete = false;
        }
       
        void GetAllFiles(string fileinfo)
        {
           
            try { 
            if (Directory.Exists(fileinfo))
            {
                foreach (var path in Directory.GetFileSystemEntries(fileinfo))
                {
                    if (Directory.Exists(path))
                    {
                         GetAllFiles(path);
                    }
                    else
                    {
                        if(new TimeSpan(DateTime.Now.Ticks- File.GetLastWriteTime(path).Ticks).TotalHours >= 24)
                        {
                                deleteFile(path);
                        }
                    }
                }
            }
            else
            {
                    deleteFile(fileinfo);
            }
            }
            catch
            {

            }
            
        }
        void deleteFile(string filePath)
        { 
            if (File.Exists(filePath))
            {
                try
                { 
                    File.Delete(filePath);
                }
                catch
                {

                }
            }
        }
        

        //加载监视项记录
        private void LoadWatches()
        {
            List<WatchInfo> watches = serializationHandler.Deserialize();
            if (watches != null)
            {
                foreach (WatchInfo w in watches)
                {
                    AddWatchItem(w);
                }
            }
        }
        //从一个WatchInfo载入一个监视项到界面中，并重现该WatchInfo的信息
        private void AddWatchItem(WatchInfo watch)
        {
            XWXFileSystemWatcher watcher = new XWXFileSystemWatcher(watch.WatchedFolder);
            watcher.BackupFolder = watch.BackupFolder;
            watcher.NotifyFilter =  NotifyFilters.Security
                                  | NotifyFilters.LastWrite
                                  | NotifyFilters.FileName
                                  | NotifyFilters.DirectoryName
                                  | NotifyFilters.Size
                                  | NotifyFilters.Attributes|NotifyFilters.CreationTime;
            
            watcher.OnWatchStatusChanged += new WatchStatusChangedHandler(watcher_OnWatchStatusChanged);

            //目前版本不监视删除和重命名操作
            //watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
            //watcher.Renamed += new RenamedEventHandler(watcher_Renamed); 
            if ((watch.ChangeTypes & WatcherChangeTypes.Renamed) == WatcherChangeTypes.Renamed)
            {
                watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
                watcher.WatchingChangeTypes = (watcher.WatchingChangeTypes | WatcherChangeTypes.Renamed);
            }
            if ((watch.ChangeTypes & WatcherChangeTypes.Created) == WatcherChangeTypes.Created)
            {
                watcher.Created += new FileSystemEventHandler(watcher_Created);
                watcher.WatchingChangeTypes = (watcher.WatchingChangeTypes | WatcherChangeTypes.Created);
            }
            if ((watch.ChangeTypes & WatcherChangeTypes.Changed) == WatcherChangeTypes.Changed)
            {
                watcher.Changed += new FileSystemEventHandler(watcher_Changed);
                watcher.WatchingChangeTypes = (watcher.WatchingChangeTypes | WatcherChangeTypes.Changed);
            }

            int rowIndex = dgrdTaskList.Rows.Add();
            dgrdTaskList.Rows[rowIndex].Cells[IDX_WATCHINGDIR].Value = watcher.Path;
            dgrdTaskList.Rows[rowIndex].Cells[IDX_BACKUPDIR].Value = watcher.BackupFolder;
            dgrdTaskList.Rows[rowIndex].Cells[IDX_STATUS].Value = GetWatchingStatusName(watcher.EnableRaisingEvents);
            dgrdTaskList.Rows[rowIndex].Tag = watcher;

            DataGridViewComboBoxCell cell = dgrdTaskList[IDX_CHANGETYPE, rowIndex] as DataGridViewComboBoxCell;
            cell.Items.Add("创建、修改及重命名");
            cell.Items.Add("仅创建");
            cell.Items.Add("仅修改");
            cell.Items.Add("仅重命名");
            if (watch.ChangeTypes == WatcherChangeTypes.Changed)
                cell.Value = "仅修改";
            else if (watch.ChangeTypes == WatcherChangeTypes.Created)
                cell.Value = "仅创建";
            else if (watch.ChangeTypes == WatcherChangeTypes.Renamed)
                cell.Value = "仅重命名";
            else
                cell.Value = "创建、修改及重命名";
            cell.ReadOnly = !watch.Enable;

            DataGridViewCheckBoxCell checkbox = dgrdTaskList.Rows[rowIndex].Cells[IDX_SUBDIR] as DataGridViewCheckBoxCell;
            if (checkbox != null)
                checkbox.Value = watch.IncludeSubdirectories;
            dgrdTaskList.Rows[rowIndex].Cells[IDX_SUBDIR].ReadOnly = !watch.Enable;
            
            if (watch.Enable)
                watcher.StartWatch();
            else
                watcher.StopWatch();

            //同时将该监视项添加到watcherList中
            watcherList.Add(watcher);
        }

        //添加对一个目录的监视
        private void AddWatchingDirectory(object sender, EventArgs e)
        {
            string watchedName=string.Empty; 
            string watchedFolder; 
            string backupFolder; 
            WatcherChangeTypes changeTypes; 
            bool enable;

            FBD.Description = "请选择需要进行监视的文件夹";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                //如果该目录已经存在于监视列表，则不再重新添加
                if (watcherList.Find(w => w.Path == FBD.SelectedPath) != null)
                {
                    MessageBox.Show("该目录已经于监视目录列表中");
                    return;
                }
                watchedFolder = FBD.SelectedPath;
                backupFolder = SelectBackupFloder(watchedFolder);
                if (!string.IsNullOrEmpty(backupFolder))
                {
                    changeTypes = (WatcherChangeTypes.Changed | WatcherChangeTypes.Created|WatcherChangeTypes.Renamed);
                    enable = false;
                    WatchInfo watch = new WatchInfo();
                    watch.BackupFolder = backupFolder;
                    watch.ChangeTypes = changeTypes;
                    watch.Enable = enable;
                    watch.WatchedFolder = watchedFolder;
                    AddWatchItem(watch);
                    //添加一个监视项后触发OnWatchSettingChanged事件以便进行实时保存
                    this.OnWatchSettingChanged();
                }
            }
        }

        //当监视状态发送变化
        void watcher_OnWatchStatusChanged(object sender, WatchStatusChangedEventArgs e)
        {
            XWXFileSystemWatcher watcher = sender as XWXFileSystemWatcher;
            foreach (DataGridViewRow row in dgrdTaskList.Rows)
            {
                if (((XWXFileSystemWatcher)row.Tag) == watcher)
                {
                    //改变列表上该监视的状态文字
                    row.Cells[IDX_STATUS].Value = GetWatchingStatusName(e.IsWatching);
                    break;
                }
            }
        }

        private string SelectBackupFloder(string watchedFolder)
        {
            FBD.Description = "请选择备份文件夹";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                //备份目录不能是一个被监视的目录，否则会出现循环备份文件
                foreach (XWXFileSystemWatcher w in watcherList)
                {
                    //例如:备份目录是c:\b\d,监视目录是c:\b
                    if (FBD.SelectedPath.Contains(w.Path) || FBD.SelectedPath.Contains(watchedFolder))
                    {
                        MessageBox.Show(string.Format("该目录({0})已经被监视，不能作为备份目录", FBD.SelectedPath));
                        return SelectBackupFloder(watchedFolder);
                    }
                }
                return FBD.SelectedPath;
            }
            else
            {
                return null;
            }
        }

        //当监视的文件或者目录被更改时
        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            XWXFileSystemWatcher watcher = sender as XWXFileSystemWatcher;
            BackupHelper.Backup(watcher, e, recorder);
        }

        //当监视的文件或者目录被创建时
        void watcher_Created(object sender, FileSystemEventArgs e)
        {
            XWXFileSystemWatcher watcher = sender as XWXFileSystemWatcher;
            BackupHelper.Backup(watcher, e, recorder);
        }
        void watcher_Renamed(object sender, RenamedEventArgs e)
        { 
            XWXFileSystemWatcher watcher = sender as XWXFileSystemWatcher; 
            BackupHelper.Backup(watcher, e, recorder);
        }


        //开始一个监视
        public void StartWatch(object sender, EventArgs e)
        {
            XWXFileSystemWatcher watcher = GetSelectedWatcher(true, "请选择需要开始的监视项");
            if (watcher != null)
            {
                watcher.StartWatch();
                //开始监视后，将监视动作设置为可编辑
                dgrdTaskList.SelectedRows[0].Cells[IDX_CHANGETYPE].ReadOnly = false;
                dgrdTaskList.SelectedRows[0].Cells[IDX_SUBDIR].ReadOnly = false;
                //当开始一个监视后触发OnWatchSettingChanged事件以便进行实时保存
                this.OnWatchSettingChanged();
            }
        }
        //停止一个监视
        private void StopWatch(object sender, EventArgs e)
        {
            XWXFileSystemWatcher watcher = GetSelectedWatcher(true, "请选择需要停止的监视项");
            if (watcher != null)
            {
                watcher.StopWatch();
                //一旦停止监视，就将监视动作列表冻结，以免在停止监视时改变了监视动作。
                dgrdTaskList.SelectedRows[0].Cells[IDX_CHANGETYPE].ReadOnly = true;
                dgrdTaskList.SelectedRows[0].Cells[IDX_SUBDIR].ReadOnly = true;
                //当停止一个监视后触发OnWatchSettingChanged事件以便进行实时保存
                this.OnWatchSettingChanged();
            }
        }
        //移除一个监视
        private void RemoveWatch(object sender, EventArgs e)
        {
            XWXFileSystemWatcher watcher = GetSelectedWatcher(true, "请选择需要移除的监视项");
            if (watcher != null)
            {
                if (MessageBox.Show("删除该监视后不再会自动备份该目录文件,确定吗？", "正在删除监视", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    watcher.StopWatch();
                    watcherList.Remove(watcher);
                    dgrdTaskList.Rows.Remove(dgrdTaskList.SelectedRows[0]);
                    //当删除一个监视后触发OnWatchSettingChanged事件以便进行实时保存
                    this.OnWatchSettingChanged();
                }
            }
        }

        private string GetWatchingStatusName(bool isWatching)
        {
            return isWatching ? "正在监视" : "已经停止";
        }

        //点击关闭按钮时最小化
        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.notifyIcon1.Visible = true;
            e.Cancel = true;
        }
        //左击NotifyIcon显示主窗体
        private void ShowWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }
        //打开备份目录
        private void OpenBackupFolder(object sender, EventArgs e)
        {
            XWXFileSystemWatcher watcher = GetSelectedWatcher(true, "请选择监视项");
            if (watcher != null) System.Diagnostics.Process.Start(watcher.BackupFolder);
        }
        //在编辑行时绑定下拉列表的SelectedIndexChanged事件
        private void dgrdTaskList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            //记录当前选中行的row index
            _selectedRowIndex = grid.SelectedRows[0].Index;
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                cb.SelectedIndexChanged -= new EventHandler(cb_SelectedIndexChanged);
                cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            }
        }
        //选择需要监视的动作
        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (_selectedRowIndex > -1)
            {
                XWXFileSystemWatcher watcher = (XWXFileSystemWatcher)dgrdTaskList.Rows[_selectedRowIndex].Tag;
                string selectedAction = cb.SelectedItem.ToString();
                switch (selectedAction)
                {
                    //需要先解除原来的事件绑定，在绑定新的，否则会触发多次。
                    case "创建、修改及重命名":
                        watcher.Created -= new FileSystemEventHandler(watcher_Created);
                        watcher.Changed -= new FileSystemEventHandler(watcher_Changed);
                        watcher.Renamed -= new RenamedEventHandler(watcher_Renamed);
                        watcher.Created += new FileSystemEventHandler(watcher_Created);
                        watcher.Changed += new FileSystemEventHandler(watcher_Changed);
                        watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
                        watcher.WatchingChangeTypes = (WatcherChangeTypes.Changed | WatcherChangeTypes.Created);
                        break;
                    case "仅创建":
                        watcher.Created -= new FileSystemEventHandler(watcher_Created);
                        watcher.Changed -= new FileSystemEventHandler(watcher_Changed);
                        watcher.Created += new FileSystemEventHandler(watcher_Created);
                        watcher.Renamed -= new RenamedEventHandler(watcher_Renamed);
                        watcher.WatchingChangeTypes = WatcherChangeTypes.Created;
                        break;
                    case "仅修改":
                        watcher.Created -= new FileSystemEventHandler(watcher_Created);
                        watcher.Changed -= new FileSystemEventHandler(watcher_Changed);
                        watcher.Renamed -= new RenamedEventHandler(watcher_Renamed);
                        watcher.Changed += new FileSystemEventHandler(watcher_Changed);
                        watcher.WatchingChangeTypes = WatcherChangeTypes.Changed;
                        break;
                    case "仅重命名":
                        watcher.Created -= new FileSystemEventHandler(watcher_Created);
                        watcher.Changed -= new FileSystemEventHandler(watcher_Changed);
                        watcher.Renamed -= new RenamedEventHandler(watcher_Renamed);
                        watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
                        watcher.WatchingChangeTypes = WatcherChangeTypes.Changed;
                        break;
                }
                //当选择一个监视的更改类型后触发OnWatchSettingChanged事件以便进行实时保存
                this.OnWatchSettingChanged();
            }
        }

        private XWXFileSystemWatcher GetSelectedWatcher(bool showUnselectedRowMsg, string unselectedErrMsg)
        {
            if (dgrdTaskList.SelectedRows.Count == 0)
            {
                if (showUnselectedRowMsg)
                    MessageBox.Show(unselectedErrMsg);
                return null;
            }
            return dgrdTaskList.SelectedRows[0].Tag as XWXFileSystemWatcher;
        }
        //进行恢复
        private void Rebackup(object sender, EventArgs e)
        {
            XWXFileSystemWatcher watcher = GetSelectedWatcher(true, "请选择需要进行恢复的监视项");
            if (watcher != null)
                new FrmFilePicker(watcher).Show();
        }
        //点击包含子目录
        private void dgrdTaskList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0 && e.ColumnIndex == IDX_SUBDIR)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                XWXFileSystemWatcher watcher = row.Tag as XWXFileSystemWatcher;
                watcher.IncludeSubdirectories=(bool)row.Cells[IDX_SUBDIR].EditedFormattedValue;
                //当改变一个监视的"是否包含子目录"后触发OnWatchSettingChanged事件以便进行实时保存
                this.OnWatchSettingChanged();
            }
        }
        //开启或关闭自动模式
        private void AutoMode(object sender, EventArgs e)
        {
            if (chbAuto.Checked)
                autoMode.AutoModeOn();
            else
                autoMode.AutoModeOff();
        }
    }
}
