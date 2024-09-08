
using FreeDemoCatalog.Bussiness;
using FreeDemoCatalog.Bussiness.Services;
using FreeDemoCatalog.DataAccess.Abstract;
using FreeDomeCatalog.Catalog.DataAccess;
using FreeDomeCatalog.Catalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace FreeDomeCatalog.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  // [Authorize(LocalApi.PolicyName)]
    public class CategoryController : ControllerBase

    {
        private readonly ICategoryServices services;

        public CategoryController(ICategoryServices services)
        {
            this.services = services;
        }

       
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CategoryModel model)
        {
            Category category = new()
            {
                Name = model.CategoryName,
                Description = model.CategoryDescription
            };
            services.Add(category);
            return Ok(category);

        }

        
    }
}
