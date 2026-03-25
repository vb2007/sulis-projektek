using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KeresztrejtvenyGUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private TextBox[,]? textBoxok;
    private int sorokSzama;
    private int oszlopokSzama;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        //sorok és oszlopok ComboBox feltöltése 6-15
        for (int i = 6; i <= 15; i++)
        {
            cmbSorok.Items.Add(i);
            cmbOszlopok.Items.Add(i);
        }

        //default érték: 15
        cmbSorok.SelectedItem = 15;
        cmbOszlopok.SelectedItem = 15;

        for (int i = 1; i <= 10; i++)
        {
            cmbIndex.Items.Add(i);
        }
        //default érték: 3
        cmbIndex.SelectedItem = 3;
    }

    private void BtnLetrehozas_Click(object sender, RoutedEventArgs e)
    {
        gridRacs.Children.Clear();
        gridRacs.RowDefinitions.Clear();
        gridRacs.ColumnDefinitions.Clear();

        sorokSzama = (int)cmbSorok.SelectedItem;
        oszlopokSzama = (int)cmbOszlopok.SelectedItem;

        textBoxok = new TextBox[sorokSzama, oszlopokSzama];

        for (int i = 0; i < sorokSzama; i++)
        {
            gridRacs.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        }
        for (int j = 0; j < oszlopokSzama; j++)
        {
            gridRacs.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        }

        for (int i = 0; i < sorokSzama; i++)
        {
            for (int j = 0; j < oszlopokSzama; j++)
            {
                TextBox tb = new TextBox
                {
                    Text = "-",
                    Width = 25,
                    Height = 25,
                    MaxLength = 1,
                    TextAlignment = TextAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(1)
                };

                // Dupla kattintás esemény
                tb.MouseDoubleClick += TextBox_MouseDoubleClick;

                Grid.SetRow(tb, i);
                Grid.SetColumn(tb, j);
                gridRacs.Children.Add(tb);

                textBoxok[i, j] = tb;
            }
        }
    }

    private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is TextBox tb)
        {
            tb.Text = tb.Text == "-" ? "#" : "-";
        }
    }

    private void BtnMentes_Click(object sender, RoutedEventArgs e)
    {
        if (textBoxok == null)
        {
            MessageBox.Show("Először hozzon létre keresztrejtvényt!", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            int index = (int)cmbIndex.SelectedItem;
            string fajlnev = $"kr{index}.txt";

            using StreamWriter sw = new StreamWriter(fajlnev);
            for (int i = 0; i < sorokSzama; i++)
            {
                string sor = "";
                for (int j = 0; j < oszlopokSzama; j++)
                {
                    sor += textBoxok[i, j].Text;
                }
                sw.WriteLine(sor);
            }

            MessageBox.Show($"A keresztrejtvény sikeresen mentve: {fajlnev}", "Sikeres mentés", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}