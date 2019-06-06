using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Entities.Filters;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations.Sql
{
    public class SqlProductData : IProductData, IEmployeesEntity
    {
        private readonly WebStoreContext _context;
        public SqlProductData(WebStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Section> GetSections()
        {
            return _context.Sections.ToList();
        }
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }
        public IEnumerable<Product>GetProducts(ProductFilter filter)
        {
            var query =_context.Products.Include("Brand").Include("Section").AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue &&
            c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.SectionId.HasValue)
                query = query.Where(c =>c.SectionId.Equals(filter.SectionId.Value));
            return query.ToList();
        }
        public Product GetProductById(int id)
        {
            return _context.Products.Include("Brand").Include("Section").FirstOrDefault(p =>p.Id.Equals(id));
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
        {
            var query = _context.Employees.AsQueryable();
            model.Id = query.Max(e => e.Id) + 1;
            _context.Employees.Add(model);
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }
    }
}