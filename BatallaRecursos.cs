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
            Console.WriteLine("\nTURNO " + i);
            TurnoHeroe(enemigo);
            if (enemigo.EstaVivo()) {
                TurnoEnemigo();
            }
            if (heroe.EstaVivo() && enemigo.EstaVivo()) {
                Console.WriteLine("\nESTADO DEL HEROE");
                Console.WriteLine("Salud: " + heroe.Caract.Salud);
                Console.WriteLine("\nESTADO DEL ENEMIGO");
                Console.WriteLine("Salud: " + enemigo.Caract.Salud);
                i++;
            }
        }
        if (heroe.Caract.Salud>0) {
            Console.WriteLine("\nGANASTE LA BATALLA");
            heroe.Caract.Salud = 100;
        } else {
            Console.WriteLine("\nPERDISTE LA BATALLA");
        }
    }
    public void TurnoHeroe(Personaje enemigo) {
        Random random = new();
        int sigueEfecto;
        switch (heroe.Caract.Estado) {
            case Estado.Normal: if (enemigo.Caract.Estado == Estado.Normal) {
                                    Console.WriteLine("\n1.Atacar 2.Lanzar habilidad\n");
                                    string opcion = Console.ReadLine();
                                    Int32.TryParse(opcion, out int op);
                                    if (op == 1) {
                                    heroe.Atacar(enemigo);
                                    } else {
                                    heroe.LanzarHabilidad(enemigo);
                                    }
                                } else {
                                    Console.WriteLine("El enemigo sigue afectado por tu habilidad");
                                    Console.WriteLine("\n1.Atacar\n");
                                    string opcion = Console.ReadLine();
                                    heroe.Atacar(enemigo);
                                }
            break;
            case Estado.Paralizado: Console.WriteLine(heroe.Datos.Nombre + " está paralizado, no se puede mover!\n");
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        heroe.Caract.Estado = Estado.Normal;
                                        Console.WriteLine(heroe.Datos.Nombre + " volvió a la normalidad\n");
                                    }                                                                   
            break;
            case Estado.Envenenado: Console.WriteLine(heroe.Datos.Nombre + " está envenenado, pierde 3 puntos de salud!\n");
                                    heroe.Caract.Salud -= 3;
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        heroe.Caract.Estado = Estado.Normal;
                                        Console.WriteLine(heroe.Datos.Nombre + " volvió a la normalidad\n");
                                    } 
                                    if (enemigo.Caract.Estado == Estado.Normal) {
                                    Console.WriteLine("\n1.Atacar 2.Lanzar habilidad\n");
                                    string opcion = Console.ReadLine();
                                    Int32.TryParse(opcion, out int op);
                                    if (op == 1) {
                                        heroe.Atacar(enemigo);
                                    } else {
                                        heroe.LanzarHabilidad(enemigo);
                                    }
                                    } else {
                                        Console.WriteLine("El enemigo sigue afectado por tu habilidad");
                                        Console.WriteLine("\n1.Atacar\n");
                                        string opcion = Console.ReadLine();
                                        heroe.Atacar(enemigo);
                                    }
            break;
            case Estado.Hipnotizado: Console.WriteLine(heroe.Datos.Nombre + " está hipnotizado, se ataca a sí mismo!\n");
                                     heroe.Atacar(heroe);
                                     sigueEfecto = random.Next(2);
                                     if (sigueEfecto==0) {
                                        heroe.Caract.Estado = Estado.Normal;
                                        Console.WriteLine(heroe.Datos.Nombre + " volvió a la normalidad\n");
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
            case Estado.Paralizado: Console.WriteLine(enemigo.Datos.Nombre + " está paralizado, no se puede mover!");
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        Console.WriteLine(enemigo.Datos.Nombre + " volvió a la normalidad\n");
                                    } 
            break;
            case Estado.Envenenado: Console.WriteLine(enemigo.Datos.Nombre + " está envenenado, pierde 3 puntos de salud!\n");
                                    enemigo.Caract.Salud -= 3;
                                    sigueEfecto = random.Next(2);
                                    if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        Console.WriteLine(enemigo.Datos.Nombre + " volvió a la normalidad\n");
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
            case Estado.Hipnotizado: Console.WriteLine(enemigo.Datos.Nombre + " está hipnotizado, se ataca a sí mismo!\n");
                                     enemigo.Atacar(enemigo);
                                     sigueEfecto = random.Next(2);
                                     if (sigueEfecto==0) {
                                        enemigo.Caract.Estado = Estado.Normal;
                                        Console.WriteLine(enemigo.Datos.Nombre + " volvió a la normalidad\n");
                                     } 
            break;
        }
    }

}