namespace eNote.Services.Database.Entities
{
    public class MusicShop : BaseKorisnik
    {
        public string Naziv { get; set; } = null!;
        public string RadnoVrijeme { get; set; } = null!;

        public ICollection<Instrumenti> Instrumenti { get; set; } = new List<Instrumenti>();
    }
}
