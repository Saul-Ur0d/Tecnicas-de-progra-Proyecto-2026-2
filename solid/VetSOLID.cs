

public class Mascota //Clase base para atributos
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Edad { get; set; }

    public Mascota(string nombre, string tipo, int edad)
    {
        Nombre = nombre;
        Tipo = tipo;
        Edad = edad;
    }
}

public interface IPagoVacuna
{
    public decimal CalcularVacuna();
}

public class MascotaDescomunal : Mascota, IPagoVacuna
{
    public MascotaDescomunal(string nombre, string tipo, int edad) : base(nombre, tipo, edad) { }
    public decimal CalcularVacuna()
    {
        return Edad*70; 
    }
}
public class Perro : Mascota, IPagoVacuna
{
    public Perro(string nombre, int edad)
    {
        Nombre = nombre;
        Tipo = "Perro";
        Edad = edad;
    }
    public decimal CalcularVacuna()
    {
        return 200m; 
    }
}

public class Gato : Mascota, IPagoVacuna
{
    public Gato(string nombre, int edad)
    {
        Nombre = nombre;
        Tipo = "Gato";
        Edad = edad;
    }
    public decimal CalcularVacuna()
    {
        return 180m; 
    }
}
public class Tortuga : Mascota, IPagoVacuna
{
    public Tortuga(string nombre, int edad)
    {
        Nombre = nombre;
        Tipo = "Tortuga";
        Edad = edad;
    }
    public decimal CalcularVacuna()
    {
        return 400m; 
    }
}

public class Verificador
{
    public bool Verificar(Mascota mascota)
    {
        return (!string.IsNullOrEmpty(mascota.Nombre) && mascota.Edad > 0);
    }
}



public class EmailService
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando correo {mensaje}");
    }
}

public class Noti //Clase para mantener una sola responsabilidd
{
    protected EmailService email = new EmailService(); //Cambie el private a protected para poder usar herencia
}


public class Notificador : Noti
{
    //Por liskov aqui deberia poder ponerse la misma instancia de mascota en ambos parametros
    public void Notificar(IPagoVacuna mascota, Mascota mas) { email.Enviar($"Mascota info : {mas.Nombre}| $ {mascota.CalcularVacuna}"); }
}



public interface CuidadoAnimal //Interfaz para clinicas veterinarias
{
    public void AtenderMascota(string nombre, string tipo, int edad);
}
public class ClinicaVet
{
    protected List<Mascota> mascotas = new List<Mascota>();
    protected Notificador notificador = new Notificador();
    protected Verificador verificador = new Verificador();
    protected List <IPagoVacuna> pagoVacunas = new List<IPagoVacuna>();
}

public class SistemaVeterinaria : ClinicaVet, CuidadoAnimal
{
    public void AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new Mascota(nombre, tipo, edad);
        IPagoVacuna mascotaP = null;
        if (!verificador.Verificar(mascota) && (mascota.Tipo != "Perro" && mascota.Tipo != "Gato" && mascota.Tipo != "Tortuga"))
        {
            Console.WriteLine("Mascota no se puede registrar");
            return;
        }
        if(mascota.Tipo == "Perro")
        {
            mascotaP = new Perro(nombre, edad);
        }
        if (mascota.Tipo == "Gato")
        {
            mascotaP = new Gato(nombre, edad);
        }
        if (mascota.Tipo == "Tortuga")
        {
            mascotaP = new Tortuga(nombre, edad);
        }

        mascotas.Add(mascota);
        notificador.Notificar(mascotaP, mascota);

        Console.WriteLine("Resumen:");

        foreach (var m in mascotas)
        {
            Console.WriteLine($"{m.Nombre}- {m.Tipo}- {m.Edad}");
        }

    }
}
public class SistemaVetEspecial : ClinicaVet, CuidadoAnimal
{
    public override void AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new MascotaDescomunal(nombre, tipo, edad);
        if (!verificador.Verificar(mascota))
        {
            Console.WriteLine("Mascota no se puede registrar");
            return;
        }
        mascotas.Add(mascota);
        notificador.Notificar(mascota, mascota);
        Console.WriteLine("Resumen:");
        foreach (var m in mascotas)
        {
            Console.WriteLine($"{m.Nombre}- {m.Tipo}- {m.Edad}");
        }
    }
}


