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

            public Guid VybaveniId { get; set; }
            

        }
}
