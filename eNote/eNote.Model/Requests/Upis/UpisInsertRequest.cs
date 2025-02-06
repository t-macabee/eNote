using eNote.Model.Enums;

namespace eNote.Model.Requests.Upis
{
    public class UpisInsertRequest
    {
        public int KursId { get; set; }
        public int PolaznikId { get; set; }
        public UpisStatus UpisStatus { get; set; }
    }
}
