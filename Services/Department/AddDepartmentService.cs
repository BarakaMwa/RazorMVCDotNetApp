using System;
using System.Collections.Generic;
using RazorMVCDotNetApp.Dao.Department;
using RazorMVCDotNetApp.Dto;
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

        public List<DepartmentModel>? GetDepartments(SearchDto searchDto)
        {
            departmentDao = new DepartmentDao();
            string search = searchDto.search["value"];
            
            var departments = departmentDao.FindContaining(search);
            try
            {
                if (departments.Count == 0)
                {
                    departments = departmentDao.FindTopHundred();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured!! ");
                Console.WriteLine("Error Details : ");
                Console.WriteLine( ex );
                departments = null;
            }
            

            return departments;
        }

        public List<DepartmentModel> FindAll()
        {
            departmentDao = new DepartmentDao();
            var departments = departmentDao.FindAll();

            return departments;
        }
    }
}