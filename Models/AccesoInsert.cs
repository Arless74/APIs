using static APIsRest.Models.Accesos;

namespace APIsRest.Models
{
    public class AccesoInsert
    {
        public string Name { get; set; } = string.Empty;

        public eROL Rol { get; set; }
    }
}
