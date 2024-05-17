using EONISIT32020.Models;

namespace EONISIT32020.Services
{
    public interface IPorudzbinaService
    {
        Task<List<Porudzbina>> GetPorudzbina();
        Task<Porudzbina> GetPorudzbinaById(int porudzbinaId);
        Task<Porudzbina> CreatePorudzbina(Porudzbina porudzbina);
        Task<Porudzbina> UpdatePorudzbina(Porudzbina porudzbina);
        Task DeletePorudzbina(int porudzbinaId);

    }
}
