using System.ComponentModel.DataAnnotations;

namespace Dotnet_Core_EF_Api_Server.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Make Make { get; set; } 

        public int MakeId { get; set; }       
    }
}