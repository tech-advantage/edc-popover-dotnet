using edc_popover_dotnet.src.internalImpl.model;
using NLog;
using System;
using System.Diagnostics;
using RestSharp;
using System.IO;

namespace edc_popover_dotnet.src.utils
{
    public class OpenUrlAction
    {
        private readonly IHelpConfiguration helpConfiguration;
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public OpenUrlAction(IHelpConfiguration helpConfiguration) : base()
        {
            this.helpConfiguration = helpConfiguration;
        }

        public void OpenUrl(String url)
        {
            if (helpConfiguration.HelpViewer == HelpViewer.EDC_DESKTOP_VIEWER)
            {
                _logger.Debug("Open the url: {}", url);
                
                HandleDesktopPostRequest(url);
            }
            else if (helpConfiguration.HelpViewer == HelpViewer.SYSTEM_BROWSER)
            {
                if (!String.IsNullOrEmpty(helpConfiguration.ViewerDesktopPath))
                {                   
                    _logger.Error("Unable to open browser with this option, please change HelpViewer.SYSTEM_BROWSER option to HelpViewer.EDC_DESKTOP_VIEWER in application startup configuration settings.");
                    throw new InvalidDataException("The viewerdesktoppath value is not empty, please remove its content if you want to use the browser to view the documentation");
                }
                var sInfo = new ProcessStartInfo(url)
                {
                    UseShellExecute = true,
                };
                Process.Start(sInfo);
            }
            else
            {
                return;
            }
        }

        public void HandleDesktopPostRequest(String url)
        {
            RestClient client = new RestClient(helpConfiguration.ViewerDesktopServerUrl);
            RestRequest request = new RestRequest("api/helpviewer").AddJsonBody("{\"url\":\"" + url + "\"}");
            client.Post(request);
        }
    }
}
