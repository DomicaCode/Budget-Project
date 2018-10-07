using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Budget.Engine;
using Dapper;

namespace Project_Budget.Factories
{
    public class ItemFactory
    {
        public static void addItems(string item_name, float item_price, string item_desc)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                List<Item> items = new List<Item>();
                items.Add(new Item
                {
                    itm_name = item_name,
                    itm_price = item_price,
                    itm_desc = item_desc
                });
                connection.Execute("ItemsAdd", items,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public static List<Item> getItems(string item_name)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                var i = new DynamicParameters();
                i.Add("_itm_name", item_name);

                return connection.Query<Item>("ItemsSearch", i,
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
