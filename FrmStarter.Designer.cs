namespace AppStarter
{
    partial class FrmStarter
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStarter));
            this.timerProcessCheck = new System.Windows.Forms.Timer(this.components);
            this.gridApp = new System.Windows.Forms.DataGridView();
            this.groupAppInfo = new System.Windows.Forms.GroupBox();
            this.txtProcessStatus = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.pictAppIcon = new System.Windows.Forms.PictureBox();
            this.tabApp = new System.Windows.Forms.TabControl();
            this.tabPageAppInfo = new System.Windows.Forms.TabPage();
            this.btnOpenWorkdir = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.txtWorkdir = new System.Windows.Forms.TextBox();
            this.labelWorkdir = new System.Windows.Forms.Label();
            this.chkShowWindow = new System.Windows.Forms.CheckBox();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.labelAppName = new System.Windows.Forms.Label();
            this.tabPageStartup = new System.Windows.Forms.TabPage();
            this.txtStartupArgs = new System.Windows.Forms.TextBox();
            this.labelStartupCommand = new System.Windows.Forms.Label();
            this.labelStartupArgs = new System.Windows.Forms.Label();
            this.txtStartupCommand = new System.Windows.Forms.TextBox();
            this.tabPageShutdown = new System.Windows.Forms.TabPage();
            this.txtShutdownArgs = new System.Windows.Forms.TextBox();
            this.labelShutdownCommand = new System.Windows.Forms.Label();
            this.labelShutdownArgs = new System.Windows.Forms.Label();
            this.txtShutdownCommand = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridApp)).BeginInit();
            this.groupAppInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictAppIcon)).BeginInit();
            this.tabApp.SuspendLayout();
            this.tabPageAppInfo.SuspendLayout();
            this.tabPageStartup.SuspendLayout();
            this.tabPageShutdown.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerProcessCheck
            // 
            this.timerProcessCheck.Enabled = true;
            this.timerProcessCheck.Interval = 1000;
            this.timerProcessCheck.Tick += new System.EventHandler(this.timerProcessCheck_Tick);
            // 
            // gridApp
            // 
            this.gridApp.AllowUserToAddRows = false;
            this.gridApp.AllowUserToDeleteRows = false;
            this.gridApp.AllowUserToResizeRows = false;
            this.gridApp.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridApp.Location = new System.Drawing.Point(24, 239);
            this.gridApp.MultiSelect = false;
            this.gridApp.Name = "gridApp";
            this.gridApp.ReadOnly = true;
            this.gridApp.RowTemplate.Height = 23;
            this.gridApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridApp.Size = new System.Drawing.Size(705, 330);
            this.gridApp.TabIndex = 0;
            this.gridApp.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridApp_CellFormatting);
            this.gridApp.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridApp_CellMouseClick);
            // 
            // groupAppInfo
            // 
            this.groupAppInfo.BackColor = System.Drawing.SystemColors.Control;
            this.groupAppInfo.Controls.Add(this.txtProcessStatus);
            this.groupAppInfo.Controls.Add(this.btnExecute);
            this.groupAppInfo.Controls.Add(this.pictAppIcon);
            this.groupAppInfo.Controls.Add(this.tabApp);
            this.groupAppInfo.Location = new System.Drawing.Point(24, 10);
            this.groupAppInfo.Name = "groupAppInfo";
            this.groupAppInfo.Size = new System.Drawing.Size(705, 215);
            this.groupAppInfo.TabIndex = 1;
            this.groupAppInfo.TabStop = false;
            // 
            // txtProcessStatus
            // 
            this.txtProcessStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtProcessStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcessStatus.Location = new System.Drawing.Point(42, 142);
            this.txtProcessStatus.Name = "txtProcessStatus";
            this.txtProcessStatus.ReadOnly = true;
            this.txtProcessStatus.Size = new System.Drawing.Size(109, 14);
            this.txtProcessStatus.TabIndex = 13;
            this.txtProcessStatus.Text = "Status";
            this.txtProcessStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProcessStatus.TextChanged += new System.EventHandler(this.txtProcessStatus_TextChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(42, 171);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(109, 28);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "启动";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // pictAppIcon
            // 
            this.pictAppIcon.Location = new System.Drawing.Point(42, 32);
            this.pictAppIcon.Name = "pictAppIcon";
            this.pictAppIcon.Size = new System.Drawing.Size(109, 92);
            this.pictAppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictAppIcon.TabIndex = 10;
            this.pictAppIcon.TabStop = false;
            this.pictAppIcon.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictAppIcon_LoadCompleted);
            // 
            // tabApp
            // 
            this.tabApp.Controls.Add(this.tabPageAppInfo);
            this.tabApp.Controls.Add(this.tabPageStartup);
            this.tabApp.Controls.Add(this.tabPageShutdown);
            this.tabApp.Location = new System.Drawing.Point(184, 22);
            this.tabApp.Name = "tabApp";
            this.tabApp.SelectedIndex = 0;
            this.tabApp.Size = new System.Drawing.Size(497, 177);
            this.tabApp.TabIndex = 9;
            // 
            // tabPageAppInfo
            // 
            this.tabPageAppInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAppInfo.Controls.Add(this.btnOpenWorkdir);
            this.tabPageAppInfo.Controls.Add(this.txtVersion);
            this.tabPageAppInfo.Controls.Add(this.labelVersion);
            this.tabPageAppInfo.Controls.Add(this.txtWorkdir);
            this.tabPageAppInfo.Controls.Add(this.labelWorkdir);
            this.tabPageAppInfo.Controls.Add(this.chkShowWindow);
            this.tabPageAppInfo.Controls.Add(this.txtAppName);
            this.tabPageAppInfo.Controls.Add(this.labelAppName);
            this.tabPageAppInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageAppInfo.Name = "tabPageAppInfo";
            this.tabPageAppInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAppInfo.Size = new System.Drawing.Size(489, 151);
            this.tabPageAppInfo.TabIndex = 0;
            this.tabPageAppInfo.Text = "应用信息";
            // 
            // btnOpenWorkdir
            // 
            this.btnOpenWorkdir.Location = new System.Drawing.Point(419, 58);
            this.btnOpenWorkdir.Name = "btnOpenWorkdir";
            this.btnOpenWorkdir.Size = new System.Drawing.Size(53, 23);
            this.btnOpenWorkdir.TabIndex = 12;
            this.btnOpenWorkdir.Text = "....";
            this.btnOpenWorkdir.UseVisualStyleBackColor = true;
            this.btnOpenWorkdir.Click += new System.EventHandler(this.btnOpenWorkdir_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.SystemColors.Window;
            this.txtVersion.Location = new System.Drawing.Point(344, 25);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(128, 21);
            this.txtVersion.TabIndex = 11;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(301, 28);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(29, 12);
            this.labelVersion.TabIndex = 10;
            this.labelVersion.Text = "版本";
            // 
            // txtWorkdir
            // 
            this.txtWorkdir.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorkdir.Location = new System.Drawing.Point(84, 59);
            this.txtWorkdir.Name = "txtWorkdir";
            this.txtWorkdir.ReadOnly = true;
            this.txtWorkdir.Size = new System.Drawing.Size(328, 21);
            this.txtWorkdir.TabIndex = 9;
            // 
            // labelWorkdir
            // 
            this.labelWorkdir.AutoSize = true;
            this.labelWorkdir.Location = new System.Drawing.Point(19, 63);
            this.labelWorkdir.Name = "labelWorkdir";
            this.labelWorkdir.Size = new System.Drawing.Size(53, 12);
            this.labelWorkdir.TabIndex = 8;
            this.labelWorkdir.Text = "工作目录";
            // 
            // chkShowWindow
            // 
            this.chkShowWindow.AutoSize = true;
            this.chkShowWindow.Location = new System.Drawing.Point(22, 98);
            this.chkShowWindow.Name = "chkShowWindow";
            this.chkShowWindow.Size = new System.Drawing.Size(90, 16);
            this.chkShowWindow.TabIndex = 7;
            this.chkShowWindow.Text = "显示Console";
            this.chkShowWindow.UseVisualStyleBackColor = true;
            // 
            // txtAppName
            // 
            this.txtAppName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAppName.Location = new System.Drawing.Point(84, 24);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.ReadOnly = true;
            this.txtAppName.Size = new System.Drawing.Size(211, 21);
            this.txtAppName.TabIndex = 6;
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.Location = new System.Drawing.Point(20, 28);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(41, 12);
            this.labelAppName.TabIndex = 5;
            this.labelAppName.Text = "应用名";
            // 
            // tabPageStartup
            // 
            this.tabPageStartup.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStartup.Controls.Add(this.txtStartupArgs);
            this.tabPageStartup.Controls.Add(this.labelStartupCommand);
            this.tabPageStartup.Controls.Add(this.labelStartupArgs);
            this.tabPageStartup.Controls.Add(this.txtStartupCommand);
            this.tabPageStartup.Location = new System.Drawing.Point(4, 22);
            this.tabPageStartup.Name = "tabPageStartup";
            this.tabPageStartup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStartup.Size = new System.Drawing.Size(489, 151);
            this.tabPageStartup.TabIndex = 1;
            this.tabPageStartup.Text = "启动指令";
            // 
            // txtStartupArgs
            // 
            this.txtStartupArgs.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartupArgs.Location = new System.Drawing.Point(84, 59);
            this.txtStartupArgs.Name = "txtStartupArgs";
            this.txtStartupArgs.ReadOnly = true;
            this.txtStartupArgs.Size = new System.Drawing.Size(377, 21);
            this.txtStartupArgs.TabIndex = 13;
            // 
            // labelStartupCommand
            // 
            this.labelStartupCommand.AutoSize = true;
            this.labelStartupCommand.Location = new System.Drawing.Point(19, 26);
            this.labelStartupCommand.Name = "labelStartupCommand";
            this.labelStartupCommand.Size = new System.Drawing.Size(53, 12);
            this.labelStartupCommand.TabIndex = 10;
            this.labelStartupCommand.Text = "启动指令";
            // 
            // labelStartupArgs
            // 
            this.labelStartupArgs.AutoSize = true;
            this.labelStartupArgs.Location = new System.Drawing.Point(19, 63);
            this.labelStartupArgs.Name = "labelStartupArgs";
            this.labelStartupArgs.Size = new System.Drawing.Size(53, 12);
            this.labelStartupArgs.TabIndex = 12;
            this.labelStartupArgs.Text = "启动参数";
            // 
            // txtStartupCommand
            // 
            this.txtStartupCommand.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartupCommand.Location = new System.Drawing.Point(84, 22);
            this.txtStartupCommand.Name = "txtStartupCommand";
            this.txtStartupCommand.ReadOnly = true;
            this.txtStartupCommand.Size = new System.Drawing.Size(377, 21);
            this.txtStartupCommand.TabIndex = 11;
            // 
            // tabPageShutdown
            // 
            this.tabPageShutdown.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageShutdown.Controls.Add(this.txtShutdownArgs);
            this.tabPageShutdown.Controls.Add(this.labelShutdownCommand);
            this.tabPageShutdown.Controls.Add(this.labelShutdownArgs);
            this.tabPageShutdown.Controls.Add(this.txtShutdownCommand);
            this.tabPageShutdown.Location = new System.Drawing.Point(4, 22);
            this.tabPageShutdown.Name = "tabPageShutdown";
            this.tabPageShutdown.Size = new System.Drawing.Size(489, 151);
            this.tabPageShutdown.TabIndex = 2;
            this.tabPageShutdown.Text = "关闭指令";
            // 
            // txtShutdownArgs
            // 
            this.txtShutdownArgs.BackColor = System.Drawing.SystemColors.Window;
            this.txtShutdownArgs.Location = new System.Drawing.Point(83, 60);
            this.txtShutdownArgs.Name = "txtShutdownArgs";
            this.txtShutdownArgs.ReadOnly = true;
            this.txtShutdownArgs.Size = new System.Drawing.Size(376, 21);
            this.txtShutdownArgs.TabIndex = 17;
            // 
            // labelShutdownCommand
            // 
            this.labelShutdownCommand.AutoSize = true;
            this.labelShutdownCommand.Location = new System.Drawing.Point(18, 27);
            this.labelShutdownCommand.Name = "labelShutdownCommand";
            this.labelShutdownCommand.Size = new System.Drawing.Size(53, 12);
            this.labelShutdownCommand.TabIndex = 14;
            this.labelShutdownCommand.Text = "停止指令";
            // 
            // labelShutdownArgs
            // 
            this.labelShutdownArgs.AutoSize = true;
            this.labelShutdownArgs.Location = new System.Drawing.Point(18, 64);
            this.labelShutdownArgs.Name = "labelShutdownArgs";
            this.labelShutdownArgs.Size = new System.Drawing.Size(53, 12);
            this.labelShutdownArgs.TabIndex = 16;
            this.labelShutdownArgs.Text = "停止参数";
            // 
            // txtShutdownCommand
            // 
            this.txtShutdownCommand.BackColor = System.Drawing.SystemColors.Window;
            this.txtShutdownCommand.Location = new System.Drawing.Point(83, 23);
            this.txtShutdownCommand.Name = "txtShutdownCommand";
            this.txtShutdownCommand.ReadOnly = true;
            this.txtShutdownCommand.Size = new System.Drawing.Size(376, 21);
            this.txtShutdownCommand.TabIndex = 15;
            // 
            // FrmStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 581);
            this.Controls.Add(this.groupAppInfo);
            this.Controls.Add(this.gridApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmStarter";
            this.Text = "应用启动器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridApp)).EndInit();
            this.groupAppInfo.ResumeLayout(false);
            this.groupAppInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictAppIcon)).EndInit();
            this.tabApp.ResumeLayout(false);
            this.tabPageAppInfo.ResumeLayout(false);
            this.tabPageAppInfo.PerformLayout();
            this.tabPageStartup.ResumeLayout(false);
            this.tabPageStartup.PerformLayout();
            this.tabPageShutdown.ResumeLayout(false);
            this.tabPageShutdown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerProcessCheck;
        private System.Windows.Forms.DataGridView gridApp;
        private System.Windows.Forms.GroupBox groupAppInfo;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.PictureBox pictAppIcon;
        private System.Windows.Forms.TabControl tabApp;
        private System.Windows.Forms.TabPage tabPageAppInfo;
        private System.Windows.Forms.TextBox txtWorkdir;
        private System.Windows.Forms.Label labelWorkdir;
        private System.Windows.Forms.CheckBox chkShowWindow;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.TabPage tabPageStartup;
        private System.Windows.Forms.TextBox txtStartupArgs;
        private System.Windows.Forms.Label labelStartupCommand;
        private System.Windows.Forms.Label labelStartupArgs;
        private System.Windows.Forms.TextBox txtStartupCommand;
        private System.Windows.Forms.TabPage tabPageShutdown;
        private System.Windows.Forms.TextBox txtShutdownArgs;
        private System.Windows.Forms.Label labelShutdownCommand;
        private System.Windows.Forms.Label labelShutdownArgs;
        private System.Windows.Forms.TextBox txtShutdownCommand;
        private System.Windows.Forms.TextBox txtProcessStatus;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button btnOpenWorkdir;
    }
}

