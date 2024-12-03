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
using System.Data.Entity;
namespace Produlator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main_window_instance = null;
        public static int state = 0;
        static sort_by_products_page temp_var = null;
        public choose_by_products_page Choose_By_Products_Page = new choose_by_products_page();


        public MainWindow()
        {
            InitializeComponent();
            this.Loaded+= MainWindow_Loaded;
            CheckForState();
            Vis();
        }
        public void CheckForState()
        {
            
            if (state == 2)
            {
                this.frame_what_to_sort_by.Navigate(this.Choose_By_Products_Page);
                if (Choose_By_Products_Page.button_request != null)
                {
                    var sort_by_products_ = new sort_by_products_page(Choose_By_Products_Page.button_request);
                    temp_var = sort_by_products_;
                    this.frame_2.Navigate(sort_by_products_);
                }
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            main_window_instance = this;
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow refreshWindow = new RefreshWindow(Choose_By_Products_Page.button_request);
        }
        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            if (addEditWindow.ShowDialog() == true)
            {
                AddEditWindow addEdit = new AddEditWindow();
                addEdit.ShowDialog();
            }
        }
        private void Vis()
        {
            switch (Authorization.authorizationRole)
            {
                case 1:
                    break;
                case 2:
                    //Delete_button.Visibility = Visibility.Collapsed;
                    Add_button.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    Delete_button.Visibility = Visibility.Collapsed;
                    Add_button.Visibility = Visibility.Collapsed;
                    mainMenu.Visibility = Visibility.Collapsed;
                    //var LastRowIndex = big_table.Columns.Count - 1;
                    //var column = big_table.Columns[LastRowIndex];
                    //column.Visibility = Visibility.Collapsed;
                    break;
                default:
                    return;
            }
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var context = Produlator_dbEntities1.GetInstance();
            List<product> products_to_remove = null;
            if (choose_by_products_page.Choose_By_Products_Page.ProductsGrid.SelectedItems.Count > 0)
            {
                products_to_remove = choose_by_products_page.Choose_By_Products_Page.ProductsGrid.SelectedItems.Cast<product>().ToList();
            }
            if ((products_to_remove.Any() /*|| goods_to_remove.Any()*/) && MessageBox.Show($"Вы точно хотите удалить следующее {products_to_remove.Count()} продуктов и  товаров?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                context.product.RemoveRange(products_to_remove);

                // ...yeah...
                foreach (var product in products_to_remove)
                {
                    foreach (var good in context.goods)
                    {
                        if (product.product_id == good.product_id) context.goods.Remove(good);
                    }
                }

                context.SaveChanges();
                frame_what_to_sort_by.Navigate(new choose_by_products_page());
                frame_2.Navigate(sort_by_products_page.Sort_By_Products_Page);
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            state = 2;
        }


        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {

    }

        private void ComboBox_Choose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_choose_Click(object sender, RoutedEventArgs e)
        {
            state = 2;
            frame_2.Navigate(temp_var);
            CheckForState();
        }
    }
}
