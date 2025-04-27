using HomeWrokOOP_2.Users;
using System.Text.Json;

namespace HomeWrokOOP_2
{
    internal class Program
    {
        private static void serializeJson(string nameAndPath, User user)
        {
            string json = JsonSerializer.Serialize(user);
            using (StreamWriter sw = new StreamWriter(nameAndPath))
            {
                sw.Write(json);
                sw.Close();
            }
        }
        private static void serializeJson(string nameAndPath, Admin user)
        {
            string json = JsonSerializer.Serialize(user);
            using (StreamWriter sw = new StreamWriter(nameAndPath))
            {
                sw.Write(json);
                sw.Close();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to JSON Serialize/deserialize");
            User user1 = new User() { Name = "Jhon", Email = "jhon@gmail.com", Id = 13313123, Surname = "Hornet" };
            Admin admin = new Admin() { Name = "Admin", Email = "email@gmail.com", Age = 52, Id = 1425252, Role = "System admin", Surname = "Admin" };
            serializeJson("user1.json", user1);
            serializeJson("admin1.json", admin);
            //Deserialize User
            var streamJson = File.ReadAllText("user1.json");
            User? jsonDes = JsonSerializer.Deserialize<User>(streamJson);
            Console.WriteLine("Parsed user = {0}, {1}, {2}, {3}", jsonDes.Id, jsonDes.Surname, jsonDes.Email, jsonDes.Name);
            //Deserialize admin
            streamJson = File.ReadAllText("admin1.json");
            Admin ?admin1 = JsonSerializer.Deserialize<Admin>(streamJson);
            Console.WriteLine("The admin is = {0}, {1}, {2}, {3}, {4}, {5}", admin1.Name, admin1.Surname, admin1.Age, admin1.Email, admin1.Role, admin1.Id);

        }
    }
}
