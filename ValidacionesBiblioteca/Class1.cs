




namespace ValidacionesBiblioteca
{
    public static class Validacion
    {
        public static bool EsAnioValido(int anio)
        {
            return (anio > 0 && anio <= DateTime.Now.Year);
        }

        public static bool EsTituloValido(string titulo)
        {
            return !string.IsNullOrEmpty(titulo);
        }




    }


    public class ValidacionAnio : Exception
    {
        public static bool EsAnioValido(int anio)
        {
            return (anio > 0 && anio <= DateTime.Now.Year);
        }

    }

    public class ValidacionTitulo : Exception
    {

        public static bool EsTituloValido(string titulo)
        {
            return !string.IsNullOrEmpty(titulo);
        }




    }
}

