//Sistema de vacunas en una veterinaria


Console.WriteLine("Caso mascota comun");
var sistema = new SistemaVeterinaria();
sistema.AtenderMascota("Juanito", "Perro", 2);

Console.WriteLine("Caso mascota no contemplada");
var sistema2 = new SistemaVeterinaria();
sistema2.AtenderMascota("Jorgito", "Ave", 3);

Console.WriteLine("Caso mascota no contemplada");
var sistema3 = new SistemaVetEspecial();
sistema3.AtenderMascota("Rex", "Perro", 3);

Console.WriteLine("Caso mascota no contemplada");
var sistema4 = new SistemaVetEspecial();
sistema4.AtenderMascota("Bolillo", "Cocodrilo", 3);



//Clases dominio

public class Mascota //Demasiadas responsabilidades en una clase, esta solo para atributos
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Edad {  get; set; }

    public Mascota(string nombre, string tipo, int edad)
    {
        Nombre = nombre;
        Tipo = tipo;
        Edad = edad;
    }
    public bool EsValida()
    {
        return !string.IsNullOrEmpty(Nombre) && Edad > 0;
    }

    public decimal CalcularVacuna() //Aqui se puede aplicar interfaz para cada tipo distinto de prestamo, dejando cada uno con una responsabilidad
    {
        if (Tipo.StartsWith("P")) return 200;
        if (Tipo.StartsWith("G")) return 180;
        if (Tipo.Contains("tuga")) return 400;
        return Edad * 50;
    }
}
public class EmailService
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando correo {mensaje}");
    }
}




public class Notificador
{
    private EmailService email = new EmailService();
    public void Notificar(Mascota mascota)
    {
        email.Enviar($"Mascota info : {mascota.Nombre}| $ {mascota.CalcularVacuna()}");
    }
}




public class SistemaVeterinaria //Interfaz requerida para este y el especial
{
    private List <Mascota> mascotas = new List<Mascota> ();
    Notificador notificador = new Notificador ();
    public virtual void AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new Mascota (nombre, tipo, edad);
        if(!mascota.EsValida())
        {
            Console.WriteLine("Mascota no se puede registrar");
            return;
        }
        mascotas.Add (mascota);
        decimal costo = mascota.CalcularVacuna();
        notificador.Notificar(mascota);

        Console.WriteLine("Resumen:");

        foreach(var m  in mascotas)
        {
            Console.WriteLine($"{m.Nombre}- {m.Tipo}");
        }

    }
}

public class SistemaVetEspecial : SistemaVeterinaria
{
    public override void AtenderMascota(string nombre, string tipo, int edad)
    {
        if(tipo == "Perro")
        {
            Console.WriteLine("Los perros no se atienden en este sistema");
            throw new Exception("Sistema incorrecto");
        }
        base.AtenderMascota(nombre, tipo, edad);
    }
}






























