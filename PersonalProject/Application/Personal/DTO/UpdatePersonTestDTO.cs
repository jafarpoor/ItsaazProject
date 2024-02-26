using System.ComponentModel.DataAnnotations;

namespace Application.Personal.DTO
{
    public class UpdatePersonTestDTO
    {
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
