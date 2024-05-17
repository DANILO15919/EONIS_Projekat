namespace EONISIT32020.Models.DTOs.ProizvodDTOs
{
    public class ProizvodCreateDTO
    {
        public int? IdBrenda { get; set; }

        public string? Naziv { get; set; }

        public int? Cena { get; set; }

        public string? Veličina { get; set; }

        public string? Boja { get; set; }

        public string? Opis { get; set; }

        public int? KoličinaNaStanju { get; set; }

        public string? Slika { get; set; }
    }
}
