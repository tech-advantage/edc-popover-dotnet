using edc_popover_dotnet.src.builder;
using edc_popover_dotnet.src.internalImpl.model;
using edc_popover_dotnet.src.utils;
using edcClientDotnet;
using edcClientDotnet.model;
using NLog;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using edcClientDotnet.utils;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using FontFamilyMedia = System.Windows.Media.FontFamily;
using edc_popover_dotnet.src.internalImpl.gui.components;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;

namespace edc_popover_dotnet.src.internalImpl.gui.builder
{
    public class ContextualContentComponentBuilderImpl : IContextualContentComponentBuilder<UIElement>
    {
        private readonly IEdcClient edcClient;
        private readonly OpenUrlAction openUrlAction;
        private readonly Popover popover;
        private IContextItem contextItem;
        private Brush backgroundColor;
        private ErrorBehavior errorBehavior;
        private String labelError = "Error";
        private String friendlyMessage = "Contextual help is coming soon.";
        private String errorMessage = "An error occurred when fetching data ! n\\Check the brick keys provided to the EdcHelp component.";
        private String languageCode = "en";
        private bool enableRelatedTopics = true;
        private SolidColorBrush popoverSectionTitleColor = new SolidColorBrush(Colors.Black);
        private FontAttributes popoverSectionTitleFont = new(new FontFamilyMedia("Arial"), 12, FontWeights.Bold);
        private SolidColorBrush popoverLinksColor = new SolidColorBrush(Colors.Blue);
        private FontAttributes popoverLinksFont = new(new FontFamilyMedia("Arial"), 12, FontWeights.Normal);
        private SolidColorBrush popoverDescriptionColor = new SolidColorBrush(Colors.Black);
        private FontAttributes popoverDescriptionFont = new(new FontFamilyMedia("Arial"), 12, FontWeights.Normal);
        private bool enableArticle = true;
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public ContextualContentComponentBuilderImpl(IEdcClient edcClient, Popover popover, OpenUrlAction openUrlAction)
        {
            this.edcClient = edcClient;
            this.openUrlAction = openUrlAction;
            this.popover = popover;
            _logger.Info("Starting now");
        }

        public IContextualContentComponentBuilder<UIElement> EnableArticle(bool enable)
        {
            this.enableArticle = enable;
            _logger.Debug("Enable Article: {}", enableArticle);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> EnableRelatedTopics(bool enable)
        {
            this.enableRelatedTopics = enable;
            _logger.Debug("Enable Related Topics: {}", enableRelatedTopics);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetBackgroundColor(Brush rgbColor)
        {
            this.backgroundColor = new SolidColorBrush(((SolidColorBrush)rgbColor).Color);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetContextItem(IContextItem contextItem)
        {
            this.contextItem = contextItem;
            _logger.Debug("Set Context Item: {}", contextItem);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetErrorBehavior(ErrorBehavior errorBehavior)
        {
            this.errorBehavior = errorBehavior;
            _logger.Debug("Set Error Behavior: {}", errorBehavior);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetLanguageCode(string languageCode)
        {
            this.languageCode = languageCode;
            _logger.Debug("Set Language Code: {}", languageCode);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetPopoverSectionTitleColor(SolidColorBrush titleColor)
        {
            this.popoverSectionTitleColor = titleColor;
            _logger.Debug("Set Popover Section Title Color: {}", popoverSectionTitleColor);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetPopoverSectionTitleFont(FontAttributes fontAttr)
        {
            this.popoverSectionTitleFont = fontAttr;
            _logger.Debug("Set Popover Section Title Font: {}", popoverSectionTitleFont);
            return this;
        }

        private String GetLabel(String key, String languageCode, String publicationId)
        {

            _logger.Debug("Getting label translation for key {}, language code: {}, publication id {}", key, languageCode, publicationId);
            return this.edcClient.GetLabel(key, languageCode, publicationId);
        }

        private String GetError(String key, String languageCode, String publicationId)
        {
            _logger.Debug("Getting error translation for key {}, language code: {}, publication id {}", key, languageCode, publicationId);
            return this.edcClient.GetError(key, languageCode, publicationId);
        }

        public IContextualContentComponentBuilder<UIElement> SetPopoverLinksColor(SolidColorBrush linksColor)
        {
            this.popoverLinksColor = linksColor;
            _logger.Debug("Set Popover links color: {}", linksColor);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetPopoverLinksFont(FontAttributes fontAttr)
        {
            this.popoverLinksFont = fontAttr;
            _logger.Debug("Set Popover links Font: {}", popoverLinksFont);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetPopoverDescriptionColor(SolidColorBrush descColor)
        {
            this.popoverDescriptionColor = descColor;
            _logger.Debug("Set Popover description color: {}", popoverDescriptionColor);
            return this;
        }

        public IContextualContentComponentBuilder<UIElement> SetPopoverDescriptionFont(FontAttributes fontAttr)
        {
            this.popoverDescriptionFont = fontAttr;
            _logger.Debug("Set Popover description Font: {}", popoverDescriptionFont);
            return this;
        }

        public UIElement Build()
        {
            _logger.Debug("Build the context item: {}", contextItem != null ? contextItem.Label : "null");
            Panel container = new StackPanel();

            try
            {
                if (contextItem != null)
                {
                    container.Children.Add(GetHeader());
                    container.Children.Add(GetBody());
                }
                else
                {
                    if (container.Children.Contains(GetHeader()))
                    {
                        container.Children.Remove(GetHeader());
                    }

                    container.Children.Add(GetBody());
                }
            }
            catch (Exception)
            {
                try
                {
                    container.Children.Remove(GetHeader());
                    container.Children.Add(GetFailure());
                }
                catch (InvalidUrlException err)
                {
                    _logger.Error("Error during the get failure method creation", err);
                }
            }
            return container;
        }
        private UIElement GetHeader()
        {
            Label label = new();
            if (contextItem != null)
            {
                label.Content = contextItem.Description;
                label.Foreground = popoverDescriptionColor;
                label.FontFamily = popoverDescriptionFont.FontFamily;
                label.FontSize = popoverDescriptionFont.FontSize;
                label.FontWeight = popoverDescriptionFont.FontWeight;
            }
            return label;
        }

        private void OpenUrl(String url)
        {
            try
            {
                openUrlAction.OpenUrl(url);
                popover.Visibility = Visibility.Hidden;
            }
            catch (Exception e)
            {
                _logger.Error("Error", e);
            }
        }

        private Button CreateButton(String url, String label)
        {
            Button linkText = new();
            Run run1 = new(label);
            Hyperlink hyperl = new(run1);
            linkText.BorderThickness = new Thickness(0, 0, 0, 0);
            linkText.Margin = new Thickness(0, 6, 0, 0);
            linkText.Foreground = popoverLinksColor;
            linkText.Background = backgroundColor;
            linkText.FontFamily = popoverLinksFont.FontFamily;
            linkText.FontSize = popoverLinksFont.FontSize;
            linkText.FontWeight = popoverLinksFont.FontWeight;
            linkText.BorderBrush = Brushes.Transparent;
            linkText.Content = hyperl;
            linkText.HorizontalAlignment = HorizontalAlignment.Left;
            linkText.Cursor = Cursors.Hand;
            linkText.Click += (sender, e) =>
            {
                OpenUrl(url);
            };
            return linkText;
        }

        private UIElement GetBody()
        {
            Panel body = new StackPanel();
            body.VerticalAlignment = VerticalAlignment.Bottom;
            body.HorizontalAlignment = HorizontalAlignment.Left;
            if (contextItem != null)
            {
                _logger.Debug("article size: {}", contextItem.ArticleSize());
                if (this.enableArticle && contextItem.ArticleSize() != 0)
                {
                    StackPanel articlePanel = new()
                    {
                        Background = this.backgroundColor,
                        Margin = new Thickness(0, 4, 0, 0)
                    };

                    Label title = new()
                    {
                        Content = GetLabel(ParseEnumDescription.GetDescription(I18NTranslation.ARTICLES_KEY), contextItem.LanguageCode, contextItem.PublicationId),
                        Foreground = popoverSectionTitleColor,
                        FontFamily = popoverSectionTitleFont.FontFamily,
                        FontSize = popoverSectionTitleFont.FontSize,
                        FontWeight = popoverSectionTitleFont.FontWeight
                    };
                    articlePanel.Children.Add(title);
                    StackPanel articleContentPanel = new() { Margin = new Thickness(10, -6, 0, 6) };
                    articlePanel.Children.Add(articleContentPanel);

                    int i = 0;

                    foreach (IDocumentationItem documentationItem in contextItem.GetArticles())
                    {
                        _logger.Debug("Display article: {}", documentationItem);
                        String url = edcClient.GetContextWebHelpUrl(contextItem.MainKey, contextItem.SubKey, i++, contextItem.LanguageCode);
                        articleContentPanel.Children.Add(CreateButton(url, documentationItem.Label));
                    }
                    body.Children.Add(articlePanel);
                }
                _logger.Debug("link size: {}", contextItem.LinkSize());
                if (this.enableRelatedTopics && contextItem.LinkSize() != 0)
                {
                    StackPanel linkPanel = new()
                    {
                        Margin = new Thickness(0, 5, 0, 0),
                        Background = this.backgroundColor
                    };

                    Label title = new()
                    {
                        Foreground = popoverSectionTitleColor,
                        FontFamily = popoverSectionTitleFont.FontFamily,
                        FontSize = popoverSectionTitleFont.FontSize,
                        FontWeight = popoverSectionTitleFont.FontWeight,
                        Content = GetLabel(ParseEnumDescription.GetDescription(I18NTranslation.LINKS_KEY), contextItem.LanguageCode, contextItem.PublicationId)
                    };

                    linkPanel.Children.Add(title);

                    StackPanel linkContentPanel = new()
                    {
                        Margin = new Thickness(10, -6, 0, 6),
                        Background = this.backgroundColor
                    };

                    linkPanel.Children.Add(linkContentPanel);

                    foreach (IDocumentationItem documentationItem in contextItem.GetLinks())
                    {
                        _logger.Debug("Display link: {}", documentationItem);
                        String url = edcClient.GetDocumentationWebHelpUrl(documentationItem.ObjectId, contextItem.LanguageCode, contextItem.PublicationId);
                        linkContentPanel.Children.Add(CreateButton(url, documentationItem.Label));
                    }
                    body.Children.Add(linkPanel);
                }
            }
            else
            {
                body.Children.Add(GetFailure());
            }
            return body;
        }

        private UIElement GetFailure()
        {
            Label titleLabel = new();
            TextBlock errorText = new();

            String comingSoon = GetLabel(ParseEnumDescription.GetDescription(I18NTranslation.COMING_SOON_KEY), languageCode, null);
            String failedData = GetError(ParseEnumDescription.GetDescription(I18NTranslation.ERRORS_KEY), languageCode, null);

            if (errorBehavior == ErrorBehavior.ERROR_SHOWN)
            {
                if (!String.IsNullOrEmpty(failedData))
                {
                    errorMessage = failedData;
                }
                labelError = errorMessage;
            }

            if (errorBehavior == ErrorBehavior.FRIENDLY_MSG)
            {
                if (!String.IsNullOrEmpty(comingSoon))
                {
                    friendlyMessage = comingSoon;
                }
                labelError = friendlyMessage;
            }
            errorText.Text = labelError;
            titleLabel.Content = errorText;
            titleLabel.HorizontalAlignment = HorizontalAlignment.Center;
            titleLabel.VerticalAlignment = VerticalAlignment.Center;

            return titleLabel;
        }

        
    }
}
