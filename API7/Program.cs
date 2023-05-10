using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Random random = new Random();

        int id = random.Next(1, 101);

        string url = $"https://anapioficeandfire.com/api/characters/{id}";

        using (var client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                User user = JsonSerializer.Deserialize<User>(json);

                Console.WriteLine($"Iм'я: {user.name}");
                Console.WriteLine($"Стать: {user.gender}");
                Console.WriteLine($"Культура: {user.culture}");
            }
            else
            {
                Console.WriteLine($"Помилка запиту: {response.StatusCode}");
            }
        }

        Console.ReadLine();
    }
}

class User
{
    public int id { get; set; }
    public string name { get; set; }
    public string gender { get; set; }
    public string culture { get; set; }
}