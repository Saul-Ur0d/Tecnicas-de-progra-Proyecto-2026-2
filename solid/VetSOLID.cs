




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
}





