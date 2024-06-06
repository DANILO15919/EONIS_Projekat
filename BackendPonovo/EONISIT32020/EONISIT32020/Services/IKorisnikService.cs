using EONISIT32020.Models;

namespace EONISIT32020.Services
{
    public interface IKorisnikService
    {
        Task<List<Korisnik>> GetKorisniks();
        Task<Korisnik> GetKorisnikById(int korisnikId);
        Task<Korisnik> GetKorisnikByEmail(string korisnikEmail);
        Task<Korisnik> CreateKorisnik(Korisnik korisnik);
        Task<Korisnik> UpdateKorisnik(Korisnik korisnik);
        Task DeleteKorisnik(int korisnikId);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        bool ValidateUser(string email, string password);
        bool Register(string email, string password, string role);
    }
}
