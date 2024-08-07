using eNote.Model.Requests.Instrument;
using eNote.Model.Requests.Kurs;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace eNote.Services.Services
{
    public class KursService(ENoteContext context, IMapper mapper, IHttpContextAccessor accessor)
        : CRUDService<Model.DTOs.Kurs, NazivSearchObject, KursInsertRequest, KursUpdateRequest, Kurs>(context, mapper), IKursService
    {
        private readonly IHttpContextAccessor accessor = accessor;

        public override async Task<Model.DTOs.Kurs> Insert(KursInsertRequest request)
        {
            var UserIdClaim = (accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)) ?? throw new Exception("User ID claim not found");

            if (!int.TryParse(UserIdClaim.Value, out var userId))
            {
                throw new Exception("Invalid User ID claim");
            }

            request.Id = userId;

            return await base.Insert(request);
        }
    }
}
