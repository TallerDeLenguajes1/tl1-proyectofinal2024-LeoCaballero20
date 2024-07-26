using BatallaRecursos;
using PersonajeRecursos;

FabricaDePersonajes fabrica = new();
Personaje heroe = fabrica.CrearPersonaje();
Personaje enemigo = fabrica.CrearPersonaje();
Console.WriteLine("Nombre: " + heroe.Datos.Nombre);
Console.WriteLine("Edad: " + heroe.Datos.Edad);
Console.WriteLine("Tipo: " + heroe.Datos.Tipo);
Console.WriteLine("Velocidad: " + heroe.Caract.Velocidad);
Console.WriteLine("Destreza: " + heroe.Caract.Destreza);
Console.WriteLine("Fuerza: " + heroe.Caract.Fuerza);
Console.WriteLine("Armadura: " + heroe.Caract.Armadura);
Console.WriteLine("\nNombre: " + enemigo.Datos.Nombre);
Console.WriteLine("Edad: " + enemigo.Datos.Edad);
Console.WriteLine("Tipo: " + enemigo.Datos.Tipo);
Console.WriteLine("Velocidad: " + enemigo.Caract.Velocidad);
Console.WriteLine("Destreza: " + enemigo.Caract.Destreza);
Console.WriteLine("Fuerza: " + enemigo.Caract.Fuerza);
Console.WriteLine("Armadura: " + enemigo.Caract.Armadura);
//Console.WriteLine("BATALLA");
//Batalla b = new(heroe,enemigo);
//b.Iniciar();

