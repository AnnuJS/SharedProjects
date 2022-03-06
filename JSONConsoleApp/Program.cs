// See https://aka.ms/new-console-template for more information
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


String apiUrl = "https://api.chucknorris.io/jokes/random";
String consoleResponse = "e"; //exit

do
{
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
    using (WebResponse response = request.GetResponse())
    {
        using (var readStream = new StreamReader(response.GetResponseStream()))
        {
            string jsonResponse = readStream.ReadToEnd();
            var jo = JObject.Parse(jsonResponse);
            Console.WriteLine($"Joke : {jo["value"]}");
            Console.WriteLine($"Press J for new joke and any other key to exit;");
            consoleResponse = Console.ReadLine();
        }
    }
} while (consoleResponse == "j" || consoleResponse == "J");