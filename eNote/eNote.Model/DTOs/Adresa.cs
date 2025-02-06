namespace eNote.Model.DTOs
{
    public class Adresa
    {
        public int Id { get; set; } 
        public string Grad { get; set; } = null!;
        public string Ulica { get; set; } = null!;
        public string Broj { get; set; } = null!; 
    }
}
