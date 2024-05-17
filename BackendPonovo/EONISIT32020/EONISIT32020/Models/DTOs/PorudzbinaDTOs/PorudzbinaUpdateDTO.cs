namespace EONISIT32020.Models.DTOs.PorudzbinaDTOs
{
    public class PorudzbinaUpdateDTO
    {
        public int IdPorudzbine { get; set; }

        public int? BrojStavki { get; set; }

        public int? IdKupca { get; set; }

        public DateOnly? DatumPorudzbine { get; set; }

        public int? UkupnaCena { get; set; }
    }
}
