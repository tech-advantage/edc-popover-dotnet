using edc_popover_dotnet.src.builder;
using edc_popover_dotnet.src.internalImpl.model;
using edcClientDotnet;
using edcClientDotnet.model;
using NLog;
using System;
using System.Windows;
using System.Windows.Controls;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Media;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using System.Windows.Shapes;
using edcClientDotnet.utils;

namespace edc_popover_dotnet.src.internalImpl.gui.builder
{
    public class ContextualTitleComponentBuilderImpl : IContextualTitleComponentBuilder<UIElement>
    {
        private readonly IEdcClient edcClient;
        private IContextItem contextItem;
        private bool showTitle = true;
        private Brush backgroundColor;
        private ErrorBehavior errorBehavior;
        private String languageCode = "en";
        private String errorTitle = "Error";
        private SolidColorBrush titleColor = new SolidColorBrush(Colors.Black);
        private FontAttributes? headerTitleFont;
        private bool rectangleSeparator = true;
        private Brush rectangleSeparatorColor = Brushes.Red;
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public ContextualTitleComponentBuilderImpl(IEdcClient edcClient)
        {
            this.edcClient = edcClient;
        }

        public IContextualTitleComponentBuilder<UIElement> SetContextItem(IContextItem? contextItem)
        {
            this.contextItem = contextItem;
            _logger.Debug("Set Context Item: {}", contextItem);
            return this;
        }

        public IContextualTitleComponentBuilder<UIElement> SetBackgroundColor(Brush rgbColor)
        {
            Brush color = new SolidColorBrush(((SolidColorBrush)rgbColor).Color);
            this.backgroundColor = color;
            _logger.Debug("Set Background Color: {}", backgroundColor);
            return this;
        }

        public IContextualTitleComponentBuilder<UIElement> SetErrorBehavior(ErrorBehavior errorBehavior)
        {
            this.errorBehavior = errorBehavior;
            _logger.Debug("Set Error Behavior: {}", errorBehavior);
            return this;
        }

        public IContextualTitleComponentBuilder<UIElement> SetHeaderTitleColor(SolidColorBrush titleColor)
        {
            this.titleColor = titleColor;
            _logger.Debug("Set Header Title Color: {}", titleColor);
            return this;
        }

        public IContextualTitleComponentBuilder<UIElement> SetHeaderTitleFont(FontAttributes fontAttr)
        {
            this.headerTitleFont = fontAttr;
            _logger.Debug("Set Header Font Attributes: {}", fontAttr);
            return this;
        }

        public IContextualTitleComponentBuilder<UIElement> SetLanguageCode(string languageCode)
        {
        
            this.languageCode = languageCode;
            _logger.Debug("Set Language Code: {}", languageCode);
            return this;
        }

        public IContextualTitleComponentBuilder<UIElement> SetShowTitle(bool enable)
        {
            this.showTitle = enable;
            _logger.Debug("Set Show Title: {}", showTitle);
            return this;
        }

        public IContextualTitleComponentBuilder<UIElement> SetRectangleSeparator(bool enable)
        {
            this.rectangleSeparator = enable;
            _logger.Debug("Set Show Separator: {}", rectangleSeparator);
            return this;
        }

        public IContextualTitleComponentBuilder<UIElement> SetRectangleSeparatorColor(Brush color)
        {
            this.rectangleSeparatorColor = color;
            _logger.Debug("Set Separator Color: {}", rectangleSeparatorColor);
            return this;
        }


        public UIElement Build()
        {
            _logger.Debug("Build the context item: {}", contextItem != null ? contextItem.Label : "null");

            StackPanel container = new() 
            {
                Background = backgroundColor
            };

            try
            {
                container.Children.Add(GetBody());
                container.Margin = new Thickness(6, 0, 6, 6);
                if (showTitle)
                {
                    Rectangle rectangle = new()
                    {
                        Height = 2,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Fill = this.rectangleSeparatorColor
                    };
                    if (this.rectangleSeparator)
                    {
                        container.Children.Add(rectangle);
                    }
                }
                
            }
            catch (InvalidUrlException e) {
                _logger.Error("Error during the body creation", e);
            }

            return container;
        }
        

        private UIElement GetBody()
        {
            String errorTitleFromLanguage = GetLabel(ParseEnumDescription.GetDescription(I18NTranslation.ERROR_TITLE_KEY), languageCode, null);
            Label titleLabel = new();
            if (this.showTitle)
            {
                if (errorBehavior == ErrorBehavior.ERROR_SHOWN)
                {
                    if (!String.IsNullOrEmpty(errorTitleFromLanguage))
                    {
                        errorTitle = errorTitleFromLanguage;
                    }
                    titleLabel.Content = errorTitle;
                }


                if (contextItem != null)
                {
                    titleLabel.Content = contextItem.Label;
                }

                if (headerTitleFont != null)
                {
                    titleLabel.FontFamily = headerTitleFont.FontFamily;
                    titleLabel.FontWeight = headerTitleFont.FontWeight;
                    titleLabel.FontSize = headerTitleFont.FontSize;
                }
                titleLabel.Foreground = titleColor;
            }
            
            return titleLabel;
        }

        private String GetLabel(String key, String languageCode, String publicationId) {
            _logger.Debug("Getting label translation for key {}, language code: {}, publication id {}", key, languageCode, publicationId);
            return this.edcClient.GetLabel(key, languageCode, publicationId);
        }
    }
}
