using System;
using System.Collections.Generic;
using RazorMVCDotNetApp.Dao.Department;
using RazorMVCDotNetApp.Dto;
using RazorMVCDotNetApp.Dto.Department;
using RazorMVCDotNetApp.Interfaces.Department;
using RazorMVCDotNetApp.Models;
using RazorMVCDotNetApp.Commons;

namespace RazorMVCDotNetApp.Services.Department
{
    public class AddDepartmentService : IDepartmentService
    {
        private DepartmentDao departmentDao;
        private CryptoEngine cryptoEngine;

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
            var department = new DepartmentModel();
            var departments = new List<DepartmentModel>();
            try
            {
                departments = GetDepartment(departmentDto.IdEncryption);
                departments[0].Name = departmentDto.Name;
                departmentDao = new DepartmentDao();
                department = departmentDao.Update(departments[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Get Department for editing");
                Console.WriteLine("Error");
                Console.WriteLine(ex);
                departments.Clear();
            }

            return department;
        }
        
        public List<Object> GetDepartments(SearchDto searchDto)
        {
            var departmentList = new List<Object>();
            departmentDao = new DepartmentDao();
            string search = searchDto.search["value"];

            var departments = departmentDao.FindContaining(search);
            try
            {
                if (departments.Count == 0)
                {
                    departments = departmentDao.FindTopHundred();
                }

                foreach (var item in departments)
                {
                    var deptItem = new Dictionary<string, string>();
                    cryptoEngine = new CryptoEngine();
                    string idString = cryptoEngine.Encrypt(item.Id.ToString(), "qwer-3qa8-asdf21");
                    deptItem.Add("name", item.Name);
                    deptItem.Add("id", idString);

                    departmentList.Add(deptItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured!! ");
                Console.WriteLine("Error Details : ");
                Console.WriteLine(ex);
                departmentList = null;
            }

            return departmentList;
        }

        public List<DepartmentModel> FindAll()
        {
            departmentDao = new DepartmentDao();
            var departments = departmentDao.FindAll();

            return departments;
        }

        public List<DepartmentModel> GetDepartment(string id)
        {
            var departments = new List<DepartmentModel>();
            cryptoEngine = new CryptoEngine();
            try
            {
                id = cryptoEngine.Decrypt(id, "qwer-3qa8-asdf21");
                int idInt = Convert.ToInt32(id);
                departmentDao = new DepartmentDao();
                departments = departmentDao.FindById(idInt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get Department");
                Console.WriteLine("Error");
                Console.WriteLine(ex);
            }

            return departments;
        }

        public DepartmentModel DeleteDepartment(string id)
        {
            var department = new DepartmentModel();
            var departments = new List<DepartmentModel>();

            try
            {
                departments = GetDepartment(id);
                departmentDao = new DepartmentDao();
                department = departmentDao.Delete(departments[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Get Department for deleting");
                Console.WriteLine("Error");
                Console.WriteLine(ex);
                departments.Clear();
            }
            
            return department;
        }
    }
}