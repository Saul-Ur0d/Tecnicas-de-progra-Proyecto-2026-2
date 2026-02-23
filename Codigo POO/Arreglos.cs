//Declaracion
/*
int[] numeros = new int[2]; //Arreglo con 2 valores

//Asigmar elementos

numeros [1] = 8; //Asignando un valor al indice del segundo valor

if  (numeros[0] == 0)
{
    Console.WriteLine("Hay un cero");
}

//Obtener la longitud del arreglo

Console.WriteLine(numeros.Length);

//Decñaracion implicita



Console.WriteLine(numeros2 [3]);
Console.WriteLine(numeros2.Length);

char[] vocales = new[] { 'a', 'e', 'i', 'o', 'u'};
for (int i = 0; i < vocales.Length; i++)
{
    Console.WriteLine (vocales [i]);
}
foreach (char c in vocales) //Lo mismo pero mas rapido
{
    Console.WriteLine (c);
}

bool[] estado = new bool[3];

foreach (bool d in estado) 
{
    Console.WriteLine(d);
    if (!d)
    {
        Console.WriteLine("Esto es falso");
    }
}
*/
//Metodos arreglos

//Ordenar el arreglo

int[] numeros2 = new int[] { 4, 5, 6, 1 };

foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

Array.Sort(numeros2);
Console.WriteLine("Ordenado");

foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

//Revierte el orden de los elementos
Console.WriteLine("Revertido");

Array.Reverse(numeros2);
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

//Metodo para buscar un valor
//Binary search solo funciona si esta ordenado con sort

int indice = Array.BinarySearch(numeros2, 6); //Devuelve el indice del elemento que contiene ese valor, devuelve -1 si no lo encuentra
Console.WriteLine(indice);

//Listas
List <int> numeros3 = new List<int>();

Console.WriteLine("Lista");

numeros3.Add(0);
numeros3.Add(10);
numeros3.Add(30);


foreach (int numero in numeros3)
{
    Console.WriteLine(numero);
}

//Acceder a un eleento de la lista
int primerNumero = numeros3[2];

//Eliminar un elemento
numeros3.Remove(primerNumero);
foreach (int numero in numeros3)
{
    Console.WriteLine(numero);
}

//Eliminar por indice
numeros3.RemoveAt(0);

Console.WriteLine("Lista de nombres");
//Declarar lista con valores asignados
List<string> nombres  = new List<string> {"Luis", "Ana", "Carlos" };

nombres.Add("Pablo");
Console.WriteLine(nombres.Count());

foreach (string numero in nombres)
{
    Console.WriteLine(numero);
}

nombres.Sort();

foreach (string numero in nombres)
{
    Console.WriteLine(numero);
}

nombres.Clear();
Console.WriteLine(nombres.Count());

Console.WriteLine(nombres.Contains("Carlos"));


