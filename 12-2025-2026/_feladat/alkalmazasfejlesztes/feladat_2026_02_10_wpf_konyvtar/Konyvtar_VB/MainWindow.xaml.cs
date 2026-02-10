using System.Collections.ObjectModel;
using System.Windows;

namespace Konyvtar_VB
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> Books { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Visibility = Visibility.Collapsed;
            InputPanel.Visibility = Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Books.Add(new Book { Title = TitleTextBox.Text, Author = AuthorTextBox.Text });
            TitleTextBox.Clear();
            AuthorTextBox.Clear();
            InputPanel.Visibility = Visibility.Collapsed;
            MainPanel.Visibility = Visibility.Visible;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox.Clear();
            AuthorTextBox.Clear();
            InputPanel.Visibility = Visibility.Collapsed;
            MainPanel.Visibility = Visibility.Visible;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListBox.SelectedItem is Book book)
            {
                Books.Remove(book);
            }       
            else
            {
                MessageBox.Show("Nem jelölt ki törlendő elemet.");
            }
        }
    }
}