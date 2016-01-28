using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NorthwindService2
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeesService.svc or EmployeesService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeesService : IEmployeesService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["theDB"].ToString();
        public Employees GetEmployeeById(int id)
        {
            string query =
                "SELECT [EmployeeID], [LastName], [FirstName], [Title], [Address], [City], [Country], [Notes]" +
                "FROM [dbo].[Employees]" +
                "WHERE [EmployeeID] =" + id;
            var employee = new Employees();

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query,connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employee.Id = Convert.ToInt32(reader["EmployeeID"].ToString());
                    employee.LastName = reader["LastName"].ToString();
                    employee.FirstName = reader["FirstName"].ToString();
                    employee.Title = reader["Title"].ToString();
                    employee.Address = reader["Address"].ToString();
                    employee.City = reader["City"].ToString();
                    employee.Country = reader["Country"].ToString();
                    employee.Notes = reader["Notes"].ToString();
                }
            }
            return employee;
        }

        public int UpdateEmployee(int employeeId, string lastName, string firstName, string title, string address, string city, string country,
            string notes)
        {
            string query = "UPDATE [NORTHWND].[dbo].[Employees] SET" +
                           " lastName = @LastName," +
                           " firstName = @FirstName," +
                           " title = @Title," +
                           " address = @Address," +
                           " city = @City," +
                           " country = @Country," +
                           " notes = @Notes" +
                           " WHERE employeeId = @EmployeeID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commande = new SqlCommand(query,connection);

                SqlParameter parameterId = new SqlParameter("@EmployeeID", employeeId);
                commande.Parameters.Add(parameterId);
                SqlParameter parameterLastname = new SqlParameter("@LastName", lastName);
                commande.Parameters.Add(parameterLastname);
                SqlParameter parameterFirstname = new SqlParameter("@FirstName", firstName);
                commande.Parameters.Add(parameterFirstname);
                SqlParameter parameterTitle = new SqlParameter("@Title", title);
                commande.Parameters.Add(parameterTitle);
                SqlParameter parameterAddress = new SqlParameter("@Address", address);
                commande.Parameters.Add(parameterAddress);
                SqlParameter parameterCity = new SqlParameter("@City", city);
                commande.Parameters.Add(parameterCity);
                SqlParameter parameterCountry = new SqlParameter("@Country", country);
                commande.Parameters.Add(parameterCountry);
                SqlParameter parameterNotes = new SqlParameter("@Notes", notes);
                commande.Parameters.Add(parameterNotes);

                connection.Open();
                return commande.ExecuteNonQuery();
            }
            
        }
    }
}
