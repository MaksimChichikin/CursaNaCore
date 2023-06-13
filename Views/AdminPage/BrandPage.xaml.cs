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
    /// Логика взаимодействия для BrandPage.xaml
    /// </summary>
    public partial class BrandPage : Page
    {
        private ObservableCollection<Brand> filteredBrand;
        private ObservableCollection<Brand> brand;
        public BrandPage()
        {
            InitializeComponent();
            brand = new ObservableCollection<Brand>(DBConnect.userDataBase.Brands.ToList());
            filteredBrand = brand;
            GridBrand.ItemsSource = filteredBrand;
            GridBrand.CanUserAddRows = false;
            var maxId = DBConnect.userDataBase.Brands.Count();
            LBlBrand.Content = maxId.ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredBrand = brand;
                }
                else
                {

                    filteredBrand = new ObservableCollection<Brand>(
                        brand.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.BrandName.ToLower().Contains(searchText) ||
                            x.AddressBrand.ToLower().Contains(searchText) ||
                            x.PhoneBrand.ToLower().Contains(searchText)
                        )
                    );
                }

                GridBrand.ItemsSource = filteredBrand;
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
                GridBrand.ItemsSource = new ObservableCollection<Brand>(DBConnect.userDataBase.Brands.ToList());
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
                BrandAddWindow brandAddWindow = new BrandAddWindow();
                brandAddWindow.ShowDialog();

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
                var row = (sender as Button)?.DataContext as Brand;
                if (row != null)
                {
                    int id = row.Id;
                    string name = row.BrandName;
                    string address = row.AddressBrand;
                    string phone = row.PhoneBrand;

                    var brand = DBConnect.userDataBase.Brands.FirstOrDefault(x => x.Id == id);
                    if (brand != null)
                    {
                        brand.BrandName = name;
                        brand.AddressBrand = address;
                        brand.PhoneBrand = phone;
                        DBConnect.userDataBase.SaveChanges();
                        GridBrand.ItemsSource = new ObservableCollection<Brand>(DBConnect.userDataBase.Brands.ToList());
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
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить бренд", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Brand;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Brands.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridBrand.ItemsSource = new ObservableCollection<Brand>(DBConnect.userDataBase.Brands.ToList());
                        filteredBrand.Remove(row);
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
