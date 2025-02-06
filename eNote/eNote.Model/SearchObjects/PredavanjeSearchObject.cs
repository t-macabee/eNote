using eNote.Model.Enums;

namespace eNote.Model.SearchObjects
{
    public class PredavanjeSearchObject : BaseSearchObject
    {
        public int? KursId { get; set; }
        public string? Naziv { get; set; }
        public PredavanjeTip? PredavanjeTip { get; set; }
    }
}
