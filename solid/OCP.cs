



//Principio abierto / cerrado

//Sin ocp

public class CalculadoraPrestamo
{
    public decimal Calcular(Libro libro, string tipoPrestamo)
    {
        if (tipoPrestamo == "Regular")
        {
            return 10.0m;
        }
        if(tipoPrestamo == "Premium")
        {
            return 5.0m;
        }
        throw new ArgumentException("Tipo de prestamos no valido");


    }
}

//Aplicando OCP 

public interface IPrestamo
{
    decimal CalcularTarifa(LibroSRP librosrp);
}

public class PrestamoRegular : IPrestamo
{
    public decimal CalcularTarifa(LibroSRP librosrp)
    {
        return 10.0m;
    }
}

public class PrestamoPremium : IPrestamo
{
    public decimal CalcularTarifa(LibroSRP librosrp)
    {
        return 5.0m;
    }
}

public class CalculadoraPrestamoOCP
{
    public decimal Calcular(LibroSRP libro, IPrestamo tipoPrestamo)
    {
        return tipoPrestamo.CalcularTarifa(libro);
    }
}


