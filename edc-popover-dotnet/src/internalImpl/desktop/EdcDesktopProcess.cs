using edc_popover_dotnet.src.desktop;
using edc_popover_dotnet.src.Gui;
using NLog;
using System;
using System.Diagnostics;
using System.IO;

namespace edc_popover_dotnet.src.internalImpl.desktop
{
    public class EdcDesktopProcess : IDesktopProcess
    {
        private Process? edcDesktopProcess;
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        private void CreateProcess(string programPath)
        {
            if (edcDesktopProcess == null || !IsRunning(edcDesktopProcess))
            {
                try
                {
                    edcDesktopProcess = new Process();
                    edcDesktopProcess.StartInfo.FileName = programPath;
                    edcDesktopProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(programPath);
                    edcDesktopProcess.Start();
                }catch (Exception ex)
                {
                    _logger.Error("The edc-help-viewer-desktop.exe was not found. Please retry with the correct path.");
                    throw new IOException("The edc-help-viewer-desktop.exe was not found. Please retry with the correct path or remove the content of viewerDesktopPath variable if you're not using the desktop viewer", ex);
                }
                
            }
        }

        public void ConfigureDesktopProcess(IEdcHelpGui edcHelp, String appPath)
        {
            this.CreateProcess(appPath);
            if (this.IsRunning(this.GetProcess()))
            {
                edcHelp.SetViewerDesktopPath(appPath);
            }
        }

        public Process? GetProcess()
        {
            return edcDesktopProcess;
        }

        public void KillDesktopViewer()
        {
            Process[] pname = Process.GetProcessesByName("edc-help-viewer-desktop");

            if (pname.Length > 0)
            {
                foreach (Process process in pname)
                {
                    process.Kill();
                }
            }
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
