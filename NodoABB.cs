namespace EstructurasNoLineales.Core.Arboles;

/// <summary>Nodo dinámico de un árbol binario de búsqueda (sin arreglo fijo).</summary>
public sealed class NodoABB
{
    public int Valor { get; set; }
    public NodoABB? Izquierdo { get; set; }
    public NodoABB? Derecho { get; set; }

    public NodoABB(int valor) => Valor = valor;
}
