using Microsoft.AspNetCore.Authorization;

namespace eNote.API.Authorization
{
    public class AdminOrTeacher : AuthorizeAttribute
    {
        public AdminOrTeacher() : base(policy: "AdminOrTeacher") { }
    }
}
