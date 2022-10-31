using ITWORXAcademy.Products.Assignment.Entities;
using ITWORXAcademy.Products.Assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWORXAcademy.Products.Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IRepository<Product> _ProductRepository { get; set; }
        public ProductsController(IRepository<Product> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public Response<Product> Get()
        {
            Response<Product> productResponse = new Response<Product>() ;
            productResponse.Results = _ProductRepository.GetAll()?.ToList();
            return productResponse;
        }
        [HttpGet("GetByCategory")]
        public IEnumerable<Product> GetByCalegoryId([FromQuery]Guid categoryID)
        {
            return _ProductRepository.GetFilterByField(i=>i.CategoryID.ToString()== categoryID.ToString());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return _ProductRepository.Get(id) ;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _ProductRepository.Insert(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Product product)
        {
            var oldEntity = _ProductRepository.Get(id);
            oldEntity.CategoryID = product.CategoryID;
            oldEntity.ImageUrl = product.ImageUrl;
            oldEntity.Name = product.Name;
            oldEntity.Price = product.Price;
            oldEntity.Quantity = product.Quantity;

            _ProductRepository.Update(oldEntity);
        }

    }
}
