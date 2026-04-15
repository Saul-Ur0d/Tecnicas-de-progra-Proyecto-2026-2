

// Instrucciones de nivel superior, aqui inverti el papel dejando como caso general el vet especial
// y el sistema basico como el que solo funciona para perros, gatos y tortugas

Console.WriteLine("Caso mascota comun");
var sistema = new SistemaVeterinaria();
sistema.AtenderMascota("Kiyo", "Perro", 2);

Console.WriteLine("Caso mascota no contemplada");
var sistema2 = new SistemaVetEspecial();
sistema2.AtenderMascota("Jaime", "Iguana", 20);


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
    public Perro(string nombre, string tipo, int edad) : base(nombre, tipo, edad)
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
    public Gato(string nombre, string tipo ,int edad) : base(nombre, tipo, edad)
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
    public Tortuga(string nombre, string tipo, int edad) : base(nombre, tipo, edad)
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
    public void Notificar(IPagoVacuna mascota, Mascota mas) { email.Enviar($"Mascota info : {mas.Nombre}| precio de la vacuna: $ {mascota.CalcularVacuna()}"); }
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
    public virtual void AtenderMascota(string nombre, string tipo, int edad)
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
            mascotaP = new Perro(nombre, tipo, edad);
        }
        if (mascota.Tipo == "Gato")
        {
            mascotaP = new Gato(nombre, tipo, edad);
        }
        if (mascota.Tipo == "Tortuga")
        {
            mascotaP = new Tortuga(nombre, tipo, edad);
        }

        mascotas.Add(mascota);
        notificador.Notificar(mascotaP, mascota);

        Console.WriteLine("Resumen:");

        foreach (var m in mascotas)
        {
            Console.WriteLine($"{m.Nombre}- {m.Tipo}- {m.Edad} años");
        }

    }
}
public class SistemaVetEspecial : SistemaVeterinaria
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


