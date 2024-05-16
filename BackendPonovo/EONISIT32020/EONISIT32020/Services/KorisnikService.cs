using EONISIT32020.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace EONISIT32020.Services
{
    public class KorisnikService : IKorisnikService
    {
        ProdavnicaOdeceIt322020Context _dbContext;

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
    }
}
