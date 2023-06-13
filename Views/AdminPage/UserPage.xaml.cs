using CurcaNaCore.ClassHelper;
using CurcaNaCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
#pragma warning disable CS8602
#pragma warning disable CS8600
#pragma warning disable CS8629
namespace CurcaNaCore.Views.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private ObservableCollection<User> filteredUser;
        private ObservableCollection<User> user;
        public UserPage()
        {
            InitializeComponent();
            user = new ObservableCollection<User>(DBConnect.userDataBase.Users
                .Include(x => x.IdUserActivityNavigation)
                 .Include(x => x.IdUserActivityNavigation)
                  .Include(x => x.IdRoleNavigation)
                  .ToList());
            filteredUser = user;
            GridBrand.ItemsSource = filteredUser;
            GridBrand.CanUserAddRows = false;
            DGCBCUserStatus.ItemsSource = DBConnect.userDataBase.UserStatuses.ToList();
            DGCBCRole.ItemsSource = DBConnect.userDataBase.Roles.ToList();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredUser = user;
                }
                else
                {

                    filteredUser = new ObservableCollection<User>(
                        user.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.Login.ToLower().Contains(searchText) ||
                            x.Password.ToLower().Contains(searchText) ||
                            x.IdUserActivityNavigation.Name.ToLower().Contains(searchText) ||
                            x.IdRoleNavigation.Name.ToLower().Contains(searchText) ||
                            x.DateAdd.ToString().ToLower().Contains(searchText) ||
                            x.IdUserStatusNavigation.Name.ToLower().Contains(searchText) ||
                             x.FullName.ToLower().Contains(searchText) ||
                              x.IsFirstLogin.ToString().ToLower().Contains(searchText) 
                        )
                    );
                }

                GridBrand.ItemsSource = filteredUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GridBrand.ItemsSource = new ObservableCollection<User>(DBConnect.userDataBase.Users.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (sender as Button)?.DataContext as User;
                if (row != null)
                {
                    int id = row.Id;
                    string name = row.Login;
                    string password = row.Password;
                    DateTime DateAdd = Convert.ToDateTime(row.DateAdd);


                    var user = DBConnect.userDataBase.Users.FirstOrDefault(x => x.Id == id);
                    if (user != null)
                    {
                        user.Login = name;
                        user.Password = password;
                        user.DateAdd = DateAdd;
                        
                        DBConnect.userDataBase.SaveChanges();
                        GridBrand.ItemsSource = new ObservableCollection<User>(DBConnect.userDataBase.Users.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить заказ", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as User;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Users.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridBrand.ItemsSource = new ObservableCollection<User>(DBConnect.userDataBase.Users.ToList());
                        filteredUser.Remove(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
