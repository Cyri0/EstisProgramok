using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filmek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Movie> movies;

        private void initTypes()
        {
            typeUI.Items.Add("title");
            typeUI.Items.Add("director");
            typeUI.Items.Add("actor/actress");
            typeUI.SelectedIndex = 0;
        }

        private void read() {
            try
            {
                StreamReader sr = new StreamReader("movies.txt");
                sr.ReadLine(); // eldobjuk az első sort

                while (!sr.EndOfStream)
                {
                    movies.Add(new Movie(sr.ReadLine()));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Missing or invalid file!");
            }
        }

        public MainWindow()
        {
            movies = new List<Movie>();
            InitializeComponent();
            initTypes();
            read();
        }

        private void searchBarUI_TextChanged(object sender, TextChangedEventArgs e)
        {
            matchMoviesUI.Items.Clear();

            if(searchBarUI.Text != "")
            {
                foreach (Movie item in movies)
                {
                    if (item.title.ToUpper().Contains(searchBarUI.Text.ToUpper()))
                    {
                        matchMoviesUI.Items.Add(item);
                    }
                }
            }
        }

        private void matchMoviesUI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Movie choosen = (Movie)matchMoviesUI.SelectedItem;

            if(choosen != null)
            {
                movieTitleUI.Content = choosen.title;
                directorUI.Content = choosen.director;
                castUI.Content = choosen.cast;
                rateUI.Content = "10/" + choosen.vote_average;
            }
        }
    }
}
