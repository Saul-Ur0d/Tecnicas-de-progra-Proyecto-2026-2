//Programa principal banco
Banco banco = new Banco();
char repetir = 'y';
do
{
    try
    {
        CuentaBancaria cuentaorigen = banco.BuscarCuenta("332862");

        //Transferencia
        Console.WriteLine("Que operacion deseas realizar?" +
            "1-Depositar " +
            "2-Transferir " +
            "3-Retirar " +
            "4-Finalizar ");
        int Decision = int.Parse(Console.ReadLine() ?? "");

        switch (Decision)
        {
            case 1:
                Console.WriteLine($"Saldo inicial: ${cuentaorigen.Saldo}");
                Console.WriteLine("Cuanto deseas depositar?");
                decimal Deposito = decimal.Parse(Console.ReadLine() ?? "");
                cuentaorigen.Depositar(Deposito);
                Console.WriteLine($"Saldo final: ${cuentaorigen.Saldo}");
                break;
            case 2:
                Console.WriteLine($"Saldo inicial: ${cuentaorigen.Saldo}");
                Console.WriteLine("Cuanto deseas Transferir? ");
                decimal Transferencia = decimal.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("A quien le deseas transferir? ");
                CuentaBancaria cuentadestino = banco.BuscarCuenta(Console.ReadLine() ?? "");
                cuentaorigen.Transferir(cuentadestino, Transferencia);
                Console.WriteLine($"Saldo final: ${cuentaorigen.Saldo}");
                break;
            case 3:
                Console.WriteLine($"Saldo inicial: ${cuentaorigen.Saldo}");
                Console.WriteLine("Cuanto deseas retirar?");
                decimal Retiro = decimal.Parse(Console.ReadLine() ?? "");
                cuentaorigen.Retirar(Retiro);
                Console.WriteLine($"Saldo final: ${cuentaorigen.Saldo}");
                break;
            default:
                Console.WriteLine("Operacion no valida");
                break;
        }
        Console.WriteLine("Escribe Y para realizar mas operaciones");

    }
    catch (CuentaNoEncontradaEx ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (SaldoInsuficienteEx ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (DepositoInvalidoEx ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
} while (repetir == 'y' || repetir == 'Y');

public class SaldoInsuficienteEx : Exception
{
    //Constructor
    public SaldoInsuficienteEx(string mensaje) : base(mensaje)
    {  
    }
}
public class CuentaNoEncontradaEx : Exception
{
    //Constructor
    public CuentaNoEncontradaEx(string mensaje) : base(mensaje)
    {
    }
}
public class DepositoInvalidoEx : Exception
{
    //Constructor
    public DepositoInvalidoEx(string mensaje) : base(mensaje)
    {
    }
}

//Clases del banco

public class CuentaBancaria
{
    //Atributos

    public string NumeroCuenta { get; }
    public decimal Saldo { get; set; }

    //Constructor

    public CuentaBancaria(string numeroCuenta, decimal saldo)
    {
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
    }

    //Metodos

    public void Depositar(decimal cantidad)
    {
        if (cantidad  < 0)
        {
            throw new DepositoInvalidoEx("No puedes depositar cantidades negativas");
        }
        Saldo += cantidad;
    }

    public void Retirar(decimal cantidad)
    {
        if (cantidad > Saldo)
        {
            throw new SaldoInsuficienteEx("Saldo insuficiente para la operacion");
        }
        Saldo -= cantidad;
    }

    public void Transferir(CuentaBancaria destino, decimal cantidad)
    {
        if (destino == null)
        {
            throw new CuentaNoEncontradaEx("Cuenta no encontrada");
        }

        Retirar(cantidad);
        destino.Depositar(cantidad);

    }

}

public class Banco
{
    //Atributos

    private CuentaBancaria[] cuentas;


    //Constructor

    public Banco()
    {
        cuentas = new CuentaBancaria[]
        {
            new CuentaBancaria("332862", 6),
            new CuentaBancaria("810372", 20),
            new CuentaBancaria("930175", 10000),
        };
    }

    //Metodos

    public CuentaBancaria BuscarCuenta(string numCue)
    {
        foreach (CuentaBancaria C in cuentas)
        {
            if (C.NumeroCuenta == numCue)
            {
                return C;
            }
        }
        throw new CuentaNoEncontradaEx("Cuenta no encontrada");

    }
}







