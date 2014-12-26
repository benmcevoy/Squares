using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Squares
{
    public partial class MainWindow : Window
    {
        // knobs
        private const int SmallSizeOfRect = 16;
        private const int MaxNumberOfRects = 3600;
        private const int AttemptsToFindANonCollidingRect = 1000;
        private const int StrokeThickness = 2;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

            _palleteLength = _pallete.Length;
        }

        private void Squares_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Fill();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;

            Fill();
        }

        private void Fill()
        {
            _squares = new List<Rect>(MaxNumberOfRects);
            Squares.Children.Clear();

            for (var i = 0; i < MaxNumberOfRects; i++)
            {
                AddSquare();
                Debug.WriteLine("Added square: {0} ", i);
            }

            foreach (var square in _squares)
            {
                var rect = new Rectangle
                {
                    Height = square.Height,
                    Width = square.Width,
                    Fill = GetBrush(),
                    Stroke = Brushes.Black,
                    StrokeThickness = StrokeThickness
                };

                rect.SetValue(Canvas.LeftProperty, square.Location.X);
                rect.SetValue(Canvas.TopProperty, square.Location.Y);

                Squares.Children.Add(rect);
            }
        }

        private void AddSquare()
        {
            var attempts = 0;

            while (attempts < AttemptsToFindANonCollidingRect)
            {
                attempts++;
                var candidate = new Rect(GetLocation(), GetSize());

                if (_squares.Any(candidate.IntersectsWith)) continue;

                _squares.Add(candidate);

                return;
            }
            Debug.WriteLine("maxxed out");
        }

        private SolidColorBrush GetBrush()
        {
            return _pallete[Random.Next(0, _palleteLength)];
        }

        private Point GetLocation()
        {
            return new Point((Squares.ActualWidth - SmallSizeOfRect) * Random.NextDouble(), (Squares.ActualHeight - SmallSizeOfRect) * Random.NextDouble());
        }

        private static Size GetSize()
        {
            return new Size(Random.Next(SmallSizeOfRect, MaxLength), Random.Next(SmallSizeOfRect, MaxLength));
        }

        private readonly int _palleteLength;

        private const int MaxLength = (int)(SmallSizeOfRect * 1.61d);
        private static readonly Random Random = new Random();
        private List<Rect> _squares;

        private readonly SolidColorBrush[] _pallete =
        {
            new SolidColorBrush(Colors.AliceBlue),
            new SolidColorBrush(Colors.AntiqueWhite ),
            new SolidColorBrush(Colors.Aqua ),
            new SolidColorBrush(Colors.Aquamarine ),
new SolidColorBrush(Colors.Azure ),
new SolidColorBrush(Colors.Beige ),
new SolidColorBrush(Colors.Bisque ),
//new SolidColorBrush(Colors.Black ),
new SolidColorBrush(Colors.BlanchedAlmond ),
new SolidColorBrush(Colors.Blue ),
new SolidColorBrush(Colors.BlueViolet ),
new SolidColorBrush(Colors.Brown ),
new SolidColorBrush(Colors.BurlyWood ),
new SolidColorBrush(Colors.CadetBlue ),
new SolidColorBrush(Colors.Chartreuse ),
new SolidColorBrush(Colors.Chocolate),
new SolidColorBrush(Colors.Coral ),
new SolidColorBrush(Colors.CornflowerBlue ),
new SolidColorBrush(Colors.Cornsilk ),
new SolidColorBrush(Colors.Crimson ),
new SolidColorBrush(Colors.Cyan ),
new SolidColorBrush(Colors.DarkBlue ),
new SolidColorBrush(Colors.DarkCyan ),
new SolidColorBrush(Colors.DarkGoldenrod ),
new SolidColorBrush(Colors.DarkGray ),
new SolidColorBrush(Colors.DarkGreen ),
new SolidColorBrush(Colors.DarkKhaki ),
new SolidColorBrush(Colors.DarkMagenta ),
new SolidColorBrush(Colors.DarkOliveGreen),
new SolidColorBrush(Colors.DarkOrange ),
new SolidColorBrush(Colors.DarkOrchid ),
new SolidColorBrush(Colors.DarkRed ),
new SolidColorBrush(Colors.DarkSalmon),
new SolidColorBrush(Colors.DarkSeaGreen),
new SolidColorBrush(Colors.DarkSlateBlue),
new SolidColorBrush(Colors.DarkSlateGray ),
new SolidColorBrush(Colors.DarkTurquoise),
new SolidColorBrush(Colors.DarkViolet ),
new SolidColorBrush(Colors.DeepPink ),
new SolidColorBrush(Colors.DeepSkyBlue ),
new SolidColorBrush(Colors.DimGray ),
new SolidColorBrush(Colors.DodgerBlue ),
new SolidColorBrush(Colors.Firebrick ),
new SolidColorBrush(Colors.FloralWhite ),
new SolidColorBrush(Colors.ForestGreen ),
new SolidColorBrush(Colors.Fuchsia ),
new SolidColorBrush(Colors.Gainsboro ),
new SolidColorBrush(Colors.GhostWhite ),
new SolidColorBrush(Colors.Gold ),
new SolidColorBrush(Colors.Goldenrod ),
new SolidColorBrush(Colors.Gray ),
new SolidColorBrush(Colors.Green ),
new SolidColorBrush(Colors.GreenYellow ),
new SolidColorBrush(Colors.Honeydew ),
new SolidColorBrush(Colors.HotPink ),
new SolidColorBrush(Colors.IndianRed ),
new SolidColorBrush(Colors.Indigo ),
new SolidColorBrush(Colors.Ivory ),
new SolidColorBrush(Colors.Khaki ),
new SolidColorBrush(Colors.Lavender ),
new SolidColorBrush(Colors.LavenderBlush ),
new SolidColorBrush(Colors.LawnGreen ),
new SolidColorBrush(Colors.LemonChiffon ),
new SolidColorBrush(Colors.LightBlue ),
new SolidColorBrush(Colors.LightCoral ),
new SolidColorBrush(Colors.LightCyan ),
new SolidColorBrush(Colors.LightGoldenrodYellow ),
new SolidColorBrush(Colors.LightGreen ),
new SolidColorBrush(Colors.LightGray ),
new SolidColorBrush(Colors.LightPink),
new SolidColorBrush(Colors.LightSalmon ),
new SolidColorBrush(Colors.LightSeaGreen ),
new SolidColorBrush(Colors.LightSkyBlue ),
new SolidColorBrush(Colors.LightSlateGray ),
new SolidColorBrush(Colors.LightSteelBlue ),
new SolidColorBrush(Colors.LightYellow ),
new SolidColorBrush(Colors.Lime ),
new SolidColorBrush(Colors.LimeGreen ),
new SolidColorBrush(Colors.Linen ),
new SolidColorBrush(Colors.Magenta ),
new SolidColorBrush(Colors.Maroon ),
new SolidColorBrush(Colors.MediumAquamarine ),
new SolidColorBrush(Colors.MediumBlue),
new SolidColorBrush(Colors.MediumOrchid),
new SolidColorBrush(Colors.MediumPurple ),
new SolidColorBrush(Colors.MediumSeaGreen),
new SolidColorBrush(Colors.MediumSlateBlue ),
new SolidColorBrush(Colors.MediumSpringGreen ),
new SolidColorBrush(Colors.MediumTurquoise),
new SolidColorBrush(Colors.MediumVioletRed ),
new SolidColorBrush(Colors.MidnightBlue ),
new SolidColorBrush(Colors.MintCream),
new SolidColorBrush(Colors.MistyRose ),
new SolidColorBrush(Colors.Moccasin),
new SolidColorBrush(Colors.NavajoWhite),
new SolidColorBrush(Colors.Navy ),
new SolidColorBrush(Colors.OldLace ),
new SolidColorBrush(Colors.Olive ),
new SolidColorBrush(Colors.OliveDrab ),
new SolidColorBrush(Colors.Orange),
new SolidColorBrush(Colors.OrangeRed ),
new SolidColorBrush(Colors.Orchid ),
new SolidColorBrush(Colors.PaleGoldenrod ),
new SolidColorBrush(Colors.PaleGreen ),
new SolidColorBrush(Colors.PaleTurquoise),
new SolidColorBrush(Colors.PaleVioletRed ),
new SolidColorBrush(Colors.PapayaWhip ),
new SolidColorBrush(Colors.PeachPuff ),
new SolidColorBrush(Colors.Peru ),
new SolidColorBrush(Colors.Pink ),
new SolidColorBrush(Colors.Plum ),
new SolidColorBrush(Colors.PowderBlue ),
new SolidColorBrush(Colors.Purple ),
new SolidColorBrush(Colors.Red ),
new SolidColorBrush(Colors.RosyBrown ),
new SolidColorBrush(Colors.RoyalBlue ),
new SolidColorBrush(Colors.SaddleBrown),
new SolidColorBrush(Colors.Salmon ),
new SolidColorBrush(Colors.SandyBrown),
new SolidColorBrush(Colors.SeaGreen),
new SolidColorBrush(Colors.SeaShell ),
new SolidColorBrush(Colors.Sienna ),
new SolidColorBrush(Colors.Silver ),
new SolidColorBrush(Colors.SkyBlue ),
new SolidColorBrush(Colors.SlateBlue),
new SolidColorBrush(Colors.SlateGray ),
new SolidColorBrush(Colors.Snow ),
new SolidColorBrush(Colors.SpringGreen ),
new SolidColorBrush(Colors.SteelBlue),
new SolidColorBrush(Colors.Tan ),
new SolidColorBrush(Colors.Teal),
new SolidColorBrush(Colors.Thistle ),
new SolidColorBrush(Colors.Tomato ),
new SolidColorBrush(Colors.Transparent ),
new SolidColorBrush(Colors.Turquoise),
new SolidColorBrush(Colors.Violet ),
new SolidColorBrush(Colors.Wheat ),
new SolidColorBrush(Colors.White ),
new SolidColorBrush(Colors.WhiteSmoke),
new SolidColorBrush(Colors.Yellow),
new SolidColorBrush(Colors.YellowGreen)
};
    }
}
