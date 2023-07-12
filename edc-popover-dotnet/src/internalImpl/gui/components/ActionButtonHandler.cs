using edc_popover_dotnet.src.builder;
using edc_popover_dotnet.src.gui;
using edc_popover_dotnet.src.internalImpl.model;
using edc_popover_dotnet.src.utils;
using edcClientDotnet;
using edcClientDotnet.model;
using NLog;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace edc_popover_dotnet.src.internalImpl.gui.components
{
    public class ActionButtonHandler : IHelpListener
    {
        private string? mainKey;
        private string? subKey;

        private readonly IEdcClient? edcClient;
        private readonly IHelpConfiguration? helpConfiguration;
        private readonly IContextualContentComponentBuilder<UIElement>? contextualContentComponentBuilder;
        private readonly IContextualTitleComponentBuilder<UIElement>? contextualTitleComponentBuilder;
        private readonly Popover? popover;
        private readonly OpenUrlAction? openUrlAction;
        private IContextItem? contextItem;
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public ActionButtonHandler(IEdcClient edcClient,
            IHelpConfiguration helpConfiguration,
            IContextualContentComponentBuilder<UIElement> contextualContentComponentBuilder,
            IContextualTitleComponentBuilder<UIElement> contextualTitleComponentBuilder,
            Popover popover,
            OpenUrlAction openUrlAction)
        {
            this.edcClient = edcClient;
            this.helpConfiguration = helpConfiguration;
            this.contextualContentComponentBuilder = contextualContentComponentBuilder;
            this.contextualTitleComponentBuilder = contextualTitleComponentBuilder;
            this.popover = popover;
            this.openUrlAction = openUrlAction;
        }

        public void SetKeys(string mainKey, string subKey)
        {
            this.mainKey = mainKey;
            this.subKey = subKey;

            try
            {
                contextItem = edcClient.GetContextItem(mainKey, subKey, helpConfiguration.LanguageCode);
            }
            catch (IOException)
            {
                _logger.Error("Impossible to get the context item for key ({}, {}) and languageCode: {}", mainKey, subKey, helpConfiguration.LanguageCode);
            }
        }

        public void MouseClicked(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;

            // Get the mouse position relative to the button
            Point position = Mouse.GetPosition(button);
            
            Point pointToScreen = button.PointToScreen(position);

            double x = pointToScreen.X; // X coordinate
            double y = pointToScreen.Y;

            if (contextItem == null && helpConfiguration.IconState == IconState.DISABLED)
            {
                return;
            }
            else
            {
                if (helpConfiguration.PopoverDisplay)
                {
                    OpenPopover(x, y);
                }
                else
                {
                    if (!helpConfiguration.HoverDisplayPopover)
                    {
                        OpenBrowser();
                    }
                    if (!String.IsNullOrEmpty(helpConfiguration.ViewerDesktopServerUrl))
                    {
                        _logger.Error("\r\nUnable to open browser with this option, please choose edcHelpViewer option");
                    }
                    else
                    {
                        OpenBrowser();
                    }

                }
            }
        }

        public void MouseEntered(object sender, MouseEventArgs e)
        {
            if (contextItem == null && helpConfiguration.IconState == IconState.DISABLED)
            {
                return;
            }
            else
            {
                if (helpConfiguration.HoverDisplayPopover)
                {
                    var button = e.OriginalSource as Button;
                    OpenPopover((int)button.PointToScreen(new Point(button.ActualWidth, button.ActualHeight)).X, (int)button.PointToScreen(new Point(button.ActualWidth, button.ActualHeight)).Y);
                }
            }
        }

        private void OpenBrowser()
        {
            String url = "";
            try
            {
                url = edcClient.GetContextWebHelpUrl(mainKey, subKey, this.helpConfiguration.LanguageCode);
                openUrlAction.OpenUrl(url);
            }
            catch (InvalidUrlException e)
            {
                _logger.Error("Impossible to get the url for key ({}, {}) and languageCode: {}", mainKey, subKey, this.helpConfiguration.LanguageCode);
            }
            catch (IOException e)
            {
                _logger.Error("Error on IO", e);
            }
        }

        private void OpenPopover(double x, double y)
        {
            try
            {
                IContextItem? contextItem = edcClient.GetContextItem(mainKey, subKey, helpConfiguration.LanguageCode);
                
                if (contextItem != null || helpConfiguration.ErrorBehavior != ErrorBehavior.NO_POPOVER)
                {
                    UIElement bodyComponent = contextualContentComponentBuilder
                            .SetContextItem(contextItem)
                            .SetBackgroundColor(new SolidColorBrush(((SolidColorBrush)helpConfiguration.BackgroundColor).Color))
                            .SetErrorBehavior(helpConfiguration.ErrorBehavior)
                            .SetLanguageCode(helpConfiguration.LanguageCode)
                            .SetPopoverSectionTitleColor(helpConfiguration.PopoverSectionTitleColor)
                            .SetPopoverSectionTitleFont(helpConfiguration.PopoverSectionTitleFont)
                            .SetPopoverLinksColor(helpConfiguration.PopoverLinksColor)
                            .SetPopoverLinksFont(helpConfiguration.PopoverLinksFont)
                            .SetPopoverDescriptionColor(helpConfiguration.PopoverDescriptionColor)
                            .SetPopoverDescriptionFont(helpConfiguration.PopoverDescriptionFont)
                            .EnableArticle(helpConfiguration.ShowArticle)
                            .EnableRelatedTopics(helpConfiguration.ShowRelatedTopics)
                            .Build();
                    UIElement titleComponent = contextualTitleComponentBuilder
                            .SetContextItem(contextItem)
                            .SetBackgroundColor(new SolidColorBrush(((SolidColorBrush)helpConfiguration.BackgroundColor).Color))
                            .SetLanguageCode(helpConfiguration.LanguageCode)
                            .SetHeaderTitleFont(helpConfiguration.HeaderTitleFont)
                            .SetShowTitle(helpConfiguration.ShowTitle)
                            .SetHeaderTitleColor(helpConfiguration.HeaderTitleColor)
                            .SetRectangleSeparator(helpConfiguration.ShowSeparator)
                            .SetRectangleSeparatorColor(helpConfiguration.SeparatorColor)
                            .Build();

                    SolidColorBrush bgColor = new(((SolidColorBrush)helpConfiguration.BackgroundColor).Color);

                    popover.SetContentBackground(helpConfiguration.BackgroundColor);
                    popover.SetPopoverPlacement(helpConfiguration.PopoverPlacement);

                    popover.Clear();
                    popover.AddHeaderPanel();
                    popover.SetShowTooltip(helpConfiguration.ShowTooltip);
                    popover.SetTitle(titleComponent);

                    popover.Add(bodyComponent);

                    popover.SetIconPath(helpConfiguration.CloseIconPath);

                    popover.UpdateLayout();
                    popover.SizeToContent = SizeToContent.WidthAndHeight;

                    popover.Visibility = Visibility.Visible;
                    Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        popover.SetLocation(x, y);
                    });

                    if (helpConfiguration.HoverDisplayPopover)
                    {
                        popover.EnableCloseOnLostFocus();
                        popover.CloseOnMouseClickOutside();
                    }
                    else
                    {
                        popover.CloseOnMouseClickOutside();
                    }
                }
                if (contextItem == null && helpConfiguration.ErrorBehavior == ErrorBehavior.FRIENDLY_MSG)
                {
                    popover.RemoveHeaderPanel();
                }
            }
            catch (InvalidUrlException)
            {
                _logger.Error("Impossible to get the context item for key ({}, {}) and languageCode: {}", mainKey, subKey, helpConfiguration.LanguageCode);
            }
        }
    }
}