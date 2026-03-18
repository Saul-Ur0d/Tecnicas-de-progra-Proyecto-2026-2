// Uriostegui Rodríguez Adolfo Saul

//Codigo de clases


public class Bola
{
    protected double Masa {  get;}
    protected double X { get; set; }
    protected double Y { get; set; }
    protected double[] posicion = new double[2];

    public Bola (double masa)
    {
        Masa = masa;
        X = 0;
        Y = 0;
    }

    public void Mover(Bola bola, double mov_x, double mov_y)
    {
        bola.X += mov_x;
        bola.Y += mov_y;
    }

    public virtual double Obtener_Coef_Friccion()
    {
        return (0);
    }
    public double Obtener_Masa()
    {
        return Masa;
    }
}

public class BolaPro : Bola
{
    private double Coef;
    public BolaPro(double masa) : base(masa)
    {
        Coef = 0.6;
    }

    public override double Obtener_Coef_Friccion()
    {
        return Coef;
    }
}

public class BolaNormal : Bola
{
    private double Coef { get; }
    public BolaNormal(double masa) : base(masa)
    {
        Coef = 1.2;
    }

    public override double Obtener_Coef_Friccion()
    {
        return Coef;
    }
}

public class Tiro
{
    private double Impulso { get; }
    private double Dir_X { get; }
    private double Dir_Y { get; }
    private double Magnitud { get; set; }

    public Tiro (double impulso, double dirX, double dirY)
    {
        Impulso = impulso;
        Dir_X = dirX;
        Dir_Y = dirY;
        Magnitud = Math.Sqrt(Math.Pow(dirX, 2) + Math.Pow(dirY, 2));
    }
    public double Desplazamiento_X(double distancia)
    {
        return distancia*(Dir_X / Magnitud);
    }
    public double Desplazamiento_Y(double distancia)
    {
        return distancia*(Dir_Y / Magnitud);
    }
    public double Obt_Impulso()
    { 
        return Impulso; 
    }
    public double Obtener_Distancia(Bola bola)
    {
        double masa = bola.Obtener_Masa();
        double v_ini = Impulso / (masa / 1000);
    }

}

public interface IEstrategia_Calculo
{
    double Calcular_Distancia(Tiro tiro, Bola bola);
}

public class Calculo_Fisico : IEstrategia_Calculo
{
    public double Calcular_Distancia(Tiro tiro, Bola bola)
    {
        double distancia_total = 0;
        double distancia_X = 
        distancia_total += Math.Sqrt(Math.Pow(distancia_X, 2) + Math.Pow(distancia_Y, 2));
        return distancia_total;
    }
}

public class Calculo_Simple : IEstrategia_Calculo
{
    public double Calcular_Distancia(Tiro tiro, Bola bola)
    {
        double distancia_total = 0;
        distancia_total += tiro.Obt_Impulso() * 2;
        return distancia_total;
    }
}

public class Simulador_Billar
{
    public static Bola bola;
    public List<Tiro> Tiros = new List<Tiro>(); 
    IEstrategia_Calculo Calculo = new Calculo_Fisico();


    public void Crear_Bola(string tipo, double masa)
    {
        if(tipo == "NORMAL")
        {
            bola = new BolaNormal(masa);
        }
        else if(tipo == "PRO")
        {
            bola = new BolaPro(masa);
        }
        else
        {
            throw new ArgumentException("Tipo de bola no existente");
        }
    }

    public void Registrar_Tiro(double impulso, double EjeX, double EjeY)
    {
        Tiro NuevoTiro = new Tiro(impulso, EjeX, EjeY);
        Tiros.Add(NuevoTiro);
    }

    public void Registrar_Tiro(Tiro nuevotiro)
    {
        Tiros.Add(nuevotiro);
    }

    public void Cambiar_Estrategia(string strat)
    {
        if(strat == "FISICA")
        {
            Calculo = new Calculo_Fisico();
        }
        else if (strat == "SIMPLE")
        {
            Calculo = new Calculo_Simple();
        }
        else
        {
            throw new ArgumentException("Estrategia de calculo no disponible");
        }
    }

    public void Simular()
    {
        double distancia_Final = 0;
        double Vector_Dir_Fin = 0;
        double desplazamiento = 0;
        foreach(Tiro tiro in Tiros)
        {
            distancia_Final += Calculo.Calcular_Distancia(tiro, bola);
        }
    }

}