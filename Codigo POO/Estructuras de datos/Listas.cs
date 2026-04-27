






//La lista sigue creciendo si le agrego elementos, el arreglo tiene un numero fijo de elementos asignado al instanciarlo

List<int> numeros = new List<int>();

//Explicita

List<string> palabras = new List<string> { "Hola", "Mundo", "Adios" };

numeros.Add(10);
numeros.AddRange([20, 30, 40]); //Implicita
//numeros.AddRange(new int [] { 20, 30, 40}); Explicita


foreach (int i in numeros)
{
    Console.WriteLine(i);
}

numeros[1] = 60; //Se actualiza valor
foreach (int i in numeros)
{
    Console.WriteLine(i);
}

//Insertar
numeros.Insert(2, 25); //Se inserta un valor en el indice 2 entre el valor 20 y el 30, el resto se recorren hacia la derecha un indice
numeros.Remove(20); //Busca el valor y lo elimina
numeros.RemoveAt(3); //Busca el indice y elimina el elemento ahi

foreach (int i in numeros)
{
    Console.WriteLine(i);
}

bool existe = numeros.Contains(20); //Busca si existe el valor, regresa T/F
int indice = numeros.IndexOf(40); //Busca en que indice esta un valor
int mayor15 = numeros.Find(x => x > 15); // Regresa un solo valor que cumpla la condicion
List<int> mayores = numeros.FindAll(x => x > 15); // Regresa todos los valores que cumplen la condicion








