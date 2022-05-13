using FlowerShop.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FlowerShop.Controllers
{
    internal class FlowerDAO
    {
        private string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=FlowersDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<FlowersModel> FetchAll()

        {

            List<FlowersModel> returnList = new List<FlowersModel>();
            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                string sqlQuery = "SELECT * from dbo.Flowers";



                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();



                if (reader.HasRows)

                {

                    while (reader.Read())

                    {

                        //create a new flower object.  Add it to the list to return.   

                        FlowersModel flower = new FlowersModel();

                        flower.Id = reader.GetInt32(0);

                        flower.Name = reader.GetString(1);

                        flower.Flowering = reader.GetString(2);

                        flower.Colour = reader.GetString(3);

                        flower.Size = reader.GetInt32(4);



                        returnList.Add(flower);

                    }

                }

            }

            return returnList;
        }

        public FlowersModel FetchOne(int Id)

        {

            FlowersModel flower = new FlowersModel();

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                string sqlQuery = "SELECT * from dbo.Flowers Where Id = @Id";

                //associate @ id with parameter 

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {

                    while (reader.Read())

                    {

                        //create a new flower object.  Add it to the list to return.  

                        flower.Id = reader.GetInt32(0);

                        flower.Name = reader.GetString(1);

                        flower.Flowering = reader.GetString(2);

                        flower.Colour = reader.GetString(3);

                        flower.Size = reader.GetInt32(4);

                    }

                }

            }

            return flower;

        }

        public int CreateOrUpdate(FlowersModel flowersModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                FlowersModel flower = new FlowersModel();

                string sqlQuery = "";

                if (flowersModel.Id <= 0)

                {

                    sqlQuery = "INSERT INTO dbo.Flowers Values(@Name, @Flowering, @Colour, @Size)";

                }

                else

                {

                    // update 

                    sqlQuery = "UPDATE dbo.Flowers SET Name = @Name, Flowering = @Flowering, Colour = @Colour, Size = @Size WHERE Id = @Id";

                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = flowersModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = flowersModel.Name;
                command.Parameters.Add("@Flowering", System.Data.SqlDbType.VarChar, 1000).Value = flowersModel.Flowering;
                command.Parameters.Add("@Colour", System.Data.SqlDbType.VarChar, 1000).Value = flowersModel.Colour;
                command.Parameters.Add("@Size", System.Data.SqlDbType.Int).Value = flowersModel.Size;


                connection.Open();

                int newID = command.ExecuteNonQuery();

                return newID;
            }
        }
    }
}