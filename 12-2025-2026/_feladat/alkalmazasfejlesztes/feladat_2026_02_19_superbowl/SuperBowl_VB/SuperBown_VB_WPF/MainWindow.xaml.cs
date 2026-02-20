using System.Windows;
using SuperBowl_VB_Library;

namespace SuperBown_VB_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] romaiak = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIrany_Click(object sender, RoutedEventArgs e)
        {
            tbRomai.Text = "";
            tbArab.Text = "";

            if (btnIrany.Content.ToString() == "--->")
            {
                btnIrany.Content = "<---";
                tbRomai.IsEnabled = false;
                tbArab.IsEnabled = true;
            }
            else
            {
                btnIrany.Content = "--->";
                tbRomai.IsEnabled = true;
                tbArab.IsEnabled = false;
            }
        }

        private void btnAtvalt_Click(object sender, RoutedEventArgs e)
        {
            if (btnIrany.Content.ToString() == "--->")
            {
                string bemenet = tbRomai.Text.Trim().ToUpper();
                if (Array.IndexOf(romaiak, bemenet) > 0)
                {
                    RomaiSorszam rs = new RomaiSorszam(bemenet);
                    tbArab.Text = rs.ArabSorszam.ToString();
                }
                else
                {
                    tbArab.Text = "Hiba!";
                }
            }
            else
            {
                if (int.TryParse(tbArab.Text, out int szam) && szam >= 1 && szam <= 10)
                {
                    tbRomai.Text = romaiak[szam];
                }
                else
                {
                    tbRomai.Text = "Hiba!";
                }
            }
        }
    }
}
