using System;
using System.Collections.Generic;
using System.Windows;
using System.Text.Json;
using System.IO;

namespace regisztracio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Termek
    {
        public string nev { get; set; }
        public string kategoria { get; set; }
        public override string ToString()
        {
            return this.nev + " ("+this.kategoria+")";
        }
    }
    public partial class MainWindow : Window
    {
        private void loadData()
        {
            StreamReader sr = new StreamReader("data.json");
            List<Termek> termekek = JsonSerializer.Deserialize<List<Termek>>(sr.ReadLine());
            sr.Close();

            foreach (Termek item in termekek)
            {
                listGUI.Items.Add(item);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            dropdownGUI.Items.Add("élelmiszer");
            dropdownGUI.Items.Add("műszaki cikk");
            dropdownGUI.Items.Add("háztartás");
            dropdownGUI.Items.Add("egyéb");
            dropdownGUI.SelectedIndex = 0;

            try
            {
                loadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a fájl betöltése közben!");
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if(inputGUI.Text != "")
            {
                Termek ujtermek = new Termek
                {
                    nev = inputGUI.Text,
                    kategoria = dropdownGUI.Text
                };
                listGUI.Items.Add(ujtermek);
                inputGUI.Text = "";
            }
            else
            {
                MessageBox.Show("Írj be valamit!");
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(listGUI.SelectedItem != null)
            {
                listGUI.Items.Remove(listGUI.SelectedItem);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem!");
            }
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(listGUI.SelectedItem != null)
            {
                Termek atmeneti = (Termek)listGUI.SelectedItem;
                inputGUI.Text = atmeneti.nev;
                dropdownGUI.SelectedItem = atmeneti.kategoria;
                listGUI.Items.Remove(listGUI.SelectedItem);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem!");
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Termek> mentendoLista = new List<Termek>();

                foreach (Termek item in listGUI.Items)
                {
                    mentendoLista.Add(item);
                }

                StreamWriter sw = new StreamWriter("data.json");
                sw.Write(JsonSerializer.Serialize(mentendoLista));
                sw.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception)
            {
                MessageBox.Show("Sikertelen mentés!");
            }
        }
    }
}
