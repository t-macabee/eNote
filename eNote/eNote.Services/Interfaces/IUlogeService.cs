using eNote.Model.SearchObjects;
using eNote.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface IUlogeService : IService<Model.DTOs.Uloge, UlogeSearchObject>
    {
    }
}
