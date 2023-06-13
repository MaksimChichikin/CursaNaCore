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
    /// Логика взаимодействия для TaskAddWindow.xaml
    /// </summary>
    public partial class TaskAddWindow : Window
    {
        public TaskAddWindow()
        {
            InitializeComponent();
            CmbOrder.DisplayMemberPath = "Id";
            CmbOrder.SelectedValuePath = "Id";
            CmbOrder.ItemsSource = DBConnect.userDataBase.Orders.ToList();

            CmbDelivery.DisplayMemberPath = "Id";
            CmbDelivery.SelectedValuePath = "Id";
            CmbDelivery.ItemsSource = DBConnect.userDataBase.Deliveries.ToList();
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Models.Task task = new Models.Task()
                {

                    IdOrderNavigation = CmbOrder.SelectedItem as Order,
                    IdDeliveryNavigation = CmbDelivery.SelectedItem as Delivery,

                };

                DBConnect.userDataBase.Tasks.Add(task);
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
