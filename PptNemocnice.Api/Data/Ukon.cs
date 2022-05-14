namespace PptNemocnice.Api.Data
{
    public class Ukon
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime UkonDateTime { get; set; }

        public string JmenoPacient { get; set; } = string.Empty;

        public string PrijmeniPacient { get; set; } = string.Empty;

        public Guid VybaveniId { get; set; }

        public Vybaveni Vybaveni { get; set; } = null!;

      //  public DateTime VybaveniDateTime { get; set; };
    }
}
