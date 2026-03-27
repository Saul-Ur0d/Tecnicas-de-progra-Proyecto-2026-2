
public class Estudiante
{
    //Atributos
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad {  get; set; }
    public double Calificacion { get; set; }

    //Constructor





    //Metodos
    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Edad: {Edad}, Calificacion: {Calificacion}";
    }



}

//Clase para manejar el archivo de estudiantes

public class GestorEstudiantes
{
    //Atributos
    private string rutaArchivo;

    //Constructor
    
    public GestorEstudiantes(string ruta)
    {
        rutaArchivo = ruta;
    }
    
    //Metodo para guardar la lista de estudiantes en un archivo

    public void GuardarEstudiantes(List<Estudiante> estudiantes)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {

                foreach (Estudiante estudiante in estudiantes)
                {
                    writer.WriteLine(estudiante.ToString());
                }

            }
            Console.WriteLine("Estudiantes guardados correctamente");


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //Metodo para leer la lista de estudiantes en el archivo

    public List<Estudiante> LeerEstudiantes()
    {
        List<Estudiante> estudiantesLectura = new List<Estudiante>();
        try
        {
            using (StreamReader reader = new StreamReader(fs))
            {
                string lineaLectura = reader.ReadLine();
                Console.WriteLine("Lectura aleatoria en punto 13:" + lineaLectura);

            }
        }
        catch (Exception ex)
        {

        }

}





