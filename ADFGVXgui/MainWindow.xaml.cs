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

namespace ADFGVXgui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Betu
    {
        public char betu;
        public int darab;

        public Betu(char betu)
        {
            this.betu = betu;
            this.darab = 0;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void betoltes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if(ofd.ShowDialog() == true)
            {
                string file = ofd.FileName;

                // FÁJLBEOLVASÁS
                List<string> sorok = new List<string>();
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {
                    sorok.Add(sr.ReadLine());
                }

                // KIÍRATÁS
                betoltottKodtabla.Content = "";
                foreach (string sor in sorok)
                {
                    foreach (char betu in sor)
                    {
                        betoltottKodtabla.Content += betu + " ";
                    }
                    betoltottKodtabla.Content += "\n";
                }

                // HIBAKERESÉSEK
                listaDoboz.Items.Clear();

                if(sorok.Count == 6) {
                    foreach (string sor in sorok)
                    {
                        if(sor.Length != 6)
                        {
                            listaDoboz.Items.Add("Hiba a mátrix méretében!");
                            break;
                        }
                    }
                }
                else
                {
                    listaDoboz.Items.Add("Hiba a mátrix méretében!");
                }

                // CSAK BETŰK ÉS SZÁMOK

                foreach (string sor in sorok)
                {
                    foreach (char betu in sor)
                    {
                        if (!(betu >= 'a' && betu <= 'z' ||
                            betu >= '0' && betu <= '9'))
                        {
                            listaDoboz.Items.Add($"Hibás karakter ({betu}) van a mátrixban!");
                        }
                    }
                }

                // Minden betű egyszer
                List<Betu> betulista = new List<Betu>();
                for (char i = 'a'; i <= 'z'; i++)
                {
                    betulista.Add(new Betu(i));
                }
                for(char i = '0'; i <= '9'; i++)
                {
                    betulista.Add(new Betu(i));
                }

                foreach (string sor in sorok)
                {
                    foreach (char betu in sor)
                    {
                        foreach (Betu item in betulista)
                        {
                            if(item.betu == betu)
                            {
                                item.darab++;
                                break;
                            }
                        }
                    }
                }

                foreach (Betu item in betulista)
                {
                    if(item.darab != 1)
                    {
                        listaDoboz.Items.Add($"A(z) {item.betu} karakter {item.darab}x szerepel a mátrixban!");
                    }
                }


            }
        }
    }
}
