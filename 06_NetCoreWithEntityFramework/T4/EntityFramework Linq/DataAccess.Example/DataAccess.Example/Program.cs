using DataAccess.Example.Entities;
using System;
namespace DataAccess.Example
{
    class Program
    {
        const string mysqlConnectionString = "server=localhost;port=3306;database=sqltesting;user=root;password=1234;CharSet=utf8;SslMode=none;Pooling=false;AllowPublicKeyRetrieval=True;";
        static void Main(string[] args)
        {
            var allUsers = GetUsers();
            var user = GetUserById(1);
            var user2 = GetUserById(2);
          //  var result = CreateCompany("Hp", "MX", "admin@hp.com", "user@hp.com");
        }

        private static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);
            connection.Open();

            try
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("GetAllUsers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = (int)reader["idUser"],
                        UserName = reader["userName"] as string,
                        Email = reader["email"] as string,
                        CompanyId = (int)reader["idCompany"]

                    };

                    users.Add(user);

                }
            }
            finally{

                connection.Close();
            }
            return users;
        }

        private static User GetUserById(int userId)
        {
            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);
            connection.Open();
            User user = null;
            try
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("GetUserById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("_id", userId);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["idUser"],
                        UserName = reader["userName"] as string,
                        Email = reader["email"] as string,
                        CompanyId = (int)reader["idCompany"]

                    };
                }
            }
            finally
            {

                connection.Close();
            }
            return user;
        }

        private static companyCreationResult CreateCompany(string companyName, string companyLocation, string adminEmail, string employeEmail)
        {
            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);
            connection.Open();
            companyCreationResult result = null;
            try
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("CreateCompany", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("_companyName", companyName);
                command.Parameters.AddWithValue("_location", companyLocation);
                command.Parameters.AddWithValue("_adminEmail", adminEmail);
                command.Parameters.AddWithValue("_userEmail", employeEmail);

                var companyIdParameter = command.Parameters.Add("_idcompany", System.Data.DbType.Int32);
                companyIdParameter.Direction = System.Data.ParameterDirection.Output;

                var adminIdParameter = command.Parameters.Add("_idadmin", System.Data.DbType.Int32);
                adminIdParameter.Direction = System.Data.ParameterDirection.Output;

                var userIdParameter = command.Parameters.Add("_iduser", System.Data.DbType.Int32);
                userIdParameter.Direction = System.Data.ParameterDirection.Output;

                command.ExecuteNonQuery();
                result = new companyCreationResult
                    {
                      CompanyId =(int) companyIdParameter.Value,
                      AdminId = (int) adminIdParameter.Value,
                      UserId = (int) userIdParameter.Value
                };
                
            }
            finally
            {

                connection.Close();
            }
            return result;
        }
    }
}