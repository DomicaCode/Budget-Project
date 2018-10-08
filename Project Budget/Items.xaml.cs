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
using Project_Budget.Factories;
using Dapper;

namespace Project_Budget
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Window
    {

        public Items()
        {
            InitializeComponent();
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemFactory.addItems(txtboxItemName.Text.Trim(), float.Parse(txtboxItemPrice.Text), txtboxItemDesc.Text.Trim());

                txtboxItemName.Text = "";
                txtboxItemPrice.Text = "";
                txtboxItemDesc.Text = "";

                MessageBox.Show("Item uspjesno dodan!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Moras popuniti sve!", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

    }
}
