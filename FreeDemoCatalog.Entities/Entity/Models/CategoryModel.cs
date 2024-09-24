namespace FreeDomeCatalog.Catalog.Models
{
    public class CategoryModel
    {
         [Required(ErrorMessage = "Kategory boş greçilemez")]
        [MaxLength(20, ErrorMessage = "En fazla 20 karakter"), MinLength(5, ErrorMessage = "Minimum 5 karakter")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Açıklama boş greçilemez")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter"), MinLength(5, ErrorMessage = "Minimum 5 karakter")]
        public string? Description { get; set; }
    }
}
