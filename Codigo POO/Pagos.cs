
//Programa principal

bool continua = true;

List<Ipago> list = new List<Ipago>();
do
{
    Console.WriteLine("Ingresa el monto a pagar : ");
    
    
        string montotexto = Console.ReadLine() ?? "";
        if ()
    

}while (continua);

//Interfaz y clases

public interface Ipago
{
    void ProcesarPago();
}

public class PagoEfectivo : Ipago
{
    //Monto y como lo procesa

    public double Monto { get; set; }

    public PagoEfectivo (double monto)
    {
        Monto = monto;
    }

    //Metodos

    public void ProcesarPago()
    {
        Console.WriteLine($"Pago en efectivo de {Monto} procesado");
    }



}

public class PagoTarjeta: Ipago
{
    //Monto y como lo procesa

    public double Monto { get; set; }
    public string NumeroTarjeta { get; set; }


    public PagoTarjeta(string numerotarjeta, double monto)
    {
        NumeroTarjeta = numerotarjeta;
        Monto = monto;
    }

    //Metodos

    public void ProcesarPago()
    {
        if (NumeroTarjeta.Length == 16)
        {
            Console.WriteLine($"Pago en efectivo de {Monto} procesado");
        }
        else
        {
            Console.WriteLine("Tarjeta Invalida");
        }
    }



}