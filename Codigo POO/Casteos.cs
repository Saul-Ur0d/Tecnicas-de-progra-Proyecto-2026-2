
//Conversion Implicita

int numeroEntero = 42;
double numeroDouble = numeroEntero;

Console.WriteLine(numeroDouble);

//Conversion Explicita

double numdou = 42.75;
int numEnt2 = (int)numdou;
Console.WriteLine(numEnt2);

//Con metodos

string texto = "123";
int num3 = Convert.ToInt32(texto); //Tarda mas que el parse
Console.WriteLine(num3);

//Parse

string texto2 = "3.14";
double doublet = double.Parse(texto2);
Console.WriteLine(doublet);

//TryParse

string texto3 = "3.14";
bool exito = int.TryParse(texto3, out int entero4);
Console.WriteLine(exito);
Console.WriteLine(entero4);

//Casteos entre objetos y clases

//Upper casting hijo - padre

Animal mianimal = new Perro();

//Down casting Padre - Hijo

Animal animal = new Animal();
Perro perro = (Perro)animal;
Perro perroanimal = animal as Perro

perro.Ladrar();

if (animal is Perro)
{
    Console.WriteLine("Es un perro");
}

object obj = "cadena";
string text0 = obj as string;
Console.WriteLine(text0);
