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
    /// Логика взаимодействия для CompanyAddWindow.xaml
    /// </summary>
    public partial class CompanyAddWindow : Window
    {
        public CompanyAddWindow()
        {
            InitializeComponent();
        }

        private void BtnAddCompany_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Company company = new Company()
                {
                    CompanyName = TxbCompanyName.Text,
                    Address = TxbCompanyAddress.Text,
                    Phone = TxbCompanyPhone.Text,


                };

                DBConnect.userDataBase.Companies.Add(company);
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
