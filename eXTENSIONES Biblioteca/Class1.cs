
using BibliotecaDeLibros;

namespace ExtensionDeBiblioteca
{
    public static class LibroExtensiones
    {
        public static bool EsAntiguo(this Libro libro)
        {
            return ((DateTime.Now.Year - libro.AnioPublicacion) > 50);
        }

        public static string FormatoInformacion(this Libro libro)
        {
            return $"{libro.Autor} ({libro.Titulo}) - ({libro.AnioPublicacion})";
        }



    }
}


