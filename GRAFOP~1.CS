namespace EstructurasNoLineales.Core.Grafos;

public readonly record struct Arista(int Destino, int Peso);

/// <summary>Grafo dirigido de pesos no negativos; adyacencia mediante listas.</summary>
public sealed class GrafoPonderado
{
    private readonly string[] nombres;
    private readonly Dictionary<string, int> indices;
    private readonly List<Arista>[] adyacencia;

    public GrafoPonderado(params string[] vertices)
    {
        if (vertices.Length == 0) throw new ArgumentException("Se requiere un vértice.");
        if (vertices.Any(string.IsNullOrWhiteSpace))
            throw new ArgumentException("Los nombres no pueden ser vacíos.");
        nombres = (string[])vertices.Clone();
        indices = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < nombres.Length; i++)
        {
            if (!indices.TryAdd(nombres[i], i))
                throw new ArgumentException("Vértices duplicados.");
        }
        adyacencia = new List<Arista>[nombres.Length];
        for (int i = 0; i < nombres.Length; i++) adyacencia[i] = new List<Arista>();
    }

    public int NumeroVertices => nombres.Length;
    public IReadOnlyList<string> Vertices => nombres;
    public int IndiceDe(string nombre) => indices.TryGetValue(nombre, out int i)
        ? i : throw new ArgumentException($"Vértice desconocido: {nombre}");
    public IReadOnlyList<Arista> Vecinos(int indice) => adyacencia[indice];

    public void AgregarArista(string origen, string destino, int peso)
    {
        if (peso < 0) throw new ArgumentOutOfRangeException(nameof(peso), "Dijkstra no admite negativos.");
        int a = IndiceDe(origen), b = IndiceDe(destino);
        if (adyacencia[a].Any(e => e.Destino == b))
            throw new InvalidOperationException("La arista ya existe.");
        adyacencia[a].Add(new Arista(b, peso));
    }

    /// <summary>Null significa que no existe arista. La diagonal siempre es 0.</summary>
    public int?[,] MatrizAdyacencia()
    {
        int n = NumeroVertices;
        var m = new int?[n, n];
        for (int i = 0; i < n; i++)
        {
            m[i, i] = 0;
            foreach (Arista a in adyacencia[i]) m[i, a.Destino] = a.Peso;
        }
        return m;
    }

    public static GrafoPonderado CasoDistribucion()
    {
        var g = new GrafoPonderado("Bodega", "Centro", "Norte", "Este", "Sur", "Parque", "Cliente");
        g.AgregarArista("Bodega", "Centro", 4);
        g.AgregarArista("Bodega", "Norte", 8);
        g.AgregarArista("Bodega", "Sur", 10);
        g.AgregarArista("Centro", "Norte", 2);
        g.AgregarArista("Centro", "Este", 8);
        g.AgregarArista("Centro", "Sur", 7);
        g.AgregarArista("Norte", "Este", 3);
        g.AgregarArista("Norte", "Parque", 8);
        g.AgregarArista("Este", "Parque", 4);
        g.AgregarArista("Este", "Cliente", 11);
        g.AgregarArista("Sur", "Este", 2);
        g.AgregarArista("Sur", "Cliente", 10);
        g.AgregarArista("Parque", "Cliente", 3);
        return g;
    }
}
