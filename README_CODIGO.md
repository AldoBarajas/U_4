# Proyectos de la solución

| Proyecto | Tipo | Función |
|---|---|---|
| EstructurasNoLineales.Core | Biblioteca de clases | NodoABB, ArbolBinarioBusqueda, GrafoPonderado, Dijkstra |
| Tarea_4_2_ABB | Consola | Demostración de las operaciones ABB |
| Tarea_4_3_Rutas | Consola | Matriz, lista, traza y costo óptimo |
| Pruebas | Consola | Verificaciones automatizadas sin NuGet |

Al iniciar `Pruebas` aparecen líneas `OK` o `FAIL` y un total; el proceso retorna código diferente de cero si falla algún caso.

Los nodos ABB se crean con `new NodoABB` conforme se insertan elementos. Las listas `List<int>` se emplean sólo para devolver recorridos, NO para simular los enlaces del árbol. La lista de adyacencia del grafo usa `List<Arista>[]`, y la matriz puede generarse a demanda.

**Entorno necesario:** SDK .NET 8 y una terminal o Visual Studio compatible. Si Windows pide instalar .NET SDK, instalar desde la fuente oficial (https://dotnet.microsoft.com/download/dotnet/8.0).
