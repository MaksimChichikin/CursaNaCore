using CurcaNaCore.ClassHelper.Global;
using CurcaNaCore.Views.AdminPage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

#pragma warning disable CS8602
namespace CurcaNaCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispacherTimer_Tick;
            dispatcherTimer.Start();
            NavigationClass.frmNav = FrmMain;
            FrmMain.Navigate(new OrderPage());

        }

        private void DispacherTimer_Tick(object? sender, EventArgs e)
        {
            TxbBlkTimeNow.Text = DateTime.Now.ToString("HH:mm");
            TxbBlkDateTime.Text = DateTime.Now.ToString("d");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new DeliveryPage());
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new OrderPage());
        }

        private void BtnCompany_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new CompanyPage());
        }

        private void BtnTask_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new TaskPage());
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new ProductPage());
        }

        private void BtnBrand_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new BrandPage());
        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new UserPage());
        }

        private void BtnHistoryLog_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new HistoryLogPage());
        }
    }
}
