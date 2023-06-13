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

        void KillProcess();
    }
}
