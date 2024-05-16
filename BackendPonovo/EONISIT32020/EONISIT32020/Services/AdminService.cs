using EONISIT32020.Models;
using Microsoft.EntityFrameworkCore;

namespace EONISIT32020.Services
{
    public class AdminService : IAdminService
    {
        ProdavnicaOdeceIt322020Context _dbContext;

        public AdminService(ProdavnicaOdeceIt322020Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Admin> CreateAdmin(Admin admin)
        {
            var createdAdmin = await _dbContext.AddAsync(admin);

            await _dbContext.SaveChangesAsync();

            return createdAdmin.Entity;
        }

        public async Task DeleteAdmin(int adminId)
        {
            try
            {
                Admin? search = await _dbContext.Admins.FirstOrDefaultAsync(w => w.IdAdmina == adminId);

                if (search == null)
                    throw new KeyNotFoundException();

                _dbContext.Admins.Remove(search);

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Admin>> GetAdmin()
        {
            try
            {
                return await _dbContext.Admins.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Admin> GetAdminById(int adminId)
        {
            try
            {
                Admin? search = await _dbContext.Admins.FirstOrDefaultAsync(w => w.IdAdmina == adminId);

                if (search == null)
                    throw new KeyNotFoundException();

                return search;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            try
            {
                var toUpdate = await _dbContext.Admins.FirstOrDefaultAsync(w => w.IdAdmina == admin.IdAdmina);

                if (toUpdate == null)
                    throw new KeyNotFoundException();

                toUpdate.IdAdmina = admin.IdAdmina;
                toUpdate.IdKorisnika = admin.IdKorisnika;
                toUpdate.Ime = admin.Ime;

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
