using AdventureWorkPersistence.Entities.Product;
using AdventureWorkPersistence.Models;

namespace AdventureWorkPersistence.DataAccess.Interface
{
    public interface IAdventureWorksDataAccess
    {
        Task<List<ProductDto>> GetProducts();
		Task<Product?> GetProductById(int productId);

		Task<ProductDto?> GetCustomProducById(int productId);

		Task<int> AddProduct(Product product);

        Task<bool> UpdateProduct(Product product, int id);
	}
}