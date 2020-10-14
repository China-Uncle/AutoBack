using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AutoBackup.Core;

namespace AutoBackup
{
    public partial class FrmFilePicker : Form
    {
        FolderBrowserDialog FBD;
        SaveFileDialog SFD;
        ISearchBackupFiles searchBackupModule;
        XWXFileSystemWatcher _watcher;

        const int IDX_CHECK             = 0;
        const int IDX_FILENAME          = 1;
        const int IDX_DATE              = 2;
        const int IDX_CHANGETYPE        = 3;
        const int IDX_BACKUPFULLNAME    = 4;

        public FrmFilePicker(XWXFileSystemWatcher watcher)
        {
            InitializeComponent();
            Init();
            _watcher = watcher;
            txbBackupFolder.Text = watcher.BackupFolder;
        }

        private void Init()
        {
            FBD = new FolderBrowserDialog();
            SFD = new SaveFileDialog();
            searchBackupModule = ModuleFactory.GetSearchBackupModule();
            ddlActions.SelectedIndex = 0;
        }

        //搜索备份文件并显示在列表上
        private void DoSearch(object sender, EventArgs e)
        {
            if (txbBackupFolder.Text == string.Empty)
            {
                MessageBox.Show("请选择备份目录");
                return;
            }
            if (!Directory.Exists(txbBackupFolder.Text))
            {
                MessageBox.Show("该目录不存在");
                return;
            }
            dgvResults.Rows.Clear();//先清空列表行

            //获取ActionType
            WatcherChangeTypes changeType;
            if (ddlActions.SelectedIndex == 0) changeType = WatcherChangeTypes.Changed | WatcherChangeTypes.Created|WatcherChangeTypes.Renamed;
            else if (ddlActions.SelectedIndex == 1) changeType = WatcherChangeTypes.Created; 
            else if (ddlActions.SelectedIndex == 2) changeType = WatcherChangeTypes.Changed;
            else changeType = WatcherChangeTypes.Renamed;

            bool includeSubdir=chbSubDir.Checked;

            List<BackupInfo> searchResults = searchBackupModule.SearchBackupFiles(txbBackupFolder.Text, dtBeginning.Value, dtEnding.Value, txbFileName.Text, changeType, includeSubdir);
            foreach (BackupInfo backupInfo in searchResults)
            {
                int idx = dgvResults.Rows.Add();
                dgvResults.Rows[idx].Cells[IDX_FILENAME].Value = backupInfo.BackupFullFileName;
                dgvResults.Rows[idx].Cells[IDX_DATE].Value = backupInfo.ChangeDate.ToString("yyyy-MM-dd HH:mm:ss");
                dgvResults.Rows[idx].Cells[IDX_CHANGETYPE].Value =Enum.GetName(typeof(WatcherChangeTypes), backupInfo.ChangeType);
                dgvResults.Rows[idx].Cells[IDX_BACKUPFULLNAME].Value = backupInfo.BackupFullFileName;
                dgvResults.Rows[idx].Tag = backupInfo;
            }
            MessageBox.Show("搜索完毕");
        }


        //进行恢复
        private void DoReBackup(object sender, EventArgs e)
        {
            if (txbRebackupTo.Text == string.Empty)
            {
                MessageBox.Show("请先选择需要恢复的目录");
                return;
            }
            if (dgvResults.Rows.Count == 0)
            {
                MessageBox.Show("请先搜索并选择需要恢复的文件");
                return;
            }

            bool hasNoCheck = true;//记录是否没有任何行被记录
            List<BackupInfo> reBackupingList = new List<BackupInfo>();
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                DataGridViewCheckBoxCell chechBox = row.Cells[0] as DataGridViewCheckBoxCell;
                if (!Convert.ToBoolean(chechBox.Value))//如果没有勾选，则不恢复
                {
                    continue;
                }
                BackupInfo bf = row.Tag as BackupInfo;
                reBackupingList.Add(bf);
                hasNoCheck = false;//有勾选就设置为true
            }
            ReBackupHelper.Rebackup(reBackupingList,txbBackupFolder.Text,txbRebackupTo.Text);
            if (hasNoCheck)
            {
                MessageBox.Show("当前没有勾选任何需要恢复的行");
                return;
            }

            MessageBox.Show("恢复完毕");
        }


        private void btnBrowseRebackup_Click(object sender, EventArgs e)
        {
            FBD.Description = "将文件恢复至...";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                txbRebackupTo.Text = FBD.SelectedPath;
            }
        }
        //双击全选
        private void dgvResults_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool checkingAll = (dgvResults.Tag == null || (bool)dgvResults.Tag) ? true : false;
                foreach (DataGridViewRow row in dgvResults.Rows)
                {
                    DataGridViewCheckBoxCell checkbox = row.Cells[0] as DataGridViewCheckBoxCell;
                    checkbox.Value = checkingAll;
                }
                dgvResults.Tag = !checkingAll;
            }
        }
    }
}
