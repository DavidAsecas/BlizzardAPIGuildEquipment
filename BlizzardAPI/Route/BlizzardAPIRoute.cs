using BlizzardAPI.DataModel;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardAPI.Route
{
    public class BlizzardAPIRoute
    {
        public string GetCharacterEquipmentRequest(string accessToken, string region, string realm, string characterName)
        {
            var client = new RestClient($"https://{region}.api.blizzard.com/profile/wow/character/{realm}/{characterName}/equipment");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("authorization", $"Bearer {accessToken}");
            request.AddHeader("Battlenet-Namespace", "profile-eu");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetGuildRosterRequest(string accessToken, string region, string realm, string guildName)
        {
            var client = new RestClient($"https://{region}.api.blizzard.com/data/wow/guild/{realm}/{guildName}/roster");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("authorization", $"Bearer {accessToken}");
            request.AddHeader("Battlenet-Namespace", "profile-eu");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetCharacterImageRequest(string accessToken, string region, string realm, string characterName)
        {
            var client = new RestClient($"https://{region}.api.blizzard.com/profile/wow/character/{realm}/{characterName}/character-media");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("authorization", $"Bearer {accessToken}");
            request.AddHeader("Battlenet-Namespace", "profile-eu");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetAccesToken(string clientId, string clientSecret)
        {
            var client = new RestClient("https://us.battle.net/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var tokenResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(response.Content);

            return tokenResponse.access_token;
        }
    }
}
