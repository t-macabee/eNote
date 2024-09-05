using eNote.Model;
using eNote.Model.DTOs;
using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface IVrstaInstrumentaService : ICRUDService<VrstaInstrumenta, VrstaInstrumentaSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest>
    {       
    }
}
