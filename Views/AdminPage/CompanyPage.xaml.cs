using CurcaNaCore.ClassHelper;
using CurcaNaCore.Models;
using CurcaNaCore.Views.AdminPage.AddAdminPage;
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
namespace CurcaNaCore.Views.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для CompanyPage.xaml
    /// </summary>
    public partial class CompanyPage : Page
    {
        private ObservableCollection<Company> filteredCompany;
        private ObservableCollection<Company> company;
        public CompanyPage()
        {
            InitializeComponent();
            company = new ObservableCollection<Company>(DBConnect.userDataBase.Companies.ToList());
            filteredCompany = company;
            GridCompany.ItemsSource = filteredCompany;
            GridCompany.CanUserAddRows = false;
            var maxId = DBConnect.userDataBase.Companies.Count();
            LBlCompany.Content = maxId.ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredCompany = company;
                }
                else
                {

                    filteredCompany = new ObservableCollection<Company>(
                        company.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.CompanyName.ToLower().Contains(searchText) ||
                            x.Address.ToLower().Contains(searchText) ||
                            x.Phone.ToLower().Contains(searchText)
                        )
                    );
                }

                GridCompany.ItemsSource = filteredCompany;
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
                GridCompany.ItemsSource = new ObservableCollection<Company>(DBConnect.userDataBase.Companies.ToList());
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
            try
            {
                CompanyAddWindow companyAddWindow = new CompanyAddWindow();
                companyAddWindow.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (sender as Button)?.DataContext as Company;
                if (row != null)
                {
                    int id = row.Id;
                    string name = row.CompanyName;
                    string address = row.Address;
                    string phone = row.Phone;

                    var company = DBConnect.userDataBase.Companies.FirstOrDefault(x => x.Id == id);
                    if (company != null)
                    {
                        company.CompanyName = name;
                        company.Address = address;
                        company.Phone = phone;
                        DBConnect.userDataBase.SaveChanges();
                        GridCompany.ItemsSource = new ObservableCollection<Company>(DBConnect.userDataBase.Companies.ToList());
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
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите  удалить компанию", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Company;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Companies.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridCompany.ItemsSource = new ObservableCollection<Company>(DBConnect.userDataBase.Companies.ToList());
                        filteredCompany.Remove(row);
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
