﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Filters;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с товарами
    /// </summary>
    public interface IProductData
    {
        /// <summary>
        /// Список секций
        /// </summary>
        /// <returns></returns>
        IEnumerable<Section> GetSections();
        /// <summary>
        /// Список брендов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Brand> GetBrands();
        /// <summary>
        /// Список товаров
        /// </summary>
        /// <param name="filter">Фильтр товаров</param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}
