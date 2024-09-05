using eNote.Model.Enums;

namespace eNote.Services.Database
{
    public class Predavanje
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; } 
        public DateTime DatumVrijemePredavanja { get; set; }
        public int TrajanjeMinute { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }

        public string TipPredavanja { get; set; }
        public string StanjePredavanja { get; set; }

        public ICollection<Prisustvo> Prisustvo { get; set; } = new List<Prisustvo>();
        public ICollection<Obavijest> Napomena { get; set; } = new List<Obavijest>();
        public ICollection<Zadatak> Zadaci { get; set; } = new List<Zadatak>();
    }
}