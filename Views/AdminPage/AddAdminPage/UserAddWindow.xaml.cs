using CurcaNaCore.ClassHelper;
using CurcaNaCore.Models;
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
using System.Windows.Shapes;

namespace CurcaNaCore.Views.AdminPage.AddAdminPage
{
    /// <summary>
    /// Логика взаимодействия для UserAddWindow.xaml
    /// </summary>
    public partial class UserAddWindow : Window
    {
        public UserAddWindow()
        {
            InitializeComponent();
            CmbRole.DisplayMemberPath = "Name";
            CmbRole.SelectedValuePath = "Id";
            CmbRole.ItemsSource = DBConnect.userDataBase.Roles.ToList();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = ConvertToMD5(TxbPassword.Text);

                User user = new User()
                {
                    Login = TxbLogin.Text,
                    Password = password,
                    DateAdd = DateTime.Now,
                    NumberOfLoginAttempts = 0,
                    FullName = TxbFullName.Text,
                    IdUserActivity = 1,
                    IdUserStatus = 2,
                    IsFirstLogin = true,
                    IdRoleNavigation = CmbRole.SelectedItem as Role,

                };

                DBConnect.userDataBase.Users.Add(user);
                DBConnect.userDataBase.SaveChanges();

                MessageBox.Show("Данные успешно добавлены!",
                    "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                Window.GetWindow(this).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private string ConvertToMD5(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

    }
}
