namespace eNote.Model.DTOs
{
    public class Upis
    {
        public int Id { get; set; }
        public int PolaznikId { get; set; }
        public int KursId { get; set; }
        public string UpisStatus { get; set; } = null!;
    }
}
