using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Tabor_VB_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            cmbSzint.Items.Add("kezdő");
            cmbSzint.Items.Add("középhaladó");
            cmbSzint.Items.Add("haladó");
            cmbSzint.SelectedIndex = 0;

            ResetForm();
        }

        private void CmbSzint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSzint.SelectedItem != null)
            {
                LoadLanguages();
            }
        }

        private void LoadLanguages()
        {
            cmbNyelv.Items.Clear();
            string selectedLevel = cmbSzint.SelectedItem.ToString()!;

            if (File.Exists("nyelv.csv"))
            {
                string[] lines = File.ReadAllLines("nyelv.csv", Encoding.UTF8);
                List<string> languages = new List<string>();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(';');

                    if (parts.Length >= 2)
                    {
                        string level = parts[0].Trim();
                        string language = parts[1].Trim();

                        if (level == selectedLevel)
                        {
                            languages.Add(language);
                        }
                    }
                }

                languages.Sort();

                foreach (string lang in languages)
                {
                    cmbNyelv.Items.Add(lang);
                }

                if (cmbNyelv.Items.Count > 0)
                {
                    cmbNyelv.SelectedIndex = 0;
                }
            }
        }

        private void BtnRogzit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNev.Text))
            {
                MessageBox.Show("Adja meg a jelentkező nevét!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string nev = txtNev.Text;
            string szint = cmbSzint.SelectedItem?.ToString() ?? "";
            string nyelv = cmbNyelv.SelectedItem?.ToString() ?? "";
            string bentlakasos = chkBentlakasos.IsChecked == true ? "igen" : "nem";
            string nem = rbFiu.IsChecked == true ? "fiú" : "lány";

            string line = $"{nev};{szint};{nyelv};{bentlakasos};{nem}";

            File.AppendAllText("jelentkezok.txt", line + Environment.NewLine, Encoding.UTF8);

            ResetForm();
        }

        private void BtnMegsem_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtNev.Text = "";
            cmbSzint.SelectedIndex = 0;
            chkBentlakasos.IsChecked = false;
            rbFiu.IsChecked = true;
        }
    }
}