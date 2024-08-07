using System.IO.Pipes;
using NAudio.Wave;

public static class AdministradorDeMusica
{
    private static IWavePlayer wavePlayer;
    private static AudioFileReader audioFileReader;

    // Reproduce una pista de música. Si la pista es diferente, la cambia.
    public static void ReproducirMusica(string rutaArchivo)
    {
            // Detener y liberar recursos del reproductor anterior, si existe
            DetenerMusica();
            // Inicializa el reproductor y el lector de archivos de audio
            wavePlayer = new WaveOutEvent();
            audioFileReader = new AudioFileReader(rutaArchivo);
            wavePlayer.Init(audioFileReader);
            wavePlayer.Play();
    }

    // Detiene la música y libera los recursos
    public static void DetenerMusica()
    {
        if (wavePlayer != null)
        {
            wavePlayer.Stop();
            wavePlayer.Dispose();
            wavePlayer = null;
        }

        if (audioFileReader != null)
        {
            audioFileReader.Dispose();
            audioFileReader = null;
        }
    }
}

