namespace EONISIT32020.Models.DTOs.PorudzbinaDTOs
{
    public class PorudzbinaDTO
    {
        public int? BrojStavki { get; set; }

        public int? IdKupca { get; set; }

        public DateOnly? DatumPorudzbine { get; set; }

        public int? UkupnaCena { get; set; }
    }
}
