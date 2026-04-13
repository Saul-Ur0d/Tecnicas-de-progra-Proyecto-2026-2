




using static System.Runtime.InteropServices.JavaScript.JSType;

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

public class Verificador
{
    public bool Verificar(Mascota mascota)
    {
        return (!string.IsNullOrEmpty(mascota.Nombre) && mascota.Edad > 0);
    }
}

public class PrecioVacuna
{
    public decimal CalcularVacuna(Mascota mascota)
    {
        if (mascota.Tipo.StartsWith("P")) return 200;
        if (mascota.Tipo.StartsWith("G")) return 180;
        if (mascota.Tipo.Contains("tuga")) return 400;
        return mascota.Edad * 50; 
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
    public void Notificar(Mascota mascota, PrecioVacuna costo) { email.Enviar($"Mascota info : {mascota.Nombre}| $ {costo.CalcularVacuna(mascota)}"); }
}



public interface CuidadoAnimal //Interfaz para poder usar liskov
{
    public void AtenderMascota(string nombre, string tipo, int edad);
}
public class ClinicaVet
{
    protected List<Mascota> mascotas = new List<Mascota>();
    protected Notificador notificador = new Notificador();
    protected Verificador verificador = new Verificador();
    protected PrecioVacuna costo = new PrecioVacuna();
}

public class SistemaVeterinaria : ClinicaVet, CuidadoAnimal
{
    public void AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new Mascota(nombre, tipo, edad);
        if (!verificador.Verificar(mascota))
        {
            Console.WriteLine("Mascota no se puede registrar");
            return;
        }
        mascotas.Add(mascota);
        decimal costo = mascota.CalcularVacuna();
        notificador.Notificar(mascota);

        Console.WriteLine("Resumen:");

        foreach (var m in mascotas)
        {
            Console.WriteLine($"{m.Nombre}- {m.Tipo}");
        }

    }
}


