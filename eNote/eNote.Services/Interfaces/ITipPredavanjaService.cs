using eNote.Model.SearchObjects;
using eNote.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface ITipPredavanjaService : IService<Model.DTOs.TipPredavanja, TipPredavanjaSearchObject>
    {
    }
}
