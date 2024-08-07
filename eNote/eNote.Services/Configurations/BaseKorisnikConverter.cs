using eNote.Model.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eNote.Services.Configurations
{
    public class BaseKorisnikConverter : JsonConverter<BaseKorisnik>
    {
        public override BaseKorisnik Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, BaseKorisnik value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteNumber("id", value.Id);
            writer.WriteString("korisnickoIme", value.KorisnickoIme);
            writer.WriteString("email", value.Email);
            writer.WriteString("telefon", value.Telefon);

            if (value.Adresa != null)
            {
                writer.WritePropertyName("adresa");
                JsonSerializer.Serialize(writer, value.Adresa, options);
            }

            if (value.Uloga != null)
            {
                writer.WritePropertyName("uloga");
                JsonSerializer.Serialize(writer, value.Uloga, options);
            }

            if (value is Model.Korisnik korisnik)
            {
                writer.WriteString("ime", korisnik.Ime);
                writer.WriteString("prezime", korisnik.Prezime);
                writer.WriteString("datumRodjenja", korisnik.DatumRodjenja);
            }
            else if (value is Model.MusicShop shop)
            {
                writer.WriteString("naziv", shop.Naziv);
            }

            writer.WriteEndObject();
        }
    }
}
