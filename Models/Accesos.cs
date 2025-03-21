namespace APIsRest.Models
{
    public class Accesos
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public eROL Rol { get; set; }

        public enum eROL 
        {
            Jefe,
            Administrador,
            Programador,
            Usuario

        }
    }
}
