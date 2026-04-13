



//Sin aplicar LSP 

//Clases

List<Monstruo> monstruos = new () {
    new Vampiro("Edward"),
    new CalabazaDecorativa("John")
};


//Console.WriteLine("Fiesta sin aplicar Liskov: ");

//foreach (var m  in monstruos)
//{
//    m.Asustar();
//}

Console.WriteLine("Fiesta aplicando Liskov: ");
List<IAsustable> asustables = new()
{
    new VampiroLSP("Edward")
};


public class Monstruo
{
    public string Nombre {  get; set; }

    public Monstruo(string nombre) => Nombre = nombre;

    public virtual void Asustar()
    {
        Console.WriteLine($"{Nombre} intenta asustar...");
    }



}

public class Vampiro : Monstruo
{
    public Vampiro (string nombre) : base(nombre) { }


    public override void Asustar()
    {
        Console.WriteLine($"{Nombre} se transforma en murcielago");
    }
}

public class CalabazaDecorativa : Monstruo
{
    public CalabazaDecorativa(string nombre) : base(nombre) { }
    public override void Asustar()
    {
        //Esta clase no deberia asustar
        throw new NotImplementedException("Las calabazas decorativas no asustan");
    }
}

//Aplicando LSP

public abstract class MonstruoLSP
{
    public string Nombre { get; set;}
    public MonstruoLSP(string nombre)
    {
        Nombre = nombre;
    }
}

public interface IAsustable
{
    void Asustar();
}

public class VampiroLSP : MonstruoLSP, IAsustable
{
    public VampiroLSP(string nombre) : base(nombre) { }

    public void Asustar()
    {
        Console.WriteLine($"{Nombre} se transforma en murcielago");
    }
}

public class CalabazaLSP : MonstruoLSP
{
    public CalabazaLSP(string nombre) : base(nombre) { }
    public void Asustar()
    {
        Console.WriteLine($"{Nombre} brillo");
    }
}


