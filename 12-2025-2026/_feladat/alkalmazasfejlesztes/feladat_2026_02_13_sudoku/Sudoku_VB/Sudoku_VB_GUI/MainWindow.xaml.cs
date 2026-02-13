using System.Windows;
using System.Windows.Controls;

namespace Sudoku_VB_GUI
{
    public partial class MainWindow : Window
    {
        private int meret = 4;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (meret > 4)
            {
                meret--;
                txtMeret.Text = meret.ToString();
            }
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (meret < 9)
            {
                meret++;
                txtMeret.Text = meret.ToString();
            }
        }

        private void TxtKezdoAllapot_TextChanged(object sender, TextChangedEventArgs e)
        {
            int hossz = txtKezdoAllapot.Text.Length;
            lblHossz.Text = $"Hossz: {hossz}";
        }

        private void BtnEllenorzes_Click(object sender, RoutedEventArgs e)
        {
            int kellHossz = meret * meret;
            int ténylegesHossz = txtKezdoAllapot.Text.Length;

            if (ténylegesHossz == kellHossz)
            {
                MessageBox.Show("A feladvány megfelelő hosszúságú!", "Ellenőrzés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (ténylegesHossz < kellHossz)
            {
                int hianyzo = kellHossz - ténylegesHossz;
                MessageBox.Show($"A feladvány rövid: kell még {hianyzo} számjegy!", "Ellenőrzés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int tobblet = ténylegesHossz - kellHossz;
                MessageBox.Show($"A feladvány hosszú: törlendő {tobblet} számjegy!", "Ellenőrzés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}