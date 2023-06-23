using edc_popover_dotnet.src.Gui;
using edcClientDotnet;
using System;
using System.Diagnostics;

namespace edc_popover_dotnet.src.desktop
{
    public interface IDesktopProcess
    {
        /// <summary>
        ///     Create process
        /// </summary>
        /// <param name="path"></param>
        void CreateProcess(String path);

        /// <summary>
        ///     Get process
        /// </summary>
        /// <returns></returns>
        Process? GetProcess();

        /// <summary>
        ///     Check if is running the given process
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        bool IsRunning(Process process);

        /// <summary>
        ///     Configure the desktop process
        /// </summary>
        /// <param name="edcHelp"></param>
        /// <param name="edcClient"></param>
        /// <param name="appPath"></param>
        /// <param name="serverUrl"></param>
        void ConfigureDesktopProcess(IEdcHelpGui edcHelp, IEdcClient edcClient, String appPath, String serverUrl);

        /// <summary>
        ///     Kill the process
        /// </summary>
        void KillProcess();
    }
}
