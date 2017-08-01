namespace Dotnet_Core_EF_Api_Server.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Make Make { get; set; } 

        public int MakeId { get; set; }       
    }
}