using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Broobu.Fx.UI.Utils
{
    public class ImageSourceHelper
    {
        public static BitmapSource GetBitmapSource(Bitmap image)
        {
            Bitmap bitmap = image;
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
        }
    }
}