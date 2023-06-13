using edc_popover_dotnet.src.desktop;
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
            checkAndKillDesktopViewer();

            if (edcDesktopProcess == null || !IsRunning(edcDesktopProcess))
            {
                edcDesktopProcess = new Process();
                edcDesktopProcess.StartInfo.FileName = programPath;
                edcDesktopProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(programPath);
                edcDesktopProcess.Start();
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

        private void checkAndKillDesktopViewer()
        {
            Process[] pname = Process.GetProcessesByName("processname");

            if (pname.Length > 0)
            {
                foreach (Process process in pname)
                {
                    process.Kill();
                }
            }
        }

    }
}
