using System.Diagnostics;
using BatallaRecursos;
using PersonajeRecursos;

public class Juego {
    private Personaje heroe;
    private List<Personaje> enemigos = new();
    private List<Batalla> batallas = new();
    public Juego(List<Usuario> usuarios) { 
        heroe = FabricaDePersonajes.CrearHeroe();
        string nombreArchivo = "json/personajes.txt";
        if (usuarios==null) {
            nombreArchivo = "json/personajes2.txt";
        } 
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
        Stopwatch stopwatch = new();
        stopwatch.Start();
        EjecutarBatallas();
        stopwatch.Stop();
        double minutosTranscurridos = stopwatch.Elapsed.TotalMinutes;
        Final(minutosTranscurridos);
    }
    public void Intro() {
        InterfazGrafica.LimpiarPantalla();
        AdministradorDeMusica.ReproducirMusica("audio/superhero-intro.mp3");
        Thread.Sleep(1000);
        InterfazGrafica.MostrarMensajeGradualmente("LA ORDEN DEL CAOS");
        Thread.Sleep(3000);
        InterfazGrafica.LimpiarPantalla();
        InterfazGrafica.MostrarMensajeGradualmente("En un mundo donde la paz y la libertad son tesoros preciados, una oscura alianza de villanos conocidos como 'La Orden del Caos' ");
        InterfazGrafica.MostrarMensajeGradualmente("conspira para crear un nuevo orden mundial bajo su tiranía.");
        InterfazGrafica.MostrarMensajeGradualmente("Este malvado grupo de supervillanos ha unido fuerzas para someter a la humanidad a su voluntad."); 
        InterfazGrafica.MostrarMensajeGradualmente("Sin embargo, un héroe se alza para enfrentarse a ellos y proteger el mundo libre...");
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
        InterfazGrafica.MostrarMensajeGradualmente($"Agente {heroe.Datos.Nombre}, su misión es derrotar a La Orden del Caos, aquí está la información de cada uno de sus miembros: \n");
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
        InterfazGrafica.MostrarMensajeGradualmente("Mucha suerte en su misión agente, el destino de nuestro pacífico mundo está en sus manos...");
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
    public void Final(double duracionBatallas) {
        if (heroe.EstaVivo()) {
            string nombreArchivo = "json/ganadores.txt";
            HistorialJson.GuardarGanador(heroe, duracionBatallas, nombreArchivo);
            InterfazGrafica.LimpiarPantalla();
            AdministradorDeMusica.ReproducirMusica("audio/victory-final.mp3");
            InterfazGrafica.MostrarMensajeGradualmente("\nCon la Orden del Caos desmantelada, el mundo comienza a sanar.");
            InterfazGrafica.MostrarMensajeGradualmente($"{heroe.Datos.Nombre}, ahora un héroe reconocido, se dedica a reconstruir lo que fue destruido y proteger la paz que tanto ha costado obtener.");
            InterfazGrafica.MostrarMensajeGradualmente("Pero en su corazón sabe que siempre debe estar preparado, porque mientras exista el mal, siempre habrá necesidad de un héroe...");
            InterfazGrafica.EsperarEntradaUsuario();
            InterfazGrafica.LimpiarPantalla();
            InterfazGrafica.MostrarMensajeGradualmente($"Felicitaciones! {heroe.Datos.Nombre} entra al registro histórico de ganadores.");
            Thread.Sleep(1000);
            InterfazGrafica.LimpiarPantalla();
            HistorialJson.MostrarGanadores(nombreArchivo);
            InterfazGrafica.LimpiarPantalla();
            InterfazGrafica.MostrarMensajeGradualmente("Hasta la próxima misión, agente!");
            Thread.Sleep(2000);
            AdministradorDeMusica.DetenerMusica();
        } else {
            InterfazGrafica.LimpiarPantalla();
            AdministradorDeMusica.ReproducirMusica("audio/game-over.mp3");
            InterfazGrafica.MostrarMensajeGradualmente("\nGAME OVER");
            Thread.Sleep(2000);
            AdministradorDeMusica.DetenerMusica();
        }
    }
}