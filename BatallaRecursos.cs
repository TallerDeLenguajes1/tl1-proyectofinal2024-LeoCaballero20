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
        PresentarBatalla();
        while (heroe.Caract.Salud>0 && enemigo.Caract.Salud>0) {
            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
            TurnoHeroe(enemigo);
            Thread.Sleep(1000);
            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
            InterfazGrafica.LimpiarPantalla();
            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
            if (enemigo.EstaVivo()) {
                TurnoEnemigo();
                Thread.Sleep(1000);
                InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                InterfazGrafica.LimpiarPantalla();
                InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
            }
        }
        if (heroe.Caract.Salud>0) {
            InterfazGrafica.LimpiarPantalla();
            InterfazGrafica.MostrarMensajeGradualmente("\nHAS DERROTADO A " + enemigo.Datos.Nombre);
            heroe.Caract.Salud = 100;
            InterfazGrafica.EsperarEntradaUsuario();
        } else {
            Console.WriteLine("\nTE HAN DERROTADO");
        }
    }
    public void TurnoHeroe(Personaje enemigo) {
        Random random = new();
        int sigueEfecto;
        switch (heroe.Caract.Estado) {
            case Estado.Normal: if (enemigo.Caract.Estado == Estado.Normal) {
                                    InterfazGrafica.LimpiarPantalla();
                                    InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                    InterfazGrafica.MostrarEventoBatalla("\n1.Atacar 2.Lanzar habilidad\n");
                                    string opcion = Console.ReadLine();
                                    InterfazGrafica.LimpiarPantalla();
                                    InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                    Int32.TryParse(opcion, out int op);
                                    if (op == 1) {
                                        heroe.Atacar(enemigo);
                                    } else {
                                        heroe.LanzarHabilidad(enemigo);
                                    }
                                } else {
                                    InterfazGrafica.LimpiarPantalla();
                                    InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                    InterfazGrafica.MostrarEventoBatalla("El enemigo sigue afectado por tu habilidad");
                                    InterfazGrafica.MostrarEventoBatalla("\n1.Atacar\n");
                                    string opcion = Console.ReadLine();
                                    InterfazGrafica.LimpiarPantalla();
                                    InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                    heroe.Atacar(enemigo);
                                }
            break;
            case Estado.Paralizado: InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " está paralizado, no se puede mover!\n");
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        heroe.Caract.Estado = Estado.Normal;
                                        InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " volvió a la normalidad\n");
                                    }                                                                   
            break;
            case Estado.Envenenado: InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " está envenenado, pierde 3 puntos de salud!\n");
                                    heroe.Caract.Salud -= 3;
                                    InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        heroe.Caract.Estado = Estado.Normal;
                                        InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " volvió a la normalidad\n");
                                    } 
                                    if (enemigo.Caract.Estado == Estado.Normal) {
                                        InterfazGrafica.LimpiarPantalla();
                                        InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        InterfazGrafica.MostrarEventoBatalla("\n1.Atacar 2.Lanzar habilidad\n");
                                        string opcion = Console.ReadLine();
                                        InterfazGrafica.LimpiarPantalla();
                                        InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        Int32.TryParse(opcion, out int op);
                                        if (op == 1) {
                                            heroe.Atacar(enemigo);
                                        } else {
                                            heroe.LanzarHabilidad(enemigo);
                                        }
                                    } else {
                                        InterfazGrafica.LimpiarPantalla();
                                        InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        InterfazGrafica.MostrarEventoBatalla("El enemigo sigue afectado por tu habilidad");
                                        InterfazGrafica.MostrarEventoBatalla("\n1.Atacar\n");
                                        string opcion = Console.ReadLine();
                                        InterfazGrafica.LimpiarPantalla();
                                        InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        heroe.Atacar(enemigo);
                                    }
            break;
            case Estado.Hipnotizado: InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " está hipnotizado, se ataca a sí mismo!\n");
                                     heroe.Atacar(heroe);
                                     sigueEfecto = random.Next(2);
                                     if (sigueEfecto==0) {
                                        heroe.Caract.Estado = Estado.Normal;
                                        InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " volvió a la normalidad\n");
                                     } 
            break;
        }
        
    }
    public void TurnoEnemigo() {
        Random random = new();
        int accion = random.Next(2);
        int sigueEfecto;
        switch (enemigo.Caract.Estado) {
            case Estado.Normal: if (heroe.Caract.Estado == Estado.Normal) {
                                    if (accion == 0) {
                                        enemigo.Atacar(heroe);
                                    } else {
                                        enemigo.LanzarHabilidad(heroe);
                                    }
                                } else {
                                    enemigo.Atacar(heroe);
                                }
            break;
            case Estado.Paralizado: InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " está paralizado, no se puede mover!");
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " volvió a la normalidad\n");
                                    } 
            break;
            case Estado.Envenenado: InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " está envenenado, pierde 3 puntos de salud!\n");
                                    enemigo.Caract.Salud -= 3;
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " volvió a la normalidad\n");
                                    } 
                                    if (heroe.Caract.Estado == Estado.Normal) {
                                        if (accion == 0) {
                                            enemigo.Atacar(heroe);
                                        } else {
                                            enemigo.LanzarHabilidad(heroe);
                                        }
                                    } else {
                                        enemigo.Atacar(heroe);
                                    }
            break;
            case Estado.Hipnotizado: InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " está hipnotizado, se ataca a sí mismo!\n");
                                     enemigo.Atacar(enemigo);
                                     sigueEfecto = random.Next(2);
                                     if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " volvió a la normalidad\n");
                                     } 
            break;
        }
    }
    public void PresentarBatalla() {
        InterfazGrafica.LimpiarPantalla();
        InterfazGrafica.MostrarMensajeGradualmente("ENEMIGO");
        InterfazGrafica.MostrarMensajeGradualmente("\nNombre: " + enemigo.Datos.Nombre);
        InterfazGrafica.MostrarMensajeGradualmente("Edad: " + enemigo.Datos.Edad);
        InterfazGrafica.MostrarMensajeGradualmente("Tipo: " + enemigo.Datos.Tipo);
        InterfazGrafica.MostrarMensajeGradualmente("Habilidad: " + enemigo.Caract.Habilidad);
        InterfazGrafica.EsperarEntradaUsuario();
        InterfazGrafica.LimpiarPantalla();
    }

}