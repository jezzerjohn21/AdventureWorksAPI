using AdventureWorkPersistence.DataAccess.Interface;
using AdventureWorkPersistence.Entities.Product;
using AdventureWorkPersistence.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;//it not query all the columns of the table
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Security.AccessControl;

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
/*
		//Get
		public async Task<List<ProductDto>> GetProductsWithoutGeneric()
		{
			var productdtos = await context.Product.
				ProjectTo<ProductDto>(mapper.ConfigurationProvider).
				Take(20).ToListAsync();//to specify the query 
			*//*	var productDtos = mapper.Map<List<ProductDto>>(products);// to map data colums to display*//*
			return productdtos;
		}*/

		public async Task<List<ProductDto>> GetProducts()
		{
			var productdtos = await context.Product.
				ProjectTo<ProductDto>(mapper.ConfigurationProvider).
				Take(20).ToListAsync();//to specify the query 
			/*	var productDtos = mapper.Map<List<ProductDto>>(products);// to map data colums to display*/
			return productdtos;
		}

		public async Task<Product> GetProductById(int id)
		{
			return await context.Product.FindAsync(id);
		}

		public async Task<ProductDto?> GetCustomProducById(int id)
		{
			var productDto = await context.Product
			.Where(x => x.ProductID == id)
			.ProjectTo<ProductDto>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync();

			return productDto;
		}

		public async Task<List<ProductDto>> GetProductByName(string productName)
		{
			var productDto = await context.Product
			.Where(x => x.Name.Contains(productName))
			.ProjectTo<ProductDto>(mapper.ConfigurationProvider)
			.ToListAsync();

			return productDto;
		}
		/*
		".Where(x => x.Name == productName)"-> improved  ".Where(x => x.Name.Contains(productName))"-it can search that contain if a specific search value
		/*
		 This method can be removed because of the use of query Expression to query in a generic way
		 */
		


/*		public async Task<List<ProductDto>> GetProductByProductNumber(string productNumber)
		{
		 var productDto = await context.Product
			.Where(x => x.ProductNumber.Contains(productNumber))
			.ProjectTo<ProductDto>(mapper.ConfigurationProvider)
			.ToListAsync();
			return productDto;
		}
		*//*
		 This method can be removed because of the use of query Expression to query in a generic way
		 */



		//Post
		public async Task<int> AddProduct(AddProductDto addProductDto)
		{
			var product = mapper.Map<Product>(addProductDto);
			context.Add(product);
			await context.SaveChangesAsync();
			return product.ProductID;
		}

		public async Task<int> AddProductWithoutDto(Product product)
		{
			context.Add(product);
			await context.SaveChangesAsync();
			return product.ProductID;
		}

		//Put
		public async Task<bool> UpdateProductWithoutDto(Product product, int id)
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

		public async Task<bool> UpdateProduct(UpdateProductDto updateProductDto, int id)
		{
			var existingProduct = await context.Product.FindAsync(id);

			if (existingProduct != null)
			{
				mapper.Map(updateProductDto, existingProduct);
				await context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		//Delete


		/*//Method the can query a product table in a generic way
		public async Task<List<ProductDto>> GetProductsQuery(List<Expression<Func<Product, bool>>> predicates)
		{
			var query = GetProductsGenericQuery(predicates);
			var productDtos = await query
				.ProjectTo<ProductDto>(mapper.ConfigurationProvider)
				.ToListAsync();
			return productDtos;
		}
		private IQueryable<Product> GetProductsGenericQuery(List<Expression<Func<Product, bool>>> predicates)
		{
			var query = context.Product
						   .AsNoTracking()
						   .AsQueryable();

			foreach (var predicate in predicates)
			{
				query = query.Where(predicate);
			}

			return query;
		}*/




		//Optimize way on generic Query
		public async Task<List<T>> GetProductsQuery<T>(List<Expression<Func<Product, bool>>> predicates) 
		{ 
			var query = GetProductsGenericQuery(predicates);
			var data = await query
				.ProjectTo<T>(mapper.ConfigurationProvider)
				.ToListAsync();
			return data;
		}
		private IQueryable<Product> GetProductsGenericQuery(List<Expression<Func<Product, bool>>> predicates)
		{	
			var query = context.Product
				//add include
				.AsNoTracking()
			    .AsQueryable();

			foreach (var predicate in predicates)
			{ 
				query = query.Where(predicate);
			}
			return query;


		}

	}
}