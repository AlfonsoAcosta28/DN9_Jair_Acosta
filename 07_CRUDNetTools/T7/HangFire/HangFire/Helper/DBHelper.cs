namespace HangFire.Helper
{
    public class DBHelper
    {
        const string connectionString = "server=localhost;port=3306;database=zhemehangfire;user=root;password=1234;CharSet=utf8;SslMode=none;Pooling=false;AllowPublicKeyRetrieval=True;";

        public static void Process(int miliseconds, string args)
        {
            Thread.Sleep(miliseconds);

            MySqlConnector.MySqlConnection mySqlConnection = new MySqlConnector.MySqlConnection(connectionString);

            mySqlConnection.Open();
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(
                "Insert into hftest (date,args) values (@date,@args)");

            command.Connection = mySqlConnection;
            command.Parameters.AddWithValue("@date", DateTime.Now);
            command.Parameters.AddWithValue("@args", args);

            command.ExecuteNonQuery();
        }
    }
}
