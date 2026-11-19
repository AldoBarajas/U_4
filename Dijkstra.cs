namespace EstructurasNoLineales.Core.Grafos;

public sealed record PasoDijkstra(int Paso, string VerticeFijado, int DistanciaFijada,
    string Relajaciones, IReadOnlyList<int?> Distancias);

/// <summary>Resultado auditable, incluida la traza de iteraciones.</summary>
public sealed class ResultadoDijkstra
{
    private readonly string[] vertices;
    private readonly int origen;
    private readonly int?[] distancias;
    private readonly int[] predecesores;
    public IReadOnlyList<PasoDijkstra> Pasos { get; }
    public ResultadoDijkstra(string[] vertices, int origen, int?[] d, int[] p, List<PasoDijkstra> pasos)
    {
        this.vertices = vertices; this.origen = origen;
        distancias = d; predecesores = p; Pasos = pasos;
    }
    public int? DistanciaHasta(string destino)
    {
        int i = Array.FindIndex(vertices, x => string.Equals(x, destino, StringComparison.OrdinalIgnoreCase));
        if (i < 0) throw new ArgumentException("Destino desconocido.");
        return distancias[i];
    }
    public IReadOnlyList<string> CaminoHasta(string destino)
    {
        int i = Array.FindIndex(vertices, x => string.Equals(x, destino, StringComparison.OrdinalIgnoreCase));
        if (i < 0) throw new ArgumentException("Destino desconocido.");
        if (distancias[i] is null) return Array.Empty<string>();
        var camino = new List<string>();
        while (i != -1)
        {
            camino.Add(vertices[i]);
            if (i == origen) break;
            i = predecesores[i];
        }
        camino.Reverse();
        return camino;
    }
}

/// <summary>
/// Dijkstra con selección lineal de mínimo: O(V² + E), memoria O(V + E).
/// Usa listas de adyacencia; no admite aristas de peso negativo.
/// </summary>
public static class Dijkstra
{
    public static ResultadoDijkstra Resolver(GrafoPonderado grafo, string origen)
    {
        int n = grafo.NumeroVertices;
        int fuente = grafo.IndiceDe(origen);
        var d = new int?[n];
        var pred = Enumerable.Repeat(-1, n).ToArray();
        var visitado = new bool[n];
        var pasos = new List<PasoDijkstra>();
        d[fuente] = 0;
        for (int iteracion = 0; iteracion < n; iteracion++)
        {
            int u = -1;
            for (int v = 0; v < n; v++)
            {
                if (!visitado[v] && d[v].HasValue &&
                    (u == -1 || d[v]!.Value < d[u]!.Value)) u = v;
            }
            if (u == -1) break; // Los restantes son inalcanzables.
            visitado[u] = true;
            var cambios = new List<string>();
            foreach (Arista a in grafo.Vecinos(u))
            {
                if (visitado[a.Destino]) continue;
                long candidato = (long)d[u]!.Value + a.Peso;
                if (candidato > int.MaxValue)
                    throw new OverflowException("Costo acumulado supera Int32.MaxValue.");
                if (!d[a.Destino].HasValue || candidato < d[a.Destino]!.Value)
                {
                    d[a.Destino] = (int)candidato;
                    pred[a.Destino] = u;
                    cambios.Add($"{grafo.Vertices[a.Destino]}={(int)candidato}");
                }
            }
            pasos.Add(new PasoDijkstra(pasos.Count + 1, grafo.Vertices[u], d[u]!.Value,
                cambios.Count == 0 ? "Sin cambios" : string.Join(", ", cambios),
                (int?[])d.Clone()));
        }
        return new ResultadoDijkstra(grafo.Vertices.ToArray(), fuente, d, pred, pasos);
    }
}
