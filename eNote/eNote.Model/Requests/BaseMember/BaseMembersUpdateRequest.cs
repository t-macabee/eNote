using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Base
{
    public class BaseMembersUpdateRequest
    {
        public string? Telefon { get; set; }
        public string? Lozinka { get; set; }
        public string? LozinkaPotvrda { get; set; }
        public bool? Status { get; set; }
    }
}
