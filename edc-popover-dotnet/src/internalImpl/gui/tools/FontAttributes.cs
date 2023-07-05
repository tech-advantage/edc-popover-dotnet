using System;
using System.Windows;
using System.Windows.Media;

namespace edc_popover_dotnet.src.internalImpl.gui.tools
{
    public class FontAttributes
    {
        private FontFamily fontFamily;
        private Double fontSize;
        private FontWeight fontWeight;

        public FontAttributes(FontFamily fontFamily, double fontSize, FontWeight fontWeight)
        {
            this.fontFamily = fontFamily;
            this.fontSize = fontSize;
            this.fontWeight = fontWeight;
        }

        public FontFamily FontFamily { get => fontFamily; set => fontFamily = value; }
        public double FontSize { get => fontSize; set => fontSize = value; }
        public FontWeight FontWeight { get => fontWeight; set => fontWeight = value; }
    }
}
