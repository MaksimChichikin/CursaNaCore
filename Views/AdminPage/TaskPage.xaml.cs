using CurcaNaCore.ClassHelper;
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
#pragma warning disable CS8602
#pragma warning disable CS8600
namespace CurcaNaCore.Views.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        private ObservableCollection<Models.Task> filteredTask;
        private ObservableCollection<Models.Task> task;
        public TaskPage()
        {
            InitializeComponent();
            task = new ObservableCollection<Models.Task>(DBConnect.userDataBase.Tasks.Include(x => x.IdDeliveryNavigation.IdStatusNavigation).ToList());
            filteredTask = task;
            GridTask.ItemsSource = filteredTask;
            GridTask.CanUserAddRows = false;
            DGCBCOrder.ItemsSource = DBConnect.userDataBase.Orders.ToList();
            DGCBCDelivery.ItemsSource = DBConnect.userDataBase.Deliveries.ToList();
            DGCBCValume.ItemsSource = DBConnect.userDataBase.Deliveries.ToList();
            var maxId = DBConnect.userDataBase.Tasks.Count();
            LBlTask.Content = maxId.ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredTask = task;
                }
                else
                {

                    filteredTask = new ObservableCollection<Models.Task>(
                        task.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.IdOrderNavigation.Id.ToString().ToLower().Contains(searchText) ||
                            x.IdDeliveryNavigation.Id.ToString().ToLower().Contains(searchText) ||
                            x.IdDeliveryNavigation.Valume.ToString().ToLower().Contains(searchText) ||
                            x.IdDeliveryNavigation.IdStatusNavigation.Name.Contains(searchText)
                        )
                    );
                }

                GridTask.ItemsSource = filteredTask;
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
                GridTask.ItemsSource = new ObservableCollection<Models.Task>(DBConnect.userDataBase.Tasks.ToList());
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
                TaskAddWindow taskAddWindow = new TaskAddWindow();
                taskAddWindow.ShowDialog();

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
                var row = (sender as Button)?.DataContext as Models.Task;
                if (row != null)
                {
                    int id = row.Id;
                    var catalog = DBConnect.userDataBase.Catalogs.FirstOrDefault(x => x.Id == id);
                    if (catalog != null)
                    {

                        DBConnect.userDataBase.SaveChanges();
                        GridTask.ItemsSource = new ObservableCollection<Models.Task>(DBConnect.userDataBase.Tasks.ToList());
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
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите выполнить удалить задачу", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Models.Task;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Tasks.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridTask.ItemsSource = new ObservableCollection<Models.Task>(DBConnect.userDataBase.Tasks.ToList());
                        filteredTask.Remove(row);
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
