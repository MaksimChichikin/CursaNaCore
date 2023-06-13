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
namespace CurcaNaCore.Views.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для DeliveryPage.xaml
    /// </summary>
    public partial class DeliveryPage : Page
    {
        private ObservableCollection<Delivery> filteredDelivery;
        private ObservableCollection<Delivery> delivery;
        public DeliveryPage()
        {
            InitializeComponent();
            delivery = new ObservableCollection<Delivery>(DBConnect.userDataBase.Deliveries.ToList());
            filteredDelivery = delivery;
            GridDelivery.ItemsSource = filteredDelivery;
            GridDelivery.CanUserAddRows = false;
            DGCBCStatus.ItemsSource = DBConnect.userDataBase.Statuses.ToList();
            var maxId = DBConnect.userDataBase.Deliveries.Count();
            LBlDelivery.Content = maxId.ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredDelivery = delivery;
                }
                else
                {

                    filteredDelivery = new ObservableCollection<Delivery>(
                        delivery.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.Valume.ToString().ToLower().Contains(searchText) ||
                            x.IdStatusNavigation.Name.ToLower().Contains(searchText)

                        )
                    );
                }

                GridDelivery.ItemsSource = filteredDelivery;
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
                GridDelivery.ItemsSource = new ObservableCollection<Delivery>(DBConnect.userDataBase.Deliveries.ToList());
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
                DeliveryAddWindow deliveryAddWindow = new DeliveryAddWindow();
                deliveryAddWindow.ShowDialog();

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
                var row = (sender as Button)?.DataContext as Delivery;
                if (row != null)
                {
                    int id = row.Id;
                    int valume = row.Valume.HasValue ? row.Valume.Value : 0;
                  


                    var delivery = DBConnect.userDataBase.Deliveries.FirstOrDefault(x => x.Id == id);
                    if (delivery != null)
                    {
                        delivery.Valume = valume;
                        DBConnect.userDataBase.SaveChanges();
                        GridDelivery.ItemsSource = new ObservableCollection<Delivery>(DBConnect.userDataBase.Deliveries.ToList());
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
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить доставку", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Delivery;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Deliveries.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridDelivery.ItemsSource = new ObservableCollection<Delivery>(DBConnect.userDataBase.Deliveries.ToList());
                        filteredDelivery.Remove(row);
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
