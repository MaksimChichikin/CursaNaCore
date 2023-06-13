using CurcaNaCore.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CurcaNaCore.Views
{
    /// <summary>
    /// Логика взаимодействия для NewPasswordWindow.xaml
    /// </summary>
    public partial class NewPasswordWindow : Window
    {
        private int userId; // Поле для хранения идентификатора пользователя

        public NewPasswordWindow(int userId)
        {
            InitializeComponent();
            this.userId = userId;

        }

        private void BtnEditPassword_Click(object sender, RoutedEventArgs e)
        {
            if (TxbPassword.Text == PbPasswordComplite.Password)
            {
                string newPassword = GetMD5Hash(TxbPassword.Text);

               
                using (var context = new _130123_ChichikinContext())
                {
                    var user = context.Users.Find(userId);
                    if (user != null)
                    {
                        user.Password = newPassword;
                        user.IsFirstLogin = false;
                        context.SaveChanges();
                        MessageBox.Show("Пароль успешно обновлен!");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти пользователя.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите одинаковый пароль");
            }
        }

        private string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

  
    }
}
