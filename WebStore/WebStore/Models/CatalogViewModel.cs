using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.Models
{
    public class CatalogViewModel
    {
        public int? BrandId { get; set; }
        public int? SectionId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
