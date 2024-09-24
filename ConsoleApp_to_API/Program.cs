using ConsolaApp_To_API.ViewModel;
using System.Net.Http.Json;

Console.WriteLine("Api DB-adatok kiíratása");
HttpClient client = new HttpClient();

var valasz = await client.GetFromJsonAsync<List<UserVM>>("https://localhost:7132/api/User");

if (valasz != null)
{
    foreach (var user in valasz)
    {
        Console.WriteLine($"A felhasztnáló neve: {user.FullName} \nE-Mail címe: {user.Email}\n");
    }
}
else
{
    Console.WriteLine("Nincs adat!");
}

Console.ReadLine();