using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NorthwindService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeesService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeesService
    {
        [OperationContract]
        [FaultContract(typeof(ApplicationException))]
        Employees GetEmployeeById(int id);

        [OperationContract]
        int UpdateEmployee(int id, string lastName, string firstName, string title, 
            string address, string city, string country, string notes);
    }
}
