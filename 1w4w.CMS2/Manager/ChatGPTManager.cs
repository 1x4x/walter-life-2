using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class ChatGPTManager
    {
        static readonly HttpClient client = new HttpClient();
        static string apiKey = "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";

        public static async Task<string> ChatGPT(string query)
        {
            if (string.IsNullOrEmpty(query)) throw new Exception("What do you want to question to ChatGPT?");
            string response = await CallOpenAiApi(query, apiKey);
            //Console.WriteLine(response);
            return response;
        }
        public static async Task<string> Test()
        {
            string query = $"kan du översätta hej till 10 språk";
            //string request = $"kan du ge mig en fin hälsningsfras som har med dagen att göra. Jag heter Walter";
            //string request = $"Hur kan man bli rik";
            //string request = $"Hur kan man helautomatisera att skapa youtube videor för att tjäna pengar på youtube";
            //string request = $"kan du ge mig en fin hälsningsfras som har med dagen att göra. Jag heter Walter";
            //string query = $"Hur kan man helautomatisera att skapa youtube videor för att tjäna pengar på youtube";
            var test = await ChatGPT(query);
            return test;
        }
        public static async Task<string> CallOpenAiApi(string prompt, string apiKey)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo-instruct", // or the latest model you want to use
                prompt = prompt,
                temperature = 0.5,
                max_tokens = 1000,
                top_p = 1.0,
                frequency_penalty = 0.0,
                presence_penalty = 0.0,
            };

                string requestJson = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody; // You might want to process this JSON response further to extract the suggestions.
            }
    }
}