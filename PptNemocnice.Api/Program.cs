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
app.MapGet("/vybaveni", (NemocniceDBcontext db) =>
{
    //Console.WriteLine(db.Vybavenis.Count());

    return db.Vybavenis;
});


//HOTOVO
app.MapGet("/vybaveni/jensrevizi", (int c, NemocniceDBcontext db) =>
{
   // return seznam.Where(x => !x.NeedsRevision);

    return db.Vybavenis.Where(x => !(DateTime.Now - x.LastRevision > TimeSpan.FromDays(365 * 2)));
});


// HOTOVO
app.MapGet("/vybaveni/{Id}",(Guid Id, NemocniceDBcontext db) =>
{
    var item = db.Vybavenis.SingleOrDefault(x => x.Id == Id);
    if (item == null) return Results.NotFound("takováto entita neexistuje");
    return Results.Json(item);
});



//HOTOVO
app.MapPost("/vybaveni", (VybaveniModel prichoziModel, NemocniceDBcontext db, IMapper mapper) =>
{

    prichoziModel.Id = Guid.Empty;

    Vybaveni ent = mapper.Map<Vybaveni>(prichoziModel);
    db.Vybavenis.Add(ent);
    db.SaveChanges(); // nyni pridano do databaze
    
    
    return Results.Created("/vybaveni",ent.Id);
});





// HOTOVO
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
    Vybaveni ent = mapper.Map<Vybaveni>(staryZaznam);
    if (staryZaznam == null) return Results.NotFound("Tento záznam není v seznamu");
    
  //  int ind = db.Vybavenis.IndexOf(staryZaznam);

    db.Vybavenis.Add(ent);
    db.Vybavenis.Remove(staryZaznam);
    db.SaveChanges();

    return Results.Ok();
});


//HOTOVO
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


//HOTOVO
app.MapGet("/revize/{vyhledavanyRetezec}", (string vyhledavanyRetezec, NemocniceDBcontext db, IMapper mapper) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec)) return Results.Problem("Parametr nesmi byt prazdny");

    var kdeJeRetezec = db.Revizes.Where(x => x.Nazev.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.Run();

//HOTOVO
app.MapGet("/revize", (NemocniceDBcontext db) =>
{
    //Console.WriteLine(db.Vybavenis.Count());

    return db.Revizes;
});


//record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}