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
    }

    public DbSet<Vybaveni> Vybavenis => Set<Vybaveni>();

    public DbSet<Revize> Revizes => Set<Revize>();
}
