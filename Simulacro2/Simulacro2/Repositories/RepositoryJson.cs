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
        private string file = "data.json";
        public void Save(T entity)
        {
            var items = GetAll();
            items.Add(entity);
            File.WriteAllText(file, JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true }));
        }
        public List<T> GetAll()
        {
            if (!File.Exists(file)) return new List<T>();
            return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(file)) ?? new List<T>();
        }
    }
}
