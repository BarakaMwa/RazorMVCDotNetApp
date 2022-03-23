using System.Collections.Generic;
using System.Linq;
using RazorMVCDotNetApp.Data;
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

        public List<EmployeeModel> FindAll()
        {
            return con.Employee.OrderBy(d=>d.Id).ToList();
        }

        public List<EmployeeModel> FindContaining(string search)
        {
            return con.Employee.Where(d=>d.FirstName.Contains(search) || d.LastName.Contains(search)).ToList();
        }
        
        public List<EmployeeModel> FindTopHundred()
        {
            return con.Employee.OrderBy(d=>d.Id).Take(100).ToList();
        }

        public List<EmployeeModel> FindById(int id)
        {
            return con.Employee.Where(d => d.Id == id).ToList();
        }
        
        public EmployeeModel Update(EmployeeModel employee)
        {
            con.Employee.Update(employee);
            con.SaveChanges();
            return employee;
        }

        public EmployeeModel Delete(EmployeeModel employee)
        {
            con.Employee.Remove(employee);
            con.SaveChanges();
            return employee;
        }
        
    }
}