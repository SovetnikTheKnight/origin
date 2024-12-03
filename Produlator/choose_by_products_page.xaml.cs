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

namespace Produlator
{
    /// <summary>
    /// Логика взаимодействия для choose_by_products_page.xaml
    /// </summary>
    public partial class choose_by_products_page : Page
    {
        public static choose_by_products_page Choose_By_Products_Page = null;

        Produlator_dbEntities1 instance = Produlator_dbEntities1.GetInstance();

        public product button_request;

        public choose_by_products_page()
        {
            InitializeComponent();
            var get_products = instance.product.ToList();
            ProductsGrid.ItemsSource = get_products;
        }
        public choose_by_products_page(Produlator_dbEntities1 entity)
        {
            InitializeComponent();
            var get_products = entity.product.ToList();
            ProductsGrid.ItemsSource = get_products;
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            button_request = (sender as Button)?.DataContext as product; ///
            sort_by_products_page sort_By_Products_Page = new sort_by_products_page(button_request);
            // GOD...
            MainWindow.main_window_instance.frame_2.Navigate(sort_By_Products_Page);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Choose_By_Products_Page = this;
        }
    }
}
