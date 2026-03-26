using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KarakterDekodoloGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Oszlopok = 4;
        private const int Sorok = 7;

        public MainWindow()
        {
            InitializeComponent();
            MatrixLetrehozas();
        }

        private void MatrixLetrehozas()
        {
            for (int col = 0; col < Oszlopok; col++)
            {
                gridMatrix.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int row = 0; row < Sorok; row++)
            {
                gridMatrix.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            for (int row = 0; row < Sorok; row++)
            {
                for (int col = 0; col < Oszlopok; col++)
                {
                    TextBox tb = new()
                    {
                        Text = "0",
                        Width = 40,
                        Height = 35,
                        Margin = new Thickness(2),
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        FontSize = 16,
                        Background = Brushes.White
                    };

                    tb.TextChanged += Mezo_TextChanged;
                    tb.MouseDoubleClick += Mezo_MouseDoubleClick;

                    Grid.SetRow(tb, row);
                    Grid.SetColumn(tb, col);
                    gridMatrix.Children.Add(tb);
                }
            }
        }

        private void Mezo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.Background = tb.Text == "1" ? Brushes.LightGray : Brushes.White;
            }
        }

        private void Mezo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.Text = tb.Text == "0" ? "1" : "0";
            }
        }
    }
}