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
        Intro();
        int i = 1;
        foreach (Batalla b in batallas) {
            if (heroe.EstaVivo()) {
                AdministradorDeMusica.ReproducirMusica("audio/battle.mp3");
                InterfazGrafica.LimpiarPantalla();
                InterfazGrafica.MostrarMensajeGradualmente("\nBATALLA " + i);
                Thread.Sleep(1000);
                b.enemigo.Caract.Nivel = i;
                b.Iniciar();
                i++;
            }
        }
        if (heroe.EstaVivo()) {
            InterfazGrafica.LimpiarPantalla();
            AdministradorDeMusica.ReproducirMusica("audio/victory-final.mp3");
            InterfazGrafica.MostrarMensajeGradualmente("\nFELICITACIONES, SALVASTE EL PLANETA!");
        } else {
            InterfazGrafica.LimpiarPantalla();
            AdministradorDeMusica.ReproducirMusica("audio/game-over.mp3");
            InterfazGrafica.MostrarMensajeGradualmente("\nGAME OVER");
            Thread.Sleep(2000);
            AdministradorDeMusica.DetenerMusica();
        }
    }
    public void Intro() {
        AdministradorDeMusica.ReproducirMusica("audio/superhero-intro.mp3");
        InterfazGrafica.MostrarMensajeGradualmente("Está por comenzar la aventura...");
        InterfazGrafica.MostrarMensajeGradualmente("Ingrese el nombre de su héroe");
        heroe.Datos.Nombre = Console.ReadLine();
        InterfazGrafica.MostrarMensajeGradualmente("Ingrese la edad de su héroe");
        string edadIngresada = Console.ReadLine();
        Int32.TryParse(edadIngresada, out int edad);
        heroe.Datos.Edad = edad;
        InterfazGrafica.LimpiarPantalla();
        //InterfazGrafica.MostrarMensajeGradualmente($"En el reino de Eldoria, un lugar de paisajes majestuosos y antiguas leyendas, vivía un valiente guerrero llamado {heroe.Datos.Nombre}. {heroe.Datos.Nombre} era conocido por su destreza en el combate y su inquebrantable sentido de la justicia. Portador de la legendaria Espada de la Luz, una arma forjada por los antiguos dioses, {heroe.Datos.Nombre} había jurado proteger a los inocentes y mantener la paz en el reino.");
        InterfazGrafica.LimpiarPantalla();
        InterfazGrafica.MostrarMensajeGradualmente("\nHEROE");
        InterfazGrafica.MostrarMensajeGradualmente("Nombre: " + heroe.Datos.Nombre);
        InterfazGrafica.MostrarMensajeGradualmente("Edad: " + heroe.Datos.Edad);
        InterfazGrafica.MostrarMensajeGradualmente("Tipo: " + heroe.Datos.Tipo);
        InterfazGrafica.MostrarMensajeGradualmente("Habilidad: " + heroe.Caract.Habilidad);
        InterfazGrafica.EsperarEntradaUsuario();
        InterfazGrafica.LimpiarPantalla();
    }
}