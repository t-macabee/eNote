using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace eNote.Model.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusUpisa
    {
        NaCekanju = 1,
        Potvrdjeno = 2,
        Aktivno = 3,
        Otkazano = 4,
        Odustao = 5
    }
}
