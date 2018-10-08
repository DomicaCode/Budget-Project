using Dapper;
using MySql.Data.MySqlClient;
using Project_Budget.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Budget.Models;

namespace Project_Budget.Factories
{
    public class ShoppingFactory
    {

        public static void addShopping(string sop_name, int item_id, int trg_id, int item_quantity, string payment_type, string date)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                List<Shopping> shoppings = new List<Shopping>();
                shoppings.Add(new Shopping { sop_name = sop_name, itm_id = item_id, trg_id = trg_id,
                    item_quantity = item_quantity, payment_type = payment_type, datum = date });
                connection.Execute("SopingInsert", shoppings,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static List<ShoppingJoin> getShopping(string shop_name, string date)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                var p = new DynamicParameters();
                p.Add("_datum", date);

                return connection.Query<ShoppingJoin>("SopingSearch", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<Shopping> getAllShoppings()
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                return connection.Query<Shopping>("SELECT * FROM soping").ToList();
            }
        }
    }
}
