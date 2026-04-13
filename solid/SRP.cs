



//SIN SRP
public class Libro
{
    public string Titulo {  get; set; }
    public string Autor { get; set; }
    public int Paginas { get; set; }

    //Metodos

    public void Guardar_BD ()
    {
        Console.WriteLine($"Guardando {Titulo} en BD");
    }

    public void GenerarReporte()
    {
        Console.WriteLine($"Reporte para {Titulo}");
    }


}




//Aplicando SRP
//Primera responsabilidad instanciar objeto con encapsulamiento de datos
public class LibroSRP
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Paginas { get; set; }
}

//Segunda responsabilidad
public class RepositorioLibro
{
    public void GuardarBD(LibroSRP librosrp)
    {
        Console.WriteLine($"Guardando {librosrp.Titulo} en BD");
    }
}

//Tercera responsabilidad generar reportes

public class GeneradorReporte
{
    public void GenerarReporte(LibroSRP librosrp)
    {
        Console.WriteLine($"Reporte para {librosrp.Titulo}");
    }
}

