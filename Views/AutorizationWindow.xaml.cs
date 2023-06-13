using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CurcaNaCore.Models;
using Newtonsoft.Json;

namespace CurcaNaCore.Views
{
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
                        int? userId = users[0].id;
                        string role = users[0].role;
                        bool isFirstLogin = users[0].isFirstLogin;
                        string userStatus = users[0].userStatus;

                        if (role == "Администратор")
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            Close();
                        }
                        else if (userStatus == "Заблокирован")
                        {
                            MessageBox.Show("Ваш аккаунт заблокирован");
                        }
                        else if (isFirstLogin && userId.HasValue)
                        {
                            NewPasswordWindow newPasswordWindow = new NewPasswordWindow(userId.Value);
                            newPasswordWindow.Show();
                            Close();
                        }

                        else if (role == "Пользователь")
                        {
                            MessageBox.Show("Вы вошли как пользователь");
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
