using AutoMapper;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<NemocniceDBcontext>(opt => opt.UseSqlite("FileName=Nemocnice.db"));



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:7132")
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .AllowAnyHeader()
));

var app = builder.Build();
app.UseCors();

app.MapGet("/", () => "Hello");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//List<VybaveniModel> seznam = VybaveniModel.GetTestList();
//List<RevizeModel> seznamRevizi = RevizeModel.NahodnySeznam(1000);



//HOTOVO
app.MapGet("/vybaveni", (NemocniceDBcontext db, IMapper mapper) =>
{
    var ents = db.Vybavenis.Include(x => x.Revizes);
   // List<VybaveniModel> models = new();
    List<DateTime?> models = new();

    foreach (var aa in ents)
    {
        VybaveniModel ent = mapper.Map<VybaveniModel>(aa);//mapovaná na "databázový" typ

        if(ent.LastRevision != null) // && (DateTime.Now - ent.LastRevision) == null
        {
            models.Add(ent.LastRevision);
         //  return ent.LastRevision;
        }
        
    }  
   // models.Add(ent);
   // return db.Vybavenis;
    return models;
});



app.MapGet("/vybaveni/jensrevizi", (int c, NemocniceDBcontext db) =>
{
   // return seznam.Where(x => !x.NeedsRevision);

   // return db.Vybavenis.Where(x => !(DateTime.Now - x.LastRevision > TimeSpan.FromDays(365 * 2)));
});


// upravit
app.MapGet("/vybaveni/{Id}",(Guid Id, NemocniceDBcontext db, IMapper mapper) =>
{
    var item = db.Vybavenis.Include(x => x.Revizes).SingleOrDefault(x => x.Id == Id);
    if (item == null) return Results.NotFound("takováto entita neexistuje");
    //todo: specifikovat mapping
    
    
    //VybaveniSRevizemaModel ent = mapper.Map<VybaveniSRevizemaModel>(item);


    return Results.Json(mapper.Map<VybaveniSRevizemaModel>(item));
});




app.MapPost("/vybaveni", (VybaveniModel prichoziModel, NemocniceDBcontext db, IMapper mapper) =>
{

    prichoziModel.Id = Guid.Empty;

    Vybaveni ent = mapper.Map<Vybaveni>(prichoziModel);
    db.Vybavenis.Add(ent);
    db.SaveChanges(); // nyni pridano do databaze
    
    
    return Results.Created("/vybaveni",ent.Id);
});






app.MapPut("/vybaveni", (VybaveniModel prichoziModel, NemocniceDBcontext db, IMapper mapper) =>
{
    /*
    var staryZaznam = seznam.SingleOrDefault(x => x.Id == prichoziModel.Id);
    if (staryZaznam == null) return Results.NotFound("Tento záznam není v seznamu");
    int ind = seznam.IndexOf(staryZaznam);
    seznam.Insert(ind, prichoziModel);
    seznam.Remove(staryZaznam);
    return Results.Ok();
    */
   

    var staryZaznam = db.Vybavenis.SingleOrDefault(x => x.Id == prichoziModel.Id);
    if (staryZaznam == null) return Results.NotFound("Tento záznam není v seznamu");
    mapper.Map(prichoziModel, staryZaznam);
    db.SaveChanges();
    return Results.Ok();
});


app.MapDelete("/vybaveni/{Id}",(Guid Id , NemocniceDBcontext db, IMapper mapper) =>
{
    var item = db.Vybavenis.SingleOrDefault(x=> x.Id == Id);
    if (item == null) 
        return Results.NotFound("Tato položka nebyla nalezena!!");
    db.Vybavenis.Remove(item);
    db.SaveChanges();
    return Results.Ok();
}
);



app.MapGet("/revize/{vyhledavanyRetezec}", (string vyhledavanyRetezec, NemocniceDBcontext db, IMapper mapper) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec)) return Results.Problem("Parametr nesmi byt prazdny");

    var kdeJeRetezec = db.Revizes.Where(x => x.Nazev.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.Run();


app.MapGet("/revize", (NemocniceDBcontext db) =>
{
    //Console.WriteLine(db.Vybavenis.Count());

    return db.Revizes;
});

