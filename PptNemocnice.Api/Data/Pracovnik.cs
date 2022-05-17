namespace PptNemocnice.Api.Data
{
    public class Pracovnik
    {
        public Guid PracovnikId { get; set; }

        public string Name { get; set; } = string.Empty;

      //  public Guid UkonId { get; set; }

        public List<Ukon> Ukons { get; set; } = new();
    }
}
