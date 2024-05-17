using EONISIT32020.Models;
using Microsoft.EntityFrameworkCore;

namespace EONISIT32020.Services
{
    public class PorudzbinaService : IPorudzbinaService
    {
        ProdavnicaOdeceIt322020Context _dbContext;

        public PorudzbinaService(ProdavnicaOdeceIt322020Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Porudzbina> CreatePorudzbina(Porudzbina porudzbina)
        {

            var createdKorisnik = await _dbContext.AddAsync(porudzbina);

            await _dbContext.SaveChangesAsync();

            return createdKorisnik.Entity;
        }

        public async Task DeletePorudzbina(int porudzbinaId)
        {
            try
            {
                Porudzbina? search = await _dbContext.Porudzbinas.FirstOrDefaultAsync(w => w.IdPorudzbine == porudzbinaId);

                if (search == null)
                    throw new KeyNotFoundException();

                _dbContext.Porudzbinas.Remove(search);

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Porudzbina>> GetPorudzbina()
        {
            try
            {
                return await _dbContext.Porudzbinas.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Porudzbina> GetPorudzbinaById(int porudzbinaId)
        {
            try
            {
                Porudzbina? search = await _dbContext.Porudzbinas.FirstOrDefaultAsync(w => w.IdPorudzbine == porudzbinaId);

                if (search == null)
                    throw new KeyNotFoundException();

                return search;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Porudzbina> UpdatePorudzbina(Porudzbina porudzbina)
        {
            try
            {
                var toUpdate = await _dbContext.Porudzbinas.FirstOrDefaultAsync(w => w.IdPorudzbine == porudzbina.IdPorudzbine);

                if (toUpdate == null)
                    throw new KeyNotFoundException();

                toUpdate.IdPorudzbine = porudzbina.IdPorudzbine;
                toUpdate.BrojStavki = porudzbina.BrojStavki;
                toUpdate.IdKupca = porudzbina.IdKupca;
                toUpdate.DatumPorudzbine = porudzbina.DatumPorudzbine;
                toUpdate.UkupnaCena = porudzbina.UkupnaCena;

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
