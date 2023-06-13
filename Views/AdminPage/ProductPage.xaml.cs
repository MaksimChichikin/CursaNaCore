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
#pragma warning disable CS8629
namespace CurcaNaCore.Views.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private ObservableCollection<Catalog> filteredCatalog;
        private ObservableCollection<Catalog> catalog;
        public ProductPage()
        {
            InitializeComponent();
            catalog = new ObservableCollection<Catalog>(DBConnect.userDataBase.Catalogs.ToList());
            filteredCatalog = catalog;
            GridProduct.ItemsSource = filteredCatalog;
            GridProduct.CanUserAddRows = false;
            DGCBCBrand.ItemsSource = DBConnect.userDataBase.Brands.ToList();
            DGCBCUnit.ItemsSource = DBConnect.userDataBase.Units.ToList();
            var maxId = DBConnect.userDataBase.Catalogs.Count();
            LBlProduct.Content = maxId.ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredCatalog = catalog;
                }
                else
                {

                    filteredCatalog = new ObservableCollection<Catalog>(
                        catalog.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.NameOfProduct.ToLower().Contains(searchText) ||
                            x.IdBrandNavigation.BrandName.ToLower().Contains(searchText) ||
                            x.IdUnitNavigation.Name.ToLower().Contains(searchText) ||
                            x.Price.ToString().Contains(searchText)
                        )
                    );
                }

                GridProduct.ItemsSource = filteredCatalog;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GridProduct.ItemsSource = new ObservableCollection<Catalog>(DBConnect.userDataBase.Catalogs.ToList());
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
                ProductAddWindow productAddWindow = new ProductAddWindow();
                productAddWindow.ShowDialog();

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
                var row = (sender as Button)?.DataContext as Catalog;
                if (row != null)
                {
                    int id = row.Id;
                    string name = row.NameOfProduct;
                    decimal price = row.Price.Value;

                    var catalog = DBConnect.userDataBase.Catalogs.FirstOrDefault(x => x.Id == id);
                    if (catalog != null)
                    {
                        catalog.NameOfProduct = name;
                        catalog.Price = price;
                        DBConnect.userDataBase.SaveChanges();
                        GridProduct.ItemsSource = new ObservableCollection<Catalog>(DBConnect.userDataBase.Catalogs.ToList());
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
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите  удалить товар", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Catalog;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Catalogs.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridProduct.ItemsSource = new ObservableCollection<Catalog>(DBConnect.userDataBase.Catalogs.ToList());
                        filteredCatalog.Remove(row);
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
