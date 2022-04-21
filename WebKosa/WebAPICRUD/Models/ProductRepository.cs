using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPICRUD.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;
        public ProductRepository()
        {
            Add(new Product { Name = "soup", Category = "Foods", Price = 1 });
            Add(new Product { Name = "yoyo", Category = "Toys", Price = 4 });
            Add(new Product { Name = "note", Category = "Elec", Price = 10 });
        }
        public Product Add(Product item)
        {
            if (item == null) { throw new ArgumentNullException("item"); }  // 예외발생
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public Product Get(int id)
        {
            return products.Find(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p=>p.Id == id);
        }

        public bool Update(Product item)
        {
            if(item == null) { throw new ArgumentNullException("item"); }
            int index = products.FindIndex(x => x.Id == item.Id);
            if(index == -1) { return false; }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}