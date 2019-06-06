using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.Models.Cart
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public int ItemsCount
        {
            get
            {
                return Items?.Sum(x => x.Quantity) ?? 0;
            }
        }
    }
    
}
