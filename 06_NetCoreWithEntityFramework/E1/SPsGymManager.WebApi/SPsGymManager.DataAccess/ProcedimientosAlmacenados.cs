using Microsoft.Data.SqlClient;
using SPsGymManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPsGymManager.DataAccess
{
    public class ProcedimientosAlmacenados
    {
        const string mysqlConnectionString = "server=localhost;port=3306;database=dbgymmanager;user=root;password=1234;CharSet=utf8;SslMode=none;Pooling=false;AllowPublicKeyRetrieval=True;";

        public List<Producto> GetProductsByType(int id)
        {
            List<Producto> products = new List<Producto>();
            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);
            connection.Open();
            try
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("GetProductsInStockByType", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("typeId", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producto productResult = new Producto
                    {
                        Id = (int)reader["idProTyp"],
                        nom_proTyp = reader["nom_proTyp"] as string,
                        can_inv = (int)reader["cant_Inv"]
                    };
                    products.Add(productResult);
                }
            }
            finally
            {
                connection.Close();
            }
            return products;

        }

        public List<Members> GetMemberLastWeek()
        {
            List<Members> users = new List<Members>();
            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);
            connection.Open();

            try
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("GetMemberLastWeek", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Members user = new Members
                    {
                        Id = (int)reader["idMembers"],
                        fi_meb = (DateTime)reader["fi_meb"],
                        ff_meb = (DateTime)reader["fi_meb"],
                        User = (int)reader["idUser"],
                        MemTyp = (int)reader["idMemTyp"],
                        nom_memT = reader["nom_MemT"] as string

                    };

                    users.Add(user);

                }
            }
            finally
            {

                connection.Close();
            }
            return users;
        }

        public void NewSale(Sale sale)
        {

            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);
            connection.Open();
            try
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("NewSale", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("idPro", sale.idPro);
                command.Parameters.AddWithValue("cant", sale.cant);
                command.Parameters.AddWithValue("idMem", sale.idMem);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
