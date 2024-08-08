﻿using eNote.Model.DTOs;

namespace eNote.Model
{
    public class MusicShop : IKorisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = string.Empty;
        public string Naziv { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public Adresa Adresa { get; set; } = null!;
        public Uloge Uloga { get; set; } = null!;
    }
}
