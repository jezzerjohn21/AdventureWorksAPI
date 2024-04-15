using AdventureWorkPersistence.Entities.Product;
using AdventureWorkPersistence.Models;
using System.Linq.Expressions;

namespace AdventureWorkPersistence.DataAccess.Interface
{
    public interface IAdventureWorksDataAccess
    {

		//get
        Task<List<ProductDto>> GetProducts();
		Task<Product?> GetProductById(int id);
		Task<ProductDto?> GetCustomProducById(int id);
		
		Task<List<ProductDto>> GetProductByName(string productName);
		/*
		This method can be removed because of the use of query Expression to query in a generic way.
		*/

		/*Task<List<ProductDto>> GetProductByProductNumber(string productNumber);
		*//*
		This method can be removed because of the use of query Expression to query in a generic way.
		*/
		
		Task<List<T>> GetProductsQuery<T>(List<Expression<Func<Product, bool>>> predicates);
		/*
		Method the can query a product table in a generic way
		*/


		//post
		Task<int> AddProduct(AddProductDto addProductDto);
		Task<int> AddProductWithoutDto(Product product);

		//put
		Task<bool> UpdateProductWithoutDto(Product product, int id);
		Task<bool> UpdateProduct(UpdateProductDto updateProductDto, int id);

		//delete
		
	}
}