using System.Diagnostics.Metrics;

namespace eNote.Services.Database
{
    public class MusicShop
    {
        public int Id { get; set; }
        public string Naziv { get; set; } 

        public int AdresaId { get; set; }
        public Adresa? Adresa { get; set; }

        public ICollection<Instrumenti> Instrumenti { get; set; } = [];
    }
}