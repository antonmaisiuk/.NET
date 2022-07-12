using NET_PS_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_PS_9.DAL
{
    public interface IProductDB
    {
        public List<Product> List();
        public Product Get(int _id);
        public void Update(Product _product);
        public void Delete(int _id);
        public void Add(Product _product);
    }
}
