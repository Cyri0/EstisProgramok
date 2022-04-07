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

namespace ColorTemplateGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button selectedButton;
        List<Button> colorButtons;

        public MainWindow()
        {
            InitializeComponent();

            colorButtons = new List<Button>();
            colorButtons.Add(color1UI);
            colorButtons.Add(color2UI);
            colorButtons.Add(color3UI);
            colorButtons.Add(color4UI);
            colorButtons.Add(color5UI);

            colorButtonClicked(color1UI);
        }

        private void redSliderUI_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                redNumberUI.Text = "" + Math.Floor(redSliderUI.Value);
                changeButtonColor();
            }
            catch (Exception)
            { }
        }

        private void greenSliderUI_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                greenNumberUI.Text = "" + Math.Floor(greenSliderUI.Value);
                changeButtonColor();
            }
            catch (Exception)
            { }
        }

        private void blueSliderUI_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                blueNumberUI.Text = "" + Math.Floor(blueSliderUI.Value);
                changeButtonColor();
            }
            catch (Exception)
            { }
        }

        private void changeButtonColor()
        {
            SolidColorBrush brush = new SolidColorBrush(
                Color.FromRgb(
                    (byte)redSliderUI.Value,
                    (byte)greenSliderUI.Value,
                    (byte)blueSliderUI.Value
                )
            );

            if (redSliderUI.Value < 130 &&
               greenSliderUI.Value < 130 &&
               blueSliderUI.Value < 130)
            {
                selectedButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else
            {
                selectedButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            selectedButton.Background = brush;
        }

        private int convertHexToByte(string hexNum) {
            // FF
            int intValue = int.Parse(hexNum, System.Globalization.NumberStyles.HexNumber);

            // 0, 1, 2, ..., 9, A, B, C, D, E, F

            return intValue;
        }

        private byte[] convertHexToRgb(string hex) {
            byte[] rgb = new byte[3];

            // 012 34 56 78
            // #FF 5F 6A B8

            string redHex = "" + hex[3] + hex[4];
            string greenHex = "" + hex[5] + hex[6];
            string blueHex = "" + hex[7] + hex[8];

            rgb[0] = (byte)convertHexToByte(redHex);
            rgb[1] = (byte)convertHexToByte(greenHex);
            rgb[2] = (byte)convertHexToByte(blueHex);

            return rgb;
        }

        private void colorButtonClicked(Button b)
        {
            selectedButton = b;

            byte[] rgb = convertHexToRgb("" + b.Background);

            redSliderUI.Value = rgb[0];
            greenSliderUI.Value = rgb[1];
            blueSliderUI.Value = rgb[2];

            foreach (Button item in colorButtons)
            {
                item.BorderThickness = new Thickness(0.0);
            }


            selectedButton.BorderThickness = new Thickness(5.0);
        }

        private void color1UI_Click(object sender, RoutedEventArgs e)
        {
            colorButtonClicked(color1UI);
        }

        private void color2UI_Click(object sender, RoutedEventArgs e)
        {
            colorButtonClicked(color2UI);
        }

        private void color3UI_Click(object sender, RoutedEventArgs e)
        {
            colorButtonClicked(color3UI);
        }

        private void color4UI_Click(object sender, RoutedEventArgs e)
        {
            colorButtonClicked(color4UI);

        }

        private void color5UI_Click(object sender, RoutedEventArgs e)
        {
            colorButtonClicked(color5UI);
        }

        private void saveCSS_Click(object sender, RoutedEventArgs e)
        {
            List<string> colors = new List<string>();
            foreach (Button item in colorButtons)
            {
                colors.Add(""+item.Background);
            }

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "CascadingStyleSheet (*.css)|*.css";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == true) {

                StreamWriter sw = new StreamWriter(saveDialog.FileName);

                sw.WriteLine(":root {");

                for (int i = 0; i < colors.Count; i++)
                {
                    string color = "#" + 
                        colors[i][3] + 
                        colors[i][4] + 
                        colors[i][5] + 
                        colors[i][6] + 
                        colors[i][7] +
                        colors[i][8];

                    sw.WriteLine($"\t--color-{i}: {color};");
                }

                sw.WriteLine("}");
                sw.Close();
                MessageBox.Show("Mentve!");
            }
        }
    }
}
