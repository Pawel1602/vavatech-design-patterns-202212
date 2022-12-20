using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProxyPattern
{
    // Proxy
    // Wariant obiektowy
    public class CacheProductRepository : IProductRepository
    {
        private IDictionary<int, Product> products;

        // Real subject
        private readonly IProductRepository productRepository;

        public CacheProductRepository(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

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
            }
            else
            {
                product = productRepository.Get(id);

                if (product != null)
                {
                    Add(product);
                }
            }

            return product;
                         
        }

    }

}
