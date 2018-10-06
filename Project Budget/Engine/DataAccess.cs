using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using Project_Budget;

namespace Project_Budget.Engine
{
    public class DataAccess
    {

        public void addItems(string item_name, float item_price)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {


                List<Item> items = new List<Item>();

                items.Add(new Item { itm_name = item_name, itm_price = item_price });

                connection.Execute("ItemsAdd", items, commandType: CommandType.StoredProcedure);


                /* Laksi nacin
                var i = new DynamicParameters();

                i.Add("_itm_name", item_name);
                i.Add("_itm_price", item_price);

                var output = connection.Execute("ItemsAdd", i, commandType: CommandType.StoredProcedure);
                */

            }
        }
        
        public List<Item> getItems(string item_name)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                connection.Open();
                var i = new DynamicParameters();
                i.Add("_itm_name", item_name);

                return connection.Query<Item>($"ItemsSearch", i, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
    }
}
