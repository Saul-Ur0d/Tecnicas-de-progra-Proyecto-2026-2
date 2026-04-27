
//Programa principal

Festival festival = new Festival("KesmesFI");
Console.WriteLine($"Bienbenidos al festival {festival.Nombre}");
//Banda

Console.WriteLine("Registrando bandas y sets");

//
Banda muse = new Banda("Muse", "UK", new TimeSpan (19,0,0),4);
muse.CargaCancion(0, new Cancion("Starlight", 4, "Rock"));
muse.CargaCancion(1, new Cancion("Hysteria", 3, "Rock"));
muse.CargaCancion(2, new Cancion("Unintended", 3, "Rock"));
muse.CargaCancion(3, new Cancion("Madness", 5, "Rock"));

Banda djo = new Banda("DJO", "UE", new TimeSpan(17,0,0),3);
djo.CargaCancion(0, new Cancion("Crux", 3, "Rock"));
djo.CargaCancion(1, new Cancion("End of Beginning", 3, "Rock"));
djo.CargaCancion(2, new Cancion("Back on you", 5, "Rock"));

Banda bts = new Banda("BTS", "COR", new TimeSpan(21, 0, 0), 3);
bts.CargaCancion(0, new Cancion("Butter", 3, "Kpop"));
bts.CargaCancion(1, new Cancion("Body To Body", 3, "Kpop"));
bts.CargaCancion(2, new Cancion("Hooligan", 5, "Kpop"));

Banda c50 = new Banda("Calibre50", "Mex", new TimeSpan(24, 0, 0), 3);
c50.CargaCancion(0, new Cancion("Si te pudiera mentir", 4, "Banda"));
c50.CargaCancion(1, new Cancion("El tierno se fue", 4, "Banda"));
c50.CargaCancion(2, new Cancion("El amor de mi vida", 2, "Banda"));

festival.AgregarBandas(muse);
festival.AgregarBandas(djo);
festival.AgregarBandas(bts);
festival.AgregarBandas(c50);

Console.WriteLine($" Duracion de sets por banda");
foreach (Banda b in festival.Cartel)
{
    Console.WriteLine($" {b.Nombre} - {b.DuracionTotalSet()}");
}

Console.WriteLine("Reordenando Show");
festival.ResumenCartel();

//Cambio de ultimo minuto 


Banda MJ = new Banda("Michael Jackson", "UE", new TimeSpan(20, 0, 0), 2);
MJ.CargaCancion(0, new Cancion("Thriller", 5, "Pop"));
MJ.CargaCancion(1, new Cancion("Beat it", 4, "Pop"));
Console.WriteLine($"Cambio de ultimo minuto {MJ.Nombre} confirma de ultima hora");

//Insertar al orden 





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

public class Festival
{
    public string Nombre { get; set; }
    public List<Banda> Cartel { get; set; }
    public Stack<Banda> HistorialEscenario { get; set; }
    public Queue<Asistente> FilaIngreso { get; set; }
    public LinkedList<Banda> OrdenShow { get; set; }

    public Festival(string nombre)
    {
        Nombre = nombre;
        Cartel = new List<Banda>();
        HistorialEscenario = new Stack<Banda>();
        FilaIngreso = new Queue<Asistente>();
        OrdenShow = new LinkedList<Banda>();
    }
    public void AgregarBandas(Banda banda)
    {
        Cartel.Add(banda);
        OrdenShow.AddLast(banda);
        Console.WriteLine($"{banda.ToString()} Se ha agregado correctamente");
    }

    public void CancelarBanda(Banda banda)
    {
        if (Cartel.Contains(banda))
        {
            Cartel.Remove(banda);
            OrdenShow.Remove(banda);
            Console.WriteLine($"Banda cancelada: {banda.ToString()}");
        }
        else
        {
            Console.WriteLine($"Banda{banda.Nombre} no se encontro");
        }
    }

    public void InsertarBandaDespuesDe(Banda nueva, LinkedListNode<Banda> despuesDe)
    {
        OrdenShow.Remove(nueva);
        OrdenShow.AddAfter(despuesDe, nueva);
        Console.WriteLine($" [] {nueva.Nombre} reubicada en el orden del show");
    }

    public void RegistrarPresentacion(Banda banda)
    {
        HistorialEscenario.Push(banda);
        Console.WriteLine($"{banda.ToString} se ha preentado y registrado correctamente");
    }

    public Asistente AdmitirSiguiente()
    {
        Asistente asistente = FilaIngreso.Dequeue();
        asistente.YaIngreso = true;
        return asistente;
    }

    public Banda UltimaEnTocar()
    {
        return HistorialEscenario.Peek();
    }


    public void ResumenCartel()
    {
        //Copia de la lista de bandas para no alterar la original
        List<Banda> ordenada = new List<Banda>(Cartel);

        //Ordenamiento de burbuja
        int n = ordenada.Count();

        for (int i = 0; i < n-1; i++)
        {
            for (int j = 0; j < n-i-1; j++)
            {
                if (ordenada[j].HoraPresentacion > ordenada[j+1].HoraPresentacion)
                {
                    Banda temp = ordenada[j];
                    ordenada[j] = ordenada[j+1];
                    ordenada[j+1] = temp;
                }
            }
        }

        Console.WriteLine($"Cartel oficial - {Nombre}");
        foreach (Banda banda in ordenada)
        {
            Console.WriteLine($" {banda.HoraPresentacion:hh\\mm} {banda.Nombre}");
        }
    }



}












































