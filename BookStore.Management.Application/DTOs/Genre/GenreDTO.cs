namespace BookStore.Management.Application.DTOs.Genre
{
    public class GenreDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
