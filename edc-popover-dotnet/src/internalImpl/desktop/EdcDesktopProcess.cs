using edc_popover_dotnet.src.desktop;
using edc_popover_dotnet.src.Gui;
using edcClientDotnet;
using System;
using System.Diagnostics;
using System.IO;

namespace edc_popover_dotnet.src.internalImpl.desktop
{
    public class EdcDesktopProcess : IDesktopProcess
    {
        private Process? edcDesktopProcess;

        public void CreateProcess(string programPath)
        {
            if (edcDesktopProcess == null || !IsRunning(edcDesktopProcess))
            {
                edcDesktopProcess = new Process();
                edcDesktopProcess.StartInfo.FileName = programPath;
                edcDesktopProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(programPath);
                edcDesktopProcess.Start();
            }
        }

        public void ConfigureDesktopProcess(IEdcHelpGui edcHelp, IEdcClient edcClient,String appPath, String serverUrl)
        {
            this.CreateProcess(appPath);
            if (this.IsRunning(this.GetProcess()))
            {
                edcHelp.SetViewerDesktopPath(appPath);
                edcHelp.SetViewerDesktopServerURL(serverUrl);
                edcClient.SetServerUrl(serverUrl);
            }
        }

        public Process? GetProcess()
        {
            return edcDesktopProcess;
        }

        public void KillProcess()
        {
            edcDesktopProcess?.Kill();
        }

        public bool IsRunning(Process process)
        {
            try
            {
                Process.GetProcessById(process.Id);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
    }
}
