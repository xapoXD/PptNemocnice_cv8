using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PptNemocnice.Shared
{

        public class VybaveniSRevizemaModel
        {
            public Guid Id { get; set; }
            public string Nazev { get; set; } = string.Empty;

            public DateTime DateTime { get; set; }
 

            public List<RevizeModel> Revizes { get; set; } = new();

            public int PriceCzk { get; set; }

            public List<UkonModel> Ukons { get; set; } = new();

    }
}
