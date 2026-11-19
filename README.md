# Unidad 4 — Estructuras no lineales

**Asignatura:** Estructuras de Datos  
**Alumno:** Aldo Alberto Barajas Ancira · **Control:** I24050397  
**Docente:** Rubén Riojas · **Institución:** Instituto Tecnológico Superior de Monclova  
**Fecha de elaboración:** 9 de noviembre de 2026

## Contenido para las tres tareas

- `Documentos/Tarea_4_1_Organizadores_Arboles_y_Grafos.pdf`: reporte formal y organizadores vectoriales de árboles y grafos.
- `Documentos/Tarea_4_2_Reporte_Arbol_Binario_Busqueda.pdf`: ABB dinámico, insertar, buscar, eliminar y tres recorridos; casos de prueba.
- `Documentos/Tarea_4_3_Reporte_Grafo_y_Dijkstra.pdf`: red ponderada de distribución ficticia, representaciones, traza de siete pasos y ruta óptima.
- `Diagramas/`: cuatro diagramas en `.drawio`, `.dot`, `.svg`, `.pdf` y `.png`. Son originales editables con diagrams.net / Graphviz.
- `Codigo/Unidad_4_Estructuras_No_Lineales.sln`: solución Visual Studio 2022 / .NET 8 con cuatro proyectos.
- `Codigo/EstructurasNoLineales.Core`: biblioteca de algoritmos.
- `Codigo/Tarea_4_2_ABB`: demostración en consola del ABB.
- `Codigo/Tarea_4_3_Rutas`: grafo y Dijkstra con impresión de matriz, lista y traza.
- `Codigo/Pruebas`: pruebas automáticas sin paquetes externos de terceros.
- `Fuentes/`: CSV del grafo y traza independiente.
- `Guias/`: guiones y plan para subir a GitHub y YouTube.
- `Evidencias/`: instrucciones y registro de validación algorítmica independiente (NO ejecución del proyecto C#).

## Ejecutar con Visual Studio

1. Instalar Visual Studio 2022 con la carga de trabajo **Desarrollo de escritorio de .NET** y SDK **.NET 8**.
2. Abrir `Codigo/Unidad_4_Estructuras_No_Lineales.sln` y compilar en modo Debug (Ctrl+Shift+B).
3. Clic derecho sobre `Tarea_4_2_ABB` → Establecer como proyecto de inicio → Ctrl+F5.
4. Repetir con `Tarea_4_3_Rutas`. En `Pruebas`, el programa devolverá código 0 cuando todas sus comprobaciones se aprueben.

Desde terminal, situada en la carpeta principal de Unidad 4:

```powershell
 dotnet --version
 dotnet build Codigo/Unidad_4_Estructuras_No_Lineales.sln
 dotnet run --project Codigo/Tarea_4_2_ABB
 dotnet run --project Codigo/Tarea_4_3_Rutas
 dotnet run --project Codigo/Pruebas
```

*Los comandos requieren el SDK .NET 8. Las carpetas `bin/` y `obj/` se crearán al compilar. La compilación Release deja los ejecutables en el directorio `bin/Release/net8.0` correspondiente (para el sistema operativo utilizado).*

## Interpretación correcta de la práctica

- ABB: usa referencias dinámicas; rechaza duplicados; la altura se mide en **aristas**, de modo que vacío=-1 y hoja=0.
- Recorridos: preorden = raíz-izquierda-derecha; inorden = izquierda-raíz-derecha; postorden = izquierda-derecha-raíz.
- Eliminación: se comprueban casos hoja, un hijo, dos hijos y raíz.
- Grafo: 7 vértices y 13 aristas **dirigidas**; pesos hipotéticos medidos en minutos.
- Dijkstra: ruta óptima Bodega → Centro → Norte → Este → Parque → Cliente, costo total 16 minutos. Se admiten pesos no negativos. Implementación con selección lineal: O(V² + E).

## Estado de las pruebas y evidencias

Se revisó la estructura de los archivos y se verificaron las secuencias del ABB y la trayectoria óptima del grafo contra cálculos independientes en Python. **No hay .NET SDK instalado en este entorno**; por ello no se afirma que el proyecto C# se haya compilado o ejecutado aquí. Los casos de prueba C# están listos para ejecutarse y debes capturar sus salidas reales en tu equipo antes de presentar las tareas como ejecutadas.

Las capturas de ejemplo no son evidencias reales de ejecución C#. En `Evidencias/GUIA_EVIDENCIAS.md` está el listado de pantallas necesarias.

## Publicación

El paquete está organizado para un repositorio público: sube el contenido de la carpeta principal sin incluir `bin/`, `obj/`, ni capturas con información personal no deseada. Registra en Teams el enlace público del repositorio y los tres enlaces de YouTube **del mismo canal**. Graba los videos con pantalla visible y cámara web situada en la esquina inferior derecha. No se han publicado repositorios ni videos automáticamente.

## Fuentes de estudio

- Cormen et al. (2022), *Introduction to Algorithms*, 4ª ed., MIT Press.
- Sedgewick y Wayne (2011), *Algorithms*, 4ª ed., Addison-Wesley.
- Goodrich, Tamassia y Goldwasser (2014), *Data Structures and Algorithms in Java*, 6ª ed., Wiley.
- OpenDSA: https://opendsa-server.cs.vt.edu/
