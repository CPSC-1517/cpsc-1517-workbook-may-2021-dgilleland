using System;
using WestWind.App.DAL;
using System.Collections.Generic;
using WestWind.App.Entities;
using System.Linq; // Language Integrated Query
using WestWind.App.Collections;

namespace WestWind.App.BLL
{
    public class ProductInventoryService
    {
        private readonly WestWindContext _context;
        public ProductInventoryService(WestWindContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        [Obsolete] // just to remember that I'm moving away from using this method
        public List<Product> GetProducts()
        {
            var result = _context.Products;

            return result.ToList();
        }

        public PartialList<Product> GetProducts(int skip, int take)
        {
            int total = _context.Products.Count();
            var items = _context.Products.Skip(skip).Take(take);
            return new PartialList<Product>(total, items.ToList());
        }
    }
}