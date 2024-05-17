using EONISIT32020.Models;
using Microsoft.EntityFrameworkCore;

namespace EONISIT32020.Services
{
    public class ProizvodService : IProizvodService
    {
        ProdavnicaOdeceIt322020Context _dbContext;

        public ProizvodService(ProdavnicaOdeceIt322020Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Proizvod> CreateProizvod(Proizvod proizvod)
        {
            var createdProizvod = await _dbContext.AddAsync(proizvod);

            await _dbContext.SaveChangesAsync();

            return createdProizvod.Entity;
        }

        public async Task DeleteProizvod(int proizvodId)
        {
            try
            {
                Proizvod? search = await _dbContext.Proizvods.FirstOrDefaultAsync(w => w.IdProizvoda == proizvodId);

                if (search == null)
                    throw new KeyNotFoundException();

                _dbContext.Proizvods.Remove(search);

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Proizvod> GetProizvodById(int proizvodId)
        {
            try
            {
                Proizvod? search = await _dbContext.Proizvods.FirstOrDefaultAsync(w => w.IdProizvoda == proizvodId);

                if (search == null)
                    throw new KeyNotFoundException();

                return search;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Proizvod>> GetProizvods()
        {
            try
            {
                return await _dbContext.Proizvods.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Proizvod> UpdateProizvod(Proizvod proizvod)
        {
            try
            {
                var toUpdate = await _dbContext.Proizvods.FirstOrDefaultAsync(w => w.IdProizvoda == proizvod.IdProizvoda);

                if (toUpdate == null)
                    throw new KeyNotFoundException();

                toUpdate.IdProizvoda = proizvod.IdProizvoda;
                toUpdate.IdBrenda = proizvod.IdBrenda;
                toUpdate.Naziv = proizvod.Naziv;
                toUpdate.Cena = proizvod.Cena;
                toUpdate.Veličina = proizvod.Veličina;
                toUpdate.Boja = proizvod.Boja;
                toUpdate.Opis = proizvod.Opis;
                toUpdate.KoličinaNaStanju = proizvod.KoličinaNaStanju;
                toUpdate.Slika = proizvod.Slika;

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
