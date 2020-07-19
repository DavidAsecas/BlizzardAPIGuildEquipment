using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardAPI.DataModel
{
    public class EquipmentInfo
    {
        public List<Equipment> equipped_items { get; set; }

        public class Equipment
        {
            public Slot slot { get; set; }
            public Name name { get; set; }
            public Item item { get; set; }

            public class Slot
            {
                public Name name { get; set; }
            }

            public class Name
            {
                public string es_ES { get; set; }
            }

            public class Item
            {
                public int id { get; set; }
            }
        }
    }
}
