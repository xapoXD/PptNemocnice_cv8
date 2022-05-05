namespace PptNemocnice.Api.Data
{
    public class Vybaveni
    {
       
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public int PriceCzk { get; set; }
        public DateTime BoughtDateTime { get; set; }

        // public DateTime LastRevision { get; set; } // v revizi je pridano

        public List<Revize> Revizes { get; set; } = new();

        public List<Ukon> Ukons { get; set; } = new();
    }
}
