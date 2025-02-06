using eNote.Model.DTOs;
using eNote.Model.Requests.Predavanje;
using eNote.Model.SearchObjects;


namespace eNote.Services.Interfaces
{
    public interface IPredavanjeService : ICRUDService<Predavanje, PredavanjeSearchObject, PredavanjeInsertRequest, PredavanjeUpdateRequest>
    {
        
    }
}
