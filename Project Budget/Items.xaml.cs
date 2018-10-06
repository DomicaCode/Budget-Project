using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;
using Project_Budget.Engine;
using Dapper;

namespace Project_Budget
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Window
    {
        DataAccess da = new DataAccess();

        public Items()
        {
            InitializeComponent();
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            da.addItems(txtboxItemName.Text.Trim(), float.Parse(txtboxItemPrice.Text));

            txtboxItemName.Text = "";
            txtboxItemPrice.Text = "";
        }

        private void btnSearchItemByName_Click(object sender, RoutedEventArgs e)
        {
            List<Item> items = new List<Item>();
            items = da.getItems(txtboxItemNameSearch.Text.Trim());

            this.datagridItems.ItemsSource = items;

            txtboxItemNameSearch.Text = "";
        }

        public void fillData(int sqlOutput)
        {
            DataTable da = new DataTable();


        }
    }
}
