using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace Broobu.Fx.UI.Utils
{
    public static class ColorUtils
    {
        public static Dictionary<int, string> KnownColorDictionary = Drawing.GetKnownColorDictionary();

        /// <summary>
        ///     Convert between System.Drawing.Color (for GDI+ use) and System.Windows.Media.Color (for WPF use)
        /// </summary>
        public static class Convert
        {
            /// <summary>
            ///     Convert drawing color to media color
            /// </summary>
            /// <param name="drawingColor">System.Drawing.Color</param>
            /// <returns></returns>
            public static Color ToMediaColor(System.Drawing.Color drawingColor)
            {
                return
                    (Color)
                        ColorConverter.ConvertFromString(drawingColor.Name);
            }

            /// <summary>
            ///     Convert media color to drawing color
            /// </summary>
            /// <param name="mediaColor">System.Windows.Media.Color</param>
            /// <returns></returns>
            public static System.Drawing.Color ToDrawingColor(Color mediaColor)
            {
                return System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
            }
        }

        /// <summary>
        ///     The System.Drawing namespace provides access to GDI+ basic graphics functionality.
        ///     More advanced functionality is provided in the System.Drawing.Drawing2D,
        ///     System.Drawing.Imaging, and System.Drawing.Text namespaces.
        /// </summary>
        public static class Drawing
        {
            /// <summary>
            ///     Argb drawing color to int.
            /// </summary>
            /// <param name="wpfColor">Color of the WPF.</param>
            /// <returns></returns>
            public static Int32 ColorToInt(System.Drawing.Color drawingColor)
            {
                System.Drawing.Color dColor = System.Drawing.Color.FromArgb(drawingColor.A, drawingColor.R,
                    drawingColor.G, drawingColor.B);
                return dColor.ToArgb();
            }

            /// <summary>
            ///     Argb drawing color to int.
            /// </summary>
            /// <param name="wpfColor">Color of the WPF.</param>
            /// <returns></returns>
            public static Int32 ArgbToInt(int alpha, int red, int green, int blue)
            {
                System.Drawing.Color dColor = System.Drawing.Color.FromArgb(alpha, red, green, blue);
                return dColor.ToArgb();
            }

            /// <summary>
            ///     Knowns the color to int.
            /// </summary>
            /// <param name="knownColor">Color of the known.</param>
            /// <returns></returns>
            public static Int32 KnownColorToInt(KnownColor knownColor)
            {
                System.Drawing.Color drawingColor = System.Drawing.Color.FromKnownColor(knownColor);
                return ColorToInt(drawingColor);
            }

            /// <summary>
            ///     Ints the color of to known.
            /// </summary>
            /// <param name="colorValue">The color value.</param>
            /// <returns>The known color, if not found returns Transparant</returns>
            public static KnownColor IntToKnownColor(int colorValue)
            {
                if (KnownColorDictionary == null)
                    KnownColorDictionary = GetKnownColorDictionary();

                if (KnownColorDictionary.ContainsKey(colorValue))
                {
                    return
                        (KnownColor)
                            Enum.Parse(typeof (KnownColor), KnownColorDictionary[colorValue]);
                }
                return KnownColor.Transparent;
            }

            /// <summary>
            ///     Ints the color of to knowncolor name.
            /// </summary>
            /// <param name="colorValue">The color value.</param>
            /// <returns>The known color, if not found returns "Unknown"</returns>
            public static string IntToKnownColorName(int colorValue)
            {
                if (KnownColorDictionary == null)
                    KnownColorDictionary = GetKnownColorDictionary();

                string colorName = "Unknown";
                KnownColorDictionary.TryGetValue(colorValue, out colorName);
                return colorName;
            }

            /// <summary>
            ///     Gets or sets the get known color dictionary. Key is the KnownColor name, Value contains the ARGB int Color value.
            /// </summary>
            /// <value>get known color dictionary.</value>
            public static Dictionary<int, string> GetKnownColorDictionary()
            {
                var knownColorDictionary = new Dictionary<int, string>();
                List<string> knownColorName = Enum.GetNames(typeof (KnownColor)).ToList();

                foreach (string name in knownColorName)
                {
                    //cast the colorName into a KnownColor
                    var knownColor = (KnownColor) Enum.Parse(typeof (KnownColor), name);
                    System.Drawing.Color drawingColor = System.Drawing.Color.FromKnownColor(knownColor);
                    //check if the knownColor variable is a System color
                    if (knownColor > KnownColor.Transparent)
                    {
                        int argbValue = drawingColor.ToArgb();
                        if (!knownColorDictionary.ContainsKey(argbValue))
                        {
                            knownColorDictionary.Add(argbValue, name);
                        }
                    }
                }
                knownColorName = null;
                return knownColorDictionary;
            }
        }

        /// <summary>
        ///     Provides types that enable integration of rich media,
        ///     including drawings, text, and audio/video content in Windows Presentation Foundation (WPF) applications.
        /// </summary>
        public static class Media
        {
            /// <summary>
            ///     Media Color to drawing color int
            /// </summary>
            /// <param name="wpfColor">Color of the WPF.</param>
            /// <returns></returns>
            public static Int32 ColorToInt(Color wpfColor)
            {
                System.Drawing.Color drawingColor = System.Drawing.Color.FromArgb(wpfColor.A, wpfColor.R, wpfColor.G,
                    wpfColor.B);
                return drawingColor.ToArgb();
            }

            /// <summary>
            ///     Argb media color to drawing color int.
            /// </summary>
            /// <param name="wpfColor">Color of the WPF.</param>
            /// <returns></returns>
            public static Int32 ArgbToInt(int alpha, int red, int green, int blue)
            {
                System.Drawing.Color drawingColor = System.Drawing.Color.FromArgb(alpha, red, green, blue);
                return drawingColor.ToArgb();
            }

            /// <summary>
            ///     Int to color.
            /// </summary>
            /// <param name="colorValue">The color value.</param>
            /// <returns></returns>
            public static Color IntToColor(int colorValue)
            {
                byte a = 255;
                var r = (byte) (colorValue >> 16);
                var g = (byte) (colorValue >> 8);
                var b = (byte) (colorValue >> 0);
                return Color.FromArgb(a, r, g, b);
            }

            /// <summary>
            ///     Colors the color of the nameto.
            /// </summary>
            /// <param name="colorName">Name of the color.</param>
            /// <returns></returns>
            public static Color KnownColortoColor(KnownColor knownColor)
            {
                var brushConverter = new BrushConverter();
                if (knownColor == KnownColor.ActiveCaption || knownColor == KnownColor.ActiveCaptionText ||
                    knownColor == KnownColor.ActiveBorder || knownColor == KnownColor.InactiveBorder ||
                    knownColor == KnownColor.InactiveCaption || knownColor == KnownColor.InactiveCaptionText)
                {
                    knownColor = KnownColor.Black;
                }
                var brush = brushConverter.ConvertFromString(knownColor.ToString()) as SolidColorBrush;
                return brush != null ? brush.Color : new Color();
            }
        }
    }
}