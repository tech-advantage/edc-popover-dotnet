using edc_popover_dotnet.src.internalImpl.model;

namespace edc_popover_dotnet.src.internalImpl
{
    public class EdcHelpImpl : IEdcHelp
    {
        private readonly IHelpConfiguration helpConfiguration;

        public EdcHelpImpl(IHelpConfiguration helpConfiguration)
        {
            this.helpConfiguration = helpConfiguration;
        }

        public HelpViewer GetHelpViewer()
        {
            return helpConfiguration.HelpViewer;
        }

        public void SetArticleDisplay(bool enable)
        {
            helpConfiguration.ShowArticle = enable;
        }

        public void SetCloseIconPath(string iconPath)
        {
            helpConfiguration.CloseIconPath = iconPath;
        }

        public void SetErrorBehavior(ErrorBehavior errorBehavior)
        {
            helpConfiguration.ErrorBehavior = errorBehavior;
        }

        public void SetErrorIconPath(string iconPath)
        {
            helpConfiguration.ErrorIconPath = iconPath;
        }

        public void SetHelpViewer(HelpViewer viewer)
        {
            helpConfiguration.HelpViewer = viewer;
        }

        public void SetHoverDisplayPopover(bool enable)
        {
            helpConfiguration.HoverDisplayPopover = enable;
        }

        public void SetIconPath(string iconPath)
        {
            helpConfiguration.IconPath = iconPath;
        }

        public void SetIconDarkModePath(string iconPath)
        {
            helpConfiguration.IconDarkModePath = iconPath;
        }

        public void SetIconState(IconState iconState)
        {
            helpConfiguration.IconState = iconState;
        }

        public void SetLanguageCode(string languageCode)
        {
            helpConfiguration.LanguageCode = languageCode;
        }

        public void SetPopoverDisplay(bool enable)
        {
            helpConfiguration.PopoverDisplay = enable;
        }

        public void SetPopoverPlacement(PopoverPlacement popoverPlacement)
        {
            helpConfiguration.PopoverPlacement = popoverPlacement;
        }

        public void SetRelatedTopicsDisplay(bool enable)
        {
            helpConfiguration.ShowRelatedTopics = enable;
        }

        public void SetSeparatorDisplay(bool enable)
        {
            helpConfiguration.ShowSeparator = enable;
        }

        public void SetTitleDisplay(bool enable)
        {
            helpConfiguration.ShowTitle = enable;
        }

        public void SetTooltipDisplay(bool enable)
        {
            helpConfiguration.ShowTooltip = enable;
        }

        public void SetTooltipLabel(string label)
        {
            helpConfiguration.TooltipLabel = label;
        }

        public void SetViewerDesktopPath(string path)
        {
            helpConfiguration.ViewerDesktopPath = path;
        }

        public void SetViewerDesktopServerURL(string url)
        {
            helpConfiguration.ViewerDesktopServerUrl = url;
        }

        public void SetDarkMode(bool enable)
        {
            helpConfiguration.DarkMode = enable;
        }

        protected IHelpConfiguration GetHelpConfiguration()
        {
            return helpConfiguration;
        }
    }
}
