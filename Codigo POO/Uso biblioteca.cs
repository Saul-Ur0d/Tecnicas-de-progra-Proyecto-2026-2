
using BibliotecaDeLibros;

GestorLibros gestor = new GestorLibros();

//Agregar Libro 

gestor.AgregarLibro(new Libro("El señor de los anillos", "Tolkien", 1954));
gestor.AgregarLibro(new Libro("Duna", "Frank", 1965));
gestor.AgregarLibro(new Libro("Juego de tronos", "George", 1996));

//Mostar libros

Console.WriteLine("Libros actuales: ");
gestor.MostrarLibros();