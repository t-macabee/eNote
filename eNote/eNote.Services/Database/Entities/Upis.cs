using eNote.Model.Enums;

namespace eNote.Services.Database.Entities
{
    public class Upis
    {
        public int Id { get; set; }
        public UpisStatus UpisStatus { get; set; }

        public int PolaznikId { get; set; }
        public Polaznik Polaznik { get; set; } = null!;
        public int KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;
    }
}