
//Lista enlazada
//Cada elemento tiene un valor y un puntero al siguiente elemento


LinkedList<string> frutas = new LinkedList<string>();

//Agregar nodos

frutas.AddLast("Mango");
frutas.AddFirst("Mandarina");
frutas.AddLast("Sandia");
frutas.AddLast("Uva");


foreach (string fruta in frutas)
{
    Console.WriteLine(fruta);
}
//Recorrer mostrando enlaces

Console.WriteLine("Waos frutas en lista enlazada");

LinkedListNode<string> actual = frutas.First;
/*
while (actual != null)
{
    string anterior = actual.Previous?.Value ?? "null";
    string siguiente = actual.Next?.Value ?? "null";
    Console.WriteLine($"[{anterior}]<- {actual.Value} -> [{siguiente}]");
    actual = actual.Next;
}*/

LinkedListNode<string> nodoNuevo = frutas.Find("Uva");
frutas.AddBefore(frutas.First,"Mango");
frutas.AddAfter(nodoNuevo, "Tuna");


while (actual != null)
{
    string anterior = actual.Previous?.Value ?? "null";
    string siguiente = actual.Next?.Value ?? "null";
    Console.WriteLine($"[{anterior}]<- {actual.Value} -> [{siguiente}]");
    actual = actual.Next;
}







