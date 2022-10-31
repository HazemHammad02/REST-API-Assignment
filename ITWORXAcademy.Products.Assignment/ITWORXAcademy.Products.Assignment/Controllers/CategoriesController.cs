using ITWORXAcademy.Products.Assignment.Entities;
using ITWORXAcademy.Products.Assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITWORXAcademy.Products.Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IRepository<Category> _CategoryRepository { get; set; }
        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public Response<Category> Get()
        {
            Response<Category> response = new Response<Category>();
            response.Results = _CategoryRepository.GetAll()?.ToList();
            return response; 
        }
    }
}
