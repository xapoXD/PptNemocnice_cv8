using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PptNemocnice.Shared
{

    public class UkonModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public DateTime UkonDateTime { get; set; }

        public string JmenoPacient { get; set; } = "";

        public string PrijmeniPacient { get; set; } = "";

        public Guid VybaveniId { get; set; }

        public Guid? PracovnikId { get; set; }

      //  public string? PracovnikJmeno { get; set; }


        public bool IsInNewMode { get; set; }

       //public DateTime VybaveniDateTime { get; set; };
    }
}
