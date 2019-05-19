using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppStarter
{
    public partial class FrmStarter : Form
    {

        private ShellExecutor executor = new ShellExecutor();

        private DataTable appTable = new DataTable();

        public FrmStarter()
        {
            executor.LoadConfig("config.json");

            InitializeComponent();

            InitializeAppGrid();

        }

        private void InitializeAppGrid()
        {
            DataColumn appNameColumn = new DataColumn("名称", typeof(string));
            DataColumn appVersionColumn = new DataColumn("版本", typeof(string));
            DataColumn appWorkdirColumn = new DataColumn("目录", typeof(string));
            DataColumn appPortColumn = new DataColumn("端口", typeof(string));
            DataColumn appStatusColumn = new DataColumn("状态", typeof(string));

            appTable.Columns.Add(appNameColumn);
            appTable.Columns.Add(appVersionColumn);
            appTable.Columns.Add(appWorkdirColumn);
            appTable.Columns.Add(appPortColumn);
            appTable.Columns.Add(appStatusColumn);

            appTable.PrimaryKey = new DataColumn[] { appNameColumn };

            this.gridApp.DataSource = appTable;
            this.gridApp.Columns[0].Width = 120;
            this.gridApp.Columns[1].Width = 100;
            this.gridApp.Columns[2].Width = 270;
            this.gridApp.Columns[3].Width = 100;
            this.gridApp.Columns[4].Width = 70;

            LoadAppList();

            int rowIndex = gridApp.CurrentRow.Index;

            DisplayAppInfo(rowIndex);
        }

        private void LoadAppList()
        {
            Dictionary<string, object> appConfigDict = executor.GetAppList();
            foreach (string appName in appConfigDict.Keys)
            {
                Dictionary<string, object> appConfig = (Dictionary<string, object>)appConfigDict[appName];

                DataRow row = appTable.NewRow();
                row[0] = appConfig["name"];
                row[1] = appConfig.ContainsKey("version") ? appConfig["version"] : "未知版本";
                row[2] = appConfig["workdir"];
                row[3] = appConfig.ContainsKey("port") ? appConfig["port"] : "--";
                row[4] = executor.GetAppStatusByName(appName);

                appTable.Rows.Add(row);
            }
        }

        private void timerProcessCheck_Tick(object sender, EventArgs e)
        {
            executor.CheckProcessStatus();

            foreach (DataRow row in appTable.Rows)
            {
                string appName = row[0].ToString();
                UpdateAppStatus(appName);
            }
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (executor.GetRunningProccessCount() > 0)
            {
                DialogResult result = MessageBox.Show("目前还有启动的进程, 是否强制关闭?", "强制关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridApp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value.ToString().Equals("Stopped") || e.Value.ToString().Equals("Error"))
            {
                e.CellStyle.ForeColor = Color.Red;
            }
            else if (e.Value.ToString().Equals("Running"))
            {
                e.CellStyle.ForeColor = Color.Green;
            }
        }

        private void UpdateAppStatus(string appName)
        {
            string status = executor.GetAppStatusByName(appName);
            DataRowCollection rows = this.appTable.Rows;
            DataRow row = rows.Find(appName.Trim());
            if (row != null)
            {
                row[4] = status;
            }

            if (txtAppName.Text.Equals(appName))
            {
                txtProcessStatus.Text = status;
            }
        }

        private void gridApp_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisplayAppInfo();
        }

        private void DisplayAppInfo()
        {
            int rowIndex = gridApp.CurrentRow.Index;

            DisplayAppInfo(rowIndex);
        }

        private void DisplayAppInfo(int rowIndex)
        {
            DataRow appRow = this.appTable.Rows[rowIndex];
            string appName = appRow[0].ToString();

            DisplayAppInfo(appName);
        }

        private void DisplayAppInfo(string appName)
        {
            Dictionary<string, object> appConfig = executor.GetAppByName(appName);

            txtAppName.Text = appName;
            txtWorkdir.Text = appConfig["workdir"].ToString();
            txtVersion.Text = appConfig.ContainsKey("version") ? appConfig["version"].ToString() : "未知版本";
            if (appConfig.ContainsKey("icon"))
            {
                string icon = appConfig["icon"].ToString();
                pictAppIcon.LoadAsync(icon);
            }
            else
            {
                pictAppIcon.LoadAsync("images\\application_128px.png");
            }

            string status = executor.GetAppStatusByName(appName);
            txtProcessStatus.Text = status;
            
            if (appConfig.ContainsKey("window"))
            {
                if ("true".Equals(appConfig["window"]))
                {
                    chkShowWindow.Checked = true;
                }
                else
                {
                    chkShowWindow.Checked = false;
                }
            }
            else
            {
                chkShowWindow.Checked = false;
            }

            if (appConfig.ContainsKey("startup"))
            {
                Dictionary<string, object> startupConfig = (Dictionary<string, object>)appConfig["startup"];
                txtStartupCommand.Text = startupConfig.ContainsKey("command") ? startupConfig["command"].ToString() : "";
                txtStartupArgs.Text = startupConfig.ContainsKey("args") ? startupConfig["args"].ToString() : "";
            }

            if (appConfig.ContainsKey("shutdown"))
            {
                Dictionary<string, object> shutdownConfig = (Dictionary<string, object>)appConfig["shutdown"];
                txtShutdownCommand.Text = shutdownConfig.ContainsKey("command") ? shutdownConfig["command"].ToString() : "";
                txtShutdownArgs.Text = shutdownConfig.ContainsKey("args") ? shutdownConfig["args"].ToString() : "";
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string appName = txtAppName.Text;
            executor.Execute(appName, chkShowWindow.Checked);

            UpdateAppStatus(appName);
        }

        private void txtProcessStatus_TextChanged(object sender, EventArgs e)
        {
            string status = txtProcessStatus.Text;
            if (status.Equals("Stopped") || status.Equals("Error"))
            {
                txtProcessStatus.ForeColor = Color.Red;
            }
            else if (status.Equals("Running"))
            {
                txtProcessStatus.ForeColor = Color.Green;
            }

            if (status.Equals("Running"))
            {
                btnExecute.Text = "停止";
            }
            else
            {
                btnExecute.Text = "启动";
            }
        }

        private void pictAppIcon_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                pictAppIcon.LoadAsync("images\\application_128px.png");
            }
        }

        private void btnOpenWorkdir_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtWorkdir.Text))
            {
                System.Diagnostics.Process.Start("explorer.exe", txtWorkdir.Text);
            }
            else
            {
                MessageBox.Show("需要打开的目录不存在");
            }
        }
    }
}
