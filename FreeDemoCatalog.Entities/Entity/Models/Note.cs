namespace FreeDemoCatalog.Entities.Entity.Models
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public string? NoteName { get; set; }
        public string? NoteDescription { get; set; }
        public Category? NoteCategory { get; set; }
        public string? CategoryId { get; set; }
    }
}
