using BibliotecaDeLibros;

namespace BibliotecaDeLibros
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public int AnioPublicacion { get; set; }

        public Libro (string titulo, string autor, int anioPublicacion)
        {
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = anioPublicacion;
        }

       
        




    }
    public class GestorLibros
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public void EliminarLibro(string titulo)
        {
            libros.RemoveAll(l => l.Titulo == titulo);
        }

        public List<Libro> BuscarLibrosPorAutor(string autor)
        {
            return libros.FindAll(l => l.Autor == autor);
        }

        public void MostrarLibros()
        {
            foreach (Libro libro in libros)
            {
                Console.WriteLine($"Titulo: {libro.Titulo}| Autor: {libro.Autor}| Año: {libro.AnioPublicacion}");
            }
        }


    }
}

/*
namespace BiBliotek //guarda un espacio de trabajo donde puedo tener una clase con un nombre igual al de otra clase de otro espacio
{
    public class Calculadora { }
    public class Calculadora { }
}

namespace BibBBB
{
    public class Calculadora { }
}*/


