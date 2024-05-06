using ProductDependencyInjection.Database;
using ProductDependencyInjection.Model;
using ProductDependencyInjection.Repositories.Interfaces;

namespace ProductDependencyInjection.Repositories
{
    public class ProductRepositories :IProductRepositories
    {
        private ProductDb _productDb;

        public ProductRepositories(ProductDb productDb)
        {
            _productDb = productDb;
        }

        public void AddProduct(Product product)
        {
            _productDb._products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            _productDb._products.Remove(product);
        }

        public List<Product> GetAllProducts() { 
            return _productDb._products.ToList();
        }
        public Product GetProductbyId(int id) {

            return _productDb._products.Find(x => x.Id == id);
        }
 
    }
}
