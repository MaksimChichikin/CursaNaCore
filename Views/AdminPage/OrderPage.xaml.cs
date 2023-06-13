using CurcaNaCore.ClassHelper;
using CurcaNaCore.Models;
using CurcaNaCore.Views.AdminPage.AddAdminPage;
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

namespace CurcaNaCore.Views.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private ObservableCollection<Order> filteredOrder;
        private ObservableCollection<Order> order;
        public OrderPage()
        {
#pragma warning disable CS8602
            InitializeComponent();
            order = new ObservableCollection<Order>(
    DBConnect.userDataBase.Orders.Include(o => o.IdCatalogNavigation.IdBrandNavigation).ToList());
            filteredOrder = order;
            GridOrder.ItemsSource = filteredOrder;
            GridOrder.CanUserAddRows = false;
            DGCBCCompany.ItemsSource = DBConnect.userDataBase.Companies.ToList();

            DGCBCIdCatalog.ItemsSource = DBConnect.userDataBase.Catalogs.ToList();
            DGCBCPrice.ItemsSource = DBConnect.userDataBase.Catalogs.ToList();
            var maxId = DBConnect.userDataBase.Orders.Count();
            LBlOrder.Content = maxId.ToString();

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredOrder = order;
                }
                else
                {

                    filteredOrder = new ObservableCollection<Order>(
                        order.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.IdCompanyNavigation.CompanyName.ToLower().Contains(searchText) ||
                            x.IdCatalogNavigation.NameOfProduct.ToString().ToLower().Contains(searchText) ||
                            x.IdCatalogNavigation.IdBrandNavigation.BrandName.ToString().ToLower().Contains(searchText) ||
                            x.IdCatalogNavigation.Price.ToString().Contains(searchText) ||
                            x.NumberOfGoods.ToString().ToLower().Contains(searchText) ||
                            x.OrderDate.ToString().ToLower().Contains(searchText) ||
                            x.DeliveryDate.ToString().ToLower().Contains(searchText)
                        )
                    );
                }

                GridOrder.ItemsSource = filteredOrder;
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
                GridOrder.ItemsSource = new ObservableCollection<Order>(DBConnect.userDataBase.Orders.ToList());
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
                OrderAddWindow orderAddWindow = new OrderAddWindow();
                orderAddWindow.ShowDialog();

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
                var row = (sender as Button)?.DataContext as Order;
                if (row != null)
                {
                    int id = row.Id;
                    int numberOfGoods = row.NumberOfGoods.HasValue ? row.NumberOfGoods.Value : 0;
                    DateTime orderDate = Convert.ToDateTime(row.OrderDate);
                    DateTime orderDelivery = Convert.ToDateTime(row.DeliveryDate);

                    var order = DBConnect.userDataBase.Orders.FirstOrDefault(x => x.Id == id);
                    if (order != null)
                    {
                        order.NumberOfGoods = numberOfGoods;
                        order.OrderDate = orderDate;
                        order.DeliveryDate = orderDelivery;
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Order>(DBConnect.userDataBase.Orders.ToList());
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
                    var row = (sender as Button)?.DataContext as Order;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Orders.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Order>(DBConnect.userDataBase.Orders.ToList());
                        filteredOrder.Remove(row);
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
#pragma warning restore CS8602
