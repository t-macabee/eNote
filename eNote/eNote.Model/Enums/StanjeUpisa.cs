using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace eNote.Model.Enums
{
    public enum StanjeUpisa
    {
        NaCekanju = 1,
        Potvrdjeno = 2,
        Aktivno = 3,
        Odbijeno = 4,
        Odustao = 5
    }
}
