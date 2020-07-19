using BlizzardAPI.DataModel;
using BlizzardAPI.Model;
using BlizzardAPI.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BlizzardAPI.Controller
{
    public class BlizzardAPIController
    {
        private BlizzardAPIRoute BlizzardApiRoute { get; set; }
        private BlizzardAPIModel BlizzardApiModel { get; set; }
        public BlizzardAPIController()
        {
            BlizzardApiRoute = new BlizzardAPIRoute();
            BlizzardApiModel = new BlizzardAPIModel();
        }
        public EquipmentInfo GetCharacterEquipment(string accessToken, string region, string realm, string characterName)
        {
            var json = BlizzardApiRoute.GetCharacterEquipmentRequest(accessToken, region, realm, characterName);
            return BlizzardApiModel.DeserializeData<EquipmentInfo>(json);
        }

        public string GetAccessToken(string clientId, string clientSecret)
        {
            return BlizzardApiRoute.GetAccesToken(clientId, clientSecret);
        }

        public EquipmentData ReadEquipmentDataFromJson()
        {
            return BlizzardApiModel.ReadEquipmentDataFromJson();
        }

        public GuildData GetGuildRoster(string accessToken, string region, string realm, string guildName)
        {
            var json = BlizzardApiRoute.GetGuildRosterRequest(accessToken, region, realm, guildName);
            return BlizzardApiModel.DeserializeData<GuildData>(json);
        }

        public BitmapImage GetCharacterImage(string accessToken, string region, string realm, string characterName)
        {
            var json = BlizzardApiRoute.GetCharacterImageRequest(accessToken, region, realm, characterName);
            var url =  BlizzardApiModel.DeserializeData<RenderData>(json).render_url;
            return BlizzardApiModel.GetCharacterImage(url);

        }
    }
}
