using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace FreeDemoCatalog.Entities.Entity.Models
{
    public class Category { 


        public Guid Id { get; set; }


        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Note>? Notes { get; set; }
    }

}
