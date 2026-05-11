


//Las tuplas no son estructuras, son una forma de agrupar datos heterogeneos (de diferentes tipos)
//Tamaño fijo e inmutable, tiene un limite de elementos (maximo 8)

//Tupla sin nombres

(string, int) personal = ("Ana", 25);

//Tupla con nombres

(string Nombre, int Edad) persona2 = ("Juan", 30);

//Acceso a elementos

Console.WriteLine(persona2);

Console.WriteLine(personal.Item1);
Console.WriteLine(persona2.Nombre);

//Devolver tupla en metodo

static(int, int) Div(int dividendo, int divisor)
{
    return (dividendo / divisor, dividendo % divisor);
}

var resultado = Div(10, 3);

Console.WriteLine($"Cociente {resultado.Item1} modulo {resultado.Item2}");

