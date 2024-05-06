using ProductDependencyInjection.Database;
using ProductDependencyInjection.Exceptions;
using ProductDependencyInjection.Model;
using ProductDependencyInjection.Repositories.Interfaces;
using ProductDependencyInjection.Services.Interfaces;
using System.Linq.Expressions;

namespace ProductDependencyInjection.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositories _productRepositories;

        public ProductService(IProductRepositories productRepositories)
        {
            _productRepositories = productRepositories;
        }

        public void AddProduct(Product product)
        {
            ValidateProduct(product);
            _productRepositories.AddProduct(product);
        }

        public List<Product> GetAllProducts()
        {
             var products = _productRepositories.GetAllProducts();
            if (products == null)
            {
                throw new ProductValidationException("Product not found");
            }
            else
            {
                return products;
            }
        }

        public Product GetProductbyId(int id)
        {
            var product =  _productRepositories.GetProductbyId(id);
            if (product == null)
            {

                throw new ProductValidationException("Product not found");
            }
            else
            {
                return product;
            }
         
            
        }

        public void RemoveProduct(Product product)
        {
            ValidateProduct(product);

            var productToBeRemoved = _productRepositories.GetProductbyId(product.Id);
            if (product == null)
            {

                throw new ProductValidationException("Product not found");
            }
            else
            {
                _productRepositories.RemoveProduct(productToBeRemoved);
            }
        }

        public void RemoveProductbyId(int id)
        {
            

            var productToBeRemoved = _productRepositories.GetProductbyId(id);
            if (productToBeRemoved == null)
            {

                throw new ProductValidationException("Product not found.");
            }
            else
            {
                _productRepositories.RemoveProduct(productToBeRemoved);
            }
        }

        private void ValidateProduct(Product product)
        {
            if (product == null)
                throw new ProductValidationException("Product data cannot be null.");

            if (string.IsNullOrEmpty(product.Name))
                throw new ProductValidationException("Product name cannot be empty.");

            if (product.Price <= 0)
                throw new ProductValidationException("Product price must be greater than zero.");
        }

        public List<Product> FilterProducts(string name, double? minPrice, double? maxPrice)
        {
            var filteredProducts =  _productRepositories.GetAllProducts(); ;

            if (!string.IsNullOrEmpty(name))
                filteredProducts = filteredProducts.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (minPrice.HasValue)
                filteredProducts = filteredProducts.Where(p => p.Price >= minPrice.Value).ToList();

            if (maxPrice.HasValue)
                filteredProducts = filteredProducts.Where(p => p.Price <= maxPrice.Value).ToList();

            if(filteredProducts.Count == 0)
                throw new NoProductsFoundException();
            return filteredProducts;


        }

        public List<Product> FilterProductByname(Expression<Func<Product, bool>> predicate)
        {
            var filteredProducts = _productRepositories.GetAllProducts().Where(predicate.Compile()).ToList();
            if (filteredProducts.Count == 0)
                throw new NoProductsFoundException();
            return filteredProducts;

        }

    }
}
