using System.Collections.Generic;
using System.Linq;
using Data.DataBaseConnection;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Dao.Department
{
    public class DepartmentDao
    {
        
        private readonly DbConnection con;

        public DepartmentDao(DbConnection con)
        {
            this.con = con;
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