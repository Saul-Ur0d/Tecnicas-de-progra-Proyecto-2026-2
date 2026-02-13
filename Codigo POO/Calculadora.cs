//Programa principal

Calculadora calculadora = new Calculadora(28, 6);

calculadora.Mostrar_Numeros();

int Resultado_Suma = calculadora.Suma();
Console.WriteLine($"El resultado de la suma es: {Resultado_Suma}");

int Resultado_Resta = calculadora.Resta();
Console.WriteLine($"El resultado de la Resta es: {Resultado_Resta}");

int Resultado_Multiplicacion = calculadora.Multiplicacion();
Console.WriteLine($"El resultado de la multiplicacion es: {Resultado_Multiplicacion}");

float Resultado_Division = calculadora.Division();
Console.WriteLine($"El resultado de la division es: {Resultado_Division}");



//Clases

//Calculadora basica que solo opera dos numeros enteros

public class Calculadora
{
    //Atributos
    public int Numero1 {  get; set; }
    public int Numero2 { get; set; }

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
    public int Suma()
    {
        return Numero1 + Numero2;
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

}