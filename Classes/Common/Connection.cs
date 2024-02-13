﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace savichev27pr.Classes.Common
{
    public class Connection
    {
        public static  readonly string config = "server=localhost;uid=root;pwd=;database=kino;";
        public MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(config);
            connection.Open();
            return connection;
        }

        public MySqlDataReader Queryable(string SQL, MySqlConnection connection)
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }

        public void CloseConnection(MySqlConnection connection) 
        { 
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
