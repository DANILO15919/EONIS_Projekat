using EONISIT32020.Models;

namespace EONISIT32020.Services
{
    public interface IBrendService
    {
        Task<List<Brend>> GetBrends();
        Task<Brend> GetBrendById(int typeId);
        Task<Brend> GetBrendByTitle(String typeName);
        Task<Brend> CreateBrend(Brend type);
        Task<Brend> UpdateBrend(Brend type);
        Task DeleteBrend(int typeId);
    }
}
