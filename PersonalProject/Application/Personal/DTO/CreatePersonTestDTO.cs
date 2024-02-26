using System.ComponentModel.DataAnnotations;

namespace Application.Personal.DTO
{
    public class CreatePersonTestDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Title { get; set; }
        public required string UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
