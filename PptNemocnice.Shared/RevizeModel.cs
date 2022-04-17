using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PptNemocnice.Shared
{

    
    public class RevizeModel
    {
        public Guid Id { get; set; }
        public string Nazev { get; set; } = "";


        public static List<RevizeModel> NahodnySeznam(int v)
        {
            List<RevizeModel> list = new();
            Random random = new();
            for (int i = 0; i < v - 1; i++)
            {
                var r = new RevizeModel { Id = Guid.NewGuid(), Nazev = VybaveniModel.RandomString(15, random) };
                list.Add(r);
            }
            return list;
        }


    }
}
