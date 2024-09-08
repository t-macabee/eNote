using eNote.Model.Requests.Adresa;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class TipPredavanjaController(ITipPredavanjaService tipPredavanjaService) : BaseController<Model.DTOs.TipPredavanja, TipPredavanjaSearchObject>(tipPredavanjaService)
    {
    }
}
