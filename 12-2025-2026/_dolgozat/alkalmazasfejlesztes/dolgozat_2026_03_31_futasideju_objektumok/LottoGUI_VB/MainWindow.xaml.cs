using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LottoGUI_VB
{
    public partial class MainWindow : Window
    {
        private int _maxNumber;
        private int _drawnCount;
        private int _rows;
        private int _columns;
        private readonly List<Label> _selectedLabels = new();

        public MainWindow()
        {
            InitializeComponent();
            BuildGrid();
        }

        private void GameModeChange_Click(object sender, RoutedEventArgs e)
        {
            BuildGrid();
        }

        private void BuildGrid()
        {
            if (gridNumbers == null)
            {
                return;
            }

            if (rbOtos.IsChecked == true)
            {
                _maxNumber = 90;
                _drawnCount = 5;
                _rows = 9;
                _columns = 10;
            }
            else if (rbHatos.IsChecked == true)
            {
                _maxNumber = 45;
                _drawnCount = 6;
                _rows = 5;
                _columns = 9;
            }
            else //ilyenkor csak a skandináv lehet
            {
                _maxNumber = 35;
                _drawnCount = 7;
                _rows = 5;
                _columns = 7;
            }

            _selectedLabels.Clear();
            gridNumbers.Rows = _rows;
            gridNumbers.Columns = _columns;
            gridNumbers.Children.Clear();

            for (int i = 1; i <= _maxNumber; i++)
            {
                Label label = new Label
                {
                    Content = i.ToString(),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Background = Brushes.White,
                    Margin = new Thickness(1),
                    MinWidth = 30,
                    MinHeight = 25
                };

                label.MouseDown += Label_MouseDown;
                gridNumbers.Children.Add(label);
            }

            btnRoll.IsEnabled = false;
            tbDrawn.Visibility = Visibility.Collapsed;
            tbResult.Visibility = Visibility.Collapsed;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;

            if (_selectedLabels.Contains(label))
            {
                label.Background = Brushes.White;
                _selectedLabels.Remove(label);
            }
            else
            {
                if (_selectedLabels.Count < _drawnCount)
                {
                    label.Background = Brushes.LightGreen;
                    _selectedLabels.Add(label);
                }
            }

            btnRoll.IsEnabled = _selectedLabels.Count == _drawnCount;
        }

        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            HashSet<int> drawn = new();

            while (drawn.Count < _drawnCount)
            {
                drawn.Add(Random.Shared.Next(1, _maxNumber + 1));
            }

            foreach (Label label in gridNumbers.Children) //kiemeli a húzott számokat
            {
                int num = int.Parse(label.Content.ToString()!);

                if (drawn.Contains(num))
                {
                    if (!_selectedLabels.Contains(label))
                    {
                        label.Background = Brushes.LightGreen;
                    }
                }
            }

            HashSet<int> userNumbers = _selectedLabels
                .Select(x =>
                    int.Parse(x.Content.ToString()!)).ToHashSet();
            int matchedCount = userNumbers.Intersect(drawn).Count();

            IEnumerable<int> sortedDrawn = drawn.OrderBy(x => x);
            tbDrawn.Text = $"A kihúzott számok: {string.Join(", ", sortedDrawn)}";
            tbDrawn.Visibility = Visibility.Visible;
            tbResult.Text = $"Találatok száma: {matchedCount}";
            tbResult.Visibility = Visibility.Visible;

            btnRoll.IsEnabled = false;
        }
    }
}