using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Budget.Engine;

namespace Project_Budget.Factories
{
    public class StoreFactory
    {
        public static List<Trgovina> getAllStores()
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("dbConn")))
            {
                return connection.Query<Trgovina>("TrgovineViewAll", null,
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
