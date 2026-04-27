


//Declaracion

using System.Runtime.InteropServices;

int[] numeros = new int[5];
string[] palabras = new string[3] { "Hola", "mundo", "Adios"};

//Acceso

int primerNumero = numeros[0];
palabras[1] = "Universo"; //Se actualiza el valor


//Arreglo multidmensional

int[][,] matriz = new int[3][,]; //Jagged array, este es un arreglo de arreglos, la "," marca la dimension
int[,] matriz2 = new int[3, 3]; //Ambos son validos, este es arreglo de dos dimensiones
int[,] matrizinicializada = { {1,2,3 }, {4,5,6 }, {7,8,9 } };

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(matrizinicializada[i,j]);
    }
    Console.WriteLine("\n");
}

int[][] jaggedArray = new int[3][];

//Asignar elementos
jaggedArray[0] = new int[] { 1, 2 };
jaggedArray[1] = new int[3] { 3,4,5};
jaggedArray[2] = new int[] { 6 };

//Acceder a los elementos

foreach (int[] arreglo in jaggedArray)
{
    foreach (int i in arreglo)
    {
        Console.Write(i);
    }
    Console.WriteLine("");
}
