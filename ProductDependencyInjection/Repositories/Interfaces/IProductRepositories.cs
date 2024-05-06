using ProductDependencyInjection.Model;

namespace ProductDependencyInjection.Repositories.Interfaces
{
    public interface IProductRepositories
    {
        public void AddProduct(Product product);

        public void RemoveProduct(Product product);


        public List<Product> GetAllProducts();

        public Product GetProductbyId(int id);
      
       
    }
}
