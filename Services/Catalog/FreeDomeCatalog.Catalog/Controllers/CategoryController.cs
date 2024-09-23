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
    public class CategoryController : ControllerBase

    {
        private readonly IServices<Category> services;
        public CategoryController(IServices<Category> services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {


            // Örnek veri
            var data = await services.GetAllAsync();

            // Başarılı yanıt (birden fazla mesaj ile)
            var response = new ApiResponse<List<Category>>(200, data, new List<string> { "Data GetAllAsync successfully" });
            return Ok(response);
        }
    
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
           
            var data = await services.CreateAsync(category);
            var response =new ApiResponse<Category>(200,data, new List<string> { "Data Add successfully" });
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await services.GetByIdAsync(id);
            var response = new ApiResponse<Category>(200,product, new List<string> { "Data GetById successfully" });
            return Ok(response);
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
