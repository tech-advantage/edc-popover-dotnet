using edc_popover_dotnet.src.builder;
using edc_popover_dotnet.src.internalImpl.gui.components;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using edc_popover_dotnet.src.internalImpl.model;
using edc_popover_dotnet.src.utils;
using edcClientDotnet;
using edcClientDotnet.model;
using NLog;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static edc_popover_dotnet.src.internalImpl.gui.builder.ContextualComponentBuilderImpl;

namespace edc_popover_dotnet.src.components
{
    public class IconButton : Button
    {
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();
        public IconButton(String label, ImageIconCreator image)
        {
            this.Background = Brushes.Transparent;
            this.BorderThickness = new Thickness(0, 0, 0, 0);
            this.ToolTip = label;
            this.Content = image;
        }
    }
}
