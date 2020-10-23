using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Consumer
{
  class Program
  {
    static void Main()
    {
			Console.WriteLine("Intializing consumer ....");
			var result = Consume().GetAwaiter().GetResult();
			Console.WriteLine(result);
			Console.ReadKey();
		}

		private static async Task<String> Consume()
		{
			var url = "https://localhost:5001/";

			var client = new HttpClient()
			{
				BaseAddress = new Uri(url),
				Timeout = TimeSpan.FromSeconds(30)
			};
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			Console.WriteLine("Requesting consumer ....");
			var response = await client.GetAsync("/api/kommunes");
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();

			return content;
		}

	}
}
