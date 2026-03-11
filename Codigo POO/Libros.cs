
Libreria libreria = new Libreria();

try
{
    int operaciones = int.Parse(Console.ReadLine() ?? "");
    for (int i = 0; i < operaciones; i++)
    {
        string[] entrada = (Console.ReadLine() ?? "").Split(' ');
        string comando = entrada[0];

        switch(comando)
        {
            case "LIBRO":
                libreria.AgregarLibro(entrada[1], entrada[2], entrada[3]);
                break;
            case "CALIFICAR":
                if(entrada.Length == 4)
                {
                    libreria.CalificarLibro(entrada[1], int.Parse(entrada[3]));
                }
                else
                {
                    //Control
                    Console.WriteLine(entrada.Length);
                    libreria.CalificarLibro(entrada[1], int.Parse(entrada[3]), string.Join(" ", entrada.Skip(4)));
                }
                    break;
            case "MEJOR":
                libreria.MostrarMejorLibro(entrada[1]);
                break;
            case "CRITERIO":
                libreria.CambiarCriterio(entrada[1]);
                break;
            default:
                throw new InvalidOperationException("Comando no valido");

        }


    }


}
catch(Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}






public class Libro
{
    public string Titulo { get; } // No se estabalece el cambio en el valor de este
    public string Autor { get; }
    public string Genero { get; }

    //variable de clase
    List<int> Calificaciones;

    //Constructor
    public Libro(string titulo, string autor, string genero)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Calificaciones = new List<int>();
    }
    //Metodos
    
    public void Calificar(int estrellas)
    {
        if(estrellas >= 1 && estrellas <= 5)
        {
            Calificaciones.Add(estrellas);
        }
        else
        {
            throw new ArgumentException("Calificacion invalida (debe ser del 1 al 5)");
        }

    }

    //Sobrecarga de calificar
    public void Calificar(int estrellas, string comentario)
    {
        Console.WriteLine($"Comentario recibido: {comentario}");
        Calificar(estrellas);
    }
    public double ObtenerPromedio()
    {
        if(Calificaciones.Count == 0)
        {
            throw new InvalidOperationException("No hay califiaciones para este libro aun");
        }
        else 
        {
            double promedio = Calificaciones.Average();
            return promedio;
        }
            
    }

    public int ObtenerCantidadVotos()
    {
        return Calificaciones.Count;
    }

}


//Clases hijas

public class LibroFiccion : Libro
{
    //Variable de clase

    //Constructor
    public LibroFiccion(string titulo, string autor, string genero) : base(titulo, autor, genero)
    {
        /*
        if(!tipoFiccion.Contains(genero))
        {
            throw new ArgumentException("El libro no pertenece a esta categoria");
        }
        */
    }
    
}
public class LibroTecnico : Libro
{
    //Variable de clase

    //Constructor
    public LibroTecnico(string titulo, string autor, string genero) : base(titulo, autor, genero)
    {
        /*
        if (!tipoTecnico.Contains(genero))
        {
            throw new ArgumentException("El libro no pertenece a esta categoria");
        }
        */
    }
    
}

//Interfaz para criterio de recomendacion

interface IRecomendable
{
    Libro ObtenerMejorLibro(List<Libro> libros);
}

//Clases que implementan interfaz

public class RecomendacionPorPromedio : IRecomendable
{
    public Libro ObtenerMejorLibro(List<Libro> libros)
    {
        Libro mejorLibro = null;
        double mejorPromedio = 0; //Pivote

        foreach(Libro libro in libros)
        {
            double promedio = libro.ObtenerPromedio();
            if(promedio > mejorPromedio)
            {
                mejorPromedio = promedio;
                mejorLibro = libro;
            }

        }

        return mejorLibro;
    }

}

public class RecomendacionPorVotos : IRecomendable
{
    public Libro ObtenerMejorLibro(List<Libro> libros)
    {
        Libro mejorLibro = null;
        double maxVotos = -1; //Pivote

        foreach (Libro libro in libros)
        {
            double votos = libro.ObtenerCantidadVotos();
            if (votos > maxVotos)
            {
                maxVotos = votos;
                mejorLibro = libro;
            }

        }

        return mejorLibro;
    }
}

//Clase de libreria

public class Libreria
{
    public List<Libro> libros = new List<Libro>();
    IRecomendable estrategiaRecomendacion = new RecomendacionPorPromedio();
    List<string> tipoFiccion = new List<string> { "Fantasia", "Ciencia_Ficcion", "Romance", "Terror", "Misterio" };
    List<string> tipoTecnico = new List<string> { "Matematicas", "Historia", "Programacion", "Filosofia", "Medicina" };

    //Metodos

    public void AgregarLibro(string titulo, string autor, string genero)
    {
        try
        {
            if (tipoFiccion.Contains(genero))
            {
                Libro nuevoLibro = new LibroFiccion(titulo, autor, genero);
                libros.Add(nuevoLibro);
            }
            else if(tipoTecnico.Contains(genero))
            {
                Libro nuevoLibro = new LibroTecnico(titulo, autor, genero);
                libros.Add(nuevoLibro);
            }
        }
        catch (Exception ex)
        {

        }

    }
    public void CalificarLibro(string titulo, int estrellas)
    {
        Libro libroEncontrado = null;

        foreach (Libro libro in libros)
        {
            if (libro.Titulo == titulo)
            {
                libroEncontrado = libro;
                break;
            }
        }
        if(libroEncontrado != null)
        {
            libroEncontrado.Calificar(estrellas);
        }
        else
        {
            throw new KeyNotFoundException("Libro no encontrado");
        }
    }

    //Sobrecarca
    public void CalificarLibro(string titulo, int estrellas, string comentario)
    {
        Libro libroEncontrado = null;

        foreach (Libro libro in libros)
        {
            if (libro.Titulo == titulo)
            {
                libroEncontrado = libro;
                break;
            }
        }
        if (libroEncontrado != null)
        {
            libroEncontrado.Calificar(estrellas, comentario);
        }
        else
        {
            throw new KeyNotFoundException("Libro no encontrado");
        }
    }

    public void CambiarCriterio(string criterio)
    {
        if(criterio == "PROMEDIO")
        {
            estrategiaRecomendacion = new RecomendacionPorPromedio();
        }
        else if (criterio == "PROMEDIO")
        {
            estrategiaRecomendacion = new RecomendacionPorVotos();

        }
    }

    public void MostrarMejorLibro(string genero)
    {
        List<Libro> LibrosGenero = new List<Libro>();
        foreach(Libro libro in libros)
        {
            if(libro.Genero == genero)
            {
                LibrosGenero.Add(libro);
            }
        }

        Libro mejorlibro = estrategiaRecomendacion.ObtenerMejorLibro(LibrosGenero);
        if (mejorlibro != null)
        {
            Console.WriteLine(mejorlibro.Titulo);
        }
        else
        {
            Console.WriteLine("Ninguno");
        }
    }

}


