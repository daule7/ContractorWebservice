using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;


namespace ContractorWebservice
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private const string CONNECTION_STRING = "Data Source=dwh-test;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [WebMethod]
        public void Create(string iin, string name, int age, DateTime createdDate, DateTime editedDate,string gender)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Individ_contractor (iin, name,age,created_date,edited_date,gender) VALUES (@iin,@name, @age,@createdDate,@editedDate,@gender)", connection))
                {
                    command.Parameters.AddWithValue("@iin", iin);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@createdDate", createdDate);
                    command.Parameters.AddWithValue("@editedDate", editedDate);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Read a record from the database
        [WebMethod]
        public DataSet Read(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Individ_contractor WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }
       
       

        // Update a record in the database
        [WebMethod]
        public void Update(int id,string iin, string name, int age,DateTime createdDate, DateTime editedDate, string gender)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Individ_contractor SET iin = @iin, name = @name, age = @age, created_date = @createdDate,edited_date = @editedDate,gender = @gender WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@iin", iin);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@createdDate", createdDate);
                    command.Parameters.AddWithValue("@editedDate", editedDate);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete a record from the database
        [WebMethod]
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Individ_contractor WHERE Id = @id", connection))
                    connection.Close();

            }
        }

        public DataSet Search(string name, int minAge, int maxAge)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Indivivd_contractor WHERE name LIKE @name AND Age >= @minAge AND Age <= @maxAge", connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + name + "%");
                    command.Parameters.AddWithValue("@minAge", minAge);
                    command.Parameters.AddWithValue("@maxAge", maxAge);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }        

    }
}
