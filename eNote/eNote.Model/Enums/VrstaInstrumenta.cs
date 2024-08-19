using System.Text.Json.Serialization;

namespace eNote.Model.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VrstaInstrumenta
    {
        Zicani = 1,
        Limeni = 2,
        Udaraljke = 3,
        Tipke = 4,
        Elektronicki = 5
    }
}