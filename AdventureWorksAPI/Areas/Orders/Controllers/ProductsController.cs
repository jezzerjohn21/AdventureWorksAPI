using AdventureWorkPersistence.DataAccess.Interface;
using AdventureWorkPersistence.Entities.Product;
using AdventureWorkPersistence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace AdventureWorksAPI.Areas.Orders.Controllers
{
    [ApiController]

    //feature Areas
    [Area("Orders")]
    public class ProductsController : ControllerBase
    {
        private readonly IAdventureWorksDataAccess _data;
        public ProductsController(IAdventureWorksDataAccess data)
        {
            _data = data;
        }

        //get
        [HttpGet]
        [Route("AdventureWorks/[area]/GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _data.GetProducts());
        }

        [HttpGet]
        [Route("AdventureWorks/[area]/GetProductsById")]
        public async Task<IActionResult> GetProductsById(int id)
        {
            return Ok(await _data.GetProductById(id));
        }

        [HttpGet]
        [Route("AdventureWorks/[area]/GetCustomProductsById")]
        public async Task<IActionResult> GetCustomProductsById(int id)
        {
            return Ok(await _data.GetCustomProducById(id));
        }

        [HttpGet]
        [Route("AdventureWorks/[area]/GetProductByNameWithoutQueryExpressionsInGenericway")]
        public async Task<IActionResult> GetProductByNameWithoutQueryExpressionsInGenericway(string productname)
        {
            return Ok(await _data.GetProductByName(productname));
        }
        /*
		This method can be removed because of the use of query Expression to query in a generic way
		*/


        [HttpGet]
        [Route("AdventureWorks/[area]/GetProductByName")]
        public async Task<IActionResult> GetProductByName(string productname)
        {
            //Call the new method  and passing the expression to the method which gets applied
            var predicates = new List<Expression<Func<Product, bool>>>();
            Expression<Func<Product, bool>> expression = x => x.Name.Contains(productname);
            predicates.Add(expression);
            /*	return Ok(await _data.GetProductsQuery(predicates));*/
            return Ok(await _data.GetProductsQuery<ProductDto>(predicates));//optimize way

            /*return Ok(await _data.GetProductByName(productname));*/
        }



        /*[HttpGet]
		[Route("GetProductByProductNumerWithoutQueryExpressionsInGenericway/{productnumber}")]
		public async Task<IActionResult> GetProductByProductNumberWithoutQueryExpressionsInGenericway(string productnumber)
		{
			return Ok(await _data.GetProductByProductNumber(productnumber));
		}
		*//*
		This method can be removed because of the use of query Expression to query in a generic way
		*/

        [HttpGet]
        [Route("AdventureWorks/[area]/GetProductByProductNumer")]
        public async Task<IActionResult> GetProductByProductNumer(string productnumber)
        {
            //Call the new method  and passing the expression to the method which gets applied
            var predicates = new List<Expression<Func<Product, bool>>>();
            Expression<Func<Product, bool>> expression = x => x.ProductNumber.Contains(productnumber);
            predicates.Add(expression);
            /*return Ok(await _data.GetProductsQuery(predicates))*/
            ;
            return Ok(await _data.GetProductsQuery<ProductDto>(predicates)); //optimize way
        }

        [HttpGet]
        [Route("AdventureWorks/[area]/GetProductByProductNameAndProductNumber")]
        public async Task<IActionResult> GetProductByproductNameAndProductNumer(string productnumber, string productname)
        {
            //Call the new method  and passing the expression to the method which gets applied
            var predicates = new List<Expression<Func<Product, bool>>>();
            Expression<Func<Product, bool>> expression1 = x => x.ProductNumber.Contains(productnumber);
            Expression<Func<Product, bool>> expression2 = x => x.Name.Contains(productname);
            predicates.Add(expression1);
            predicates.Add(expression2);
            /*return Ok(await _data.GetProductsQuery(predicates))*/
            ;
            return Ok(await _data.GetProductsQuery<ProductDto>(predicates)); //optimizeway
        }





        //post
        [HttpPost]
        [Route("AdventureWorks/[area]/AddProductWithoutDto")]
        public async Task<int> AddProductWithoutDto(Product product)
        {
            return await _data.AddProductWithoutDto(product);
        }

        [HttpPost]
        [Route("AdventureWorks/[area]/AddProduct")]
        public async Task<int> AddProduct(AddProductDto addProductDto)
        {
            return await _data.AddProduct(addProductDto);
        }

        //put

        [HttpPut]
        [Route("AdventureWorks/[area]/UpdateProductWithoutDto")]
        public async Task<bool> UpdateProductWithoutDto(Product product, int id)
        {
            return await _data.UpdateProductWithoutDto(product, id);
        }

        [HttpPut]
        [Route("AdventureWorks/[area]/UpdateProduct")]
        public async Task<bool> UpdateProduct(UpdateProductDto updateProductDto, int id)
        {
            return await _data.UpdateProduct(updateProductDto, id);
        }

        //delete






    }
}
