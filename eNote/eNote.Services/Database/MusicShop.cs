using System.Diagnostics.Metrics;

namespace eNote.Services.Database
{
    public class MusicShop
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }

        public ICollection<Instrumenti> Instrumenti { get; set; }
    }
}