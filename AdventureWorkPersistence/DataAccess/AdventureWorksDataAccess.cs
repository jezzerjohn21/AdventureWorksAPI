using AdventureWorkPersistence.DataAccess.Interface;
using AdventureWorkPersistence.Entities.Product;
using AdventureWorkPersistence.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;//it not query all the columns of the table
using Microsoft.EntityFrameworkCore;

namespace AdventureWorkPersistence.DataAccess
{
	public class AdventureWorksDataAccess : IAdventureWorksDataAccess
	{
		public readonly AdventureWorksDBContext context;
		private readonly IMapper mapper;

		public AdventureWorksDataAccess(AdventureWorksDBContext context,IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<int> AddProduct(Product product)
		{
			context.Add(product);
			await context.SaveChangesAsync();
			return product.ProductID;
		}

		public async Task<ProductDto?> GetCustomProducById(int id)
		{
			var productDto = await context.Product
			.Where(x => x.ProductID == id)
			.ProjectTo<ProductDto>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync();

			return productDto;



		}

		public async Task<Product> GetProductById(int id)
		{
			return await context.Product.FindAsync(id);
		}

		public async Task<List<ProductDto>> GetProducts()
		{
			var productdtos = await context.Product.
				ProjectTo<ProductDto>(mapper.ConfigurationProvider).
				Take(20).ToListAsync();//to specify the query 
		/*	var productDtos = mapper.Map<List<ProductDto>>(products);// to map data colums to display*/
			 return productdtos;
		}

		public async Task<bool> UpdateProduct(Product product, int id)
		{
			var existingProduct = await context.Product.FindAsync(id);
			if (existingProduct != null)
			{
				existingProduct.Name = product.Name;
				await context.SaveChangesAsync();
				return true;
			}
			return false;
		}
	}
}