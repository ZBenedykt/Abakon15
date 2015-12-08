using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Abakon15WPF.Utility
{
    public static class ImageUtility
    {
        //http://wrb.home.xs4all.nl/Articles/Article_WPFButtonImage_01.htm
        public static Image ImageFromResource(string sFileName, int iImageWidth)
        {
            System.Windows.Controls.Image oImage = new Image();
            oImage.Width = iImageWidth;
            oImage.Margin = new Thickness(0);
            oImage.SnapsToDevicePixels = true;

            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            Uri mUri = new Uri("pack://application:,,,/Images/" + sFileName, UriKind.Absolute);
            bi.UriSource = mUri;
            // In order to preserve aspect ratio, set DecodePixelWidth
            // or DecodePixelHeight but not both.
            bi.DecodePixelWidth = iImageWidth;
            bi.EndInit();

            oImage.Source = bi;
            return oImage;
        }
    }
}
