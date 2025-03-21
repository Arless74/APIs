namespace APIsRest.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        public List<Accesos>? Accesos { get; set; } = new List<Accesos>();

    }
}
