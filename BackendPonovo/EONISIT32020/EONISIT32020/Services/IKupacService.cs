using EONISIT32020.Models;

namespace EONISIT32020.Services
{
    public interface IKupacService
    {
        Task<List<Kupac>> GetKupacs();
        Task<Kupac> GetKupacById(int kupacId);
        Task<Kupac> CreateKupac(Kupac kupac);
        Task<Kupac> UpdateKupac(Kupac kupac);
        Task DeleteKupac(int kupacId);
    }
}
