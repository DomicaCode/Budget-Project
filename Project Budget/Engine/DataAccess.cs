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

        public void addItems(string item_name, float item_price, string item_desc)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                List<Item> items = new List<Item>();
                items.Add(new Item { itm_name = item_name, itm_price = item_price,
                                        itm_desc = item_desc });
                connection.Execute("ItemsAdd", items,
                    commandType: CommandType.StoredProcedure);

            }
        }
        
        public List<Item> getItems(string item_name)
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

        public List<Trgovina> getAllStores()
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                return connection.Query<Trgovina>("TrgovineViewAll", null,
                    commandType: CommandType.StoredProcedure
                    ).ToList();

            }
        }

        public void addShop(string sop_name, int item_id, int trg_id, int item_quantity, string payment_type, string date)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                List<Shopping> shoppings = new List<Shopping>();
                shoppings.Add(new Shopping { sop_name = sop_name, itm_id = item_id, trg_id = trg_id, item_quantity = item_quantity, payment_type = payment_type, datum = date });
                connection.Execute("SopingInsert", shoppings, 
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Shopping> getShopping(string shop_name, string date)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                var p = new DynamicParameters();
                p.Add("_sop_name", shop_name);
                p.Add("_datum", date);

                return connection.Query<Shopping>("SopingSearch", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Shopping> getAllShoppings()
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                return connection.Query<Shopping>("SELECT * FROM soping").ToList();
            }
        }
    }
}
