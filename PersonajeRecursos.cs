namespace PersonajeRecursos;
using BatallaRecursos;
using NAudio.CoreAudioApi;
using System.Text.Json;

public class Personaje {
    private Datos datos;
    private Caracteristicas caract;
    public Personaje() {}
    public Personaje(Datos d, Caracteristicas c) {
        datos = d;
        caract = c;
    }

    public Datos Datos { get => datos; set => datos = value;}
    public Caracteristicas Caract { get => caract; set => caract = value;}

    public void Atacar(Personaje enemigo) {
        InterfazGrafica.MostrarMensajeGradualmente(Datos.Nombre +  " ataca!\n");
        int danio = CalcularDanio(enemigo);
        if (Caract.Estado == Estado.Hipnotizado) {
            danio /= 2;
        }
        InterfazGrafica.MostrarMensajeGradualmente("Daño realizado: " + danio + "\n");
        enemigo.Caract.Salud -= danio;
    }
    public void LanzarHabilidad(Personaje enemigo) {
        switch (Caract.Habilidad) {
            case Habilidad.Paralisis: InterfazGrafica.MostrarMensajeGradualmente(Datos.Nombre +  " lanza su habilidad!\n");
                                      enemigo.Caract.Estado = Estado.Paralizado;
                                      InterfazGrafica.MostrarMensajeGradualmente(enemigo.Datos.Nombre + " fue paralizado!");
            break;
            case Habilidad.Envenenamiento: InterfazGrafica.MostrarMensajeGradualmente(Datos.Nombre +  " lanza su habilidad!\n");
                                           enemigo.Caract.Estado = Estado.Envenenado;
                                           InterfazGrafica.MostrarMensajeGradualmente(enemigo.Datos.Nombre + " fue envenenado!");
            break;
            case Habilidad.Hipnosis: InterfazGrafica.MostrarMensajeGradualmente(Datos.Nombre +  " lanza su habilidad!\n");
                                     enemigo.Caract.Estado = Estado.Hipnotizado;
                                     InterfazGrafica.MostrarMensajeGradualmente(enemigo.Datos.Nombre + " fue hipnotizado!");
            break;
        }
    }
    public int CalcularDanio(Personaje defensor) {
        Random random = new();
        int ataque = Caract.Destreza * Caract.Fuerza * Caract.Nivel;
        int defensa = defensor.Caract.Armadura * defensor.Caract.Velocidad;
        int efectividad = random.Next(20,101);
        int danio = ((ataque * efectividad) - defensa)/300;
        return danio;
    }
    public bool EstaVivo() {
        return Caract.Salud>0;
    }
    public string mostrarEstado() {
        string mensaje = "";
        switch (Caract.Estado) {
            case Estado.Normal: mensaje = "";
            break;
            case Estado.Paralizado: if (Datos.Genero == "Masculino") {
                                        mensaje = "PARALIZADO";
                                    } else {
                                        mensaje = "PARALIZADA";
                                    }
            break;
            case Estado.Envenenado: if (Datos.Genero == "Masculino") {
                                        mensaje = "ENVENENADO";
                                    } else {
                                        mensaje = "ENVENENADA";
                                    }
            break;
            case Estado.Hipnotizado: if (Datos.Genero == "Masculino") {
                                        mensaje = "HIPNOTIZADO";
                                    } else {
                                        mensaje = "HIPNOTIZADA";
                                    }
            break;
        }
        return mensaje;
    }
}

public class Caracteristicas {
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;
    private Habilidad habilidad;
    private Estado estado;
    public Caracteristicas() {}
    public Caracteristicas(int vel, int des, int fuer, int arm, Habilidad hab) {
        velocidad = vel;
        destreza = des;
        fuerza = fuer;
        armadura = arm;
        nivel = 0;
        salud = 50;
        Habilidad = hab;
        estado = Estado.Normal;
    }

    public int Velocidad { get => velocidad; set => velocidad = value;}
    public int Destreza { get => destreza; set => destreza = value;}
    public int Fuerza { get => fuerza; set => fuerza = value;}
    public int Nivel { get => nivel; set => nivel = value;}
    public int Armadura { get => armadura; set => armadura = value;}
    public int Salud { get => salud; set => salud = value; }
    public Habilidad Habilidad { get => habilidad; set => habilidad = value; }
    public Estado Estado { get => estado; set => estado = value; }
}

public class Datos {
    private Tipo tipo;
    private string nombre;
    private int edad;
    private string locacion;
    private string genero;
    //private DateTime fechaNac;
    public Datos() {}
    public Datos(Tipo t, string n, int ed, string loc, string gen) {
        tipo = t;
        nombre = n;
        edad = ed;
        Locacion = loc;
        genero = gen;
    }

    public Tipo Tipo { get => tipo; set => tipo = value;}
    public string Nombre { get => nombre; set => nombre = value;}
    public int Edad { get => edad; set => edad = value;}
    public string Locacion { get => locacion; set => locacion = value; }
    public string Genero { get => genero; set => genero = value; }
}

public static class FabricaDePersonajes {
    public static Personaje CrearPersonaje(Usuario usu) {
        Tipo tipo = ElegirTipoAleatorio();
        Random random = new Random();
        int velocidad = 5;
        int destreza = 5;
        int fuerza = 5;
        int armadura = 5;
        switch (tipo) {
            case Tipo.Detonante: velocidad = random.Next(3,6);
                                 destreza = random.Next(4,7);
                                 fuerza = random.Next(7,10);
                                 armadura = random.Next(5,7);
            break;
            case Tipo.Guardia:  velocidad = random.Next(1,4);
                                destreza = random.Next(2,5);
                                fuerza = random.Next(7,10);
                                armadura = random.Next(8,11);
            break;
            case Tipo.Combatiente: velocidad = random.Next(6,9);
                                   destreza = random.Next(4,7);
                                   fuerza = random.Next(8,11);
                                   armadura = random.Next(7,10);
            break;
            case Tipo.Espía:    velocidad = random.Next(8,11);
                                destreza = random.Next(7,10);
                                fuerza = random.Next(2,5);
                                armadura = random.Next(1,4);
            break;
            case Tipo.Estratega: velocidad = random.Next(4,7);
                                 destreza = random.Next(7,11);
                                 fuerza = random.Next(3,6);
                                 armadura = random.Next(2,5);
            break;
        }
        string nombre = usu.Name.Title + " " + usu.Name.First + " " + usu.Name.Last;
        int edad = usu.Nacimiento.Age;
        string loc = usu.Location.City + ", " + usu.Location.State + ", " + usu.Location.Country;
        string genero = usu.Gender;
        if (genero == "male") {
            genero = "Masculino";
        } else {
            genero = "Femenino";
        }
        Datos d = new(tipo,nombre,edad,loc, genero);
        Habilidad h = ElegirHabilidadAleatoria();
        Caracteristicas c = new(velocidad,destreza,fuerza,armadura,h);
        Personaje p = new(d,c);
        return p;
    }
    public static Tipo ElegirTipoAleatorio() {
        Array tipos = Enum.GetValues(typeof(Tipo));
        Random random = new();
        Tipo tipoAleatorio = (Tipo)tipos.GetValue(random.Next(tipos.Length));
        return tipoAleatorio;
    }
    public static Habilidad ElegirHabilidadAleatoria() {
        Array habilidades = Enum.GetValues(typeof(Habilidad));
        Random random = new();
        Habilidad habAleatoria = (Habilidad)habilidades.GetValue(random.Next(habilidades.Length));
        return habAleatoria;
    }
    public static Personaje CrearHeroe() {
        string nombreHeroe = "Leonardo";
        int edadHeroe = 24;
        Datos d = new(ElegirTipoAleatorio(),nombreHeroe,edadHeroe,"Tucuman, Argentina","Masculino");
        Caracteristicas c = new(5,5,5,5,ElegirHabilidadAleatoria());
        Personaje p = new(d,c);
        p.Caract.Nivel = 5;
        p.Caract.Salud = 100;
        return p;
    }
    
}
public enum Tipo {
    Detonante,
    Guardia,
    Combatiente,
    Espía,
    Estratega,
}

public enum Habilidad {
    Paralisis,
    Envenenamiento,
    Hipnosis,
}
public enum Estado {
    Normal,
    Paralizado,
    Envenenado,
    Hipnotizado,
}