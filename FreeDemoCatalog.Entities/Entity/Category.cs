
using FreeDemoCategory.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace FreeDomeCatalog.Catalog.Models
{
    public class Category:IEntity
    {
    
        [Key]
            public Guid Id { get; set; }

            [Required]
            public string? Name { get; set; }

            public string? Description { get; set; }

            //public List<Note>? Notes { get; set; }
        }
    
}
