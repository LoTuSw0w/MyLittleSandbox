using System.ComponentModel.DataAnnotations;

namespace APIProjectWithRedis.Models
{
    public class Platform
    {
        [Required]
        public string Id { get; set; } = $"platform:{Guid.NewGuid()}";

        [Required]
        public string Name { get; set; } = String.Empty;
    }
}
