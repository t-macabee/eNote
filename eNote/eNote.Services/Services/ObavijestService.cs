using eNote.Model.Requests.Obavijest;
using eNote.Model.Requests.Obavijesti;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Services
{
    public class ObavijestService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.Obavijest, ObavijestSearchObject, ObavijestInsertRequest, ObavijestUpdateRequest, Database.Obavijest>(context, mapper), IObavijestService
    {
    }
}
