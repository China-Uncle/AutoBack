namespace AutoBackup
{
    partial class FrmFilePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilePicker));
            this.dtBeginning = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbFileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbSubDir = new System.Windows.Forms.CheckBox();
            this.btnBrowseRebackup = new System.Windows.Forms.Button();
            this.btnReBackup = new System.Windows.Forms.Button();
            this.txbRebackupTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlActions = new System.Windows.Forms.ComboBox();
            this.txbBackupFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtEnding = new System.Windows.Forms.DateTimePicker();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackupFileFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.gbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dtBeginning
            // 
            this.dtBeginning.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtBeginning.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBeginning.Location = new System.Drawing.Point(64, 54);
            this.dtBeginning.Name = "dtBeginning";
            this.dtBeginning.Size = new System.Drawing.Size(152, 21);
            this.dtBeginning.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始时间";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.txbFileName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chbSubDir);
            this.groupBox1.Controls.Add(this.btnBrowseRebackup);
            this.groupBox1.Controls.Add(this.btnReBackup);
            this.groupBox1.Controls.Add(this.txbRebackupTo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ddlActions);
            this.groupBox1.Controls.Add(this.txbBackupFolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtEnding);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtBeginning);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(879, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txbFileName
            // 
            this.txbFileName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txbFileName.Location = new System.Drawing.Point(577, 19);
            this.txbFileName.Name = "txbFileName";
            this.txbFileName.Size = new System.Drawing.Size(112, 21);
            this.txbFileName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "文件名";
            // 
            // chbSubDir
            // 
            this.chbSubDir.AutoSize = true;
            this.chbSubDir.Location = new System.Drawing.Point(469, 60);
            this.chbSubDir.Name = "chbSubDir";
            this.chbSubDir.Size = new System.Drawing.Size(84, 16);
            this.chbSubDir.TabIndex = 11;
            this.chbSubDir.Text = "包含子目录";
            this.chbSubDir.UseVisualStyleBackColor = true;
            // 
            // btnBrowseRebackup
            // 
            this.btnBrowseRebackup.Location = new System.Drawing.Point(447, 17);
            this.btnBrowseRebackup.Name = "btnBrowseRebackup";
            this.btnBrowseRebackup.Size = new System.Drawing.Size(58, 23);
            this.btnBrowseRebackup.TabIndex = 10;
            this.btnBrowseRebackup.Text = "浏览...";
            this.btnBrowseRebackup.UseVisualStyleBackColor = true;
            this.btnBrowseRebackup.Click += new System.EventHandler(this.btnBrowseRebackup_Click);
            // 
            // btnReBackup
            // 
            this.btnReBackup.Location = new System.Drawing.Point(712, 54);
            this.btnReBackup.Name = "btnReBackup";
            this.btnReBackup.Size = new System.Drawing.Size(121, 31);
            this.btnReBackup.TabIndex = 10;
            this.btnReBackup.Text = "恢复";
            this.btnReBackup.UseVisualStyleBackColor = true;
            this.btnReBackup.Click += new System.EventHandler(this.DoReBackup);
            // 
            // txbRebackupTo
            // 
            this.txbRebackupTo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txbRebackupTo.Location = new System.Drawing.Point(284, 19);
            this.txbRebackupTo.Name = "txbRebackupTo";
            this.txbRebackupTo.ReadOnly = true;
            this.txbRebackupTo.Size = new System.Drawing.Size(157, 21);
            this.txbRebackupTo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "恢复至";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(710, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "动作";
            // 
            // ddlActions
            // 
            this.ddlActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlActions.Items.AddRange(new object[] {
            "创建、修改及重命名",
            "仅创建",
            "仅修改",
            "仅重命名"});
            this.ddlActions.Location = new System.Drawing.Point(745, 19);
            this.ddlActions.Name = "ddlActions";
            this.ddlActions.Size = new System.Drawing.Size(88, 20);
            this.ddlActions.TabIndex = 8;
            // 
            // txbBackupFolder
            // 
            this.txbBackupFolder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txbBackupFolder.Location = new System.Drawing.Point(64, 19);
            this.txbBackupFolder.Name = "txbBackupFolder";
            this.txbBackupFolder.ReadOnly = true;
            this.txbBackupFolder.Size = new System.Drawing.Size(152, 21);
            this.txbBackupFolder.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "备份目录";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(577, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 34);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.DoSearch);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束时间";
            // 
            // dtEnding
            // 
            this.dtEnding.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEnding.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnding.Location = new System.Drawing.Point(296, 56);
            this.dtEnding.Name = "dtEnding";
            this.dtEnding.Size = new System.Drawing.Size(157, 21);
            this.dtEnding.TabIndex = 2;
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.dgvResults);
            this.gbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResults.Location = new System.Drawing.Point(0, 105);
            this.gbResults.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(879, 263);
            this.gbResults.TabIndex = 3;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "结果";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colFileName,
            this.colDate,
            this.colAction,
            this.colBackupFileFullName});
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(3, 17);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowTemplate.Height = 23;
            this.dgvResults.Size = new System.Drawing.Size(873, 243);
            this.dgvResults.TabIndex = 0;
            this.dgvResults.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResults_ColumnHeaderMouseDoubleClick);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "双击全选/取消";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 90;
            // 
            // colFileName
            // 
            this.colFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFileName.FillWeight = 21.2766F;
            this.colFileName.HeaderText = "文件名";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 178.7234F;
            this.colDate.HeaderText = "时间";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 150;
            // 
            // colAction
            // 
            this.colAction.HeaderText = "变更类型";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            // 
            // colBackupFileFullName
            // 
            this.colBackupFileFullName.HeaderText = "备份文件全名";
            this.colBackupFileFullName.Name = "colBackupFileFullName";
            this.colBackupFileFullName.ReadOnly = true;
            this.colBackupFileFullName.Visible = false;
            // 
            // FrmFilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(879, 368);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFilePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "备份文件恢复";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtBeginning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtEnding;
        private System.Windows.Forms.TextBox txbBackupFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlActions;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnReBackup;
        private System.Windows.Forms.Button btnBrowseRebackup;
        private System.Windows.Forms.TextBox txbRebackupTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbSubDir;
        private System.Windows.Forms.TextBox txbFileName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBackupFileFullName;
    }
}