using BlizzardAPI.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BlizzardAPI.Model
{
    public class BlizzardAPIModel
    {
        public BlizzardAPIModel()
        {

        }

        public EquipmentData ReadEquipmentDataFromJson()
        {
            var json = File.ReadAllText(@"D:\Users\David\source\repos\BlizzardAPI\BlizzardAPI\Data\EquipmentData.json");
            return JsonConvert.DeserializeObject<EquipmentData>(json);
        }

        public T DeserializeData<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public BitmapImage GetCharacterImage(string url)
        {
            var image = new BitmapImage();
            int BytesToRead = 100;

            WebRequest request = WebRequest.Create(new Uri(url, UriKind.Absolute));
            request.Timeout = -1;
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            BinaryReader reader = new BinaryReader(responseStream);
            MemoryStream memoryStream = new MemoryStream();

            byte[] bytebuffer = new byte[BytesToRead];
            int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);

            while (bytesRead > 0)
            {
                memoryStream.Write(bytebuffer, 0, bytesRead);
                bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
            }

            image.BeginInit();
            memoryStream.Seek(0, SeekOrigin.Begin);

            image.StreamSource = memoryStream;
            image.EndInit();
            return image;
        }
    }
}
