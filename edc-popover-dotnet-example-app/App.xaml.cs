using edc_popover_dotnet.src.desktop;
using edc_popover_dotnet.src.gui;
using edc_popover_dotnet.src.Gui;
using edc_popover_dotnet.src.internalImpl.model;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using edcClientDotnet;

namespace edc_popover_dotnet_example_app
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static String languageCode = "en";
        IEdcDesktop edcDesktop;
        IEdcHelpGui edcHelp;
        IEdcClient edcClient;

        Window mainWindow = new()
        {
            Title = "Edc Popover Demo",
            Width = 400,
            Height = 400,
            Background = Brushes.White,
            BorderThickness = new Thickness(20, 0, 20, 20),
            BorderBrush = Brushes.White
        };

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetupGui(mainWindow);
            mainWindow.Closing += App_Exit;
        }

        void App_Exit(object sender, CancelEventArgs e)
        {
            if (edcDesktop != null)
            {
                edcDesktop.ShutDownDesktopViewer();
            }
        }

        private void SetupGui(Window mainWindow)
        {
            TextBlock titleApp = new();
            String viewerDesktopPath = "";
            HelpViewer helpViewerMode = HelpViewer.SYSTEM_BROWSER;
            String serverUrl = "https://demo.easydoccontents.com";
            
            edcHelp = EdcHelpSingletonGui.GetInstance();
            edcClient = EdcHelpSingletonGui.GetInstance().GetEdcClient();

            

            if (!String.IsNullOrEmpty(viewerDesktopPath) && helpViewerMode == HelpViewer.EDC_DESKTOP_VIEWER)
            {
                // Desktop viewer configuration
                edcHelp.SetViewerDesktopWidth(800);
                edcHelp.SetViewerDesktopHeight(800);
                edcDesktop = EdcHelpSingletonGui.GetInstance().GetEdcDesktop();
                edcDesktop.ConfigureDesktopProcess(edcHelp, viewerDesktopPath);
            }
            
            edcClient.SetServerUrl(serverUrl);
            edcHelp.SetTooltipLabel("Help me");
            edcHelp.SetTitleDisplay(true);
            edcHelp.SetSeparatorDisplay(true);
            edcHelp.SetBackgroundColor(Brushes.White);
            edcHelp.SetPopoverDisplay(true);
            edcHelp.SetHoverDisplayPopover(false);
            edcHelp.SetIconState(IconState.SHOWN);
            edcHelp.SetErrorBehavior(ErrorBehavior.FRIENDLY_MSG);
            edcHelp.SetTooltipDisplay(true);
            edcHelp.SetIconPath("icons/icon-32px.png");
            edcHelp.SetPopoverSectionTitleColor(Brushes.Blue);
            edcHelp.SetHeaderTitleColor(Brushes.Red);
            edcHelp.SetRelatedTopicsDisplay(true);
            edcHelp.SetArticleDisplay(true);
            edcHelp.SetHelpViewer(helpViewerMode);
            edcHelp.SetLanguageCode(languageCode);
            edcHelp.SetDarkMode(false);
            edcHelp.SetIconDarkModePath("icons/icon2-32px.png");
            edcHelp.SetCloseIconPath("popover/close.png");            
            
            /* Design app */
            /* Create the grid */
            Grid mainGrid = new();
            
            // Define the Columns
            ColumnDefinition colDef1 = new() { Width = new GridLength(70, GridUnitType.Star) };
            ColumnDefinition colDef2 = new() { Width = new GridLength(30, GridUnitType.Star) };
            mainGrid.ColumnDefinitions.Add(colDef1);
            mainGrid.ColumnDefinitions.Add(colDef2);

            // Define the Rows
            RowDefinition rowDef1 = new();
            RowDefinition rowDef2 = new();
            RowDefinition rowDef3 = new();
            RowDefinition rowDef4 = new();
            mainGrid.RowDefinitions.Add(rowDef1);
            mainGrid.RowDefinitions.Add(rowDef2);
            mainGrid.RowDefinitions.Add(rowDef3);
            mainGrid.RowDefinitions.Add(rowDef4);

            /* Header Panel */
            StackPanel headerPanel = new();

            titleApp.Text = "Popover Demo v1.0";
            titleApp.FontSize = 20;
            titleApp.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./assets/fonts/#Oswald Regular");
            titleApp.HorizontalAlignment = HorizontalAlignment.Center;
            titleApp.VerticalAlignment = VerticalAlignment.Top;

            headerPanel.HorizontalAlignment = HorizontalAlignment.Center;
            headerPanel.VerticalAlignment = VerticalAlignment.Top;
            headerPanel.Margin = new Thickness(0, 10, 0, 0);
            headerPanel.Children.Add(CreateEdcLogo());
            headerPanel.Children.Add(titleApp);

            /* Top Panel to expose the language selector */
            StackPanel langSelectorPanel = new();

            ComboBox langSelect = CreatelangSelector();
            langSelectorPanel.Margin = new Thickness(0, 5, 0, 0);
            langSelectorPanel.HorizontalAlignment = HorizontalAlignment.Center;
            langSelectorPanel.VerticalAlignment = VerticalAlignment.Top;
            langSelectorPanel.Children.Add(langSelect);
            
            WrapPanel wrapHelpIconPanel = new();
            wrapHelpIconPanel.Children.Add(edcHelp.CreateComponent("fr.techad.edc.configuration", "storehouses"));
            wrapHelpIconPanel.Children.Add(edcHelp.CreateComponent("fr.techad.edc.showcase.external", "external.header"));
            
            
            foreach (Button element in wrapHelpIconPanel.Children)
            {
                element.HorizontalAlignment = HorizontalAlignment.Center;
                element.Margin = new Thickness(5, 5, 5, 0);
            }

            /** Button Help Panel **/
            StackPanel helpPanel = new()
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            IMouseListener mouseListener = edcHelp.GetMouseListener("fr.techad.edc.showcase.external", "external.header");
            Button helpButton = new Button();

            helpButton.VerticalAlignment = VerticalAlignment.Center;
            helpButton.Content = "Help Info";
            helpButton.Click += mouseListener.MouseClicked;
            helpButton.MouseEnter += mouseListener.MouseEntered;
            helpButton.Padding = new Thickness(10, 5, 10, 5);
            helpButton.BorderThickness = new Thickness(1);
            helpButton.Background = new SolidColorBrush(Colors.Transparent);

            helpPanel.Children.Add(helpButton);

            Label label = new()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Content = "Click here for help"
            };

            helpPanel.Children.Add(label);
            /** End Button Help Panel **/

            /** Link element **/
            Button linkButton = new();
            Run run1 = new("Storehouse Help");
            Hyperlink hyperl = new(run1);
            linkButton.BorderThickness = new Thickness(0, 0, 0, 0);
            linkButton.Background = new SolidColorBrush(Colors.Transparent);
            linkButton.Content = hyperl;
            linkButton.VerticalAlignment = VerticalAlignment.Bottom;

            Grid.SetRow(headerPanel, 0);
            Grid.SetColumn(headerPanel, 0);
            Grid.SetColumnSpan(headerPanel, 2);
            Grid.SetRow(langSelectorPanel, 1);
            Grid.SetColumn(langSelectorPanel, 1);
            Grid.SetRow(wrapHelpIconPanel, 1);
            Grid.SetColumn(wrapHelpIconPanel, 0);
            Grid.SetRow(helpPanel, 3);
            Grid.SetColumn(helpPanel, 0);
            Grid.SetColumnSpan(helpPanel, 1);
            Grid.SetRow(linkButton, 3);
            Grid.SetColumn(linkButton, 2);

            mainGrid.Children.Add(headerPanel);
            mainGrid.Children.Add(langSelectorPanel);
            mainGrid.Children.Add(wrapHelpIconPanel);
            mainGrid.Children.Add(helpPanel);
            mainGrid.Children.Add(linkButton);

            try
            {
                edcClient.LoadContext();
            }
            catch (IOException ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            mainWindow.Content = mainGrid;
            mainWindow.Show();
        }

        private static ComboBox CreatelangSelector()
        {
            IEdcHelpGui edcHelpGui = EdcHelpSingletonGui.GetInstance();
            String[] langOptions = { "en", "fr", "ru", "vi", "zh", "it", "es" };

            int pos = Array.IndexOf(langOptions, languageCode);
            if (pos == -1)
            {
                pos = 0;
            }

            ComboBox comboBox = new()
            {
                Padding = new Thickness(10, 5, 10, 5),
                ItemsSource = langOptions,
                SelectedIndex = pos
            };

            comboBox.SelectionChanged += (sender, e) =>
            {
                string newLang = (string)comboBox.SelectedItem;
                // Change the language to be used in popover for labels and content
                edcHelpGui.SetLanguageCode(newLang);
            };

            return comboBox;
        }

        private static Image CreateEdcLogo()
        {
            BitmapImage edcLogoBi = new(new Uri(@"assets\edc-logo.png", UriKind.RelativeOrAbsolute));
            Image edcLogo = new()
            {
                Stretch = Stretch.Uniform,
                Height = 50,
                Width = 150,
                Source = edcLogoBi
            };

            return edcLogo;
        }
    }
}
