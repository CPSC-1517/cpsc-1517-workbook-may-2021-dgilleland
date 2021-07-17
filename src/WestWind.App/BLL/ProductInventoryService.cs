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

        public PartialList<Product> GetProducts(string partialProductName, int skip, int take)
        {
            var items = _context.Products
                                // The .Where() extension method allows me to filter the Products results
                                // This method uses a Lambda expression to do the filter check
                                .Where(item => item.ProductName.Contains(partialProductName))
                                // The .Skip() extension method says to "pass over" a certain number of rows
                                .Skip(skip)
                                // The .Take() extension method says to "retrieve" a certain number of rows
                                .Take(take);
            return new PartialList<Product>(items.Count(), items.ToList());
        }
    }
}