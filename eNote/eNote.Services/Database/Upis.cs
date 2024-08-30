using eNote.Model.Enums;

namespace eNote.Services.Database
{
    public class Upis
    {
        public int Id { get; set; }        
        public StanjeUpisa StatusUpisa { get; set; }

        public int StudentId { get; set; }
        public Korisnik Student { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
    }
}