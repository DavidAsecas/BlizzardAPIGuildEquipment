using BlizzardAPI.Controller;
using BlizzardAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlizzardAPI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BlizzardAPIController BlizzardApiController { get; set; }
        public GuildData GuildRoster { get; set; }
        public string AccesToken { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            BlizzardApiController = new BlizzardAPIController();
            Init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var region = regionBox.Text;
            var realm = realmBox.Text;
            var guildName = guildBox.Text;
            GuildRoster = BlizzardApiController.GetGuildRoster(AccesToken, region, realm, guildName);
            membersCombo.ItemsSource = GuildRoster.members.Select(m => new StringBuilder(m.character.name).Append(" - ").Append(m.character.realm.slug).ToString()).OrderBy(x => x);
        }

        private void Init()
        {
            var apiClient = Environment.GetEnvironmentVariable("BlizzardAPI_Client", EnvironmentVariableTarget.User);
            var apiSecret = Environment.GetEnvironmentVariable("BlizzardAPI_Secret", EnvironmentVariableTarget.User);
            AccesToken = BlizzardApiController.GetAccessToken(apiClient, apiSecret);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var region = regionBox.Text;
            var character = GuildRoster.members.Find(m => String.Compare(m.character.name, membersCombo.Text) == 0).character;
            var characterName = character.name.ToLower();
            var realm = character.realm.slug;
            var equipment = BlizzardApiController.GetCharacterEquipment(AccesToken, region, realm, characterName);
            var url = BlizzardApiController.GetCharacterImage(AccesToken, region, realm, characterName);
            var stringBuilder = new StringBuilder();
            var image = BlizzardApiController.GetCharacterImage(AccesToken, region, realm, characterName);
            foreach (var item in equipment.equipped_items)
            {
                var slotName = item.slot.name.es_ES;
                var itemName = item.name.es_ES;
                stringBuilder = stringBuilder.Append(slotName).Append(": ").Append(itemName).AppendLine();
            }
            characterImage.Source = image;
            textBox.Text = stringBuilder.ToString();
        }
    }
}
