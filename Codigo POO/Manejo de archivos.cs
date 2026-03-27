
//Manejo de archivos

using System.IO;

//Escritura

//Ruta relativa

string ruta = "./archivo.txt";

//Ruta absoluta

string ruta2 = @"C:\Users\Alumnos\Documents\Saul Uriostegui\archivo2.txt";

using (StreamWriter writer = new StreamWriter(ruta))
    {
    writer.WriteLine("Hola, este es un archivo de texto");
    writer.WriteLine("Hola, esta es una segunda linea");
}

using (StreamWriter writer = new StreamWriter(ruta2))
{
    writer.WriteLine("Hola, este es un archivo de texto");
    writer.WriteLine("Hola, esta es una segunda linea");
}

//Lectura
 
using (StreamReader reader = new StreamReader(ruta))
{
    string contenido = reader.ReadToEnd();
    Console.WriteLine(contenido);
}

//Archivo binario escritorio

string rutaB = @"C:\Users\Alumnos\Documents\Saul Uriostegui\datosBinarios.bin";
using (BinaryWriter writer = new BinaryWriter(File.Open(rutaB, FileMode.Create)))
{
    writer.Write(25);
    writer.Write(3.1416);
    writer.Write("Texto Binario");
}
Console.WriteLine("Archivo binario escrito");

using (BinaryReader reader = new BinaryReader(File.Open(rutaB, FileMode.Open)))
{
    int numero = reader.ReadInt32();
    double numeroDecimal = reader.ReadDouble();
    string texto = reader.ReadString();
    Console.WriteLine(numero);
    Console.WriteLine(texto);
    Console.WriteLine(numeroDecimal);
}

//Acceso secuencial

string rutaSecuencial = @"C:\Users\Alumnos\Documents\Saul Uriostegui\secuencial.txt";
using (StreamWriter writer = new StreamWriter(rutaSecuencial))
{
    for (int i=1; i<= 200; i++)
    {
        writer.WriteLine($"Linea {i}");
    }
}

using (StreamReader reader = new StreamReader(rutaSecuencial))
{
    string lineaLectura;
    while((lineaLectura = reader.ReadLine()) != null)
    {
        if (lineaLectura == "Linea 150")
        {
            Console.WriteLine(lineaLectura);
        }
        //Console.WriteLine(lineaLectura);
    }
}

//Acceso aleatorio

string rutaAleatoria = @"C:\Users\Alumnos\Documents\Saul Uriostegui\aleatorio.txt";

using (FileStream fs = new FileStream(rutaAleatoria, FileMode.Create, FileAccess.ReadWrite))
{
    using (StreamWriter writer = new StreamWriter(fs))
    {
        writer.WriteLine("Linea 1: Hola, mundo");
        writer.WriteLine("Linea 2: C# es genial");
        writer.WriteLine("Linea 3: Adios, mundo");
    }
}



using (FileStream fs = new FileStream(rutaAleatoria, FileMode.Open, FileAccess.ReadWrite))
{
    fs.Seek(0, SeekOrigin.Begin);

    using (StreamReader reader = new StreamReader(fs))
    {
        string lineaLectura = reader.ReadLine();
        Console.WriteLine("Lectura aleatoria en punto 13:" + lineaLectura);
        
    }
}