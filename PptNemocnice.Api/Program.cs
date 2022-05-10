using AutoMapper;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<NemocniceDBcontext>(opt => opt.UseSqlite("FileName=Nemocnice.db"));



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins(builder.Configuration["AllowedOrigins"])
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .AllowAnyHeader()
));

var app = builder.Build();
app.UseCors();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//List<VybaveniModel> seznam = VybaveniModel.GetTestList();
//List<RevizeModel> seznamRevizi = RevizeModel.NahodnySeznam(1000);



//JE TO PREDELANY JINAM


//app.MapGet("/vybaveni", (NemocniceDBcontext db, IMapper mapper) =>
//{
//    var ents = db.Vybavenis.Include(x => x.Revizes);
//    List<VybaveniModel> modelss = new();
//   // List<DateTime?> models = new();


//    foreach (var aa in ents)
//    {
//        var ent = mapper.Map<VybaveniModel>(aa);//mapovaná na "databázový" typ

//      //  DateTime poslvaredni = DateTime.Now - ent.LastRevision;
//      /*
//        aa.Revizes.OrderBy(b => b.DateTime);
//        ent.LastRevision = aa.Revizes.FirstOrDefault()?.DateTime;7
//      */
//        ent.LastRevision = aa.Revizes.OrderByDescending(x => x.DateTime).FirstOrDefault()?.DateTime;

//        modelss.Add(ent);
//        //  if (ent.LastRevision != null) // && (DateTime.Now - ent.LastRevision) == null  && posledni < ent.LastRevision
//        //   {

//        //     models.Add(ent.LastRevision);
//        //  return ent.LastRevision;
//        //   modelss.Add(ent);
//        //  }

//    }  


//   // models.Add(ent);
//   // return db.Vybavenis;
//    return Results.Json(modelss);
//});


/*
app.MapGet("/vybaveni/jensrevizi", (int c, NemocniceDBcontext db) =>
{
   // return seznam.Where(x => !x.NeedsRevision);

   // return db.Vybavenis.Where(x => !(DateTime.Now - x.LastRevision > TimeSpan.FromDays(365 * 2)));
});
*/

app.MapGet("/", () => "Heloou");

// detail + ukon added
app.MapGet("/vybaveni/{Id}",(Guid Id, NemocniceDBcontext db, IMapper mapper) =>
{
  
    
    var item = db.Vybavenis.Include(x => x.Revizes).Include(x => x.Ukons).SingleOrDefault(x => x.Id == Id);

  //   item = db.Vybavenis.Include(x => x.Ukons).SingleOrDefault(x => x.Id == Id);

    if (item == null) return Results.NotFound("takováto entita neexistuje");
    // if (item == null) return Results.NotFound("takováto entita neexistuje");
    //todo: specifikovat mapping


    VybaveniSRevizemaModel ent = mapper.Map<VybaveniSRevizemaModel>(item);
      //  var pp = db.Revizes.SingleOrDefault(x => x.Id == Id);


    return Results.Json(ent);
});

//NEW
app.MapGet("/ukon/{Id}", (Guid Id, NemocniceDBcontext db, IMapper mapper) =>
{
   var item = db.Vybavenis.Include(x => x.Ukons).SingleOrDefault(x => x.Id == Id);

    if (item == null) return Results.NotFound("takováto entita neexistuje");

    VybaveniSRevizemaModel ent = mapper.Map<VybaveniSRevizemaModel>(item);

    return Results.Json(ent);
});

/// NEW ---
app.MapPost("/ukon", (UkonModel prichoziModel, NemocniceDBcontext db, IMapper mapper) =>
{

    prichoziModel.Id = Guid.Empty;

    Ukon ent = mapper.Map<Ukon>(prichoziModel);
    db.Ukons.Add(ent);
    db.SaveChanges(); // nyni pridano do databaze


    return Results.Created("/ukon", ent.Id);
});

// NEW
app.MapDelete("/ukon/{Id}", (Guid Id, NemocniceDBcontext db, IMapper mapper) =>
{
    var item = db.Ukons.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");
    db.Ukons.Remove(item);
    db.SaveChanges();
    return Results.Ok();
}
);

//NEW
app.MapPut("/ukon", (UkonModel prichoziModel, NemocniceDBcontext db, IMapper mapper) =>
{
  
    var staryZaznam = db.Ukons.SingleOrDefault(x => x.Id == prichoziModel.Id);
    if (staryZaznam == null) return Results.NotFound("Tento záznam není v seznamu");
    mapper.Map(prichoziModel, staryZaznam);
    db.SaveChanges();
    return Results.Ok();
});


app.MapPost("/vybaveni", (VybaveniModel prichoziModel, NemocniceDBcontext db, IMapper mapper) =>
{

    prichoziModel.Id = Guid.Empty;

    Vybaveni ent = mapper.Map<Vybaveni>(prichoziModel);
    db.Vybavenis.Add(ent);
    db.SaveChanges(); // nyni pridano do databaze


    return Results.Created("/vybaveni", ent.Id);
});


app.MapPost("/revize", (RevizeModel prichoziModel, NemocniceDBcontext db, IMapper mapper) =>
{
    /* var item = db.Vybavenis.Include(x => x.Revizes);
     Revize ent = mapper.Map<Revize>(item);
     db.Revizes.Add(ent);
     db.SaveChanges(); // nyni pridano do databaze


     return Results.Created("/revize", ent.DateTime); */


    prichoziModel.Id = Guid.Empty;//vynuluju id, db si idèka ošéfuje sama
  //  prichoziModel.DateTime = DateTime.UtcNow;
    Revize ent = mapper.Map<Revize>(prichoziModel);//mapovaná na "databázový" typ
    db.Revizes.Add(ent);//pøidání do db
    db.SaveChanges();//uložení db (v tuto chvíli se vytvoøí id)

    return Results.Created("/revize", ent.Id);
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



app.MapGet("/revize", (NemocniceDBcontext db) =>
{
    //Console.WriteLine(db.Vybavenis.Count());

    return db.Revizes;
});

app.MapGet("/revize/{vyhledavanyRetezec}", (string vyhledavanyRetezec, NemocniceDBcontext db, IMapper mapper) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec)) return Results.Problem("Parametr nesmi byt prazdny");

    var kdeJeRetezec = db.Revizes.Where(x => x.Nazev.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.MapControllers();

app.Run();




