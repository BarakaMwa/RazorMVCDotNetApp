using System;
using System.Collections.Generic;
using Data.DataBaseConnection;
using RazorMVCDotNetApp.Dao.Department;
using RazorMVCDotNetApp.Dto.Department;
using RazorMVCDotNetApp.Interfaces.Department;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Services.Department
{
    public class AddDepartmentService : IDepartmentService
    {
        private DepartmentDao departmentDao;

        public AddDepartmentService()
        {
        }
        
        public DepartmentModel AddDepartment(DepartmentDto departmentDto)
        {
            var department = new DepartmentModel();

            try
            {
                department.Name = departmentDto.Name;
                //goes in doa as function save
                departmentDao = new DepartmentDao();
                return departmentDao.Save(department);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Add Department");
                Console.WriteLine(ex);
                return department;
            }
        }

        public DepartmentModel EditDepartment(DepartmentDto departmentDto)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentModel> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}