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

namespace Project_Budget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Items items = new Items();
        Trgovina stores = new Trgovina();
        DataAccess da = new DataAccess();

        public MainWindow()
        {
            InitializeComponent();

            List<Trgovina> stores = new List<Trgovina>();
            stores = da.getAllStores();
            comboxStoreNames.ItemsSource = stores;
            comboxStoreNames.DisplayMemberPath = "ime_trg";
            comboxStoreNames.SelectedValuePath = "id";
        }

        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            items.Owner = this;
            items.ShowDialog();
        }

        private void btnSearchItemByName_Click(object sender, RoutedEventArgs e)
        {
            List<Item> items = new List<Item>();
            items = da.getItems(txtboxItemNameSearch.Text.Trim());

            this.datagridItems.ItemsSource = items;

            txtboxItemNameSearch.Text = "";
        }
    }
}
