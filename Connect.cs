using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;

namespace WebSite
{
    public class Connect
    {
        private string connectString;
        private DataSet ds;
        
        public string ConnectString
        {
            get { return connectString; }
            set { connectString = value; }
        }

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        public Connect(string ConnString)
        {
            connectString = ConnString;
        }

        public Connect()
        { }

        public DataSet SqlCommand(string sqlCommand)
        {
            ds = new DataSet();
            try
            {
                using (MySqlDataAdapter dataAdapter =
                new MySqlDataAdapter(sqlCommand, connectString))
                {
                    dataAdapter.Fill(ds, "list");
                    dataAdapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return ds;
        }
    }
}