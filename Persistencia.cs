using PersonajeRecursos;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class PersonajesJson {
    public static void GuardarPersonajes(List<Personaje> lista, string nombreArchivo) {
        string jsonString = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(nombreArchivo, jsonString);
    }
    public static List<Personaje> LeerPersonajes(string nombreArchivo) {
        string jsonString = File.ReadAllText(nombreArchivo);
        List<Personaje> lista = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
        return lista;
    }
    public static bool Existe(string nombreArchivo) {
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
    }
}

public static class HistorialJson {
    public static void GuardarGanador(Personaje ganador, double duracion, string nombreArchivo) {
        List<RegistroPartida> historial;
        if (Existe(nombreArchivo)) {
            historial = LeerGanadores(nombreArchivo);
        } else {
            historial = new();
        }
        RegistroPartida registro = new(ganador,DateTime.Now, duracion);
        historial.Add(registro);
        string jsonString = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(nombreArchivo, jsonString);
    }
    public static List<RegistroPartida> LeerGanadores(string nombreArchivo) {
        string jsonString = File.ReadAllText(nombreArchivo);
        List<RegistroPartida> lista = JsonSerializer.Deserialize<List<RegistroPartida>>(jsonString);
        return lista;
    }
    public static bool Existe(string nombreArchivo) {
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
    }
    public static void MostrarGanadores(string nombreArchivo) {
        List<RegistroPartida> historial = LeerGanadores(nombreArchivo);
        InterfazGrafica.MostrarMensajeGradualmente("HISTORIAL DE GANADORES\n");
        foreach (RegistroPartida r in historial) {
            InterfazGrafica.MostrarMensajeGradualmente("Nombre del Ganador: " + r.Ganador.Datos.Nombre);
            InterfazGrafica.MostrarMensajeGradualmente("Fecha de la victoria: " + r.Fecha.ToString("dd/MM/yyyy"));
            InterfazGrafica.MostrarMensajeGradualmente($"Duración de las batallas: {r.DuracionEnMinutos:F2} minutos\n");  
            Thread.Sleep(1000);
        }
        InterfazGrafica.EsperarEntradaUsuario();
    }
}
public class RegistroPartida {

    [JsonPropertyName("ganador")]
    Personaje ganador;

    [JsonPropertyName("fecha")]
    DateTime fecha;

    [JsonPropertyName("duracion")]
    double duracionEnMinutos;
    
    public RegistroPartida() {}

    public RegistroPartida(Personaje gan, DateTime fec, double dur) {
        ganador = gan;
        fecha = fec;
        DuracionEnMinutos = dur;
    }

    public Personaje Ganador { get => ganador; set => ganador = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public double DuracionEnMinutos { get => duracionEnMinutos; set => duracionEnMinutos = value; }
}