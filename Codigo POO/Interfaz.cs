
////Programa principal
//IEjemplo algo = new EjemploClase();
//algo.HacerAlgo();
//algo.HacerAlgoMas();


////Herencia con polimorfismo

//Perro perro = new Perro();
//perro.Hacer_Sonido();

//Animal otroPerro = new Perro();
//otroPerro.Hacer_Sonido();

//Paloma paloma = new Paloma();
//paloma.Hacer_Sonido();
//paloma.Volar();

//Tucan tucan = new Tucan();
//tucan.Hacer_Sonido();
//tucan.Volar();

////Con interfaces

//IVolar pajaro = new PalomaI();
//IAnimal otropaja = new PerroI();

//Dragon dragon = new Dragon();
//dragon.Hacer_Sonido();
//dragon.Volar();





public interface IEjemplo
{
    //Metodos
    void HacerAlgo();

    //Metodo con implementacion predeterminada

    public void HacerAlgoMas()
    {
        Console.WriteLine("Haciendo Algo Mas");
    }


}

public class EjemploClase() : IEjemplo
{
    public void HacerAlgo()
    {
        Console.WriteLine("Haciendo algo");
    }
}


//Herencia con plimorfismo

//Clase padre o clase base

public class Animal
{
    public void Respirar()
    {
        Console.WriteLine("Estoy respirando");
    }

    public virtual void Hacer_Sonido()
    {
        Console.WriteLine("El animal hace sonido");
    }

}

//Clases hijas
public class Perro : Animal
{
    public void Ladrar()
    {
        Console.WriteLine("WOOF WOOF");
    }

    public override void Hacer_Sonido()
    {
        //base.Hacer_Sonido();
        Ladrar();       
    }
    
}

public class Gato : Animal
{
    public override void Hacer_Sonido()
    {
        Console.WriteLine("Miau Miau");
    }
}

public class Paloma : Animal
{
    public void Volar()
    {
        Console.WriteLine("Paloma Volando");
    }
    public override void Hacer_Sonido()
    {
        Console.WriteLine("Currucu");
    }
}

public class Tucan : Paloma
{

}

//Usando interfaces

public interface IAnimal
{
    void HacerSonido();
}

public interface IVolar
{
    void Volar();
}



public class PerroI : IAnimal
{
    public void HacerSonido()
    {
        Console.WriteLine("WOW WOW");
    }
}

public class PalomaI : IAnimal, IVolar
{
    public void HacerSonido()
    {
        Console.WriteLine("Cucurrucu");
    }

    public void Volar()
    {
        Console.WriteLine("Paloma vuela");
    }
}
public class ColibriI : IAnimal, IVolar
{
    public void HacerSonido()
    {
        Console.WriteLine("SONIDO DE COLIBRI");
    }

    public void Volar()
    {
        Console.WriteLine("Colibri vuela");
    }
}

public class Dragon : Animal, IVolar
{
    public void Volar()
    {
        Console.WriteLine("Dragon vuela");
    }
}