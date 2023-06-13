using edc_popover_dotnet.src.internalImpl.model;
using NLog;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace edc_popover_dotnet.src.internalImpl.gui.tools
{
    public class ImageIconCreator : Image
    {
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public ImageIconCreator(String? path, Stretch? stretch)
        {
            CreateImageIcon(path, stretch);
        }

        public ImageIconCreator(String? path, Stretch? stretch, bool enable, IconState state)
        {
            CreateImageIcon(path, stretch);
            if (enable == false && state == IconState.DISABLED)
            {
                this.Opacity = 0.5;
            }
        }

        public Image CreateImageIcon(String? path, Stretch? stretch)
        {
            BitmapImage imageIconBMI = new BitmapImage(new Uri(@"assets\" + path, UriKind.RelativeOrAbsolute));
            if (stretch != Stretch.None)
            {
                this.Stretch = Stretch.Uniform;
                this.Width = 8;
                this.Height = 8;
            }
            else
            {
                this.Stretch = Stretch.None;
            }
            this.Source = imageIconBMI;

            return this;
        }
    }
}
