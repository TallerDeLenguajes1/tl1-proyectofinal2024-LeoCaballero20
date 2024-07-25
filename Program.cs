using PersonajeRecursos;

FabricaDePersonajes fabrica = new();
Personaje p = fabrica.crearPersonaje();
Console.WriteLine("Nombre: " + p.Datos.Nombre);
Console.WriteLine("Edad: " + p.Datos.Edad);
Console.WriteLine("Tipo: " + p.Datos.Tipo);
Console.WriteLine("Velocidad: " + p.Caract.Velocidad);
Console.WriteLine("Destreza: " + p.Caract.Destreza);
Console.WriteLine("Fuerza: " + p.Caract.Fuerza);
Console.WriteLine("Armadura: " + p.Caract.Armadura);

