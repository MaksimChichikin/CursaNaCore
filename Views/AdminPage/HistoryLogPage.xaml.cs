using CurcaNaCore.ClassHelper;
using CurcaNaCore.Models;
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
    /// Логика взаимодействия для HistoryLogPage.xaml
    /// </summary>
    public partial class HistoryLogPage : Page
    {
       private ObservableCollection<HistoryLog> filteredHistoryLog;
        private ObservableCollection<HistoryLog> historylog;
 
        public HistoryLogPage()
        {
            InitializeComponent();
            historylog = new ObservableCollection<HistoryLog>(DBConnect.userDataBase.HistoryLogs.Include(x=>x.IdUserNavigation).Include(x=> x.IdUserNavigation.IdUserActivityNavigation).Include(x=>x.IdUserNavigation.IdUserStatusNavigation).ToList());
            filteredHistoryLog = historylog;
            GridBrand.ItemsSource = filteredHistoryLog;
            GridBrand.CanUserAddRows = false;
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredHistoryLog = historylog;
                }
                else
                {

                    filteredHistoryLog = new ObservableCollection<HistoryLog>(
                        historylog.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.IdUserNavigation.Login.ToLower().Contains(searchText) ||
                            x.UserLoginDate.ToString().ToLower().Contains(searchText) ||
                            x.LoginAttempt.ToString().ToLower().Contains(searchText)
                        )
                    );
                }

                GridBrand.ItemsSource = filteredHistoryLog;
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
                GridBrand.ItemsSource = new ObservableCollection<HistoryLog>(DBConnect.userDataBase.HistoryLogs.ToList());
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
