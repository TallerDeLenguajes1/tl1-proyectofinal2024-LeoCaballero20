namespace PersonajeRecursos;

public class Personaje {
    private Datos datos;
    private Caracteristicas caract;

    public Personaje(Datos d, Caracteristicas c) {
        datos = d;
        caract = c;
    }

    public Datos Datos { get => datos; }
    public Caracteristicas Caract { get => caract; }
}

public class Caracteristicas {
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;
    public Caracteristicas(int vel, int des, int fuer, int arm) {
        velocidad = vel;
        destreza = des;
        fuerza = fuer;
        armadura = arm;
        nivel = 1;
        salud = 100;
    }

    public int Velocidad { get => velocidad; }
    public int Destreza { get => destreza; }
    public int Fuerza { get => fuerza; }
    public int Nivel { get => nivel; }
    public int Armadura { get => armadura; }
    public int Salud { get => salud; }
}

public class Datos {
    private Tipo tipo;
    private string nombre;
    private int edad;
    //private DateTime fechaNac;
    public Datos(Tipo t, string n, int ed) {
        tipo = t;
        nombre = n;
        edad = ed;
    }

    public Tipo Tipo { get => tipo; }
    public string Nombre { get => nombre; }
    public int Edad { get => edad; }
}

public enum Tipo {
    Detonante,
    Guardia,
    Combatiente,
    Espía,
    Estratega,
}

public class FabricaDePersonajes {
    public Personaje crearPersonaje() {
        Tipo tipo = elegirTipoAleatorio();
        Random random = new Random();
        int velocidad = 5;
        int destreza = 5;
        int fuerza = 5;
        int armadura = 5;
        switch (tipo) {
            case Tipo.Detonante: velocidad = random.Next(3,6);
                                 destreza = random.Next(3,6);
                                 fuerza = random.Next(6,8);
                                 armadura = random.Next(5,7);
            break;
            case Tipo.Guardia:  velocidad = random.Next(1,4);
                                destreza = random.Next(1,3);
                                fuerza = random.Next(8,10);
                                armadura = random.Next(9,11);
            break;
            case Tipo.Combatiente: velocidad = random.Next(3,6);
                                   destreza = random.Next(4,7);
                                   fuerza = random.Next(9,11);
                                   armadura = random.Next(7,10);
            break;
            case Tipo.Espía:    velocidad = random.Next(7,10);
                                destreza = random.Next(8,11);
                                fuerza = random.Next(2,5);
                                armadura = random.Next(1,4);
            break;
            case Tipo.Estratega: velocidad = random.Next(3,6);
                                 destreza = random.Next(7,11);
                                 fuerza = random.Next(3,7);
                                 armadura = random.Next(2,5);
            break;
        }
        string nombre = "Chespirito";
        int edad = random.Next(15,101);
        Datos d = new(tipo,nombre,edad);
        Caracteristicas c = new(velocidad,destreza,fuerza,armadura);
        Personaje p = new(d,c);
        return p;
    }
    public Tipo elegirTipoAleatorio() {
        Array tipos = Enum.GetValues(typeof(Tipo));
        Random random = new Random();
        Tipo tipoAleatorio = (Tipo)tipos.GetValue(random.Next(tipos.Length));
        return tipoAleatorio;
    }
    
}

public class Habilidad {
    private string nombre;
    private bool ulti;
    private int daño;
}