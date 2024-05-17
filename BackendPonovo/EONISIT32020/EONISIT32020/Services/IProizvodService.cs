using EONISIT32020.Models;

namespace EONISIT32020.Services
{
    public interface IProizvodService
    {
        Task<List<Proizvod>> GetProizvods();
        Task<Proizvod> GetProizvodById(int proizvodId);
        Task<Proizvod> CreateProizvod(Proizvod proizvod);
        Task<Proizvod> UpdateProizvod(Proizvod proizvod);
        Task DeleteProizvod(int proizvodId);
    }
}
