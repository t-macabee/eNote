﻿using eNote.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface ICRUDService<TModel, TSearch, TInsert, TUpdate> : IService<TModel, TSearch> where TModel : class where TSearch : BaseSearchObject
    {

        Task<TModel> Insert(TInsert request);
        Task<TModel> Update(int id, TUpdate request);
        Task<TModel> Delete(int id);
    }
}
