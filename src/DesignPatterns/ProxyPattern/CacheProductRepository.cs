using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProxyPattern
{
    public class CacheProductRepository
    {
        private IDictionary<int, Product> products;

        public CacheProductRepository()
        {
            products = new Dictionary<int, Product>();
        }

        public void Add(Product product)
        {
            products.Add(product.Id, product);
        }

        public Product Get(int id)
        {
            if (products.TryGetValue(id, out Product product))
            {
                product.CacheHit++;

                return product;
            }
            else
                return null;            
        }

    }

}
