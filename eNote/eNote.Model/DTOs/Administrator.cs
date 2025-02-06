namespace eNote.Model.DTOs
{
    public class Administrator
    {
        public int Id { get; set; } 
        public string KorisnickoIme { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string BrojTelefona { get; set; } = null!;
        public string Uloga { get; set; } = null!;
        public byte[]? Slika { get; set; }
    }
}
