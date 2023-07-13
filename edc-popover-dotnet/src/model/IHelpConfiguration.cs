using System;
using Brush = System.Windows.Media.Brush;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using System.Windows.Media;

namespace edc_popover_dotnet.src.internalImpl.model
{
    public interface IHelpConfiguration
    {
        /// <summary>
        ///     <para>GET: The icon path.</para>
        ///     SET: Define the icon path
        /// </summary>
        /// <returns>the icon path</returns>
        String IconPath { get; set; }

        /// <summary>
        ///     <para>GET: the icon dark mode path.</para>
        ///     SET: Define the icon dark mode path
        /// </summary>
        /// <returns>the icon dark mode path</returns>
        String IconDarkModePath { get; set; }

        /// <summary>
        ///     <para>GET: the close icon path.</para>
        ///     SET: Define the close icon path
        /// </summary>
        /// <returns>the close icon path</returns>
        String CloseIconPath { get; set; }

        /// <summary>
        ///     <para>GET: the error icon path.</para>
        ///     SET: Define the error icon path
        /// </summary>
        /// <returns>the error icon path</returns>
        String ErrorIconPath { get; set; }

        /// <summary>
        ///     <para>GET: the language code.</para>
        ///     SET: Define the language code
        /// </summary>
        /// <returns>the language code</returns>
        String LanguageCode { get; set; }

        /// <summary>
        ///     <para>GET: the tooltip label.</para>
        ///     SET: Define the tooltip label
        /// </summary>
        /// <returns>the tooltip label</returns>
        String TooltipLabel { get; set; }

        /// <summary>
        ///     <para>GET: the status for the summary display of the help.</para>
        ///     SET: Define the status
        /// </summary>
        /// <returns>the state</returns>
        Boolean PopoverDisplay { get; set; }

        /// <summary>
        ///     If true, the popover will be displayed when the mouse is hover it
        ///     <para>GET: the state</para>
        /// </summary>
        /// <param name="enable">the new state to set</param>
        /// <returns>true if enable</returns>
        Boolean HoverDisplayPopover { get;  set; }

        /// <summary>
        ///     <para>GET => The title visibility</para>
        ///     Set the visibility of the title
        /// </summary>
        /// <param name="enable">the visibility status to set</param>
        /// <returns>true if visible</returns>
        Boolean ShowTitle { get;  set; }

        /// <summary>
        ///     <para>GET => The state of the related topics</para>
        ///     Set the visibility of the related topics
        /// </summary>
        /// <param name="enable">the visibility status to set</param>
        /// <returns>true if enable</returns>
        Boolean ShowRelatedTopics { get; set; }

        /// <summary>
        ///     <para>GET => The state of the article visibility</para>
        ///     Set the visibility of the article
        /// </summary>
        /// <param name="enable">the visibility status to set</param>
        /// <returns>true if enable</returns>
        Boolean ShowArticle { get; set; }

        /// <summary>
        ///     <para>GET: the background color.</para>
        ///     SET: Define the background color
        /// </summary>
        /// <returns>the background color</returns>
        Brush BackgroundColor { get; set; }

        /// <summary>
        ///     <para>GET => The state of the separator visibility</para>
        ///     Set the visibility of the separator
        /// </summary>
        /// <param name="enable">the visibility status to set</param>
        /// <returns>true if visible</returns>
        Boolean ShowSeparator { get; set; }

        /// <summary>
        ///     <para>GET: the Separator color.</para>
        ///     SET: Define the Separator color
        /// </summary>
        /// <returns>the Separator color</returns>
        Brush SeparatorColor { get; set; }

        /// <summary>
        ///     <para>GET: the selected viewer type between : SYSTEM_BROWSER, EDC_DESKTOP_VIEWER</para>
        ///     SET: Define the selected viewer type
        /// </summary>
        /// <returns>the selected viewer</returns>
        HelpViewer HelpViewer { get; set; }

        /// <summary>
        ///     <para>GET: the path of the executable</para>
        ///     SET: Define the path of the executable
        /// </summary>
        /// <returns>the path of the executable</returns>
        String ViewerDesktopPath { get; set; }

        /// <summary>
        ///     <para>GET: the url of viewer desktop server</para>
        ///     SET: Define the url of viewer desktop server
        /// </summary>
        /// <returns>the url of viewer desktop server</returns>
        String ViewerDesktopServerUrl { get; set; }

        /// <summary>
        ///     <para>GET: the viewer desktop window width</para>
        ///     SET: viewer desktop window width
        /// </summary>
        /// <returns>the viewer desktop window width</returns>
        int ViewerDesktopWidth { get; set; }

        /// <summary>
        ///     <para>GET: the viewer desktop window height</para>
        ///     SET: viewer desktop window height
        /// </summary>
        /// <returns>the viewer desktop window height</returns>
        int ViewerDesktopHeight { get; set; }

        /// <summary>
        ///     <para>GET: the selected Popover placement between : TOP, RIGHT, BOTTOM, LEFT</para>
        ///     SET: Define the Popover placement
        /// </summary>
        /// <returns>the Popover placement</returns>
        PopoverPlacement PopoverPlacement { get; set; }

        /// <summary>
        ///     <para>GET: the error behavior</para>
        ///     SET: Define the error behavior
        /// </summary>
        /// <returns>the error behavior</returns>
        ErrorBehavior ErrorBehavior { get; set; }

        /// <summary>
        ///     <para>GET: the icon state</para>
        ///     SET: Define the icon state
        /// </summary>
        /// <returns>the icon state</returns>
        IconState IconState { get; set; }

        /// <summary>
        ///     Return true if darkMode is enable
        /// </summary>
        /// <returns>true if enable</returns>
        Boolean DarkMode { get; set; }

        /// <summary>
        ///     <para>GET: Return true if enable</para>
        ///     SET: Set the visibility of the tooltip
        /// </summary>
        /// <param name="showTooltip">the visibility status to set</param>
        Boolean ShowTooltip { get; set; }

        /// <summary>
        ///     <para>GET: the font attributes of the popover section title</para>
        ///     SET: Define the font attributes of the popover section title
        /// </summary>
        /// <returns>the font attributes</returns>
        FontAttributes PopoverSectionTitleFont { get; set; }

        /// <summary>
        ///     <para>GET: the popover section title color</para>
        ///     SET: Define the popover section title color
        /// </summary>
        /// <returns>the popover section title color</returns>
        SolidColorBrush PopoverSectionTitleColor { get; set; }

        /// <summary>
        ///     <para>GET: the font attributes of the header title</para>
        ///     SET: Define the font attributes of the header title
        /// </summary>
        /// <returns>the font attributes of the header title</returns>
        FontAttributes? HeaderTitleFont { get; set; }

        /// <summary>
        ///     <para>GET: the popover links color</para>
        ///     SET: Define the popover links color
        /// </summary>
        /// <returns>the popover links color</returns>
        SolidColorBrush PopoverLinksColor { get; set; }

        /// <summary>
        ///     <para>GET: the font attributes of the popover links</para>
        ///     SET: Define the font attributes of the popover links
        /// </summary>
        /// <returns>the popover links fonts</returns>
        FontAttributes PopoverLinksFont { get; set; }

        /// <summary>
        ///     <para>GET: the font attributes of the popover description</para>
        ///     SET: Define the font attributes of the popover description
        /// </summary>
        /// <returns>the popover description fonts</returns>
        FontAttributes PopoverDescriptionFont { get; set; }

        /// <summary>
        ///     <para>GET: the header title color</para>
        ///     SET: Define the header title color
        /// </summary>
        /// <returns>the popover description color</returns>
        SolidColorBrush PopoverDescriptionColor { get; set; }

        /// <summary>
        ///     <para>GET: the header title color</para>
        ///     SET: Define the header title color
        /// </summary>
        /// <returns>the header title color</returns>
        SolidColorBrush HeaderTitleColor { get; set; }
    }
}