using edc_popover_dotnet.src.internalImpl.gui.tools;
using edc_popover_dotnet.src.internalImpl.model;
using System;

namespace edc_popover_dotnet.src
{
    public interface IEdcHelp
    {
        void SetIconPath(String iconPath);

        void SetIconDarkModePath(String iconPath);

        void SetCloseIconPath(String iconPath);

        void SetErrorIconPath(String iconPath);

        void SetLanguageCode(String languageCode);

        void SetTooltipLabel(String label);

        void SetPopoverDisplay(Boolean enable);

        void SetHoverDisplayPopover(Boolean enable);

        void SetHelpViewer(HelpViewer viewer);

        HelpViewer GetHelpViewer();

        void SetViewerDesktopPath(String path);

        void SetViewerDesktopServerURL(String url);

        void SetPopoverPlacement(PopoverPlacement popoverPlacement);

        void SetTitleDisplay(Boolean enable);

        void SetTooltipDisplay(Boolean enable);

        void SetSeparatorDisplay(Boolean enable);

        void SetErrorBehavior(ErrorBehavior errorBehavior);

        void SetIconState(IconState iconState);

        void SetDarkMode(Boolean enable);

        void SetRelatedTopicsDisplay(Boolean enable);

        void SetPopoverSectionTitleFont(FontAttributes fontAttr);

        void SetArticleDisplay(Boolean enable);
    }
}
