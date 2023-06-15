using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using edc_popover_dotnet.src.components;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using edc_popover_dotnet.src.internalImpl.model;
using NLog;
using Brush = System.Windows.Media.Brush;

namespace edc_popover_dotnet.src.internalImpl.gui.components
{
    public class Popover : Window
    {
        private readonly static int HORIZONTAL = 1;
        private readonly static int VERTICAL = 0;
        private readonly static int TOP = 0;
        private readonly static int BOTTOM = 1;

        private readonly DockPanel mainPanel;
        private readonly StackPanel headerPanel;
        private readonly StackPanel contentPanel;
        private UIElement? titlePanel;
        private Separator? headerSeparator;
        private String iconPath = "popover/close.png";
        private bool showTooltip = true;
        private readonly int direction = VERTICAL;
        private int closablePosition;
        private UIElement? closableComponent;
        private PopoverPlacement popoverPlacement;
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public void SetPopoverPlacement(PopoverPlacement placement)
        {
            this.popoverPlacement = placement;
        }

        public void SetIconPath(String iconPath)
        {
            if (iconPath != null && !iconPath.Equals(this.iconPath))
            {
                this.iconPath = iconPath;
                SetClosePosition(this.closablePosition);
            }
        }

        public void SetClosePosition(int closePosition)
        {

            if (this.closableComponent != null)
                mainPanel.Children.Remove(this.closableComponent);
            if (closePosition == TOP)
            {
                this.closableComponent = GetHeader();
                this.headerPanel.Children.Add(this.closableComponent);
            }
            else
            {
                this.closableComponent = GetFooter();
                mainPanel.Children.Add(this.closableComponent);
            }
            this.closablePosition = closePosition;
        }

        public void AddHeaderPanel()
        {
            headerSeparator ??= new Separator();
            headerPanel.Children.Clear();
            SetClosePosition(closablePosition);
            DockPanel.SetDock(headerPanel, Dock.Top);
            mainPanel.Children.Remove(this.headerPanel);
            mainPanel.Children.Add(this.headerPanel);
        }

        public void RemoveHeaderPanel()
        {
            if (this.headerSeparator != null)
            {
                this.headerPanel.Children.Remove(headerSeparator);
            }
            if (this.headerPanel != null)
            {
                mainPanel.Children.Remove(this.headerPanel);
            }
        }

        public void SetContentBackground(Brush c)
        {
            _logger.Debug("Define new content background color: {}", c);
            
            mainPanel.Background = new SolidColorBrush(((SolidColorBrush)c).Color);
        }

        public void SetSeparatorColor(Brush c)
        {

            _logger.Debug("Define new content separator color: {}", c);
            if (c != null)
            {
                this.headerSeparator.Foreground = c;
                this.headerSeparator.Background = c;
                this.headerSeparator.Height = 25;
            }
        }
        public void Clear()
        {
            contentPanel.Children.Clear();
        }

        public void SetTitle(UIElement comp)
        {
            if (this.titlePanel != null)
                this.headerPanel.Children.Remove(this.titlePanel);
            if (comp != null)
            {
                this.titlePanel = comp;
                this.headerPanel.Children.Add(this.titlePanel);
            }
        }

        public void SetShowTooltip(bool enable)
        {
            this.showTooltip = enable;
        }

        public Popover()
        {
            closablePosition = TOP;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            Topmost = true;
            Focusable = true;
            SizeToContent = SizeToContent.WidthAndHeight;
            /* Create border around the popover */
            BorderThickness = new Thickness(1, 1, 1, 1);
            BorderBrush = new SolidColorBrush(Color.FromRgb(60, 141, 188));

            mainPanel = new DockPanel();
            headerPanel = new StackPanel();
            
            mainPanel.Children.Add(headerPanel);

            DockPanel.SetDock(headerPanel, Dock.Top);
            contentPanel = new StackPanel();
            contentPanel.Margin = new Thickness(6, 0, 6, 0);
            DockPanel.SetDock(contentPanel, Dock.Bottom);

            mainPanel.Children.Add(contentPanel);
            
            SetClosePosition(closablePosition);
            Content = mainPanel;
            LostFocus += (sender, args) => { Hide(); };
        }

        private UIElement GetHeader()
        {
            StackPanel header = new()
            {
                Background = contentPanel.Background,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            ImageIconCreator imageIcon = new ImageIconCreator(iconPath, Stretch.Uniform);
            
            IconButton closeButton = new(showTooltip ? "Close" : null, imageIcon)
            {
                Margin = new Thickness(2, 8, 8, 0)
            };

            closeButton.Click += (sender, e) => Hide();
            header.Children.Add(closeButton);

            return header;
        }

        public void Add(UIElement comp)
        {
            if (comp != mainPanel)
            {
                _logger.Debug("Add component in the contentPanel inside the popover");
                contentPanel.Children.Add(comp);
            }
        }

        public void EnableCloseOnLostFocus()
        {
            Mouse.AddMouseLeaveHandler(this, HidePopover);
        }

        public void CloseOnMouseClickOutside()
        {
            this.Deactivated += HidePopover;
        }

        public void HidePopover(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private UIElement GetFooter()
        {
            StackPanel header = new()
            {
                Background = contentPanel.Background
            };

            ImageIconCreator imageIcon = new ImageIconCreator(iconPath, Stretch.Uniform);

            IconButton closeButton = new(showTooltip ? "Close" : null, imageIcon);
            closeButton.Click += (sender, e) => Hide();
            header.Children.Add(closeButton);

            return header;
        }

        public void SetLocation(double x, double y)
        {
            double width = Width;
            double height = Height;

            double widthDisplay = SystemParameters.PrimaryScreenWidth;
            double heightDisplay = SystemParameters.PrimaryScreenHeight;

            double newX = x;
            double newY = y;

            int padX = 0;
            int padY = 0;
            bool reverseX = false;
            bool reverseY = false;

            if (direction == HORIZONTAL)
                padY = 5;
            else
                padX = 5;

            if (x + width + padX > widthDisplay)
            {
                newX = x - width;
                reverseX = true;

            }
            if (y + height + padY > heightDisplay)
            {
                newY = y - height;
                reverseY = true;
            }
            if (direction == HORIZONTAL)
                newY += (reverseY ? -padY : padX);
            else
                newX += (reverseX ? -padX : padX);

            Left = newX;
            Top = newY; 
        }
    }
}
