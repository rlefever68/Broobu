using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wulka.Core;

namespace Broobu.Fx.UI.Utils
{
    public static class ImageUtils
    {
        /// <summary>
        ///     Gets the bitmap image from bytes.
        /// </summary>
        /// <param name="imageBytes">The image bytes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static BitmapImage GetBitmapImageFromBytes(byte[] imageBytes)
        {
            var rslt = new BitmapImage
            {
                StreamSource = ResourceUtil.ConvertByteArrayToStream(imageBytes)
            };
            return rslt;
        }

        /// <summary>
        ///     Gets the bitmap image from bytes.
        /// </summary>
        /// <param name="imageBytes">The image bytes.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static BitmapImage GetBitmapImageFromBytes(byte[] imageBytes, int width, int height)
        {
            var rslt = new BitmapImage();
            var sOut = new MemoryStream();
            Image img = GetImageFromBytes(imageBytes);
            Bitmap bmp = ResizeBitmap(img, width, height);
            bmp.Save(sOut, ImageFormat.Png);
            rslt.StreamSource = sOut;
            return rslt;
        }


        /// <summary>
        ///     Resizes the bitmap.
        /// </summary>
        /// <param name="sourceBMP">The source BMP.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static Bitmap ResizeBitmap(Image sourceBMP, int width, int height)
        {
            var result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, width, height);
            return result;
        }


        /// <summary>
        ///     Gets the image from bytes.
        /// </summary>
        /// <param name="imageBytes">The image bytes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Image GetImageFromBytes(byte[] imageBytes)
        {
            return Image.FromStream(ResourceUtil.ConvertByteArrayToStream(imageBytes));
        }


        /// <summary>
        ///     Gets the embedded image.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Bitmap GetEmbeddedImage(Type type, string fileName)
        {
            Stream str = ResourceUtil.GetEmbeddedFile(type, fileName);
            return new Bitmap(str);
        }

        /// <summary>
        ///     Bytes the array to image source.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static ImageSource ByteArrayToImageSource(byte[] value)
        {
            var img = new BitmapImage();
            using (var stream = new MemoryStream(value))
            {
                img.StreamSource = stream;
            }
            return img;
        }
    }
}