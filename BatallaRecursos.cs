using System.Collections;
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
        EjecutarBatalla();
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
                                    if (op == 2) {
                                                heroe.LanzarHabilidad(enemigo);
                                            } else {
                                                heroe.Atacar(enemigo);
                                            }
                                } else {
                                    InterfazGrafica.LimpiarPantalla();
                                    InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                    InterfazGrafica.MostrarEventoBatalla($"{enemigo.Datos.Nombre} sigue {enemigo.mostrarEstado()}");
                                    InterfazGrafica.MostrarEventoBatalla("\n1.Atacar\n");
                                    string opcion = Console.ReadLine();
                                    InterfazGrafica.LimpiarPantalla();
                                    InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                    heroe.Atacar(enemigo);
                                }
            break;
            case Estado.Paralizado: sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        heroe.Caract.Estado = Estado.Normal;
                                        if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                                            InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " volvió a la normalidad\n");
                                            Thread.Sleep(1000);
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        }
                                    }
                                    if (heroe.Caract.Estado==Estado.Paralizado) {
                                        InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + $" está {heroe.mostrarEstado()}, no se puede mover!\n");
                                        Thread.Sleep(1000);
                                    } else {
                                       if (enemigo.Caract.Estado == Estado.Normal) {
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            InterfazGrafica.MostrarEventoBatalla("\n1.Atacar 2.Lanzar habilidad\n");
                                            string opcion = Console.ReadLine();
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            Int32.TryParse(opcion, out int op);
                                            if (op == 2) {
                                                heroe.LanzarHabilidad(enemigo);
                                            } else {
                                                heroe.Atacar(enemigo);
                                            }
                                        } else {
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            InterfazGrafica.MostrarEventoBatalla($"{enemigo.Datos.Nombre} sigue {enemigo.mostrarEstado()}");
                                            InterfazGrafica.MostrarEventoBatalla("\n1.Atacar\n");
                                            string opcion = Console.ReadLine();
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            heroe.Atacar(enemigo);
                                        }
                                    }                                                                      
            break;
            case Estado.Envenenado: InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + $" está {heroe.mostrarEstado()}, pierde {enemigo.Caract.Nivel*2} puntos de salud!\n");
                                    Thread.Sleep(1000);
                                    heroe.Caract.Salud -= enemigo.Caract.Nivel*2;
                                    InterfazGrafica.LimpiarPantalla();
                                    InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                    if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                                        if (enemigo.Caract.Estado == Estado.Normal) {
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            InterfazGrafica.MostrarEventoBatalla("\n1.Atacar 2.Lanzar habilidad\n");
                                            string opcion = Console.ReadLine();
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            Int32.TryParse(opcion, out int op);
                                            if (op == 2) {
                                                heroe.LanzarHabilidad(enemigo);
                                            } else {
                                                heroe.Atacar(enemigo);
                                            }
                                        } else {
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            InterfazGrafica.MostrarEventoBatalla($"El enemigo sigue {enemigo.mostrarEstado()}\n");
                                            InterfazGrafica.MostrarEventoBatalla("\n1.Atacar\n");
                                            string opcion = Console.ReadLine();
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            heroe.Atacar(enemigo);
                                        }
                                        sigueEfecto = random.Next(2);
                                        if (sigueEfecto==0) {
                                            heroe.Caract.Estado = Estado.Normal;
                                            if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                                                InterfazGrafica.LimpiarPantalla();
                                                InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                                InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " volvió a la normalidad\n");
                                                Thread.Sleep(1000);
                                                InterfazGrafica.LimpiarPantalla();
                                                InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            }
                                        } 
                                    }
            break;
            case Estado.Hipnotizado: sigueEfecto = random.Next(2);
                                     if (sigueEfecto==0) {
                                        heroe.Caract.Estado = Estado.Normal;
                                        if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                                            InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + " volvió a la normalidad\n");
                                            Thread.Sleep(1000);
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        }
                                     } 
                                     if (heroe.Caract.Estado == Estado.Hipnotizado) {
                                        InterfazGrafica.MostrarEventoBatalla(heroe.Datos.Nombre + $" está {heroe.mostrarEstado()}, se ataca a sí mismo!\n");
                                        heroe.Atacar(heroe);
                                        Thread.Sleep(1000);
                                     } else {
                                        if (enemigo.Caract.Estado == Estado.Normal) {
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            InterfazGrafica.MostrarEventoBatalla("\n1.Atacar 2.Lanzar habilidad\n");
                                            string opcion = Console.ReadLine();
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            Int32.TryParse(opcion, out int op);
                                            if (op == 2) {
                                                heroe.LanzarHabilidad(enemigo);
                                            } else {
                                                heroe.Atacar(enemigo);
                                            }
                                        } else {
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            InterfazGrafica.MostrarEventoBatalla($"{enemigo.Datos.Nombre} sigue {enemigo.mostrarEstado()}");
                                            InterfazGrafica.MostrarEventoBatalla("\n1.Atacar\n");
                                            string opcion = Console.ReadLine();
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                            heroe.Atacar(enemigo);
                                        }
                                     }
                                     
                                     
            break;
        }
        
    }
    public void TurnoEnemigo() {
        Random random = new();
        int accion = random.Next(3);
        int sigueEfecto;
        switch (enemigo.Caract.Estado) {
            case Estado.Normal: if (heroe.Caract.Estado == Estado.Normal) {
                                    if (accion == 0) {
                                        enemigo.LanzarHabilidad(heroe);      
                                    } else {
                                        enemigo.Atacar(heroe);
                                    }
                                } else {
                                    enemigo.Atacar(heroe);
                                }
            break;
            case Estado.Paralizado: sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                                            InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " volvió a la normalidad\n");
                                            Thread.Sleep(1000);
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        }
                                    }
                                    if (enemigo.Caract.Estado == Estado.Paralizado) {
                                        InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + $" está {enemigo.mostrarEstado()}, no se puede mover!");
                                        Thread.Sleep(1000);  
                                    } else {
                                        if (heroe.Caract.Estado == Estado.Normal) {
                                            if (accion == 0) {
                                                enemigo.LanzarHabilidad(heroe);      
                                            } else {
                                                enemigo.Atacar(heroe);
                                            }
                                            } else {
                                                enemigo.Atacar(heroe);
                                        }
                                    }
            break;
            case Estado.Envenenado: InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + $" está {enemigo.mostrarEstado()}, pierde {heroe.Caract.Nivel*2} puntos de salud!\n");
                                    enemigo.Caract.Salud -= heroe.Caract.Nivel*2;
                                    Thread.Sleep(1000);
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                                            InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " volvió a la normalidad\n");
                                            Thread.Sleep(1000);
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        }
                                    }
                                    if (enemigo.EstaVivo()) {
                                        if (heroe.Caract.Estado == Estado.Normal) {
                                            if (accion == 0) {
                                                enemigo.LanzarHabilidad(heroe);      
                                            } else {
                                                enemigo.Atacar(heroe);
                                            }
                                        } else {
                                            enemigo.Atacar(heroe);
                                        }
                                    } 
            break;
            case Estado.Hipnotizado: sigueEfecto = random.Next(2);
                                     if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                                            InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + " volvió a la normalidad\n");
                                            Thread.Sleep(1000);
                                            InterfazGrafica.LimpiarPantalla();
                                            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                                        }
                                     } 
                                     if (enemigo.Caract.Estado == Estado.Hipnotizado) {
                                        InterfazGrafica.MostrarEventoBatalla(enemigo.Datos.Nombre + $" {enemigo.mostrarEstado()}, se ataca a sí mismo!\n");
                                        enemigo.Atacar(enemigo);
                                        Thread.Sleep(1000);
                                     } else {
                                        if (heroe.Caract.Estado == Estado.Normal) {
                                            if (accion == 0) {
                                                enemigo.LanzarHabilidad(heroe);      
                                            } else {
                                                enemigo.Atacar(heroe);
                                            }
                                            } else {
                                                enemigo.Atacar(heroe);
                                        }
                                     }
            break;
        }
    }
    public void PresentarBatalla() {
        InterfazGrafica.LimpiarPantalla();
        InterfazGrafica.MostrarMensajeGradualmente("ENEMIGO");
        InterfazGrafica.MostrarMensajeGradualmente("\nNombre: " + enemigo.Datos.Nombre);
        InterfazGrafica.MostrarMensajeGradualmente("Edad: " + enemigo.Datos.Edad);
        InterfazGrafica.MostrarMensajeGradualmente("Género: " + enemigo.Datos.Genero);
        InterfazGrafica.MostrarMensajeGradualmente("Ubicación: " + enemigo.Datos.Locacion);
        InterfazGrafica.MostrarMensajeGradualmente("Tipo: " + enemigo.Datos.Tipo);
        InterfazGrafica.MostrarMensajeGradualmente("Habilidad: " + enemigo.Caract.Habilidad);
        InterfazGrafica.EsperarEntradaUsuario();
        InterfazGrafica.LimpiarPantalla();
    }
    public void EjecutarBatalla() {
        int saludHeroe = heroe.Caract.Salud;
        while (heroe.EstaVivo() && enemigo.EstaVivo()) {
            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
            TurnoHeroe(enemigo);
            Thread.Sleep(1000);
            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
            InterfazGrafica.LimpiarPantalla();
            InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
            if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                TurnoEnemigo();
                Thread.Sleep(1000);
                InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
                InterfazGrafica.LimpiarPantalla();
                InterfazGrafica.MostrarEstadoPersonajes(heroe,enemigo);
            }
        }
        if (heroe.EstaVivo()) {
            InterfazGrafica.LimpiarPantalla();
            InterfazGrafica.MostrarMensajeGradualmente("VICTORIA");
            AdministradorDeMusica.ReproducirMusica("audio/victory-sound.mp3");
            Thread.Sleep(1500);
            AdministradorDeMusica.ReproducirMusica("audio/victory.mp3");
            Thread.Sleep(1500);
            InterfazGrafica.MostrarMensajeGradualmente("\nHAS DERROTADO A " + enemigo.Datos.Nombre);
            if (heroe.Caract.Nivel<12) {
                InterfazGrafica.MostrarMensajeGradualmente("\nSUBES DE NIVEL!");
                heroe.Caract.Nivel++;
                if (heroe.Caract.Nivel==12) {
                    InterfazGrafica.MostrarMensajeGradualmente("\nNIVEL MÁXIMO ALCANZADO");
                }
            }
            heroe.Caract.Salud = saludHeroe;
            heroe.Caract.Estado = Estado.Normal;
            InterfazGrafica.EsperarEntradaUsuario();
        } else {
            InterfazGrafica.LimpiarPantalla();
            AdministradorDeMusica.ReproducirMusica("audio/lost.mp3");
            InterfazGrafica.MostrarMensajeGradualmente("\nTE HAN DERROTADO");
            Thread.Sleep(2000);
        }
    }

}