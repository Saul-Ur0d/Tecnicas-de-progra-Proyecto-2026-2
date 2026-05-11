




//Diccionario es estructura no lineal
//Cada clave es unica y tiene un valor asociado
//No mantiene orden especifico
//No tiene orden de insercion

//Creacion

using System.Runtime.CompilerServices;

Dictionary<string, int> edades = new Dictionary<string, int>();

//Agregar elementos

edades.Add("Ana", 25);
edades.Add("Juan", 30);
edades["Maria"] = 28;

//Acceso

int edadAna = edades["Ana"];
Console.WriteLine(edadAna);

//Verificar la existencia de clave

if(edades.ContainsKey("Carlos"))
{
    Console.WriteLine("Carlos existe");
}
if (edades.ContainsKey("Maria"))
{
    Console.WriteLine("Maria existe");
}
if(edades.ContainsValue(30))
{
    Console.WriteLine("Alguien tiene 30 años");
}

//Intenta obtener valor

if(edades.TryGetValue("Juan", out int edadJuan))
{
    Console.WriteLine($"Edad juan: {edadJuan}");
}

//Recorrer diccionario

foreach(KeyValuePair<string,int> kvp in edades)
{
    Console.WriteLine($"{kvp.Key}, {kvp.Value}");
}

foreach(string nombre in edades.Keys)
{
    Console.WriteLine(nombre);
}

foreach (int edad in edades.Values)
{
    Console.WriteLine(edad);
}

//Eliminar

edades.Remove("Ana");
foreach (int edad in edades.Values)
{
    Console.WriteLine(edad);
}

Dictionary<string, int[,][]> dic = new Dictionary<string, int[,][]>(); //Puede ser tan complejo como yo quiera



