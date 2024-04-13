using AdventureWorkPersistence.DataAccess.Interface;
using AdventureWorkPersistence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
	public class ProductsController : ControllerBase
	{
          private readonly IAdventureWorksDataAccess _data;
        public ProductsController(IAdventureWorksDataAccess data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async  Task<IActionResult> GetProducts() {
        return Ok(await _data.GetProducts());
        }

		[HttpGet]
		[Route("GetProductsById/{id}")]
		public async Task<IActionResult> GetProductsById(int id)
		{
			return Ok(await _data.GetProductById(id));
		}

		[HttpGet]
		[Route("GetCustomProductsById/{id}")]
		public async Task<IActionResult> GetCustomProductsById(int id)
		{
			return Ok(await _data.GetCustomProducById(id));
		}//custom GetProduct by IT

		[HttpPost]
        [Route("AddProduct")]
        public async Task<int> AddProduct(Product products)
        { 
        return await _data.AddProduct(products);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<bool> UpdateProduct(Product product, int id) { 
        return await _data.UpdateProduct(product, id);
        }
	}
}
    