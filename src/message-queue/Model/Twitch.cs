using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace message_queue.Model
{
    public class Twitch
    {
        public Action<object, OnConnectedArgs> OnConnected { get; set; } = (sender, e) => { };
        public Action<object, OnMessageReceivedArgs> OnMessage { get; set; } = (sender, e) => { };

        private static readonly HttpClient client = new HttpClient();
        private ConnectionCredentials _credentials;
        private TwitchClient _client;

        public Twitch(string botName, string botToken, string observingChannel)
        {
            if (botName == "" || botToken == "" || observingChannel == "")
            {
                throw new Exception("Botname or bottoken must be specified.");
            }

            _credentials = new ConnectionCredentials(botName, botToken);
            _client = new TwitchClient();
            _client.Initialize(_credentials, observingChannel);
            _client.OnMessageReceived += (sender, e) => OnMessage.Invoke(sender, e);
            _client.OnConnected += (sender, e) => OnConnected.Invoke(sender, e);
            _client.Connect();

        }

        public static async Task<TwitchResponseEmoticons> GetEmotesForStreamAsync(string name, string clientId)
        {
            client.DefaultRequestHeaders.Remove("Client-ID");
            client.DefaultRequestHeaders.Add("Client-ID", clientId);
            HttpResponseMessage response = await client.GetAsync("https://api.twitch.tv/kraken/chat/" + name + "/emoticons");

            var _data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TwitchResponseEmoticons>(_data);
        }

        public static async Task<bool> ChechIfStreamExistsAsync(string name, string clientId)
        {
            client.DefaultRequestHeaders.Remove("Client-ID");
            client.DefaultRequestHeaders.Add("Client-ID", clientId);
            HttpResponseMessage response = await client.GetAsync("https://api.twitch.tv/kraken/channels/" + name);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
