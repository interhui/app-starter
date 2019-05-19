using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AppStarter
{
    class ShellExecutor
    {

        private Dictionary<string, object> appConfigDict = new Dictionary<string, object>();

        private Dictionary<string, Process> processDict = new Dictionary<string, Process>();

        private Dictionary<string, string> statusDict = new Dictionary<string, string>();

        public void LoadConfig(string configFile)
        {
            StringBuilder appConfigJson = new StringBuilder();

            using (StreamReader sr = new StreamReader(configFile))
            {
                while (sr.Peek() >= 0)
                {
                    appConfigJson.AppendLine(sr.ReadLine());
                }
            }

            JObject appConfigObj = JObject.Parse(appConfigJson.ToString());
            if (appConfigObj.ContainsKey("app"))
            {
                var appJsonArray = appConfigObj["app"];
                if (appJsonArray != null && appJsonArray.Count() > 0)
                {
                    foreach (var appJson in appJsonArray)
                    {
                        string name = appJson.Value<string>("name");
                        if (name != null)
                        {
                            Dictionary<string, object> appConfig = new Dictionary<string, object>();
                            appConfig.Add("name", name);

                            string version = appJson.Value<string>("version");
                            if (!String.IsNullOrEmpty(version))
                            {
                                appConfig.Add("version", version);
                            }

                            string icon = appJson.Value<string>("icon");
                            if (!String.IsNullOrEmpty(icon))
                            {
                                appConfig.Add("icon", icon);
                            }

                            string port = appJson.Value<string>("port");
                            if (!String.IsNullOrEmpty(port))
                            {
                                appConfig.Add("port", port);
                            }

                            appConfig.Add("window", appJson.Value<string>("window"));
                            appConfig.Add("workdir", appJson.Value<string>("workdir"));

                            var startupJson = appJson["startup"];
                            if (startupJson != null)
                            {
                                Dictionary<string, object> startupConfig = new Dictionary<string, object>();
                                startupConfig.Add("command", startupJson.Value<string>("command"));

                                string args = startupJson.Value<string>("args");
                                if (!String.IsNullOrEmpty(args))
                                {
                                    startupConfig.Add("args", args);
                                }

                                appConfig.Add("startup", startupConfig);
                            }

                            var shutdownJson = appJson["shutdown"];
                            if (shutdownJson != null)
                            {
                                Dictionary<string, object> shutdownConfig = new Dictionary<string, object>();
                                shutdownConfig.Add("command", shutdownJson.Value<string>("command"));

                                string args = shutdownJson.Value<string>("args");
                                if (!String.IsNullOrEmpty(args))
                                {
                                    shutdownConfig.Add("args", args);
                                }

                                appConfig.Add("shutdown", shutdownConfig);
                            }

                            appConfigDict.Add(name, appConfig);
                        }

                    }
                }
            }
        }

        private Process StartupProcess(string appName, string workdir, string command, string args, bool showWindows)
        {

            if (!String.IsNullOrEmpty(workdir) && !String.IsNullOrEmpty(command))
            {
                string fullPath = workdir + "\\" + command;
                if (File.Exists(fullPath))
                {
                    ProcessStartInfo processInfo = null;
                    if (String.IsNullOrEmpty(args))
                    {
                        processInfo = new ProcessStartInfo(fullPath);
                    }
                    else
                    {
                        processInfo = new ProcessStartInfo(fullPath, args);
                    }
                    processInfo.WorkingDirectory = workdir;
                    processInfo.CreateNoWindow = !showWindows;
                    processInfo.UseShellExecute = false;

                    return Process.Start(processInfo);//启动程序;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private Process KillProcess(string appName, string workdir, string command, string args)
        {

            if (String.IsNullOrEmpty(workdir) || String.IsNullOrEmpty(command))
            {
                Process process = processDict[appName];
                process.Kill();
                processDict.Remove(appName);
                return process;
            }
            else
            {
                string fullPath = workdir + "\\" + command;
                if (File.Exists(fullPath))
                {
                    ProcessStartInfo processInfo = null;
                    if (String.IsNullOrEmpty(args))
                    {
                        processInfo = new ProcessStartInfo(fullPath);
                    }
                    else
                    {
                        processInfo = new ProcessStartInfo(fullPath, args);
                    }
                    processInfo.WorkingDirectory = workdir;
                    processInfo.UseShellExecute = false;

                    return Process.Start(processInfo);//停止程序;
                }
                else
                {
                    return null;
                }
            }

        }

        private void SetStatus(string program, string status)
        {
            if (!String.IsNullOrEmpty(program) && !String.IsNullOrEmpty(status))
            {
                statusDict[program] = status;
            }
        }

        private Dictionary<string, object> GetSubDictionary(Dictionary<string, object> dict, string key)
        {
            if (dict.ContainsKey(key))
            {
                object dictObj = dict[key];
                if (dictObj != null && dictObj is Dictionary<string, object>)
                {
                    return (Dictionary<string, object>)dictObj;
                }
            }
            return new Dictionary<string, object>();
        }

        private string GetDictionaryValue(IDictionary<string, object> dict, string key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key].ToString();
            }
            return null;
        }

        public void Execute(string appName, bool showWindow)
        {
            Dictionary<string, object> appConfig = GetSubDictionary(appConfigDict, appName);

            if (appConfig.ContainsKey("workdir"))
            {
                string workdir = appConfig["workdir"].ToString();

                if (!processDict.ContainsKey(appName))
                {
                    if (appConfig.ContainsKey("startup"))
                    {
                        Dictionary<string, object> startupConfig = GetSubDictionary(appConfig, "startup");

                        string command = GetDictionaryValue(startupConfig, "command");
                        string args = GetDictionaryValue(startupConfig, "args");

                        Process process = StartupProcess(appName, workdir, command, args, showWindow);
                        if (process != null)
                        {
                            if (process.Responding)
                            {
                                SetStatus(appName, "Running");
                            }
                        }
                        else
                        {
                            SetStatus(appName, "Error");
                        }
                        processDict[appName] = process;
                    }
                }
                else
                {
                    Dictionary<string, object> shutdownConfig = GetSubDictionary(appConfig, "shutdown");

                    string command = GetDictionaryValue(shutdownConfig, "command");
                    string args = GetDictionaryValue(shutdownConfig, "args");

                    Process process = KillProcess(appName, workdir, command, args);
                    if (process != null && process.HasExited)
                    {
                        SetStatus(appName, "Stopped");
                    }
                    else
                    {
                        SetStatus(appName, "Error");
                    }
                    processDict.Remove(appName);
                }
            }
        }

        private Process CheckProcess(Process process, Process[] sysProcesses)
        {
            int processId = process.Id;

            foreach (Process sysProcesse in sysProcesses)
            {
                int sysProcesseId = sysProcesse.Id;
                if (processId == sysProcesseId)
                {
                    return process;
                }
            }

            return null;
        }

        public int GetRunningProccessCount()
        {
            return processDict.Count;
        }

        public void CheckProcessStatus()
        {
            List<string> processNameList = new List<string>();
            foreach (var key in processDict.Keys)
            {
                processNameList.Add(key);
            }

            Process[] sysProcesses = Process.GetProcesses();

            foreach (var processName in processNameList)
            {
                Process process = processDict[processName];
                if (CheckProcess(process, sysProcesses) == null)
                {
                    processDict.Remove(processName);
                    SetStatus(processName, "Stopped");
                }
                else
                {
                    processDict[processName] = process;
                    SetStatus(processName, "Running");
                }
            }

            FileProperties processProp = new FileProperties();
            foreach (string processName in this.processDict.Keys)
            {
                Process process = this.processDict[processName];
                processProp.Add(processName, process.Id.ToString());
            }
            processProp.Save("apps.pid");
        }

        public Dictionary<string, object> GetAppList()
        {
            return this.appConfigDict;
        }

        public Dictionary<string, object> GetAppByName(string appName)
        {
            return GetSubDictionary(this.appConfigDict, appName);
        }

        public String GetAppStatusByName(string appName)
        {
            return this.statusDict.ContainsKey(appName) ? this.statusDict[appName] : "Stopped";
        }
    }
}
