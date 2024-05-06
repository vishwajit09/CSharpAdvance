using ProductDependencyInjection.Model;
using System.Linq.Expressions;

namespace ProductDependencyInjection.Services.Interfaces
{
    public interface IProductService
    {
        public void AddProduct(Product product);

        public void RemoveProduct(Product product);


        public List<Product> GetAllProducts();

        public Product GetProductbyId(int id);
        public void RemoveProductbyId(int id);
        public List<Product> FilterProducts(string name, double? minPrice, double? maxPrice);
        public List<Product> FilterProductByname(Expression<Func<Product, bool>> predicate);

    }
}
