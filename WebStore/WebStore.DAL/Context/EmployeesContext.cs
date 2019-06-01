using Microsoft.EntityFrameworkCore;
using WebStore.DomainNew.Entities;

namespace WebStore.DAL.Context
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions options) : base(options){ }
        public DbSet<Employee> Employees { get; set; }
    }
}
