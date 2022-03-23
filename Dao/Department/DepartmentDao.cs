using System.Collections.Generic;
using System.Linq;
using RazorMVCDotNetApp.Data;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Dao.Department
{
    public class DepartmentDao
    {
        
        DbConnection con = new DbConnection();

        public DepartmentDao(){ }
        
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

        public List<DepartmentModel> FindContaining(string search)
        {
            return con.Department.Where(d=>d.Name.Contains(search)).ToList();
        }

        public List<DepartmentModel> FindTopHundred()
        {
            return con.Department.OrderBy(d=>d.Id).Take(100).ToList();
        }

        public List<DepartmentModel> FindById(int id)
        {
            return con.Department.Where(d => d.Id == id).ToList();
        }

        public DepartmentModel Update(DepartmentModel department)
        {
            con.Department.Update(department);
            con.SaveChanges();
            return department;
        }

        public DepartmentModel Delete(DepartmentModel department)
        {
            con.Department.Remove(department);
            con.SaveChanges();
            return department;
        }
    }
}