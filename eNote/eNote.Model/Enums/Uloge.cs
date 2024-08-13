using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace eNote.Model.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Uloge
    {
        Administrator = 1,
        Instruktor = 2,
        Polaznik = 3,
        MusicShop = 4
    }
}
