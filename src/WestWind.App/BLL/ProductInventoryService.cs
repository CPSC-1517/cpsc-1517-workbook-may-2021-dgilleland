using System;
using WestWind.App.DAL;
using System.Collections.Generic;
using WestWind.App.Entities;
using System.Linq; // Language Integrated Query
using WestWind.App.Collections;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

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
            var itemCount = _context.Products.Where(item => item.ProductName.Contains(partialProductName)).Count();
            return new PartialList<Product>(itemCount, items.ToList());
        }

        public List<Category> ListCategories()
        {
            return _context.Categories.ToList(); // Gets all the categories in the database
        }

        public List<Supplier> ListSuppliers()
        {
            return _context.Suppliers.ToList(); // Gets all the suppliers in the database
        }

        #region CRUD functionality for managing data in the Products table
        public Product GetProduct(int productId)
        {
            return _context.Products.Find(productId); // Find a single product with the PK of productID
        }

        public int AddProduct(Product item)
        {
            _context.Products.Add(item); // Put the new product item in the DbSet<Product>
            _context.SaveChanges(); // Examine the database context to see if there are any changes in the DbSet items
                                    // and then will save those changes to the database
            // Because the ProductID on the database table is an IDENTITY column, the database will generate the
            // value for this newly added item
            // I will see that new value reflected in my Product item object.
            return item.ProductId; // Send back the database-generated PK value for this new row of data.
        }

        public void UpdateProduct(Product item)
        {
            // The .Entry() method will fetch the most recent information on the Product object as it exists in the database.
            // It can do that because the Product item we are supplying has the ProductID
            EntityEntry<Product> existing = _context.Entry(item);
            // Next, I tell EF that I do indeed want to modify whatever is in the database with
            // what item information I have been given through my parameter variable.
            existing.State = EntityState.Modified;
            _context.SaveChanges(); // Perform an update on the database with the changes supplied
        }

        public void DeleteProduct(Product item)
        {
            EntityEntry<Product> existing = _context.Entry(item);
            existing.State = EntityState.Deleted; // I want to delete this from the databae
            _context.SaveChanges();
        }
        #endregion
    }
}