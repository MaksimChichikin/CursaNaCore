using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace CurcaNaCore.Views
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private async void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            try
            {
                string login = TxbLogin.Text;
                string password = PbPassword.Password;

                string url = $"https://localhost:7237/api/Users?UserLogin={Uri.EscapeDataString(login)}&UserPassword={Uri.EscapeDataString(password)}";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<dynamic>>(responseContent);

                    if (users.Count > 0)
                    {
                        string role = users[0].role;
                        bool isFirstLogin = users[0].isFirstLogin;

                        if (role == "Администратор")
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            Close();
                        }
                        else if (isFirstLogin)
                        {
                            NewPasswordWindow newPasswordWindow = new NewPasswordWindow();
                            newPasswordWindow.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("У вас нет доступа к главной странице.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите правильный логин или пароль.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
