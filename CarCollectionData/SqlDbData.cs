using System;
using System.Data.SqlClient;
using CarCollectionModel;

namespace CarCollectionData
{
    public class SqlDbData
    {
        static string connectionString
            //= "Server = tcp:20.189.113.46,1433; Database = CarManagement; User Id = sa; Password = integ2!"; //RDP
        = "Data Source =MATTHEW\\SQLEXPRESS; Initial Catalog = CarManagement; Integrated Security = True;"; //LOCAL

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Cars> GetCars()
        {
            string selectStatement = "SELECT Brand, Model, YearModel FROM Cars";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Cars> cars = new List<Cars>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string Brand = reader["Brand"].ToString();
                string Model = reader["Model"].ToString();
                string YearModel = reader["YearModel"].ToString();

                Cars readCars = new Cars();
                readCars.Brand = Brand;
                readCars.Model = Model;
                readCars.YearModel = YearModel;

                cars.Add(readCars);
            }

            sqlConnection.Close();

            return cars;

        }
        public int AddCars(string Brand, string Model, string YearModel)
        {
            int success;

            string insertStatement = "INSERT INTO cars VALUES (@Brand, @Model, @YearModel)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Brand", Brand);
            insertCommand.Parameters.AddWithValue("@Model", Model);
            insertCommand.Parameters.AddWithValue("@YearModel", YearModel);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();
            
            sqlConnection.Close();

            return success;
        }
        
        public int UpdateCars(string Brand, string Model, string YearModel)
        {
            int success;

            string updateStatement = $"UPDATE cars SET Model = @Model WHERE Brand = @Brand";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@Model", Model);
            updateCommand.Parameters.AddWithValue("@Brand", Brand);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;

        }

        public int DeleteCars(string Brand)
        {
            int success;

            string deleteStatement = $"DELETE FROM cars WHERE Brand = @Brand";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@Brand", Brand);


            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}
