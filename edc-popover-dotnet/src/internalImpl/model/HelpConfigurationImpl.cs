﻿using edc_popover_dotnet.src.internalImpl.gui.tools;
using System;
using System.Windows;
using System.Windows.Media;
using BrushMedia = System.Windows.Media.Brush;
using FontFamily = System.Windows.Media.FontFamily;

namespace edc_popover_dotnet.src.internalImpl.model
{
    public class HelpConfigurationImpl : IHelpConfiguration
    {
        private String iconPath = "icons/icon-32px.png";
        private String iconDarkModePath = "icons/icon2-32px.png";
        private String closeIconPath = "popover/close.png";
        private String errorIconPath = "icons/icon_exclamation-32px.png";
        private String languageCode = "en";
        private String tooltipLabel = "help";
        private Boolean popoverDisplay = false;
        private Boolean hoverPopoverDisplay = false;
        private BrushMedia backgroundColor;
        private BrushMedia underlineColor;
        private Boolean showTitle = true;
        private ErrorBehavior errorBehavior = ErrorBehavior.FRIENDLY_MSG;
        private IconState iconState = IconState.SHOWN;
        private bool darkMode = false;
        private Boolean showTooltip = true;
        private Boolean showRelatedTopics = true;
        private FontAttributes popoverSectionTitleFont = new(new FontFamily("Arial"), 12, FontWeights.Bold);
        private SolidColorBrush popoverSectionTitleColor = new SolidColorBrush(Colors.Black);
        private Boolean showArticle = true;
        private PopoverPlacement popoverPlacement;
        private Boolean showSeparator = true;
        private Brush separatorColor = Brushes.Red;
        private HelpViewer helpViewer;
        private String desktopViewerPath = "";
        private FontAttributes headerTitleFontAttr = new(new FontFamily("Dialog"), 20, FontWeights.Bold);
        private SolidColorBrush titleColor = new SolidColorBrush(Colors.Black);
        private String viewerDesktopServerURL = "http://localhost:60000";


        public HelpConfigurationImpl()
        {
            Brush rgbColor = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            Brush rgbColorUnderline = new SolidColorBrush(Color.FromRgb(60, 141, 188));
            this.backgroundColor = new SolidColorBrush(((SolidColorBrush)rgbColor).Color);
            this.underlineColor = new SolidColorBrush(((SolidColorBrush)rgbColorUnderline).Color);
        }

        public string IconPath { get => iconPath; set => iconPath = value; }
        public string IconDarkModePath { get => iconDarkModePath; set => iconDarkModePath = value; }
        public string CloseIconPath { get => closeIconPath; set => closeIconPath = value; }
        public string ErrorIconPath { get => errorIconPath; set => errorIconPath = value; }
        public string LanguageCode { get => languageCode; set => languageCode = value; }
        public string TooltipLabel { get => tooltipLabel; set => tooltipLabel = value; }
        public bool PopoverDisplay { get => popoverDisplay; set => popoverDisplay = value; }
        public bool HoverDisplayPopover { get => hoverPopoverDisplay; set => hoverPopoverDisplay = value; }
        public BrushMedia UnderlineColor { get => underlineColor; set => underlineColor = value; }
        public HelpViewer HelpViewer { get => helpViewer; set => helpViewer = value; }
        public string ViewerDesktopPath { get => desktopViewerPath; set => desktopViewerPath = value; }
        public PopoverPlacement PopoverPlacement { get => popoverPlacement; set => popoverPlacement = value; }
        public ErrorBehavior ErrorBehavior { get => errorBehavior; set => errorBehavior = value; }
        public IconState IconState { get => iconState; set => iconState = value; }
        public bool DarkMode { get => darkMode; set => darkMode = value; }
        public FontAttributes PopoverSectionTitleFont { get => popoverSectionTitleFont; set => popoverSectionTitleFont = value; }
        public SolidColorBrush PopoverSectionTitleColor { get => popoverSectionTitleColor; set => popoverSectionTitleColor = value; }
        public FontAttributes HeaderTitleFontAttributes { get => headerTitleFontAttr; set => headerTitleFontAttr = value; }
        public SolidColorBrush HeaderTitleColor { get => titleColor; set => titleColor = value; }
        public BrushMedia BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public string ViewerDesktopServerUrl { get => viewerDesktopServerURL; set => viewerDesktopServerURL = value; }
        public BrushMedia SeparatorColor { get => separatorColor; set => separatorColor = value; }
        public bool ShowRelatedTopics { get => showRelatedTopics; set => showRelatedTopics = value; }
        public bool ShowArticle { get => showArticle; set => showArticle = value; }
        public bool ShowSeparator { get => showSeparator; set => showSeparator = value; }
        public bool ShowTooltip { get => showTooltip; set => showTooltip = value; }
        public bool ShowTitle { get => showTitle; set => showTitle = value; }
    }
}
