using Microsoft.EntityFrameworkCore;
using RazorMVCDotNetApp.Models;

namespace Data.DataBaseConnection
{
    public class DbConnection: DbContext
    {
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<DepartmentModel> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost;userid=root;pwd=rootmysql;port=3399;database=test;sslmode=none;");
        }
    }
}