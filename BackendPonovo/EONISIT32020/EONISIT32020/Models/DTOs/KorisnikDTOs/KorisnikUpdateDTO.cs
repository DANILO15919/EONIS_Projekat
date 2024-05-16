namespace EONISIT32020.Models.DTOs.KorisnikDTOs
{
    public class KorisnikUpdateDTO
    {
        public int IdKorisnika { get; set; }
        public string? Email { get; set; }

        public string? Lozinka { get; set; }

        public string? Uloga { get; set; }

    }
}
