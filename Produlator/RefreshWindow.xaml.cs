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
    /// Логика взаимодействия для RefreshWindow.xaml
    /// </summary>
    public partial class RefreshWindow : Window
    {

        private product db_instance;
        public RefreshWindow(product selectedRequest)
        {
            InitializeComponent();
            db_instance = selectedRequest;


        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь код для обновления данных в базе
        }
    }
}
