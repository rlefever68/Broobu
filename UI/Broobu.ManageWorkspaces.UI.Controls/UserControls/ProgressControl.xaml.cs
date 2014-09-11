using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for ProgressControl.xaml
    /// </summary>
    public partial class ProgressControl : UserControl
    {
        public ProgressControl()
        {
            InitializeComponent();
            drawCanvas();
            canvas2.Visibility = Visibility.Visible;
            var animation=new DoubleAnimation();
            animation.From = 0;
            animation.To = 360;
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.SpeedRatio = 1;
            spin.BeginAnimation(RotateTransform.AngleProperty,animation);

        }


        void drawCanvas()
        {
            for (int i = 0; i < 12; i++)
            {
                Line line = new Line()
                {
                    X1 = 50,
                    X2 = 50,
                    Y1 = 0,
                    Y2 = 20,
                    StrokeThickness = 5,
                    Stroke = Brushes.Gray,
                    Width = 100,
                    Height = 100
                };
                line.VerticalAlignment = VerticalAlignment.Center;
                line.HorizontalAlignment = HorizontalAlignment.Center;
                line.RenderTransformOrigin = new Point(.5, .5);
                line.RenderTransform = new RotateTransform(i * 30);
                line.Opacity = (double)i / 12;
                canvas1.Children.Add(line);
            }
        }
    }
}
