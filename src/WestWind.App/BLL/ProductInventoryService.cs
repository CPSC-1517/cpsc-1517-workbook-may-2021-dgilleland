using System;
using WestWind.App.DAL;
using System.Collections.Generic;
using WestWind.App.Entities;
using System.Linq; // Language Integrated Query

namespace WestWind.App.BLL
{
    public class ProductInventoryService
    {
        private readonly WestWindContext _context;
        public ProductInventoryService(WestWindContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public List<Product> GetProducts()
        {
            var result = _context.Products;

            return result.ToList();
        }
    }
}