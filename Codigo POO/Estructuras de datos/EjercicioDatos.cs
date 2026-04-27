
public class Cancion
{
    public string Titulo { get; set; }
    public int DuracionMinutos { get; set; }
    public string Genero { get; set; }

    public Cancion(string titulo, int duracionMinutos, string genero)
    {
        Titulo = titulo;
        DuracionMinutos = duracionMinutos;
        Genero = genero;
    }


    public override string ToString()
    {

        return $"{Titulo} -- {DuracionMinutos}min [{Genero}]";
    }

}

public class Banda
{
    public string Nombre { get; set; }
    public string Origen {  get; set; }
    public TimeSpan HoraPresentacion { get; set; }
    public Cancion[] SetCanciones { get; set; }

    public Banda(string nombre, string origen, TimeSpan hora, int cantidadCanciones)
    {
        Nombre = nombre;
        Origen = origen;
        HoraPresentacion = hora;
        SetCanciones = new Cancion[cantidadCanciones];
    }

    public void CargaCancion(int posicion, Cancion cancion)
    {
        if(posicion >= SetCanciones.Length || posicion <0)
        {
            throw new ArgumentException($"Posicion invalida: {posicion}");
        }

        SetCanciones[posicion] = cancion;

    }

    public int DuracionTotalSet()
    {
        int total = 0;

        foreach (Cancion cancion in SetCanciones)
        {
            if (cancion != null)
            {
                total += cancion.DuracionMinutos;
            }
        }
        return total;
    }

    public override string ToString()
    {
        return $"{Nombre} ({Origen}) | {HoraPresentacion}:hh\\:mm";
    }
}


public class Asistente
{
    public string Nombre { get; set; }
    public int NumeroEntrada { get; set; }
    public TimeSpan HoraLlegada { get; set; }
    public bool YaIngreso { get; set; }

    public Asistente(string nombre, int numeroEntrada, TimeSpan horaLlegada)
    {
        Nombre = nombre;
        NumeroEntrada = numeroEntrada;
        HoraLlegada = horaLlegada;
        YaIngreso = false;
    }

    public override string ToString()
    {
        return $"{Nombre} | Entrada # {NumeroEntrada} | llego a las {HoraLlegada}:hh\\mm";
    }
}













































