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
using Project_Budget.Engine;
using Project_Budget.Factories;

namespace Project_Budget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Items items = new Items();
        Trgovina stores = new Trgovina();

        public string date;

        public MainWindow()
        {
            InitializeComponent();

            // popuni combobox za trgovine
            List<Trgovina> stores = new List<Trgovina>();
            stores = StoreFactory.getAllStores();
            comboxStoreNames.ItemsSource = stores;
            comboxStoreNames.DisplayMemberPath = "ime_trg";
            comboxStoreNames.SelectedValuePath = "id";

            // popuni combobox za payment type
            comboxShoppingPaymentType.Items.Add("Cash");
            comboxShoppingPaymentType.Items.Add("Card");
        }

        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            items.Owner = this;
            items.ShowDialog();
        }

        private void btnSearchItemByName_Click(object sender, RoutedEventArgs e)
        {
            List<Item> items = new List<Item>();
            items = ItemFactory.getItems(txtboxItemNameSearch.Text.Trim());

            this.datagridItems.ItemsSource = items;
            this.datagridItems.SelectedValuePath = "itm_id";

            txtboxItemNameSearch.Text = "";
        }

        private void btnShoppingAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                checkDate();
                ShoppingFactory.addShopping(txtboxShoppingName.Text.Trim(),
                     (int)datagridItems.SelectedValue, (int)comboxStoreNames.SelectedValue,
                        Convert.ToInt32(txtboxShoppingQuantity.Text.Trim()), 
                            comboxShoppingPaymentType.SelectedItem.ToString(), date);

                txtboxShoppingQuantity.Text = "";

                MessageBox.Show("Shopping uspjesno dodan!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Moras popuniti sve!", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

        public void checkDate()
        {
            DateTime? selectedDate = datePickerShopping.SelectedDate;
            if (selectedDate.HasValue)
            {
                date = selectedDate.Value.ToString("yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
               // MessageBox.Show("Nisi datum upisao!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnShoppingWindow_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow shop = new ShopWindow();
            shop.Owner = this;
            shop.ShowDialog();
        }
    }
}
