using edc_popover_dotnet.src.gui;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using System;
using System.Windows;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;

namespace edc_popover_dotnet.src.Gui
{
    public interface IEdcHelpGui : IEdcHelp
    {
        UIElement CreateComponent(String mainKey, String subKey);

        UIElement CreateComponent(String mainKey, String subKey, String iconPath);

        IMouseListener GetMouseListener(String mainKey, String subKey);

        void SetBackgroundColor(Brush backgroundColor);

        void SetSeparatorColor(Brush separatorColor);

        void SetPopoverSectionTitleColor(SolidColorBrush titleColor);

        void SetHeaderTitleColor(SolidColorBrush titleColor);

        void SetHeaderTitleFontAttributes(FontAttributes fontAttr);
    }
}
