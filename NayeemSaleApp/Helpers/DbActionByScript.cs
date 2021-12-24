//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using Microsoft.Data;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;


//namespace NayeemSaleApp.Helpers
//{
//    public static class DbActionByScript
//    {
//        public static void ActionByScript(string script)
//        {
//            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
//            var configuration = builder.Build();

//            using (var db = new SqlConnection(configuration.GetConnectionString("AppDbConnection")))
//            {
//                db.Open();

//                string Tmp1 = $"{script}";
//                SqlCommand cmd1 = new SqlCommand(Tmp1, db);
//                cmd1.ExecuteScalar();

//                db.Close();
//            }
//        }
//    }
//}
