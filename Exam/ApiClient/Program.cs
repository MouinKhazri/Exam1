using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class Company
{
    public string Name { get; set; }
}

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Company Company { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
        };

        try
        {
            var user = await httpClient.GetFromJsonAsync<User>("users/1");

            if (user != null)
            {
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Company: {user.Company?.Name}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
