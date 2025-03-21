using System.Runtime.Intrinsics.X86;

namespace APIsRest.Helpers
{
    public static class Mensajes
    {
        public static class User
        {
            public const string NotFound = "El Usuario solicitado No Existe";
        }

        public static class Acceso
        {
            public const string NotFound = "El nivel de Acceso solicitado No Existe";

            public const string mismoAcceso = "Ya existe ese nivel de Acceso con ese Nombre";
        }
    }
}
