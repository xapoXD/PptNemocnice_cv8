using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PptNemocnice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class VybaveniController : ControllerBase
    {

        private readonly NemocniceDBcontext _db;
        private readonly IMapper _mapper;

        public VybaveniController(NemocniceDBcontext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<VybaveniModel>> GetAllVybaveni()
        {

            var ents = _db.Vybavenis.Include(x => x.Revizes);

            List<VybaveniModel> models = new();
            foreach (var ent in ents)
            {
                var vybModel = _mapper.Map<VybaveniModel>(ent);
                vybModel.LastRevision = ent.Revizes.OrderByDescending(x => x.DateTime).FirstOrDefault()?.DateTime;
                models.Add(vybModel);
            }
            return models;

        }



       
    }
}
