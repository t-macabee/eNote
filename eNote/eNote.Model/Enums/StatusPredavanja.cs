using System.Text.Json.Serialization;

namespace eNote.Model.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusPredavanja
    {
        Planirano = 1,        
        UToku = 2,
        Zavrseno = 3,
        Otkazano = 4
    }
}
