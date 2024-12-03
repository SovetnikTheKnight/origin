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

namespace Produlator
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        //private Requests request = new Requests();
        //private Equipment equipment = new Equipment();
        //private Clients client = new Clients();
        //private FaultTypes faultType = new FaultTypes();
        private Produlator_dbEntities1 context;
        public AddEditWindow()
        {
            InitializeComponent();
        }


        private goods good = new goods();
        private shelf shelf = new shelf();
        private product product = new product();
        private product_date product_date = new product_date();
        private void BtnSave_Click(Object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (NumTextBpx.Text == null)
            {
                error.AppendLine("Введите номер товара!");
            }
            else if (!int.TryParse(good.goods_id.ToString(), out int applicationNumber) || applicationNumber <= 0)
                error.AppendLine("Номер заявки должен иметь положительное и не отрицательное значение!");
            else if (Produlator_dbEntities1.GetInstance().goods.Any(row => row.goods_id == good.goods_id))
                error.AppendLine("Номер заявки уже существует!");
            if (product_date.arrival_date== null || product_date.arrival_date == DateTime.MinValue)
                error.AppendLine("Укажите дату доставки!");
            if (product_date.expiration_date== null || product_date.expiration_date == DateTime.MinValue)
                error.AppendLine("Укажите дату порчи!");
            if (shelf.shelf_name == null) error.AppendLine("Укажите название полки!");

            try
            {
                var context = Produlator_dbEntities1.GetInstance();

                shelf.shelf_name = ShelfTextBox.Text;
                context.shelf.Add(shelf);

                product.product_amount = Convert.ToInt32(AmountTextBox.Text);
                product.product_name = Product_text_box.Text;
                context.product.Add(product);

                product_date.product_id = product.product_id;
                product_date.arrival_date = DateTime.Parse(DeliverTextBox.Text);
                product_date.expiration_date = DateTime.Parse(RotTextBox.Text);
                context.product_date.Add(product_date);

                good.goods_id = Convert.ToInt32(NumTextBpx.Text);
                good.shelf_id = shelf.shelf_id;
                good.product_id = product.product_id;
                good.product_date_id = product_date.product_date_id;
                good.descr = DescrTextBox.Text;
                context.goods.Add(good);

                context.SaveChanges();

                MainWindow.main_window_instance.frame_what_to_sort_by.Navigate(new choose_by_products_page(Produlator_dbEntities1.GetInstance()));


                this.Close();

            } catch (Exception ex) { error.AppendLine(ex.ToString()); }
        }
    }
}
