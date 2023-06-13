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
#pragma warning disable CS8629
namespace CurcaNaCore.Views.AdminPage.AddAdminPage
{
    /// <summary>
    /// Логика взаимодействия для OrderAddWindow.xaml
    /// </summary>
    public partial class OrderAddWindow : Window
    {
        public OrderAddWindow()
        {
            InitializeComponent();
            CmbCompany.DisplayMemberPath = "CompanyName";
            CmbCompany.SelectedValuePath = "Id";
            CmbCompany.ItemsSource = DBConnect.userDataBase.Companies.ToList();


            CmbProduct.DisplayMemberPath = "NameOfProduct";
            CmbProduct.SelectedValuePath = "Id";
            CmbProduct.ItemsSource = DBConnect.userDataBase.Catalogs.ToList();
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime selectedDateTimeOrder = DtpDateOrder.SelectedDate.Value;
                DateTime selectedDateTimeDelivery = DtpDateDelivery.SelectedDate.Value;

                DateTime dateTimeToSaveOrder = new DateTime(selectedDateTimeOrder.Year, selectedDateTimeOrder.Month, selectedDateTimeOrder.Day, 12, 0, 0);
                DateTime dateTimeToSaveDelivery = new DateTime(selectedDateTimeDelivery.Year, selectedDateTimeDelivery.Month, selectedDateTimeDelivery.Day, 12, 0, 0);



                Order order = new Order()
                {
                    NumberOfGoods = int.Parse(TxbNumberOfGoods.Text),
                    IdCompanyNavigation = CmbCompany.SelectedItem as Company,
                    IdCatalogNavigation = CmbProduct.SelectedItem as Catalog,
                    OrderDate = dateTimeToSaveOrder,
                    DeliveryDate = dateTimeToSaveDelivery
                };

                DBConnect.userDataBase.Orders.Add(order);
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
