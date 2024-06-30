using eNote.Services.Database;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentiController : ControllerBase
    {
        protected IInstrumentService _service;

        public InstrumentiController(IInstrumentService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Instrumenti> GetList()
        {
            return _service.GetAll();
        }
    }
}
