using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для sort_by_products_page.xaml
    /// </summary>
    public partial class sort_by_products_page : Page
    {
        public static sort_by_products_page Sort_By_Products_Page = null;
        private product _product_instance;
        public sort_by_products_page(product product)
        {
            InitializeComponent();
            _product_instance = product;
            var context = Produlator_dbEntities1.GetInstance();

            try
            {
                // Monstrosity
                var thingy = context.goods.Where(x => x.product_id == _product_instance.product_id)
                    .Join(context.shelf,
                    g => g.shelf_id,
                    s => s.shelf_id,
                    (g, s) => new { g.goods_id, g.descr, g.product_id, s.shelf_name, g.product_date_id }
                    )
                    .Join(context.product,
                    g => g.product_id,
                    p => p.product_id,
                    (g, p) => new { g.goods_id, g.descr, p.product_amount, g.shelf_name, g.product_date_id }
                    );
                sort_by_products_datagrid.ItemsSource = thingy.Join(context.product_date,
                    g => g.product_date_id,
                    p => p.product_date_id,
                    (g,p) => new {g.goods_id, g.descr, g.product_amount, g.shelf_name, p.arrival_date, p.expiration_date }).ToList();
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Sort_By_Products_Page = this;
        }
    }
}