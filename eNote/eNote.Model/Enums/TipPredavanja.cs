using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace eNote.Model.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipPredavanja
    {
        Teorija = 1,
        Praksa = 2,
        Kombinovano = 3
    }
}
