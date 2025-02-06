using eNote.Model.Enums;

namespace eNote.Services.Database.Entities
{
    public class Predavanje
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Lokacija { get; set; } = null!;
        public int TrajanjeMinute { get; set; }
        public DateTime DatumVrijemePredavanja { get; set; }
        public PredavanjeTip PredavanjeTip { get; set; }
        public PredavanjeStatus PredavanjeStatus { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;

        public ICollection<Prisustvo> Prisustvo { get; set; } = new List<Prisustvo>();
        public ICollection<Napomena> Napomena { get; set; } = new List<Napomena>();
        public ICollection<Zadatak> Zadaci { get; set; } = new List<Zadatak>();
    }
}