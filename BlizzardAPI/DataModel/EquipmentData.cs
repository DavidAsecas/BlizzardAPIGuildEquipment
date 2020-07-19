using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardAPI.DataModel
{
    public class EquipmentData
    {
        public List<string> Regions { get; set; }
        public List<string> Realms { get; set; }
        public List<string> CharacterNames { get; set; }
    }
}
