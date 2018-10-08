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
using Project_Budget.Engine;
using Project_Budget.Factories;
using Project_Budget.Models;

namespace Project_Budget
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        private string date;

        public ShopWindow()
        {
            InitializeComponent();
        }

        private void btnSearchShopping_Click(object sender, RoutedEventArgs e)
        {
            checkDate();
            List<ShoppingJoin> shoppings = new List<ShoppingJoin>();
            shoppings = ShoppingFactory.getShopping(date);
            datagridShoppings.ItemsSource = shoppings;
        }

        public void checkDate()
        {
            DateTime? selectedDate = datePickerShopping.SelectedDate;
            if (selectedDate.HasValue)
            {
                date = selectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                // MessageBox.Show("Nisi datum upisao!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnListAllShopping_Click(object sender, RoutedEventArgs e)
        {
            List<Shopping> shoppings = new List<Shopping>();
            shoppings = ShoppingFactory.getAllShoppings();
            datagridShoppings.ItemsSource = shoppings;
        }
    }
}
