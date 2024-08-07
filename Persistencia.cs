using PersonajeRecursos;
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
    public static void GuardarGanador(Personaje ganador, string nombreArchivo) {
        List<RegistroPartida> historial;
        if (Existe(nombreArchivo)) {
            historial = LeerGanadores(nombreArchivo);
        } else {
            historial = new();
        }
        RegistroPartida registro = new(ganador,DateTime.Now);
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
        foreach (RegistroPartida r in historial) {
            InterfazGrafica.LimpiarPantalla();
            Console.WriteLine("\nNombre del Ganador: " + r.Ganador.Datos.Nombre);
            Console.WriteLine("Fecha: " + r.Fecha.ToString("dd/mm/YY") + "\n");
            InterfazGrafica.EsperarEntradaUsuario();
        }
    }
}
public class RegistroPartida {

    [JsonPropertyName("ganador")]
    Personaje ganador;

    [JsonPropertyName("fecha")]
    DateTime fecha;
    
    public RegistroPartida() {}

    public RegistroPartida(Personaje gan, DateTime fec) {
        ganador = gan;
        fecha = fec;
    }

    public Personaje Ganador { get => ganador; set => ganador = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
}