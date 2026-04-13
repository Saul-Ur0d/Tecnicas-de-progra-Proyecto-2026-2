





interface  IMonstruo
{
    void Asustar();
    void Volar();
    void LanzarHechizo();

}

public class Fantasma : IMonstruo
{
    public void Asustar() => Console.WriteLine("Buu");
    public void Volar() => Console.WriteLine("Fantasma levita");
    public void LanzarHechizo() => throw new NotImplementedException("Los fantasmas no lanzan hechizos");

}

class Bruja : IMonstruo
{
    public void Asustar() => Console.WriteLine("Risa macabra");
    public void Volar() => Console.WriteLine("Vuela en su esoba");
    public void LanzarHechizo() => Console.WriteLine("Te convierte en chocolate");
}



//Aplicando ISL

interface IAsustador { void Asustar(); }
interface IVolador { void Asustar(); }
interface IHechicero{ void Asustar(); }

public class FantasmaISL : IAsustador, IVolador
{
    public void Asustar() => Console.WriteLine("Buu");
    public void Volar() => Console.WriteLine("Fantasma levita");
}

public class BrujaI : IAsustador, IVolador, IHechicero
{
    public void Asustar() => Console.WriteLine("Risa macabra");
    public void Volar() => Console.WriteLine("Vuela en su esoba");
    public void LanzarHechizo() => Console.WriteLine("Te convierte en chocolate");
}


