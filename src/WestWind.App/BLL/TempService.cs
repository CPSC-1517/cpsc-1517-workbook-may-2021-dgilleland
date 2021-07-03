using System;
using System.Collections.Generic;
using System.Linq;
using WestWind.App.DAL;
using WestWind.App.Entities;

namespace WestWind.App.BLL
{
    public class TempService
    {
        private readonly WestWindContext _context;
        public TempService(WestWindContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
        public List<Shipper> ListShippers()
        {
            return _context.Shippers.ToList();
        }
    }
}