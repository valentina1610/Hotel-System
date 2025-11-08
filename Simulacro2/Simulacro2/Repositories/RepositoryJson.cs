using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Simulacro2.Models;

namespace Simulacro2.Repositories
{
    public class RepositoryJson<T> : IRepository<T>
    {
        private string file = "data.json";  // Ruta/nombre del archivo donde se van a guardar los datos en formato JSON.
                                            // Se crea la primera vez que guardás algo.

       
        public void Save(T entidad) // Guarda una entidad (de tipo T) en el archivo JSON.
        {        // La lógica: leo todo lo que ya está guardado -> le agrego la nueva entidad -> vuelvo a escribir el archivo.

            var items = GetAll(); // Cargo todas las entidades que ya estén guardadas (si no hay, GetAll devuelve lista vacía).

            items.Add(entidad); // Agrego la nueva entidad a la lista en memoria.

            var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });// Convierte la lista a texto JSON. WriteIndented = true
                                                                                                              // hace que el JSON sea "bonito" (con saltos y sangrías).

            File.WriteAllText(file, json); // Escribe (o sobrescribe) el archivo con el JSON actual de la lista completa.

        }
        public List<T> GetAll()// Devuelve la lista completa de entidades guardadas en el JSON.

        {
            if (!File.Exists(file)) return new List<T>();// Si el archivo NO existe, devolvemos una lista vacía (no tiramos error).

            string json = File.ReadAllText(file); // Leemos todo el texto que hay en el archivo.

            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>(); // DESERIALIZAR: convertimos el texto JSON a List<T>.
                                                                               // Si por alguna razón la deserialización devuelve null, usamos '??' para devolver una lista vacía.
        }
    }
}
