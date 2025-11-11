using System;
using System.IO;
using System.Text.Json;

namespace ClubDeportivo
{
    public sealed class ConexionSettings
    {
        public string BaseDatos { get; set; } = "clubDeportivoAACMP";
        public string Servidor { get; set; } = "localhost";
        public string Puerto { get; set; } = "3306";
        public string Usuario { get; set; } = "root";
        public string Clave { get; set; } = "root";

        public static string FilePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                         "ClubDeportivo", "conexion.json");

        public static ConexionSettings Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<ConexionSettings>(json) ?? new ConexionSettings();
                }
            }
            catch { /* ignore: si se corrompe, vuelvo a defaults */ }
            return new ConexionSettings();
        }

        public void Save()
        {
            var dir = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir!);
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
