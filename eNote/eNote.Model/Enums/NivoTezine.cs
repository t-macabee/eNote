using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace eNote.Model.Enums
{ 
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NivoTezine
    {
        Pocetni = 1,
        Srednji = 2,
        Napredni = 3
    }
}
