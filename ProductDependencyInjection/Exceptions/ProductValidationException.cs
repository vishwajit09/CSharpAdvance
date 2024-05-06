namespace ProductDependencyInjection.Exceptions
{
    public class ProductValidationException : Exception
    {
        public ProductValidationException(string message): base(message) { }
    }
    public class NoProductsFoundException : Exception
    {
        public NoProductsFoundException() : base("No products found.") { }
    }
}
