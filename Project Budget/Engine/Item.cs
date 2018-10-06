using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace Project_Budget.Engine
{
    public class Item
    { 
        public int itm_id { get; set; }
        public string itm_name { get; set; }
        public float itm_price { get; set; }


    }
}
