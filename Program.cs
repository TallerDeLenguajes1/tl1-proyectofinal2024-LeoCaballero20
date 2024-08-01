Results resultados = await GeneradorDeUsuarios.GenerarUsuariosAsync();

Juego miJuego = new(resultados.Usuarios);
miJuego.Iniciar();

