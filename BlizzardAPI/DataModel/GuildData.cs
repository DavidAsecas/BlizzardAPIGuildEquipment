using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardAPI.DataModel
{
    public class GuildData
    {
        public List<Member> members { get; set; }

        public class Member
        {
            public Character character { get; set; }

            public class Character
            {
                public string name { get; set; }
                public Realm realm { get; set; }
                public class Realm
                {
                    public string slug { get; set; }
                }
            }
        }
    }
}
