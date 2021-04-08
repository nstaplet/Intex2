using System.ComponentModel.DataAnnotations;

namespace Intex.Models
{
    public class UserModification
    {
        [Required]
        public string UserName { get; set; }

        public string UserId { get; set; }

        public string[] AddIds { get; set; }

        public string[] DeleteIds { get; set; }
    }
}