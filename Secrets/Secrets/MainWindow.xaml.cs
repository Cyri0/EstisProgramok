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
using System.Text.Json;

namespace Secrets
{
    class Secret
    {
        public string username { get; set; }
        public string secret { get; set; }
        public Secret(string username, string secret) {
            this.username = username;
            this.secret = secret;
        }
    }

    class LoginInfo {
        public string username { get; set; }
        public string password { get; set; }

        public LoginInfo(string username, string password) {
            this.username = username;
            this.password = password;
        }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginInfo loggedUser;

        public MainWindow()
        {
            loggedUser = null;
            InitializeComponent();
        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        { // BELÉPÉS
            foreach (LoginInfo item in readUsers())
            {
                if(item.username == usernameGUI.Text)
                {
                    if(item.password == passwordGUI.Password)
                    {
                        MessageBox.Show("Sikeres bejelentkezés " + item.username + " fiókjába!");
                        loggedUser = item;
                        updateList();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Hibás jelszó!");
                    }
                }
            }
        }

        private void updateList()
        {
            secretsGUI.Items.Clear();
            foreach (Secret item in readAllSecrets())
            {
                if(item.username == loggedUser.username)
                {
                    secretsGUI.Items.Add(item.secret);
                }
            }
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        { // REGISZTRÁCIÓ
            string username = usernameGUI.Text;
            string password = passwordGUI.Password;
            // TODO Titkosítás
            LoginInfo newUser = new LoginInfo(username, password);
            if (testNewUser(newUser))
            {
                regUser(readUsers(), newUser);
                MessageBox.Show("Sikeres regisztráció " + username + " néven!");
            }
            else
            {
                MessageBox.Show("Hibás vagy már létező felhasználónév!");
            }
        }

        private List<LoginInfo> readUsers()
        {
            StreamReader sr = new StreamReader("login.json");
            string raw = sr.ReadLine();
            sr.Close();
            List<LoginInfo> users = JsonSerializer
                .Deserialize<List<LoginInfo>>(raw);
            return users;
        }

        private void regUser(List<LoginInfo> users, LoginInfo newUser)
        {
            users.Add(newUser);
            StreamWriter sw = new StreamWriter("login.json");
            sw.Write( JsonSerializer.Serialize(users) );
            sw.Close();
        }

        private bool testNewUser(LoginInfo newUser) {
            if (newUser.username == "") return false;

            foreach (LoginInfo item in readUsers())
            {
                if(item.username == newUser.username)
                {
                    return false;
                }
            }
            return true;
        }

        private List<Secret> readAllSecrets()
        {
            StreamReader sr = new StreamReader("topsecret.json");
            string raw = sr.ReadLine();
            sr.Close();
            return JsonSerializer.Deserialize<List<Secret>>(raw);
        }

        private void addSecretBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Secret> secrets = readAllSecrets();
            secrets.Add(new Secret(usernameGUI.Text, newSecretGUI.Text));

            StreamWriter sw = new StreamWriter("topsecret.json");
            sw.Write(JsonSerializer.Serialize(secrets));
            sw.Close();
            updateList();
            newSecretGUI.Text = "";
        }
    }
}
