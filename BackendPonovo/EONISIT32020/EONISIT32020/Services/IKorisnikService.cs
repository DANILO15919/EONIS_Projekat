using EONISIT32020.Models;

namespace EONISIT32020.Services
{
    public interface IKorisnikService
    {
        Task<List<Korisnik>> GetKorisniks();
        Task<Korisnik> GetKorisnikById(int korisnikId);
        Task<Korisnik> CreateKorisnik(Korisnik korisnik);
        Task<Korisnik> UpdateKorisnik(Korisnik korisnik);
        Task DeleteKorisnik(int korisnikId);
    }
}
