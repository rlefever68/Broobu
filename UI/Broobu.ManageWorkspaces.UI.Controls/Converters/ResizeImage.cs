using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Pms.ManageWorkspaces.UI.Controls.Converters
{
    class ResizeImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CreateResizedImage(value as byte[]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CreateResizedImage(value as byte[]);
        }

        /// <summary>
        /// Creates a new ImageSource with the specified width/height
        /// </summary>
        /// <param name="source">Source image to resize</param>
        /// <returns>Resized image</returns>
        private byte[] CreateResizedImage(byte[] source)
        {
            System.Drawing.Image img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(source));
            System.Drawing.Image thumbnailImage = img.GetThumbnailImage(18, 18, null, new System.IntPtr());
            var ms = new MemoryStream();
            thumbnailImage.Save(ms,ImageFormat.Png);
            var mstream1 = new MemoryStream(ms.ToArray(), 0, System.Convert.ToInt32(ms.Length));
            thumbnailImage.Save(mstream1, ImageFormat.Png);
            return mstream1.ToArray();
        }

    }
}
