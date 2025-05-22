using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NukeWeb
{
    public class Request
    {
        private static HttpClient HttpClient { get; } = new();
        internal static async Task<string> Get(string variable)
        {
            if (!Reachable())
            {
                return "UNREACHABLE";
            }
            var request = new HttpRequestMessage(HttpMethod.Get, Constants.VariableUrl + variable);
            var response = await HttpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception($"Request failed with status code: {response.StatusCode}");
            }
        }
        internal static async Task<string> Post(string variable, object? body = null)
        {
            if (!Reachable())
            {
                return "UNREACHABLE";
            }
            var request = new HttpRequestMessage(HttpMethod.Post, Constants.VariableUrl + variable + $"&value={body}");
            var response = await HttpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception($"Request failed with status code: {response.StatusCode}");
            }
        }

        public static async Task<string> CustomGet(string variable)
        {
            return await Get(variable);
        }

        public static async Task<string> CustomPost(string variable, object? body = null)
        {
            return await Post(variable, body);
        }

        public static bool Reachable()
        {
            if (GameRunning())
            {
                if (PortOpen() == "OK")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Port is not open.");
                    return false;
                }
            }
            return false;
        }

        public static bool GameRunning()
        {
            var gameExe = System.Diagnostics.Process.GetProcessesByName("Nucleares").FirstOrDefault();
            if (gameExe != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string PortOpen()
        {
            try
            {
                var client = new TcpClient("localhost", 8785);
                client.Close();
                return "OK";
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Port is not open. {ex.Message}");
                return $"ERROR - {ex.Message}";
            }
        }
    }
}
