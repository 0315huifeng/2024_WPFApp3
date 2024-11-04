using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace _2024_WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> drinks = new Dictionary<string, int>
        {
            {"紅茶大杯" ,60},
            {"紅茶小杯" ,30},
            {"綠茶大杯" ,55},
            {"綠茶小杯" ,35},
            {"奶茶大杯" ,70},
            {"奶茶小杯" ,60},
        };
        public MainWindow()
        {
            InitializeComponent();

            DisplayDrinksMenu(drinks);
        }

        private void DisplayDrinksMenu(Dictionary<string, int> drinks)
        {
            stackpanel_DrinkMenu.Children.Clear();
            stackpanel_DrinkMenu.Height = drinks.Count * 40;
            foreach (var drink in drinks)
            {
                var sp = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(2),
                    Height =35,
                    VerticalAlignment = VerticalAlignment.Center,
                    Background = Brushes.AliceBlue,
                };

                var cb = new CheckBox
                {
                    Content = $"{drink.Key} {drink.Value}元",
                    FontFamily = new FontFamily("微軟正黑體"),
                    FontSize = 18,
                    Foreground = Brushes.Blue,
                    Margin = new Thickness (10,0,40,0),
                    VerticalContentAlignment = VerticalAlignment.Center,
                };

                var sl = new Slider
                {
                    Width = 150,
                    Value = 0,
                    Minimum = 0,
                    Maximum = 10,
                    IsSnapToTickEnabled = true,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                var lb = new Label
                {
                    Width = 30,
                    Content = 0,
                    FontFamily = new FontFamily("微軟正黑體"),
                    FontSize = 18,
                };

                Binding mybinding = new Binding("Value")
                {
                    Source = sl,
                    Mode = BindingMode.OneWay,
                };
                lb.SetBinding(ContentProperty, mybinding);

                sp.Children.Add(cb);
                sp.Children.Add(sl);
                sp.Children.Add(lb);
                stackpanel_DrinkMenu.Children.Add(sp);
            }
        }
    }
}