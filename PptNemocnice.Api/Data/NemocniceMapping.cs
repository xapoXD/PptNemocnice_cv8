namespace PptNemocnice.Api.Data;
using AutoMapper;
using PptNemocnice.Shared;

public class NemocniceMapping : Profile
    {
    public NemocniceMapping()
    {

        CreateMap<Vybaveni, VybaveniModel>().ReverseMap();

        CreateMap<Revize, RevizeModel>().ReverseMap();

        CreateMap<Vybaveni, VybaveniSRevizemaModel>().ReverseMap();
    }
    
    }

