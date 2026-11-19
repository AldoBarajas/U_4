namespace EstructurasNoLineales.Core.Arboles;

/// <summary>
/// ABB dinámico de enteros sin duplicados. Invariante:
/// izquierda menor que nodo, derecha mayor que nodo.
/// Complejidad inserción/búsqueda/eliminación: O(h), h=altura en nodos.
/// </summary>
public sealed class ArbolBinarioBusqueda
{
    private NodoABB? raiz;
    public int Cantidad { get; private set; }
    public bool EstaVacio => raiz is null;

    public bool Insertar(int valor)
    {
        bool insertado = false;
        raiz = InsertarRec(raiz, valor, ref insertado);
        if (insertado) Cantidad++;
        return insertado;
    }

    private static NodoABB InsertarRec(NodoABB? nodo, int valor, ref bool insertado)
    {
        if (nodo is null)
        {
            insertado = true;
            return new NodoABB(valor);
        }
        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor, ref insertado);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor, ref insertado);
        return nodo; // Un duplicado no se inserta.
    }

    public bool Buscar(int valor)
    {
        NodoABB? actual = raiz;
        while (actual is not null)
        {
            if (valor == actual.Valor) return true;
            actual = valor < actual.Valor ? actual.Izquierdo : actual.Derecho;
        }
        return false;
    }

    public bool Eliminar(int valor)
    {
        bool eliminado = false;
        raiz = EliminarRec(raiz, valor, ref eliminado);
        if (eliminado) Cantidad--;
        return eliminado;
    }

    private static NodoABB? EliminarRec(NodoABB? nodo, int valor, ref bool eliminado)
    {
        if (nodo is null) return null;
        if (valor < nodo.Valor)
        {
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor, ref eliminado);
            return nodo;
        }
        if (valor > nodo.Valor)
        {
            nodo.Derecho = EliminarRec(nodo.Derecho, valor, ref eliminado);
            return nodo;
        }

        eliminado = true;
        // Caso 1: sin hijos; caso 2: con un único hijo.
        if (nodo.Izquierdo is null) return nodo.Derecho;
        if (nodo.Derecho is null) return nodo.Izquierdo;

        // Caso 3: dos hijos. Sustituir por sucesor inorden (mínimo derecho).
        NodoABB sucesor = nodo.Derecho;
        while (sucesor.Izquierdo is not null) sucesor = sucesor.Izquierdo;
        nodo.Valor = sucesor.Valor;
        bool ignorar = false; // No descontar Cantidad por segunda vez.
        nodo.Derecho = EliminarRec(nodo.Derecho, sucesor.Valor, ref ignorar);
        return nodo;
    }

    public IReadOnlyList<int> Preorden()
    {
        var lista = new List<int>(); PreordenRec(raiz, lista); return lista;
    }
    public IReadOnlyList<int> Inorden()
    {
        var lista = new List<int>(); InordenRec(raiz, lista); return lista;
    }
    public IReadOnlyList<int> Postorden()
    {
        var lista = new List<int>(); PostordenRec(raiz, lista); return lista;
    }

    private static void PreordenRec(NodoABB? nodo, List<int> r)
    {
        if (nodo is null) return;
        r.Add(nodo.Valor); PreordenRec(nodo.Izquierdo, r); PreordenRec(nodo.Derecho, r);
    }
    private static void InordenRec(NodoABB? nodo, List<int> r)
    {
        if (nodo is null) return;
        InordenRec(nodo.Izquierdo, r); r.Add(nodo.Valor); InordenRec(nodo.Derecho, r);
    }
    private static void PostordenRec(NodoABB? nodo, List<int> r)
    {
        if (nodo is null) return;
        PostordenRec(nodo.Izquierdo, r); PostordenRec(nodo.Derecho, r); r.Add(nodo.Valor);
    }

    public int AlturaEnAristas() => AlturaRec(raiz);
    private static int AlturaRec(NodoABB? n) => n is null
        ? -1 : 1 + Math.Max(AlturaRec(n.Izquierdo), AlturaRec(n.Derecho));

    public bool ValidarInvariante()
    {
        int contados = 0;
        return EsValido(raiz, long.MinValue, long.MaxValue, ref contados)
               && contados == Cantidad;
    }
    private static bool EsValido(NodoABB? nodo, long min, long max, ref int contados)
    {
        if (nodo is null) return true;
        if (nodo.Valor <= min || nodo.Valor >= max) return false;
        contados++;
        return EsValido(nodo.Izquierdo, min, nodo.Valor, ref contados)
            && EsValido(nodo.Derecho, nodo.Valor, max, ref contados);
    }
}
