using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Upis
{
    public class UpisUpsertRequest
    {
        public int KursId { get; set; }
        public int StudentId { get; set; }
        public StatusUpisa StatusUpisa { get; set; } = StatusUpisa.NaCekanju;
    }
}
