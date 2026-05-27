//Mapa matricial 
/*    c0  c1  c2  c3  c4
 * f0 [S] [0] [0] [1] [0]
 * f1 [0] [1] [0] [1] [0]
 * f2 [0] [1] [0] [0] [0]
 * f3 [0] [0] [1] [1] [0]
 * f4 [1] [0] [0] [0] [G]
 */

//Programa principal:
AStar.Buscar();





//Estrella
//Nodos de estados

public class Nodo
{
    public int X, Y;
    public int G; //Costo real acomulado desde el inicio
    public int H; //Heuristica: distancia de Manhattan a la meta
    public int F => G + H; //f(nodo) = g(nodo) + h(nodo)
    public Nodo Padre; //Para reconstruir el camino
    //Constructor
    public Nodo(int x, int y)
    {
        X = x;
        Y = y;
        G = 0;
        H = 0;
        Padre = null;
    }
}

class AStar
{
    public static int[,] grid =
        { { 0,0,0,1,0},
    {0,1,0,1,0 },
    { 0,1,0,0,0},
    { 0,0,1,1,0},
    { 1,0,0,0,0} };
    static int filas = 5;
    static int columnas = 5;

    //Heuristica distancia de Manhattan
    // h(n) = |xn - xmeta| + |yn - ymeta|

    static int Heuristica(Nodo a, Nodo b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    static bool EstaEnQueue(Queue<Nodo> cola, Nodo buscado)
    {
        foreach (Nodo nodo in cola)
        {
            if(nodo.X == buscado.X && nodo.Y == buscado.Y)
            {
                return true;
            }
        }
        return false;
    }

    private static Nodo[] ObtenerVecinos(Nodo n)
    {
        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };

        Nodo[] temp = new Nodo[4];
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            int nx = n.X + dx[i];
            int ny = n.Y + dy[i];

            // Descartar fuera de limites
            if (nx < 0 || ny < 0 || nx >= filas || ny >= columnas)
            {
                continue;
            }
            //Descartar paredes (1 en el mapa)

            if (grid[nx, ny] == 1)
            {
                continue;
            }

            temp[count++] = new Nodo(nx, ny);

        }
        //Devolver el arreglo con el tamaño exacto
        Nodo[] vecinos = new Nodo[count];
        Array.Copy(temp, vecinos, count);
        return vecinos;
    }

    //Extraer nodo con menor F

    private static Nodo ExtraerMejor(Queue<Nodo> cola)
    {
        Nodo mejor = null;

        foreach(Nodo n in cola)
        {
            if(mejor == null)
            {
                mejor = n;
                continue;
            }
            if(n.F < mejor.F || (n.F == mejor.F && n.G > mejor.G))
            {
                mejor = n;
            }
        }
        //Reconstruir la cola sin nodo elegido
        Queue<Nodo> sinMejor = new Queue<Nodo>();
        foreach(Nodo n in cola)
        {
            if(n != mejor)
            {
                sinMejor.Enqueue(n);
            }
        }
        //Vaciar y volver a llenar la cola original
        cola.Clear();
        foreach(Nodo n in sinMejor)
        {
            cola.Enqueue(n);
        }
        return mejor;
    }

    //Algoritmo principal
    
    public static void Buscar()
    {
        Nodo inicio = new Nodo(0, 0);
        Nodo meta = new Nodo(4, 4);

        //Paso 1 calcular h del inicio y f final

        inicio.G = 0;
        inicio.H = Heuristica(inicio, meta);

        Console.WriteLine("Algoritmo A*");
        Console.WriteLine($"Inicio: ({inicio.X},{inicio.Y}) Meta: ({meta.X},{meta.Y})");

        //Paso 2 crear la estructura abierta nodos por explorar y estructura cerrada
        //nodos ya explorados

        Queue<Nodo> abierta = new Queue<Nodo>();
        Queue<Nodo> cerrada = new Queue<Nodo>();

        //Paso 3 agrega el nodo inicio estructura cerrada
        abierta.Enqueue(inicio);

        int iter = 0;

        //Paso 4 Bucle principal
        //Sigue mientras haya nodos candidatos en la cola abierta
        //Si se vacia sin encontrar la meta = no hay camino

        while(abierta.Count > 0)
        {
            iter++;
            Console.WriteLine($"Iteracion {iter}---");

            //4a Extraer nodo con menor f de la cola abierta
            Nodo actual = ExtraerMejor(abierta);
            Console.WriteLine($"Explorando: ({actual.X},{actual.Y}) g={actual.G}" + $" h={actual.H} f={actual.F}");

            //4b Comprobar si llegamos a la meta

            if(actual.X == meta.X && actual.Y == meta.Y)
            {
                Console.WriteLine("Meta alcanzada");
                Reconstruir(actual);
                return;
            }

            //4c mover el nodo actual a la lista cerrada

            cerrada.Enqueue(actual);

            //4d explorar cada vecino valido del nodo actual

            foreach(Nodo vecino in ObtenerVecinos(actual))
            {
                //si el vecino ya esta en la cola cerrada
                if(EstaEnQueue(cerrada, vecino))
                {
                    continue;
                }
                //4e calcular g tentativo para llegar al vecino
                int gTentativo = actual.G + 1;

                //4f calcular h del vecino
                vecino.G = gTentativo;
                vecino.H = Heuristica(vecino, meta);
                vecino.Padre = actual;

                //4g si el vecino no esta en la cola abierta, agregarlo 
                if(!EstaEnQueue(abierta, vecino))
                {
                    abierta.Enqueue(vecino);
                    Console.WriteLine($"  + Abierta: ({vecino.X},{vecino.Y}) g={vecino.G} h={vecino.H} f={vecino.F}");
                }

            }

            //Mostrar estado actual de ambas listas
            Console.Write("   Abierta :  ");
            foreach(Nodo n in abierta)
            {
                Console.Write($"({n.X},{n.Y}) f= {n.F}");
            }

            Console.Write("\n   Cerrada :  ");
            foreach (Nodo n in cerrada)
            {
                Console.Write($"({n.X},{n.Y}) f= {n.F}");
            }

            Console.Write("\n");

        }

    }

    public static void Reconstruir(Nodo nodo)
    {
        //Acomular nodos en un arreglo temporal
        Nodo[] temp = new Nodo[25];
        int count = 0;
        Nodo cur = nodo;

        while(cur != null)
        {
            temp[count++] = cur;
            cur = cur.Padre;
        }

        //Imprimir de inicio a meta
        Console.WriteLine("Camino encontrado ---");
        for (int i = count; i >= 0; i--)
        {
            Console.WriteLine($"Paso {count - 1 - i}: ({temp[i].X},{temp[i].Y})");
        }

        Console.WriteLine($"Costo total (g): {nodo.G}");

    }

}















