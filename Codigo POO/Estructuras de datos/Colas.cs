
//Cola (QUEUE)
//FIFO primero en entrar primero en salir
//Solo accede al primer elemento
//No permite busqueda

//Crear

Queue<string> cola = new Queue<string> ();

//Añadir elementos
cola.Enqueue("Primero");
cola.Enqueue("Segundo");
cola.Enqueue("Tercero");

foreach(string s in cola)
{
    Console.WriteLine(s);
}

string primerElemento = cola.Dequeue(); //Regresa el valor y lo elimina de la cola

string frontal = cola.Peek(); //Devuelve el elemento sin eliminarlo

























