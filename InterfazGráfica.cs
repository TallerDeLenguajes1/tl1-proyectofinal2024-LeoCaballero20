using PersonajeRecursos;

public static class InterfazGrafica
{
    public static void MostrarEstadoPersonajes(Personaje heroe, Personaje enemigo)
    {
        Console.SetCursorPosition(50, 0); // Posiciona el cursor en la columna 50
        Console.WriteLine("==== Estado de los Personajes ====");
        Console.SetCursorPosition(50, 1);
        Console.WriteLine($"{heroe.Datos.Nombre} | Salud: {heroe.Caract.Salud} {heroe.mostrarEstado().ToUpper()}");
        Console.SetCursorPosition(50, 2);
        Console.WriteLine($"{enemigo.Datos.Nombre} | Salud: {enemigo.Caract.Salud} {enemigo.mostrarEstado().ToUpper()}");
        Console.SetCursorPosition(50, 3);
        Console.WriteLine("==================================");
    }

    public static void MostrarEventoBatalla(string evento)
    {
        Console.SetCursorPosition(0, Console.CursorTop); 
        MostrarMensajeGradualmente(evento);
    }

    public static void LimpiarPantalla()
    {
        Console.Clear();
    }
    public static void EsperarEntradaUsuario()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
    public static void MostrarMensajeGradualmente(string mensaje, int delay = 20)
    {
        foreach (char c in mensaje)
        {
            Console.Write(c);
            Thread.Sleep(delay); 
        }
        Console.WriteLine();
    }
}