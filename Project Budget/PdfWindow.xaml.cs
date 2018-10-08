using iTextSharp.text;
using iTextSharp.text.pdf;
using MoreLinq;
using Project_Budget.Engine;
using Project_Budget.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace Project_Budget
{
    /// <summary>
    /// Interaction logic for PdfWindow.xaml
    /// </summary>
    public partial class PdfWindow : Window
    {
        List<Item> items = new List<Item>();
        DataTable dt = new DataTable();


        public PdfWindow()
        {
            InitializeComponent();
        }

        private void btnGetItems_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxItemSearch.Text != "")
            {
                List<Item> i = ItemFactory.getItems(txtboxItemSearch.Text.Trim());
                items.AddRange(i);
                datagridItems.ItemsSource = items;
                datagridItems.SelectedValuePath = "itm_id";
                datagridItems.DataContext = items;


                txtboxItemSearch.Text = "";
            }
            else
            {
                MessageBox.Show("Nisi nista upisao!");
            }

        }


        private void btnGetPdf_Click(object sender, RoutedEventArgs e)
        {
            dt = items.ToDataTable();
            Logic.exportGridPdf(dt);
            this.Close();
        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
