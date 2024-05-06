using ProductDependencyInjection.Model;

namespace ProductDependencyInjection.Database
{
    public class ProductDb
    {
        public  List<Product> _products;
        public ProductDb() {
           
            _products = new List<Product>() { new Product(1, "Smartphone", 599.99),
                        new Product (2, "Laptop", 1299.99),
                        new Product(3, "Headphones", 149.99),
                        new Product(4, "Tablet", 399.99),
                        new Product(5, "Smartwatch", 199.99),
                        new Product(6, "Camera", 899.99),
                        new Product(7, "Television", 1499.99),
                        new Product(8, "Speakers", 299.99),
                        new Product(9, "Gaming Console", 499.99),
                        new Product(10, "Router", 79.99) };
        }
    }
}
