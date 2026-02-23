


List <Persona> Personas = new List <Persona>();
Personas.Add(new Persona("Joaquin", 20, "Mexico"));
Personas.Add(new Persona("Enrique", 15, "Canada"));
Personas.Add(new Persona("Elias", 8, "Uruguay"));
Personas.Add(new Persona("Luis", 18, "Colombia"));
Personas.Add(new Persona("Daniela", 21, "Canada"));


foreach (Persona individuo in Personas)
{
    individuo.MostrarDatos();
}

List <Persona> Mayores  = new List <Persona>();

foreach(Persona individuo in Personas)
{
    if (individuo.Edad >= 18)
    {
        Mayores.Add(individuo);
    }
}
//Mayores.Sort();

Console.WriteLine("Mayores de edad:");
foreach (Persona individuo in Mayores)
{
    individuo.MostrarDatos();
}