using eNote.Model.Enums;
using eNote.Model.Requests.Predavanje;
using eNote.Model.SearchObjects;


namespace eNote.Services.Interfaces
{
    public interface IPredavanjeService : ICRUDService<Model.DTOs.Predavanje, PredavanjeSearchObject, PredavanjeInsertRequest, PredavanjeUpdateRequest>
    {
        
    }
}
