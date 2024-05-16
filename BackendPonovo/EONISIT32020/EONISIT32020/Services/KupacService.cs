using EONISIT32020.Models;
using Microsoft.EntityFrameworkCore;

namespace EONISIT32020.Services
{
    public class KupacService : IKupacService
    {
        ProdavnicaOdeceIt322020Context _dbContext;

        public KupacService(ProdavnicaOdeceIt322020Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Kupac> CreateKupac(Kupac kupac)
        {
            var createdKorisnik = await _dbContext.AddAsync(kupac);

            await _dbContext.SaveChangesAsync();

            return createdKorisnik.Entity;
        }

        public async Task DeleteKupac(int kupacId)
        {

            try
            {
                Kupac? search = await _dbContext.Kupacs.FirstOrDefaultAsync(w => w.IdKupca == kupacId);

                if (search == null)
                    throw new KeyNotFoundException();

                _dbContext.Kupacs.Remove(search);

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Kupac> GetKupacById(int kupacId)
        {
            try
            {
                Kupac? search = await _dbContext.Kupacs.FirstOrDefaultAsync(w => w.IdKupca == kupacId);

                if (search == null)
                    throw new KeyNotFoundException();

                return search;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Kupac>> GetKupacs()
        {
            try
            {
                return await _dbContext.Kupacs.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Kupac> UpdateKupac(Kupac kupac)
        {
            try
            {
                var toUpdate = await _dbContext.Kupacs.FirstOrDefaultAsync(w => w.IdKupca == kupac.IdKupca);

                if (toUpdate == null)
                    throw new KeyNotFoundException();

                toUpdate.Ime = kupac.Ime;
                toUpdate.Prezime = kupac.Prezime;
                toUpdate.Adresa = kupac.Adresa;
                toUpdate.Telefon = kupac.Telefon;

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
