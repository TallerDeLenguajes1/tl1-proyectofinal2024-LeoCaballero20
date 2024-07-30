using PersonajeRecursos;
using System.Text.Json;

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

public class HistorialJson {
    public void GuardarGanador(Personaje ganador, string nombreArchivo) {
        string jsonString = JsonSerializer.Serialize(ganador, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(nombreArchivo, jsonString);
    }
    public List<Personaje> LeerGanadores(string nombreArchivo) {
        string jsonString = File.ReadAllText(nombreArchivo);
        List<Personaje> lista = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
        return lista;
    }
    public bool Existe(string nombreArchivo) {
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
    }
}