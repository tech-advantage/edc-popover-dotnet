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
        /// <summary>
        ///     Create a component which will display the documentation.
        /// </summary>
        /// <param name="mainKey"></param>
        /// <param name="subKey"></param>
        /// <returns></returns>
        UIElement CreateComponent(String mainKey, String subKey);

        /// <summary>
        ///     Create a component which will display the documentation.
        /// </summary>
        /// <param name="mainKey"></param>
        /// <param name="subKey"></param>
        /// <param name="iconPath"></param>
        /// <returns></returns>
        UIElement CreateComponent(String mainKey, String subKey, String iconPath);

        /// <summary>
        ///     Create a Mouse Listener which will manage the mouse event to display the documentation
        /// </summary>
        /// <param name="mainKey"></param>
        /// <param name="subKey"></param>
        /// <returns></returns>
        IMouseListener GetMouseListener(String mainKey, String subKey);

        /// <summary>
        ///     Define the background color for the component summary
        /// </summary>
        /// <param name="backgroundColor"></param>
        void SetBackgroundColor(Brush backgroundColor);

        /// <summary>
        ///     Define the separator color for the title component
        /// </summary>
        /// <param name="separatorColor"></param>
        void SetSeparatorColor(Brush separatorColor);

        /// <summary>
        ///     Define the color of the popover title section
        /// </summary>
        /// <param name="titleColor"></param>
        void SetPopoverSectionTitleColor(SolidColorBrush titleColor);

        /// <summary>
        ///    Define the fonts attributes
        /// </summary>
        /// <param name="fontAttr"></param>
        void SetPopoverSectionTitleFont(FontAttributes fontAttr);

        /// <summary>
        ///     Define the color of the popover title section
        /// </summary>
        /// <param name="titleColor"></param>
        void SetHeaderTitleColor(SolidColorBrush titleColor);

        /// <summary>
        ///     Define the fonts attributes
        /// </summary>
        /// <param name="fontAttr"></param>
        void SetHeaderTitleFont(FontAttributes fontAttr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="titleColor"></param>
        void SetPopoverLinksColor(SolidColorBrush titleColor);

        /// <summary>
        ///     Define the fonts attributes
        /// </summary>
        /// <param name="fontAttr"></param>
        void SetPopoverLinksFont(FontAttributes fontAttr);

        /// <summary>
        ///     Define component description color
        /// </summary>
        /// <param name="descColor"></param>
        void SetPopoverDescriptionColor(SolidColorBrush descColor);

        /// <summary>
        ///     Define the fonts attributes
        /// </summary>
        /// <param name="fontAttr"></param>
        void SetPopoverDescriptionFont(FontAttributes fontAttr);
    }
}
