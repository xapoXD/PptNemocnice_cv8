using Microsoft.EntityFrameworkCore;


namespace PptNemocnice.Api.Data;


public class NemocniceDBcontext : DbContext
{

    public NemocniceDBcontext(DbContextOptions<NemocniceDBcontext> options)
        : base(options)
    {



    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Guid idVybaveni = new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba");
        Guid idVybaveni2 = new Guid("c58712b5-bbfa-490e-9582-359128cd870e");
        Guid idVybaveni3 = new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0");

        builder.Entity<Vybaveni>().HasData(

            new Vybaveni() { Id = idVybaveni, Name = "RNTGN", BoughtDateTime = new DateTime(2015, 6, 6), PriceCzk = 150000 },
            new Vybaveni() { Id = idVybaveni2, Name = "CT", BoughtDateTime = new DateTime(2015, 6, 6), PriceCzk = 200000 },
            new Vybaveni() { Id = idVybaveni3, Name = "IDK", BoughtDateTime = new DateTime(2015, 6, 6), PriceCzk = 69 }
            );
        DateTime d = new DateTime(2020, 05, 06);
        DateTime d2 = new DateTime(2014, 08, 15);
        DateTime d3 = new DateTime(2017, 12, 19);

        builder.Entity<Revize>().HasData(
            new Revize() { Id = new Guid("682b9a37-b704-4c1d-903d-6136863e08f8"), VybaveniId = idVybaveni, Nazev = "idk dalsi", DateTime = d },
            new Revize() { Id = new Guid("775aee54-29a7-4a4d-8fac-f8c461e2f9e8"), VybaveniId = idVybaveni2, Nazev = "idk dalsi2", DateTime = d2 },
            new Revize() { Id = new Guid("9f659f58-2e09-47cc-a5f2-fefa3a73ef17"), VybaveniId = idVybaveni3, Nazev = "idk dalsi3", DateTime = d3 }
            );

        Guid idUkon = new Guid("148bf078-5d39-47ef-a465-889ede7d2062");
        Guid idUkon2 = new Guid("d72872dc-47d4-4f5c-95a3-78c50c936c25");
        Guid idUkon3 = new Guid("f136bbaa-faa7-4343-b29e-9887c767b265");

        Guid idPracovnik = new Guid("8ae660c7-7660-436b-9bed-ca76faa2c617");
        Guid idPracovnik2 = new Guid("071c0f36-82c6-4ecc-ac8e-37130ef35226");
        Guid idPracovnik3 = new Guid("547184e4-9a55-4172-9ffb-7ece02cd29c3");

        builder.Entity<Ukon>().HasData(
            new Ukon() { Id = idUkon , VybaveniId = idVybaveni , Name = "scan"     , UkonDateTime = d , JmenoPacient = "Johnny", PrijmeniPacient = "Karasek" },
            new Ukon() { Id = idUkon2, VybaveniId = idVybaveni2, Name = "probmemek", UkonDateTime = d2, JmenoPacient = "Paul"  , PrijmeniPacient = "Puta"  },
            new Ukon() { Id = idUkon3, VybaveniId = idVybaveni3, Name = "profiscan", UkonDateTime = d3, JmenoPacient = "Dave"  , PrijmeniPacient = "Paid"   }
            );
        // Pracovnik
        

        builder.Entity<Pracovnik>().HasData(
            new Pracovnik() { PracovnikId = idPracovnik, Name = "Paroubek" },
             new Pracovnik() { PracovnikId = idPracovnik2, Name = "Navara" },
              new Pracovnik() { PracovnikId = idPracovnik3, Name = "Reichl" }

            );
    }

    public DbSet<Vybaveni> Vybavenis => Set<Vybaveni>();

    public DbSet<Revize> Revizes => Set<Revize>();

    public DbSet<Ukon> Ukons => Set<Ukon>();

    public DbSet<Pracovnik> Pracovniks => Set<Pracovnik>();

    // public DbSet<Ukon> Ukons => Set<Ukon>();
}
