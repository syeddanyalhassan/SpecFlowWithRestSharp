using System;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RestSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://simple-books-api.glitch.me/");
            var request = new RestRequest("books");
            var response = client.Execute(request);

            // Check if the response is successful
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Deserialize json string response to JsonArray object
                var data = JsonSerializer.Deserialize<JsonArray>(response.Content!)!;

                // Check if at least two properties are included in the response body
                var dataNode = (JsonNode)data[0];
                if (dataNode is JsonObject obj && obj.ContainsKey("id") && obj.ContainsKey("name"))
                {
                    // output result
                    Console.WriteLine($@"
                    ----------------
                    json properties
                    ----------------
                    id: {data[0]["id"]}
                    name: {data[0]["name"]}


                    ");
                }
                else
                {
                    Console.WriteLine("Error: At least two properties were not found in the response body.");
                }
            }
            else
            {
                Console.WriteLine($"Error: Request failed with status code: {response.StatusCode}");
            }
        }
    }
}
