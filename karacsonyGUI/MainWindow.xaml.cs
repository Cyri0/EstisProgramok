using System;
using System.Collections.Generic;
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

namespace karacsonyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int raktarkeszlet = 0;

        private void toltNapokSzama(int kezdo) {
            napokSzama.Items.Clear();
            for (int i = kezdo; i <= 40; i++)
            {
                napokSzama.Items.Add(i);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            toltNapokSzama(1);
        }

        private void hozzaad_Click(object sender, RoutedEventArgs e)
        {
            errorLabel.Content = "";
            try
            {
                int elkeszult = int.Parse(elkeszitett.Text);
                int eladva = int.Parse(eladott.Text);

                if(elkeszult >= 0 && eladva >= 0) {
                    if(raktarkeszlet + elkeszult - eladva >= 0)
                    {
                        raktarkeszlet = raktarkeszlet + elkeszult - eladva;

                        listaDoboz.Items.Add($"{napokSzama.Text}.nap:\t+{elkeszitett.Text}\t-{eladott.Text}\t=\t{raktarkeszlet}");

                    toltNapokSzama(int.Parse(napokSzama.Text) + 1);
                    elkeszitett.Text = "0";
                    eladott.Text = "0";
                    }
                    else
                    {
                    errorLabel.Content = "Túl sok eladott angyalka!";
                    }
                }
                else
                {
                    errorLabel.Content = "Negatív számot nem adhat meg!";
                }

            }
            catch (Exception)
            {
                errorLabel.Content = "Adj meg érvényes számokat!";
            }




        }
    }
}
