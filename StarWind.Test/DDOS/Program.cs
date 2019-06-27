using System;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDOS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string myJson = "{'id': 1,'PluginName':'Plugin'}";

            var tasks = new Task[1000];
            Thread.Sleep(50000);

            for (int i = 0; i < 1000; i++)
            {
                tasks[i] = await Task.Factory.StartNew(async () =>
                {
                    var c = i;
                    try
                    {
                        HttpClient client = new HttpClient();
                        var response = await client.PostAsync("http://localhost:5000/Client/AddAge?id=1", new StringContent(myJson, Encoding.UTF8, "application/json"));
                        Console.WriteLine(c + ": " + await response.Content.ReadAsStringAsync());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                });
            }
            Task.WaitAll(tasks);
            Console.ReadKey();
        }
    }
}
