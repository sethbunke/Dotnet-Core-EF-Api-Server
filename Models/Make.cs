namespace Dotnet_Core_EF_Api_Server.Models
{
    public class Make
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}