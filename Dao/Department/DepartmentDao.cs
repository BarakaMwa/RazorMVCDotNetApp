using System.Collections.Generic;
using System.Linq;
using Data.DataBaseConnection;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Dao.Department
{
    public class DepartmentDao
    {
        
        DbConnection con = new DbConnection();

        public DepartmentDao()
        {
        }
        
        public DepartmentModel Save(DepartmentModel department)
        {
            con.Department.Add(department);
            con.SaveChanges();

            return department;
        }

        public List<DepartmentModel> FindAll()
        {
            return con.Department.OrderBy(d=>d.Name).ToList();
        }
    }
}