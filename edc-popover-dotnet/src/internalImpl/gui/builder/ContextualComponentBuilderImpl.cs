using edc_popover_dotnet.factory;
using edc_popover_dotnet.src.builder;
using edc_popover_dotnet.src.components;
using edc_popover_dotnet.src.gui;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using edc_popover_dotnet.src.internalImpl.model;
using NLog;
using System;
using System.Windows;
using System.Windows.Media;

namespace edc_popover_dotnet.src.internalImpl.gui.builder
{
    public class ContextualComponentBuilderImpl : IContextualComponentBuilder<UIElement>
    {
        private String? mainKey;
        private String? subKey;
        private String? languageCode;
        private String? label = "help";
        private String? iconPath;
        private String? iconDarkModePath;
        private String? errorIconPath;
        private ErrorBehavior errorBehavior;
        private IconState iconState;
        private bool darkMode = false;
        private Boolean enableMainKey;
        private Boolean showTooltip = true;
        private IHelpListenerFactory helpListenerFactory;
        public delegate void IconButtonClickEventHandler(object sender, RoutedEventArgs e);
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public ContextualComponentBuilderImpl(IHelpListenerFactory helpListenerFactory)
        {
            this.helpListenerFactory = helpListenerFactory;
        }

        public IContextualComponentBuilder<UIElement> SetEnableContextItem(bool enable)
        {
            enableMainKey = enable;
            _logger.Debug("Enable Main Key: {} ", enableMainKey);
            return this;
        }

        public IContextualComponentBuilder<UIElement> SetErrorBehavior(ErrorBehavior error)
        {
            errorBehavior = error;
            _logger.Debug("Set Error Behavior: {}", errorBehavior);
            return this;
        }

        public IContextualComponentBuilder<UIElement> SetErrorIconPath(string path)
        {
            errorIconPath = path;
            _logger.Debug("Set Error Icon Path: {}", errorIconPath);
            return this;
        }

        public IContextualComponentBuilder<UIElement> SetIconPath(string path)
        {
            iconPath = path;
            _logger.Debug("Set Icon Path: {}", iconPath);
            return this;
        }

        public IContextualComponentBuilder<UIElement> SetIconState(IconState state)
        {
            iconState = state;
            _logger.Debug("Set Icon State: {}", iconState);
            return this;
        }

        public IContextualComponentBuilder<UIElement> SetKeys(string mainKey, string subKey, string languageCode)
        {
            this.mainKey = mainKey;
            this.subKey = subKey;
            this.languageCode = languageCode;
            _logger.Debug("Set Keys: {}, {}, {}", mainKey, subKey, languageCode);
            return this;
        }

        public IContextualComponentBuilder<UIElement> SetLabel(string label)
        {
            this.label = label;
            _logger.Debug("Set Label: {}", label);
            return this;
        }

        public IContextualComponentBuilder<UIElement> ShowTooltip(bool enable)
        {
            showTooltip = enable;
            _logger.Debug("Show Tooltip: {}", showTooltip);
            return this;
        }

        public IContextualComponentBuilder<UIElement> SetDarkMode(bool enable)
        {
            darkMode = enable;
            _logger.Debug("Enable DarkMode: {}", enable);
            return this;
        }

        public IContextualComponentBuilder<UIElement> SetIconDarkModePath(string iconPath)
        {
            iconDarkModePath = iconPath;
            _logger.Debug("Enable DarkMode: {}", iconPath);
            return this;
        }

        public UIElement Build()
        {
            ImageIconCreator image = new ImageIconCreator(errorBehavior == ErrorBehavior.NO_POPOVER && !enableMainKey ||
                        iconState == IconState.HIDDEN && !enableMainKey ?
                        "" : iconState == IconState.ERROR && !enableMainKey ?
                        errorIconPath : darkMode == true ? iconDarkModePath : iconPath
            , Stretch.None, enableMainKey, iconState);

            IHelpListener helpListener = helpListenerFactory.Create();
            helpListener.SetKeys(mainKey, subKey);
            IconButton iconButton = new(showTooltip ? label : null, image);
            
            iconButton.Click += helpListener.MouseClicked;
            iconButton.MouseEnter += helpListener.MouseEntered;
           
            return iconButton;
        }
    }
}







