using System;
using System.Windows;
using System.Windows.Input;

namespace edc_popover_dotnet.src.gui
{
    public interface IMouseListener
    {
        public void MouseClicked(object sender, RoutedEventArgs e);
        public void MouseEntered(object sender, MouseEventArgs e);
    }
}