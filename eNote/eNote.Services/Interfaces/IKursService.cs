using eNote.Model.Requests.Kurs;
using eNote.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface IKursService : ICRUDService<Model.DTOs.Kurs, NazivSearchObject, KursInsertRequest, KursUpdateRequest>
    {

    }
}
