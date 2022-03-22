using Data.DataBaseConnection;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Dao.Employee
{
    public class EmployeeDao
    {
        DbConnection con = new DbConnection();
        
        public EmployeeDao(){}

        public EmployeeModel Save(EmployeeModel employee)
        {
            con.Employee.Add(employee);
            con.SaveChanges();

            return employee;
        }
    }
}