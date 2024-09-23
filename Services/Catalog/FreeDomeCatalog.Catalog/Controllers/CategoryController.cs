using AutoMapper;
using FreeDemoCatalog.Bussiness.Services;
using FreeDemoCatalog.Entities;
using FreeDemoCatalog.Entities.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace FreeDomeCatalog.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  // [Authorize(LocalApi.PolicyName)]
    public class CategoryController: ControllerBase

    {
        private readonly IServices<Category> services;
        public CategoryController(IServices<Category> services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var products = await services.GetAllAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
           
            var data = await services.CreateAsync(category);
            var response =new ErrorResponse<Category>(data,"Data saved",200);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await services.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,Category category)
        {
           if (id != category.Id) // Id kontrolü
            {
                return BadRequest();
            }

            await services.UpdateAsync(category);
            return NoContent(); // Güncelleme başarılı
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await services.DeleteAsync(id);
            return NoContent(); // Silme başarılı
        }





    }


    
}
