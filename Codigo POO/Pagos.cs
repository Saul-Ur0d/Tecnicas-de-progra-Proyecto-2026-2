
//Programa principal

bool continua = true;

List<Ipago> listaPagos = new List<Ipago>();
do
{
    Console.WriteLine("Ingresa el monto a pagar : ");
    string montotexto = Console.ReadLine() ?? "";
    if (double.TryParse(montotexto, out double monto))
    {
        string modoPagoT;
        int modoPago;
        do
        {

            Console.WriteLine("1- Pago con tarjeta");
            Console.WriteLine("2- Pago en efectivo");

            modoPagoT = Console.ReadLine() ?? "";




        } while (!int.TryParse(modoPagoT, out modoPago) || (modoPago != 1 && modoPago != 2));

        if(modoPago == 1)
        {
            Console.WriteLine("Ingrese el numero de la tarjeta");
            string tarjeta = Console.ReadLine() ?? "";

            //Creando objeto para pago con tarjeta

            Ipago pago = new PagoTarjeta(tarjeta, monto);
            listaPagos.Add(pago);

        }
        else
        {
            Ipago pago = new PagoEfectivo(monto);
            listaPagos.Add(pago);
        }

    }
    else
    {
        Console.WriteLine("Error monto invalido");
        return;
    }

    Console.WriteLine("Presiona S para procesar mas pagos: ");
    char continuaT = char.Parse(Console.ReadLine() ?? "".ToLower());
    if(continuaT == 's')
    {
        continua = true;
    }
    else
    {
        continua = false;
    }


} while (continua);

foreach(Ipago pago in listaPagos)
{
    pago.ProcesarPago();
}




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