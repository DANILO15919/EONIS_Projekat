using Microsoft.EntityFrameworkCore;
using EONISIT32020.Models;
using System.Data;
using System.Drawing.Drawing2D;

namespace EONISIT32020.Services
{
    public class BrendService : IBrendService
    {
        ProdavnicaOdeceIt322020Context _dbContext;

        public BrendService(ProdavnicaOdeceIt322020Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Brend> CreateBrend(Brend brend)
        {
            var createdBrend = await _dbContext.AddAsync(brend);

            await _dbContext.SaveChangesAsync();

            return createdBrend.Entity;
        }

        public async Task DeleteBrend(int brendId)
        {
            try
            {
                Brend? search = await _dbContext.Brends.FirstOrDefaultAsync(w => w.IdBrenda == brendId);

                if (search == null)
                    throw new KeyNotFoundException();

                _dbContext.Brends.Remove(search);

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Brend> GetBrendById(int brendId)
        {
            try
            {
                Brend? search = await _dbContext.Brends.FirstOrDefaultAsync(w => w.IdBrenda == brendId);

                if (search == null)
                    throw new KeyNotFoundException();

                return search;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Brend> GetBrendByTitle(string typeName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Brend>> GetBrends()
        {
            try
            {
                return await _dbContext.Brends.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Brend> UpdateBrend(Brend brend)
        {
            try
            {
                var toUpdate = await _dbContext.Brends.FirstOrDefaultAsync(w => w.IdBrenda == brend.IdBrenda);

                if (toUpdate == null)
                    throw new KeyNotFoundException();

                toUpdate.IdBrenda = brend.IdBrenda;
                toUpdate.NazivBrenda = brend.NazivBrenda;

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
