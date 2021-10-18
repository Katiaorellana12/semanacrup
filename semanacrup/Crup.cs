using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace semanacrup
{
    class Crup
    {

        private Connection conn = new Connection();

        public MySqlDataReader select(string query)
        {
            MySqlDataReader dataReader;

         
            conn.command = new MySqlCommand(query, conn.openConnection()); 
            dataReader = conn.command.ExecuteReader();
            return dataReader;
        }


        public void executeQuery(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            conn.command = new MySqlCommand(query, conn.openConnection());
            adapter.InsertCommand = conn.command;
            adapter.InsertCommand.ExecuteNonQuery(); 
            conn.closeConnection();
        }
    }
}
