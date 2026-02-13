//Programa principal


/*
calculadora.Mostrar_Numeros();

int Resultado_Suma = calculadora.Suma();
Console.WriteLine($"El resultado de la suma es: {Resultado_Suma}");

int Resultado_Resta = calculadora.Resta();
Console.WriteLine($"El resultado de la Resta es: {Resultado_Resta}");

int Resultado_Multiplicacion = calculadora.Multiplicacion();
Console.WriteLine($"El resultado de la multiplicacion es: {Resultado_Multiplicacion}");

float Resultado_Division = calculadora.Division();
Console.WriteLine($"El resultado de la division es: {Resultado_Division}");

Console.WriteLine($"El primer numero de la priera calculadora fue: {calculadora.Numero1}");

//Set
using System.ComponentModel;


Calculadora calcula_2 = new Calculadora(5, 7);
//Console.WriteLine($"El primer numero de la segunda calculadora fue: {calcula_2.Numero1}");


Console.WriteLine($"El resultado calc cientifica: {calculadoraCientifica.Suma()}");
Console.WriteLine($"El resultado calc basica: {calcula_2.Suma(3)}");

Calculadora calcula_3 = calcula_2 + calculadora;

Console.WriteLine("Para calculadora 3:");
calcula_3.Mostrar_Numeros();

calculadoraCientifica.MensajeEE();

int Res_Fac = calcula_2.Factorial();
Console.WriteLine($"El factorial de este numero es: {Res_Fac}");
*/

Console.WriteLine("Ingresa el primer numero a operar: ");
int num1 = int.Parse(Console.ReadLine() ?? "");
Console.WriteLine("Ingresa el segundo numero a operar");
int num2 = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("Presiona 1- Calculadora Basica");
Console.WriteLine("Presiona 2- Calculadora Cientifica");
int sel = int.Parse(Console.ReadLine() ?? "");

if (sel == 1)
{
    Calculadora calculadora = new Calculadora(num1, num2);
    Console.WriteLine("1- Suma");
    Console.WriteLine("2- Resta");
    Console.WriteLine("3- Multiplicacion");
    Console.WriteLine("4- Division");
    int sel = int.Parse(Console.ReadLine() ?? ""); 

    switch (sel)
    {
        case 1:
            Console.WriteLine($"El resultado calc basica: {calculadora.Suma()}");
            break;
        case 2:
            Console.WriteLine($"El resultado calc basica: {calculadora.Resta()}");
            break;
        case 3:
            Console.WriteLine($"El resultado calc basica: {calculadora.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"El resultado calc basica: {calculadora.Division()}");
            break;
        default:
            Console.WriteLine("Seleccion incorrecta");
            break;
    }
}
if (sel == 2)
{
    CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica(num1, num2);
    Console.WriteLine("1- Suma y al cuadrado");
    Console.WriteLine("2- Resta");
    Console.WriteLine("3- Multiplicacion");
    Console.WriteLine("4- Division");
    Console.WriteLine("5- Logaritmo");
    Console.WriteLine("6- Raiz cuadrada");
    Console.WriteLine("7- Factorial");
    int sel = int.Parse(Console.ReadLine() ?? "");

    switch (sel)
    {
        case 1:
            Console.WriteLine($"El resultado calc cientifica: {calculadoraCientifica.Suma()}");
            break;
        case 2:
            Console.WriteLine($"El resultado calc cientifica: {calculadoraCientifica.Resta()}");
            break;
        case 3:
            Console.WriteLine($"El resultado calc cientifica: {calculadoraCientifica.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"El resultado calc cientifica: {calculadoraCientifica.Division()}");
            break;
        case 5:
            Console.WriteLine($"El resultado calc cientifica: {calculadoraCientifica.Logaritmo()}");
            break;
        case 6:
            Console.WriteLine($"El resultado calc cientifica: {calculadoraCientifica.RaizCuadrada()}");
            break;
        case 7:
            Console.WriteLine($"El resultado calc cientifica: {calculadoraCientifica.Factorial()}");
            break;
        default:
            Console.WriteLine("Seleccion incorrecta");
            break;
    }
    }


//Clases

//Calculadora basica que solo opera dos numeros enteros

public class Calculadora
{
    //Atributos
    public int Numero1 {  get; set; }
    public int Numero2 { get; set; }

    //Atributo privado
    private int Resultado;
    private string mensaje = "Mensaje privado";

    //Constructor
    public Calculadora (int numero1, int numero2)
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }

    //Metodos
    public void Mostrar_Numeros()
    {
        Console.WriteLine($"El primer numero usdo fue: {Numero1}");
        Console.WriteLine($"El segundo numero usado fue: {Numero2}");
    }
    public virtual int Suma()
    {
        Resultado = Numero1 + Numero2;
        return Resultado;
    }
    //Metodo privado

    private void Mostrar_mensaje()
    {
        Console.WriteLine(mensaje);
    }

    //Metodo protegido

    protected void Mensaje()
    {
        Mostrar_mensaje();
    }

    //Sobrecarga del metodo suma
    public virtual int Suma(int num3)
    {
        return Numero1 + Numero2 + num3;
    }

    public int Resta()
    {
        return Numero1 - Numero2;
    }
    public int Multiplicacion()
    {
        return Numero1 * Numero2;
    }
    public float Division()
    {
        if (Numero2 == 0)
        {
            Console.WriteLine("MathError");
            return 0;
        }
        return (float) Numero1 / Numero2;
    }
   
    //Sobrecarga del operador
    public static Calculadora operator + (Calculadora calc1, Calculadora calc2)
    {
        return new Calculadora(calc1.Numero1 + calc2.Numero1, calc1.Numero2 + calc2.Numero2);
    }

}


// Clase hija

public class CalculadoraCientifica : Calculadora
{
    //Atributos



    //Constructor
    public CalculadoraCientifica(int num1, int num2) : base(num1, num2)
    { 
    
    }

    //Metodos

    public double Logaritmo()
    {
        return MathF.Log(Numero1);
    }

    public double RaizCuadrada()
    {
        return MathF.Sqrt(Numero1);
    }

    //Override cambia el metodo heredado

    public override int Suma()
    {
        int resultado = base.Suma();
        return resultado * resultado;
    }

    public void MensajeEE()
    {
        base.Mensaje();
    }

    public int Factorial()
    {

        if (Numero1 == 0 || Numero1 == 1)
        { return 1; }
        else if (Numero1 < 0)
        {
            Console.WriteLine("No hay factorial negativo");
            return 0;
        }
        else
        {
            int fct = 1;
            for (int j = 2; j <= Numero1; j++)
            {
                fct *= j;
            }
            return fct;
        }
    }
}