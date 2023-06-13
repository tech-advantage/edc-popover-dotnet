using edc_popover_dotnet.factory;
using edc_popover_dotnet.src.builder;
using edc_popover_dotnet.src.gui;
using edc_popover_dotnet.src.Gui;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using edc_popover_dotnet.src.internalImpl.model;
using edcClientDotnet;
using NLog;
using System;
using System.Windows;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;

namespace edc_popover_dotnet.src.internalImpl.gui
{
    public class EdcHelpGuiImpl : EdcHelpImpl, IEdcHelpGui
    {
        private readonly IEdcClient edcClient;
        private readonly IContextualComponentBuilder<UIElement> contextualComponentBuilder;
        private readonly IHelpListenerFactory helpListenerFactory;
        private bool enableContextItem = false;
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public EdcHelpGuiImpl(
            IEdcClient edc,
            IContextualComponentBuilder<UIElement> contextualComponentBuilder,
            IHelpConfiguration helpConfiguration,
            IHelpListenerFactory helpListenerFactory
        ) : base(helpConfiguration)
        {
            this.edcClient = edc;
            this.contextualComponentBuilder = contextualComponentBuilder;
            this.helpListenerFactory = helpListenerFactory;
        }

        public UIElement CreateComponent(string mainKey, string subKey, string iconPath)
        {
            IHelpConfiguration helpConfiguration = GetHelpConfiguration();
            String languageCode = helpConfiguration.LanguageCode;

            try
            {
                enableContextItem = edcClient.GetContextItem(mainKey, subKey, languageCode) != null;

            }
            catch (Exception e)
            {
                _logger.Error("Impossible to get the context item for key ({}, {}) and languageCode: {}, error: {}", mainKey, subKey, languageCode, e);
            }
            UIElement component = contextualComponentBuilder
                .SetKeys(mainKey, subKey, languageCode)
                .SetErrorBehavior(helpConfiguration.ErrorBehavior)
                .SetIconState(helpConfiguration.IconState)
                .SetEnableContextItem(enableContextItem)
                .SetDarkMode(helpConfiguration.DarkMode)
                .SetIconDarkModePath(helpConfiguration.IconDarkModePath)
                .SetIconPath(iconPath)
                .SetErrorIconPath(helpConfiguration.ErrorIconPath)
                .SetLabel(helpConfiguration.TooltipLabel)
                .ShowTooltip(helpConfiguration.ShowTooltip)
                .Build();

            return component;
        }

        public UIElement CreateComponent(string mainKey, string subKey)
        {

            IHelpConfiguration helpConfiguration = GetHelpConfiguration();

            return CreateComponent(mainKey, subKey, helpConfiguration.IconPath);
        }

        public IMouseListener GetMouseListener(string mainKey, string subKey)
        {
            IHelpListener helpListener = helpListenerFactory.Create();
            helpListener.SetKeys(mainKey, subKey);
            return helpListener;
        }

        public void SetBackgroundColor(Brush backgroundColor)
        {
            GetHelpConfiguration().BackgroundColor = backgroundColor;
        }

        public void SetSeparatorColor(Brush separatorColor)
        {
            GetHelpConfiguration().SeparatorColor = separatorColor;
        }

        public void SetHeaderTitleFontAttributes(FontAttributes fontAttr)
        {
            GetHelpConfiguration().HeaderTitleFontAttributes = fontAttr;
        }

        public void SetPopoverSectionTitleColor(SolidColorBrush titleColor)
        {
            GetHelpConfiguration().PopoverSectionTitleColor = titleColor;
        }

        public void ViewerDesktopServerURL(string host)
        {
            GetHelpConfiguration().ViewerDesktopServerUrl = host;
        }

        public void PopoverSectionTitleFont(FontAttributes fontAttr)
        {
            GetHelpConfiguration().PopoverSectionTitleFont = fontAttr;
        }

        public void SetHeaderTitleColor(SolidColorBrush titleColor)
        {
            GetHelpConfiguration().HeaderTitleColor = titleColor;
        }
    }
}
