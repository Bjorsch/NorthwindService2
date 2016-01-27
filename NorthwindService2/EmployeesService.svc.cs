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

        public int UpdateEmployee(int id, string lastName, string firstName, string title, string address, string city, string country,
            string notes)
        {
            throw new NotImplementedException();
        }
    }
}
