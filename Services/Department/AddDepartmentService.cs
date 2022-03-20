using System;
using Data.DataBaseConnection;
using RazorMVCDotNetApp.Dao.Department;
using RazorMVCDotNetApp.Interfaces.Department;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Services.Department
{
    public class AddDepartmentService : IDepartmentService
    {
        private DepartmentDao departmentDao;
        public AddDepartmentService(){}

        private readonly DbConnection con;
        
        public DepartmentModel AddDepartment(string name)
        {
            var department = new DepartmentModel();

            try
            {
                department.Name = name;
                //goes in doa as function save
                return departmentDao.Save(department);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Add Department");
                Console.WriteLine(ex);
                return department;
            }
        }
    }
}