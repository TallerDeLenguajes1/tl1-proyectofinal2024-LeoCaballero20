using BatallaRecursos;
using PersonajeRecursos;

public class Juego {
    private Personaje heroe;
    private List<Personaje> enemigos = new();
    private List<Batalla> batallas = new();
    public Juego(List<Usuario> usuarios) { 
        heroe = FabricaDePersonajes.CrearHeroe();
        string nombreArchivo = "registros/personajes.txt";
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
        EjecutarBatallas();
        Final();
    }
    public void Intro() {
        InterfazGrafica.LimpiarPantalla();
        AdministradorDeMusica.ReproducirMusica("audio/superhero-intro.mp3");
        Thread.Sleep(1000);
        InterfazGrafica.MostrarMensajeGradualmente("En un mundo donde la paz y la libertad son tesoros preciados, una oscura alianza de villanos conocidos como 'La Orden del Caos' ");
        InterfazGrafica.MostrarMensajeGradualmente("conspira para crear un nuevo orden mundial bajo su tiranía.");
        InterfazGrafica.MostrarMensajeGradualmente("Diez villanos, cada uno con poderes y ambiciones únicas, han unido fuerzas para someter a la humanidad a su voluntad."); 
        InterfazGrafica.MostrarMensajeGradualmente("Sin embargo, un héroe se alza para enfrentarse a ellos y proteger el mundo libre.");
        InterfazGrafica.EsperarEntradaUsuario();
        string nombreIngresado = "";
        while (Int32.TryParse(nombreIngresado, out int nom) || nombreIngresado == "") {
            InterfazGrafica.LimpiarPantalla();
            InterfazGrafica.MostrarMensajeGradualmente("Ingrese el nombre de su héroe\n");
            nombreIngresado = Console.ReadLine();
        }
        heroe.Datos.Nombre = nombreIngresado;
        string edadHeroe = "";
        int edad;
        while (!Int32.TryParse(edadHeroe, out edad) || edad<=0) {
            InterfazGrafica.LimpiarPantalla();
            InterfazGrafica.MostrarMensajeGradualmente("Ingrese la edad de su héroe\n");
            edadHeroe = Console.ReadLine();
        }
        heroe.Datos.Edad = edad;
        InterfazGrafica.LimpiarPantalla();
        MostrarHeroe();
        InterfazGrafica.LimpiarPantalla();
        MostrarEnemigos();

    }
    public void MostrarEnemigos() {
        InterfazGrafica.MostrarMensajeGradualmente($"Agente {heroe.Datos.Nombre}, tenés que derrotar a La Orden del Caos, aquí está la información de cada uno: \n");
        Thread.Sleep(1000);
        InterfazGrafica.LimpiarPantalla();
        int i = 1;
        foreach(Personaje p in enemigos) {
            InterfazGrafica.MostrarMensajeGradualmente("Batalla " + i);
            InterfazGrafica.MostrarMensajeGradualmente($"Nombre: " + p.Datos.Nombre);
            InterfazGrafica.MostrarMensajeGradualmente($"Edad: " + p.Datos.Edad);
            InterfazGrafica.MostrarMensajeGradualmente($"Ubicación: " + p.Datos.Locacion);
            InterfazGrafica.MostrarMensajeGradualmente($"Tipo: " + p.Datos.Tipo);
            InterfazGrafica.MostrarMensajeGradualmente($"Habilidad: " + p.Caract.Habilidad + "\n");
            Thread.Sleep(1000);
            InterfazGrafica.LimpiarPantalla();
            i++;
        }
        InterfazGrafica.MostrarMensajeGradualmente("Mucho éxito agente, el destino de nuestro mundo está en tus manos...");
        Thread.Sleep(2000);
    }
    public void MostrarHeroe() {
        InterfazGrafica.MostrarMensajeGradualmente("\nHEROE");
        InterfazGrafica.MostrarMensajeGradualmente("Nombre: " + heroe.Datos.Nombre);
        InterfazGrafica.MostrarMensajeGradualmente("Edad: " + heroe.Datos.Edad);
        InterfazGrafica.MostrarMensajeGradualmente("Tipo: " + heroe.Datos.Tipo);
        InterfazGrafica.MostrarMensajeGradualmente("Habilidad: " + heroe.Caract.Habilidad);
        InterfazGrafica.EsperarEntradaUsuario();
    }
    public void EjecutarBatallas() {
        int i = 1;
        foreach (Batalla b in batallas) {
            if (heroe.EstaVivo()) {
                AdministradorDeMusica.ReproducirMusica("audio/battle.mp3");
                InterfazGrafica.LimpiarPantalla();
                InterfazGrafica.MostrarMensajeGradualmente("\nBATALLA " + i);
                Thread.Sleep(1000);
                b.enemigo.Caract.Nivel = i;
                b.enemigo.Caract.Salud = 50*i;
                b.heroe.Caract.Salud = 50*i;
                b.Iniciar();
                i++;
            }
        }
    }
    public void Final() {
        if (heroe.EstaVivo()) {
            string nombreArchivo = "registros/ganadores.txt";
            HistorialJson.GuardarGanador(heroe, nombreArchivo);
            InterfazGrafica.LimpiarPantalla();
            AdministradorDeMusica.ReproducirMusica("audio/victory-final.mp3");
            InterfazGrafica.MostrarMensajeGradualmente("\nCon la Orden del Caos desmantelada, el mundo comienza a sanar.");
            InterfazGrafica.MostrarMensajeGradualmente($"{heroe.Datos.Nombre}, ahora un héroe reconocido, se dedica a reconstruir lo que fue destruido y proteger la paz que tanto ha costado obtener.");
            InterfazGrafica.MostrarMensajeGradualmente("Pero en su corazón sabe que siempre debe estar preparado, porque mientras exista el mal, siempre habrá necesidad de un héroe...");
            InterfazGrafica.EsperarEntradaUsuario();
        } else {
            InterfazGrafica.LimpiarPantalla();
            AdministradorDeMusica.ReproducirMusica("audio/game-over.mp3");
            InterfazGrafica.MostrarMensajeGradualmente("\nGAME OVER");
            Thread.Sleep(2000);
            AdministradorDeMusica.DetenerMusica();
        }
    }
}