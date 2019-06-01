using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Entities.Filters;
using WebStore.Infrastructure.Interfaces;
namespace WebStore.Infrastructure.Implementations.Sql
{
    public class SqlEmployeesData : IEmployeesData
    {
        private readonly EmployeesContext _context;
        public SqlEmployeesData(EmployeesContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            var query = _context.Employees.AsQueryable();
            return query.FirstOrDefault(e => e.Id.Equals(id));
        }


        public void Commit()
        {
            // ничего не делаем
        }
        public void AddNew(Employee model)
        {/*
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);*/
        }

        public void Delete(int id)
        {/*
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }*/
        }
    }
}