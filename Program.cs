using EstructurasNoLineales.Core.Grafos;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var g = GrafoPonderado.CasoDistribucion();
Console.WriteLine("TAREA 4.3 - RUTAS DE DISTRIBUCIÓN CON DIJKSTRA");
Console.WriteLine("Grafo dirigido; pesos: minutos hipotéticos");
Console.WriteLine("Vértices: " + string.Join(", ", g.Vertices));
Console.WriteLine("
LISTA DE ADYACENCIA");
for (int i = 0; i < g.NumeroVertices; i++)
    Console.WriteLine($"{g.Vertices[i],-8}: " + string.Join(", ",
        g.Vecinos(i).Select(a => $"{g.Vertices[a.Destino]}({a.Peso})")));
Console.WriteLine("
MATRIZ DE ADYACENCIA - ∞ = sin arco");
var matriz = g.MatrizAdyacencia();
Console.Write("         ");
foreach (string s in g.Vertices) Console.Write($"{s,9}");
Console.WriteLine();
for (int i = 0; i < g.NumeroVertices; i++)
{
    Console.Write($"{g.Vertices[i],-9}");
    for (int j = 0; j < g.NumeroVertices; j++)
        Console.Write($"{(matriz[i, j]?.ToString() ?? "∞"),9}");
    Console.WriteLine();
}
var r = Dijkstra.Resolver(g, "Bodega");
Console.WriteLine("
TRAZA DIJKSTRA (distancias tras cada relajación)");
foreach (var p in r.Pasos)
{
    Console.WriteLine($"Paso {p.Paso}: fijado {p.VerticeFijado} ({p.DistanciaFijada}); {p.Relajaciones}");
    Console.WriteLine("  d=[" + string.Join(", ", p.Distancias.Select(x => x?.ToString() ?? "∞")) + "]");
}
Console.WriteLine("
RESULTADO PARA CLIENTE");
Console.WriteLine("Ruta óptima: " + string.Join(" → ", r.CaminoHasta("Cliente")));
Console.WriteLine($"Costo total: {r.DistanciaHasta("Cliente")} minutos hipotéticos");
