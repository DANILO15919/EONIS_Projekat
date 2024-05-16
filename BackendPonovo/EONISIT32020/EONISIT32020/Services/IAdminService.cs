using EONISIT32020.Models;

namespace EONISIT32020.Services
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAdmin();
        Task<Admin> GetAdminById(int adminId);
        Task<Admin> CreateAdmin(Admin admin);
        Task<Admin> UpdateAdmin(Admin admin);
        Task DeleteAdmin(int adminId);
    }
}
