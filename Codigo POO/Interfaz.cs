
//Programa principal
IEjemplo algo = new EjemploClase();
algo.HacerAlgo();
algo.HacerAlgoMas();


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