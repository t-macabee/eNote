using Microsoft.AspNetCore.Authorization;

namespace eNote.API.Authorization
{
    public class AdminOnly : AuthorizeAttribute
    {
        public AdminOnly() : base(policy: "AdminOnly") { }
    }
}
