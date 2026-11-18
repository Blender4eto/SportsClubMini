using SportsClubMini.Data.Entities;

namespace SportsClubMini.Services.Contracts
{
    public interface ISportClubService
    {
        Task<List<SportClub>> GetAll();

        Task Create(string name, string sport, string city, string address, string description);
    }
}
