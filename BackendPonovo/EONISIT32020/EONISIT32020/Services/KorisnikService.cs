using EONISIT32020.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;

namespace EONISIT32020.Services
{
    public class KorisnikService : IKorisnikService
    {
        ProdavnicaOdeceIt322020Context _dbContext;
        private readonly List<Korisnik> _users = new List<Korisnik>();

        public KorisnikService(ProdavnicaOdeceIt322020Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Korisnik> CreateKorisnik(Korisnik korisnik)
        {
            var createdKorisnik = await _dbContext.AddAsync(korisnik);

            await _dbContext.SaveChangesAsync();

            return createdKorisnik.Entity;
        }

        public  async Task DeleteKorisnik(int korisnikId)
        {
            try
            {
                Korisnik? search = await _dbContext.Korisniks.FirstOrDefaultAsync(w => w.IdKorisnika == korisnikId);

                if (search == null)
                    throw new KeyNotFoundException();

                _dbContext.Korisniks.Remove(search);

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Korisnik> GetKorisnikById(int korisnikId)
        {
            try
            {
                Korisnik? search = await _dbContext.Korisniks.FirstOrDefaultAsync(w => w.IdKorisnika == korisnikId);

                if (search == null)
                    throw new KeyNotFoundException();

                return search;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Korisnik>> GetKorisniks()
        {
            try
            {
                return await _dbContext.Korisniks.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Korisnik> UpdateKorisnik(Korisnik korisnik)
        {
            try
            {
                var toUpdate = await _dbContext.Korisniks.FirstOrDefaultAsync(w => w.IdKorisnika == korisnik.IdKorisnika);

                if (toUpdate == null)
                    throw new KeyNotFoundException();

                toUpdate.IdKorisnika = korisnik.IdKorisnika;
                toUpdate.Email = korisnik.Email;
                toUpdate.Lozinka = korisnik.Lozinka;
                toUpdate.Uloga = korisnik.Uloga;

                await _dbContext.SaveChangesAsync();

                return toUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Korisnik> GetKorisnikByEmail(string email)
        {
            try
            {
                Korisnik? search = await _dbContext.Korisniks.FirstOrDefaultAsync(w => w.Email == email);

                if (search == null)
                    throw new KeyNotFoundException();

                return search;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInputPassword = password;
            return hashedPassword == hashedInputPassword;
        }

        public bool ValidateUser(string email, string password)
        {
            try
            {
                var user = GetKorisnikByEmail(email).Result;
                if (user == null) return false;

                return VerifyPassword(password, user.Lozinka);
            }

            catch (Exception ex)
            {
                throw new Exception("Wrong credentials", ex);
            }

        }

        public bool Register(string email, string password, string role)
        {
            if (_users.Any(u => u.Email == email))
            {
                return false; // User already exists
            }
            return true;
        }
    }
}
