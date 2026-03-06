using LoginCompositeWinForms.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoginCompositeWinForms.Data
{

    /* JSONN public static class DataStore
     {
         private static readonly string PathArchivo =
             Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.json");

         private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
         {
             WriteIndented = true
         };

         public static void GuardarUsuarios(List<Usuario> usuarios)
         {
             var json = JsonSerializer.Serialize(usuarios, Options);
             File.WriteAllText(PathArchivo, json);
         }

         public static List<Usuario> CargarUsuarios()
         {
             if (!File.Exists(PathArchivo))
                 return new List<Usuario>();

             var json = File.ReadAllText(PathArchivo);

             var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json, Options);

             return usuarios ?? new List<Usuario>();
         }
     }
 }
 */

    public static class DataStore
    {
        private static readonly string PathArchivo =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.bin");

        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            using (FileStream fs = new FileStream(PathArchivo, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, usuarios);
            }
        }

        /* public static List<Usuario> CargarUsuarios()
          {
              if (!File.Exists(PathArchivo))
                  return new List<Usuario>();

              using (FileStream fs = new FileStream(PathArchivo, FileMode.Open))
              {
                  BinaryFormatter formatter = new BinaryFormatter();
                  return (List<Usuario>)formatter.Deserialize(fs);
              }
          }*/
        public static List<Usuario> CargarUsuarios()
        {
            if (!File.Exists(PathArchivo))
                return new List<Usuario>();

            FileInfo fileInfo = new FileInfo(PathArchivo);

            if (fileInfo.Length == 0)
                return new List<Usuario>();

            using (FileStream fs = new FileStream(PathArchivo, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Usuario>)formatter.Deserialize(fs);
            }
        }
    }
}