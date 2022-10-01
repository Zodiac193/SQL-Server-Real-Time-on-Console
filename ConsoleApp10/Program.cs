using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;

namespace ConsoleApp10
{
     class Program
    {
        public static void Main(string[] args)
        {
            string connection = @"Data Source=DESKTOP-LBIQ3KN\SQLEXPRESS; Initial Catalog=new_db; User id = sa1 ; password = 123456;";

             using (var tbDependancy = new SqlTableDependency<Orders>(connection) )
            {
                tbDependancy.OnChanged += TbDependancy_OnChanged;
                tbDependancy.Start();

                Console.ReadKey();
            }
        }

        private static void TbDependancy_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Orders> e)
        {
            //throw new NotImplementedException();

            if(e.ChangeType != ChangeType.None)
            {
                var Entry = e.Entity;
                Console.WriteLine("Type : " + e.ChangeType );
                Console.WriteLine("ID : " + Entry.id + "\n" +"Status :" + Entry.Status);
            }
        }
    }
}
