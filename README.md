# **JUEGO DE ROL EN C# : "LA ORDEN DEL CAOS"**

## **IDEA GENERAL**

Es un juego de combate por turnos simple, en el que va aumentando la dificultad de las batallas a medida que éste avanza.
En cada turno, cada personaje puede elegir entre Atacar o Lanzar habilidad, (habilidad que se otorga al azar.)
Traté de hacer un proyecto en el que se cumplan todos los requisitos solicitados en la consigna, teniendo en cuenta cada una de las rúbricas, y, a partir de eso, avanzar en algo un poco más innovador.

## **CLASES Y RECURSOS**

PersonajeRecursos

    • Personaje: representa a cada personaje del juego, tanto el héroe como los enemigos. Cada uno con sus Datos y Características particulares.
      
    • Datos: son los datos propios del personaje: nombre, tipo, edad, ubicación.
      
    • Características: características de combate de un personaje: velocidad, armadura, fuerza, destreza, salud y habilidad.
      
    • FabricaDePersonajes: utilicé esta clase, solicitada en la consigna del proyecto, para crear a los enemigos, con características, tipos y habilidades aleatorias.

BatallaRecursos

    • Batalla: representa cada batalla del juego, cuyos atributos son el héroe y el enemigo.

Juego

      Usé esta clase para armar la estructura del propio juego, logrando así una modularización óptima.

InterfazGráfica

      Es una clase estática, que sirve para crear una interfaz visual cómoda para el usuario.
      Tiene métodos para: darle un efecto de máquina de escribir al texto del juego, mostrar y actualizar constantemente el estado de los personajes durante una batalla, y mostrar las acciones que van sucediendo en el combate.

Persistencia

    • PersonajesJson: clase encargada de darle persistencia a los personajes creados por la FabricaDePersonajes, creando y leyendo un archivo de texto,
      
    • HistorialJson: clase encargada de registrar el historial de ganadores en un archivo de texto.
      
    • RegistroPartida: clase que sirve para guardar la información relevante de un partida ganada.

Musicalización
	
	La música es parte esencial de todo juego, no quería que falte. Entonces averigüé cómo insertar música en un programa .NET, y conocí la librería NAudio.

    • NAudio: es una librería de audio para .NET que proporciona una amplia gama de funcionalidades para trabajar con audio. Es utilizada para desarrollar aplicaciones de audio como reproductores de música, grabadores, editores de audio, y más. 
      
    • Naudio.Wave: es un espacio de nombres dentro de NAudio que se centra en las operaciones relacionadas con el manejo de ondas de audio. Contiene clases y métodos para la reproducción, grabación y procesamiento de audio en formato WAV, así como para trabajar con dispositivos de audio en Windows. 
      
Documentación: https://github.com/naudio/NAudio/tree/master


## **IMPLEMENTACIÓN DE SERVICIO WEB**

Para implementar el uso de un servicio web en el proyecto, utilicé una API generadora de usuarios random. Dicho usuario viene con muchos datos como ser el nombre, la edad, fecha de nacimiento, dirección, ubicación, género y más. De estos datos saqué lo que me pareció más relevante, para darle a los personajes enemigos un nombre, el género, la edad, y la ubicación.

Documentación: https://randomuser.me/