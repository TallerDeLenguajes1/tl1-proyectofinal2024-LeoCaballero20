using PersonajeRecursos;

namespace BatallaRecursos;

public class Batalla {
    public Personaje heroe;
    public Personaje enemigo;

    public Batalla(Personaje h, Personaje e) {
        heroe = h;
        enemigo = e;
    }

    public void Iniciar() {
        int i = 1;
        while (heroe.Caract.Salud>0 && enemigo.Caract.Salud>0) {
            Console.WriteLine("TURNO " + i);
            Console.WriteLine("ESTADO DEL HEROE");
            Console.WriteLine("Salud: " + heroe.Caract.Salud);
            Console.WriteLine("ESTADO DEL ENEMIGO");
            Console.WriteLine("Salud: " + enemigo.Caract.Salud);
            Turno(heroe,enemigo);
            Turno(enemigo,heroe);
            i++;
        }
        if (heroe.Caract.Salud>0) {
            Console.WriteLine("GANASTE LA BATALLA");
            heroe.Caract.Salud = 100;
        } else {
            Console.WriteLine("PERDISTE LA BATALLA");
        }
    }
    public void Turno(Personaje atacante, Personaje defensor) {
        atacante.Atacar(defensor);
    }

}