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
#pragma warning disable CS8601
namespace CurcaNaCore.Views.AdminPage.AddAdminPage
{
    /// <summary>
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        public ProductAddWindow()
        {
            InitializeComponent();
            CmbBrand.DisplayMemberPath = "BrandName";
            CmbBrand.SelectedValuePath = "Id";
            CmbBrand.ItemsSource = DBConnect.userDataBase.Brands.ToList();

            CmbUnit.DisplayMemberPath = "Name";
            CmbUnit.SelectedValuePath = "Id";
            CmbUnit.ItemsSource = DBConnect.userDataBase.Units.ToList();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Catalog catalog = new Catalog()
                {
                    NameOfProduct = TxbNameOfProduct.Text,
                    IdBrandNavigation = CmbBrand.SelectedItem as Brand,
                    IdUnitNavigation = CmbUnit.SelectedItem as Unit,
                    Price = decimal.Parse(TxbPrice.Text),
                };

                DBConnect.userDataBase.Catalogs.Add(catalog);
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
    }
}
