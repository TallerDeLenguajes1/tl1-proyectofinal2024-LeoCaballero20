using BatallaRecursos;
using PersonajeRecursos;

public class Juego {
    private Personaje heroe;
    private List<Personaje> enemigos = new();
    private List<Batalla> batallas = new();
    public Juego(List<Usuario> usuarios) { 
        heroe = FabricaDePersonajes.CrearHeroe();
        string nombreArchivo = "personajes.txt";
        if (!PersonajesJson.Existe(nombreArchivo)) {
            foreach (Usuario usu in usuarios) {
                Personaje enemigo = FabricaDePersonajes.CrearPersonaje(usu);
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
        Console.WriteLine("\nHEROE");
        Console.WriteLine("Nombre: " + heroe.Datos.Nombre);
        Console.WriteLine("Edad: " + heroe.Datos.Edad);
        Console.WriteLine("Tipo: " + heroe.Datos.Tipo);
        Console.WriteLine("Velocidad: " + heroe.Caract.Velocidad);
        Console.WriteLine("Destreza: " + heroe.Caract.Destreza);
        Console.WriteLine("Fuerza: " + heroe.Caract.Fuerza);
        Console.WriteLine("Armadura: " + heroe.Caract.Armadura);
        Console.WriteLine("Habilidad: " + heroe.Caract.Habilidad);
        int i = 1;
        foreach (Batalla b in batallas) {
            if (heroe.EstaVivo()) {
                Console.WriteLine("\nBATALLA " + i);
                Console.WriteLine("ENEMIGO");
                Console.WriteLine("\nNombre: " + b.enemigo.Datos.Nombre);
                Console.WriteLine("Edad: " + b.enemigo.Datos.Edad);
                Console.WriteLine("Tipo: " + b.enemigo.Datos.Tipo);
                Console.WriteLine("Velocidad: " + b.enemigo.Caract.Velocidad);
                Console.WriteLine("Destreza: " + b.enemigo.Caract.Destreza);
                Console.WriteLine("Fuerza: " + b.enemigo.Caract.Fuerza);
                Console.WriteLine("Armadura: " + b.enemigo.Caract.Armadura);
                Console.WriteLine("Habilidad: " + b.enemigo.Caract.Habilidad);
                b.Iniciar();
                i++;
            }
        }
        if (heroe.EstaVivo()) {
            Console.WriteLine("\nGANASTE EL JUEGO");
        } else {
            Console.WriteLine("\nPERDISTE EL JUEGO");
        }
    }
}