using Microsoft.EntityFrameworkCore;


namespace PptNemocnice.Api.Data;


public class NemocniceDBcontext : DbContext
{

    public NemocniceDBcontext(DbContextOptions<NemocniceDBcontext> options)
        : base(options)
    {



    }

    public DbSet<Vybaveni> Vybavenis => Set<Vybaveni>();

    public DbSet<Revize> Revizes => Set<Revize>();
}
