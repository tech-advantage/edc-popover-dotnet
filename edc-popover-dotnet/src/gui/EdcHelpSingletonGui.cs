using edc_popover_dotnet.src.desktop;
using edc_popover_dotnet.src.Gui;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using edc_popover_dotnet.src.internalImpl.model;
using edcClientDotnet;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using BrushMedia = System.Windows.Media.Brush;
using System.Windows.Media;
using edc_popover_dotnet.injection;

namespace edc_popover_dotnet.src.gui
{
    public class EdcHelpSingletonGui : IEdcHelpGui
    {
        private static EdcHelpSingletonGui instance = null;

        private IEdcHelpGui edcHelpGui;

        private IEdcClient edcClient;

        private IDesktopProcess edcDesktop;

        private EdcHelpSingletonGui() : base() { }

        public static EdcHelpSingletonGui GetInstance()
        {
            if (instance == null)
            {
                instance = new EdcHelpSingletonGui();
                instance.Init();
            }
            return instance;
        }

        private void Init()
        {
            edcClientDotnet.Injection.Startup.ConfigureServices();
            IServiceCollection services = edcClientDotnet.Injection.Startup.services;
            Startup.ConfigureServices(services);
            edcHelpGui = Startup.serviceProvider.GetRequiredService<IEdcHelpGui>();
            edcClient = Startup.serviceProvider.GetRequiredService<IEdcClient>();
            edcDesktop = Startup.serviceProvider.GetRequiredService<IDesktopProcess>();
        }

        public IEdcClient GetEdcClient()
        {
            return this.edcClient;
        }

        public IDesktopProcess GetEdcDesktop()
        {
            return this.edcDesktop;
        }

        public UIElement CreateComponent(String mainKey, String subKey)
        {
            return edcHelpGui.CreateComponent(mainKey, subKey);
        }

        public UIElement CreateComponent(String mainKey, String subKey, String iconPath)
        {
            return edcHelpGui.CreateComponent(mainKey, subKey, iconPath);
        }

        public IMouseListener GetMouseListener(String mainKey, String subKey)
        {
            return edcHelpGui.GetMouseListener(mainKey, subKey);
        }

        public void SetArticleDisplay(bool enable)
        {
            edcHelpGui.SetArticleDisplay(enable);
        }

        public void SetCloseIconPath(string iconPath)
        {
            edcHelpGui.SetCloseIconPath(iconPath);
        }

        public void SetErrorIconPath(string iconPath)
        {
            edcHelpGui.SetErrorIconPath(iconPath);
        }

        public void SetHeaderTitleFontAttributes(FontAttributes fontAttr)
        {
            edcHelpGui.SetHeaderTitleFontAttributes(fontAttr);
        }

        public void SetHoverDisplayPopover(bool enable)
        {
            edcHelpGui.SetHoverDisplayPopover(enable);
        }

        public void SetIconPath(string iconPath)
        {
            edcHelpGui.SetIconPath(iconPath);
        }

        public void SetIconDarkModePath(string iconPath)
        {
            edcHelpGui.SetIconDarkModePath(iconPath);
        }

        public void SetLanguageCode(string languageCode)
        {
            edcHelpGui.SetLanguageCode(languageCode);
        }

        public void SetPopoverDisplay(bool enable)
        {
            edcHelpGui.SetPopoverDisplay(enable);
        }

        public void SetPopoverSectionTitleFont(FontAttributes fontAttr)
        {
            edcHelpGui.SetPopoverSectionTitleFont(fontAttr);
        }

        public void SetRelatedTopicsDisplay(bool enable)
        {
            edcHelpGui.SetRelatedTopicsDisplay(enable);
        }

        public void SetSeparatorDisplay(bool enable)
        {
            edcHelpGui.SetSeparatorDisplay(enable);
        }

        public void SetSeparatorColor(BrushMedia color)
        {
            edcHelpGui.SetSeparatorColor(color);
        }

        public void SetTitleDisplay(bool enable)
        {
            edcHelpGui.SetTitleDisplay(enable);
        }

        public void SetTooltipDisplay(bool enable)
        {
            edcHelpGui.SetTooltipDisplay(enable);
        }

        public void SetTooltipLabel(string label)
        {
            edcHelpGui.SetTooltipLabel(label);
        }

        public void SetViewerDesktopPath(string path)
        {
            edcHelpGui.SetViewerDesktopPath(path);
        }

        public void SetViewerDesktopServerURL(string url)
        {
            edcHelpGui.SetViewerDesktopServerURL(url);
        }

        public void SetBackgroundColor(BrushMedia backgroundColor)
        {
            edcHelpGui.SetBackgroundColor(backgroundColor);
        }

        public void SetPopoverSectionTitleColor(SolidColorBrush titleColor)
        {
            edcHelpGui.SetPopoverSectionTitleColor(titleColor);
        }

        public void SetHeaderTitleColor(SolidColorBrush titleColor)
        {
            edcHelpGui.SetHeaderTitleColor(titleColor);
        }

        public void SetHelpViewer(HelpViewer viewer)
        {
            edcHelpGui.SetHelpViewer(viewer);
        }

        public HelpViewer GetHelpViewer()
        {
            return edcHelpGui.GetHelpViewer();
        }

        public void SetPopoverPlacement(PopoverPlacement popoverPlacement)
        {
            edcHelpGui.SetPopoverPlacement(popoverPlacement);
        }

        public void SetErrorBehavior(ErrorBehavior errorBehavior)
        {
            edcHelpGui.SetErrorBehavior(errorBehavior);
        }

        public void SetIconState(IconState iconState)
        {
            edcHelpGui.SetIconState(iconState);
        }

        public void SetDarkMode(Boolean enable)
        {
            edcHelpGui.SetDarkMode(enable);
        }
    }
}
