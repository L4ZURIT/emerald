using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

namespace emerald
{
    internal class json_m
    {
        private static string generate_json_string_from_object<T>(T obj)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(obj, options);
            return jsonString;
        }

        private static string get_json_string_from_file(string filepath)
        {
            try
            {
                return File.ReadAllText(filepath);
            }
            catch (FileNotFoundException ex)
            {
                return "";
            }
            
        }

        private static void write_string_to_file(string json_s, string json_f)
        {
            File.WriteAllText(json_f, json_s);
        }


        // записать текущего пользователя
        public static void write_current_user(user cur_user)
        {
            string data = generate_json_string_from_object<user>(cur_user);
            write_string_to_file(data, @"current_user.json");
        }

        // получить текущего пользователя
        public static user? get_user_from_file()
        {
            try
            {
                user? cur_user = JsonSerializer.Deserialize<user>(get_json_string_from_file(@"current_user.json"));
                return cur_user;
            }
            catch (JsonException ex)
            {
                user? cur_user = null;
                return cur_user;
            }
            
        }
    }
}
