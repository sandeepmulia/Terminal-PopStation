using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Terminal.ViewModel;

namespace Terminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;
        private List<Tuple<Rectangle, ColorAnimation>> _priorAnimated = new List<Tuple<Rectangle, ColorAnimation>>();

        public MainWindow(MainWindowViewModel viewModel_)
        {
            viewModel = viewModel_;
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        #region "Main Window Loaded"
        /// <summary>
        /// Core routine to build the grid of lockers and animate them on click.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">eventargs</param>
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int tracker = 0;

            for (int column = 0; column <= viewModel.Columns; ++column)
            {
                TerminalKiosk.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(110) });
                int left = 0, top=0, right=0, bottom=0, rowCounter=0;

                viewModel.Lockers.ToList().ForEach((item) =>
                {
                    if (item.ColumnNo == column)
                    {
                        ++rowCounter;
                    }
                });

                for (int rowcount = 0; rowcount < rowCounter; ++rowcount)
                {
                    //Define a canvas which will hold the Rectangle and Ellipse
                    Canvas container = new Canvas();
                    container.SetValue(Grid.ColumnProperty, column);
                    container.VerticalAlignment = System.Windows.VerticalAlignment.Top;

                    var lockerDepiction = viewModel.Lockers[tracker];

                    Rectangle lockerImage = new Rectangle()
                    {
                        Width = 110,
                        Fill = new SolidColorBrush(Color.FromArgb(255, 255, 107, 0)),
                        StrokeThickness = 0.6,
                        RadiusX = 10,
                        RadiusY = 10,
                        Stretch = System.Windows.Media.Stretch.Fill,
                        Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                        Name = lockerDepiction.Name,
                        ToolTip = lockerDepiction.Name,
                    };
                    lockerImage.SetValue(Grid.ColumnProperty, column);                                

                    Ellipse elock = new Ellipse()
                    {
                        Height = 10,
                        StrokeThickness = 0.6,
                        Width = 10
                    };
                    elock.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    elock.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    elock.SetValue(Grid.ColumnProperty, column);

                    int height = 0;
                    bool bterminal = false;
                    switch (lockerDepiction.Size)
                    {
                        case "Small":
                            {
                                lockerImage.Height = height = 30;
                                container.Height = lockerImage.Height;                                
                                lockerImage.Margin = new Thickness(left, top, right, bottom);
                                elock.Margin = new Thickness(left, top+13, -195, bottom);
                                top = top + height;                                
                            }
                            break;
                        case "Medium":
                            {
                                lockerImage.Height = height = 60;
                                container.Height = lockerImage.Height;
                                lockerImage.Margin = new Thickness(left, top, right, bottom);
                                elock.Margin = new Thickness(left, top + 25, -195, bottom);
                                top = top + height;
                            }
                            break;
                        case "Large":
                            {
                                lockerImage.Height = height = 90;
                                container.Height = lockerImage.Height;
                                lockerImage.Margin = new Thickness(left, top, right, bottom);
                                elock.Margin = new Thickness(left, top + 35, -195, bottom);
                                top = top + height;
                            }
                            break;
                        case "ExtraLarge":
                            {
                                lockerImage.Height = height = 120;
                                container.Height = lockerImage.Height;
                                lockerImage.SetValue(Grid.ColumnProperty, column);                                
                                lockerImage.Margin = new Thickness(left, top, right, bottom);
                                elock.Margin = new Thickness(left, top + 45, -195, bottom);
                                top = top + height;
                            }
                            break;
                        case "Terminal":
                            {
                                //DrawingBrush terminal = Application.Current.Resources["terminal"] as DrawingBrush;
                                ImageBrush terminal = new ImageBrush();
                                terminal.ImageSource = new BitmapImage(new Uri("Resources/ADAM.png", UriKind.Relative));
                                  
                                lockerImage.Height = height = 150; //150/145 for xaml
                                lockerImage.Width = 108;
                                lockerImage.RadiusX = 10;
                                lockerImage.RadiusY = 10;
                                container.Height = lockerImage.Height;
                                lockerImage.Fill = terminal;

                                //override Stroke thickness
                                lockerImage.StrokeThickness = 0;
                                //lockerImage.Margin = new Thickness(-18, top, 40, bottom);
                                lockerImage.Margin = new Thickness(2, top, -10, 0);
                                lockerImage.Stretch = Stretch.Fill;//uniform
                                top = top + height;
                                bterminal = true;
                            }
                            break;
                        default:
                            break;
                    }
                    lockerImage.MouseDown += lockerImage_MouseDown;
                    container.Children.Add(lockerImage);

                    if (!bterminal)
                        container.Children.Add(elock);

                    TerminalKiosk.Children.Add(container);
                    ++tracker;
                }                
            }
        }

        /// <summary>
        /// Mouse Button Left click handler which animates the rectangle
        /// </summary>
        /// <param name="sender">Area from which the event was generated</param>
        /// <param name="e">MouseButton args</param>
        void lockerImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle)
            {
                _priorAnimated.ForEach((item) =>
                {
                    var rect = item.Item1;
                    rect.StrokeThickness = 0.6;
                    rect.Fill.BeginAnimation(SolidColorBrush.ColorProperty, null);
                });

                //Animation
                ColorAnimation animation = new ColorAnimation();

                animation.RepeatBehavior = RepeatBehavior.Forever;
                animation.From = Color.FromArgb(255, 255, 107, 0);
                animation.To = Color.FromArgb(220, 255, 255, 0);
                animation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                animation.FillBehavior = FillBehavior.Stop;

                Rectangle selected = sender as Rectangle;                

                if (selected != null)
                {
                    //Check if terminal was selected
                    if (!selected.Fill.IsFrozen)
                    {
                        selected.StrokeThickness = 2;
                        selected.Fill.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                        _priorAnimated.Add(Tuple.Create((Rectangle)sender, animation));
                    }
                }
            }
        }
        #endregion
    }
}
