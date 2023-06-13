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
    /// Логика взаимодействия для BrandAddWindow.xaml
    /// </summary>
    public partial class BrandAddWindow : Window
    {
        public BrandAddWindow()
        {
            InitializeComponent();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Brand brand = new Brand()
                {
                    BrandName = TxbBrandName.Text,
                    AddressBrand = TxbBrandAddress.Text,
                    PhoneBrand = TxbBrandPhone.Text,


                };

                DBConnect.userDataBase.Brands.Add(brand);
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

