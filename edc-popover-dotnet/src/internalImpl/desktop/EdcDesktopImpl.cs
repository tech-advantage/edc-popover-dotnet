using edc_popover_dotnet.src.desktop;
using edc_popover_dotnet.src.Gui;
using edc_popover_dotnet.src.internalImpl.model;
using NLog;
using System;
using System.Diagnostics;
using System.IO;

namespace edc_popover_dotnet.src.internalImpl.desktop
{
    public class EdcDesktopImpl : IEdcDesktop
    {
        private Process? edcDesktopProcess;
        private String desktopViewerApiPath = "http://localhost:60000";
        private IHelpConfiguration helpConfiguration;
        private readonly IHttpRestRequest httpRestRequest;
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public EdcDesktopImpl(IHelpConfiguration helpConfiguration, IHttpRestRequest httpRestRequest)
        {
            this.helpConfiguration = helpConfiguration;
            this.httpRestRequest = httpRestRequest;
        }

        private void CreateProcess(string programPath)
        {
            if (edcDesktopProcess == null || !IsRunning(edcDesktopProcess))
            {
                try
                {
                    edcDesktopProcess = new Process();
                    edcDesktopProcess.StartInfo.FileName = programPath;
                    string arguments = "app " + helpConfiguration.ViewerDesktopWidth.ToString() + " " + helpConfiguration.ViewerDesktopHeight.ToString();
                    edcDesktopProcess.StartInfo.Arguments = arguments;
                    edcDesktopProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(programPath);
                    edcDesktopProcess.Start();
                    _logger.Info("The process edc-help-viewer-desktop.exe is started.");
                }
                catch (Exception ex)
                {
                    _logger.Error("The edc-help-viewer-desktop.exe was not found. Please retry with the correct path.");
                    throw new IOException("The edc-help-viewer-desktop.exe was not found. Please retry with the correct path or remove the content of viewerDesktopPath variable if you're not using the desktop viewer", ex);
                }
                
            }
        }

        public void ConfigureDesktopProcess(IEdcHelpGui edcHelp, String appPath)
        {
            CreateProcess(appPath);
            if (IsRunning(GetProcess()))
            {
                edcHelp.SetViewerDesktopPath(appPath);
            }
        }

        public Process? GetProcess()
        {
            return edcDesktopProcess;
        }

        public void ShutDownDesktopViewer()
        {
            if(helpConfiguration.HelpViewer == HelpViewer.EDC_DESKTOP_VIEWER)
            {
                httpRestRequest.PostData(helpConfiguration.ViewerDesktopServerUrl, "api/helpviewer/shutdown", "{\"shutDown\": true}");
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

        public String GetDesktopViewerUrlApi()
        {
            if (!String.IsNullOrEmpty(helpConfiguration.ViewerDesktopServerUrl))
            {
                desktopViewerApiPath = helpConfiguration.ViewerDesktopServerUrl;
            }
            return desktopViewerApiPath;
        }
    }
}
