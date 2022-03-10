using Microsoft.Win32;
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

namespace termekbeszerzes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            termekekBetoltese();
        }
        private void termekekBetoltese() {
            try
            {
                StreamReader sr = new StreamReader("termekek.txt");

                while (!sr.EndOfStream)
                {
                    termekek.Items.Add(sr.ReadLine());
                }

                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Nem található vagy hibás termekek.txt!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int darab = int.Parse(mennyiseg.Text);

                if(termekek.Text.Length == 0)
                {
                    throw new Exception("Nem adtál meg terméket!");
                }

                //-----------------

                listadoboz.Items.Add($"{termekek.Text};{darab}");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Adj meg érvényes számot!");
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void Exportalas(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("export.csv");
            sw.WriteLine("Termek;Mennyiseg");
            foreach (var item in listadoboz.Items)
            {
                sw.WriteLine(item);
            }

            sw.Close();
            MessageBox.Show("SIKERES EXPORTÁLÁS!");
        }

        private void Importalas(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == true) {
                string path = openFile.FileName;
                StreamReader sr = new StreamReader(path);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    listadoboz.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
        }

        private void Listatorles(object sender, RoutedEventArgs e)
        {
            listadoboz.Items.Clear();
        }
    }
}
