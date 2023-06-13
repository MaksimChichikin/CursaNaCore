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
    /// Логика взаимодействия для DeliveryAddWindow.xaml
    /// </summary>
    public partial class DeliveryAddWindow : Window
    {
        public DeliveryAddWindow()
        {
            InitializeComponent();
            CmbStatus.DisplayMemberPath = "Name";
            CmbStatus.SelectedValuePath = "Id";
            CmbStatus.ItemsSource = DBConnect.userDataBase.Statuses.ToList();
        }

        private void BtnAddDelivery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Delivery delivery = new Delivery()
                {
                    IdStatusNavigation = CmbStatus.SelectedItem as Status,
                    Valume = int.Parse(TxbValume.Text)

                };

                DBConnect.userDataBase.Deliveries.Add(delivery);
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
