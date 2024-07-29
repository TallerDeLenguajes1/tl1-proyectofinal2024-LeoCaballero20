using BatallaRecursos;
using PersonajeRecursos;

public class Juego {
    Personaje heroe;
    List<Personaje> enemigos = new();
    List<Batalla> batallas = new();
    public Juego() {
        heroe = FabricaDePersonajes.CrearPersonaje();
        string nombreArchivo = "personajes.txt";
        if (!PersonajesJson.Existe(nombreArchivo)) {
            for (int i=0; i<5; i++) {
                Personaje enemigo = FabricaDePersonajes.CrearPersonaje();
                enemigos.Add(enemigo);
                PersonajesJson.GuardarPersonajes(enemigos, nombreArchivo);
            } 
        } else {
            enemigos = PersonajesJson.LeerPersonajes(nombreArchivo);
        }
        foreach (Personaje e in enemigos) {
            Batalla batalla = new(heroe,e);
            batallas.Add(batalla);
        }
    }
    public void Iniciar() {
        int i = 1;
        foreach (Batalla b in batallas) {
            if (heroe.EstaVivo()) {
                /*Console.WriteLine("BATALLA " + i);
                Console.WriteLine("Nombre: " + heroe.Datos.Nombre);
                Console.WriteLine("Edad: " + heroe.Datos.Edad);
                Console.WriteLine("Tipo: " + heroe.Datos.Tipo);
                Console.WriteLine("Velocidad: " + heroe.Caract.Velocidad);
                Console.WriteLine("Destreza: " + heroe.Caract.Destreza);
                Console.WriteLine("Fuerza: " + heroe.Caract.Fuerza);
                Console.WriteLine("Armadura: " + heroe.Caract.Armadura);
                Console.WriteLine("\nNombre: " + b.enemigo.Datos.Nombre);
                Console.WriteLine("Edad: " + b.enemigo.Datos.Edad);
                Console.WriteLine("Tipo: " + b.enemigo.Datos.Tipo);
                Console.WriteLine("Velocidad: " + b.enemigo.Caract.Velocidad);
                Console.WriteLine("Destreza: " + b.enemigo.Caract.Destreza);
                Console.WriteLine("Fuerza: " + b.enemigo.Caract.Fuerza);
                Console.WriteLine("Armadura: " + b.enemigo.Caract.Armadura);*/
                b.Iniciar();
                i++;
            }
        }
        if (heroe.EstaVivo()) {
            Console.WriteLine("GANASTE EL JUEGO");
        } else {
            Console.WriteLine("PERDISTE EL JUEGO");
        }
    }
}