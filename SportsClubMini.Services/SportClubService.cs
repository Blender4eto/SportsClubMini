using Microsoft.EntityFrameworkCore;
using SportsClubMini.Data;
using SportsClubMini.Data.Entities;
using SportsClubMini.Services.Contracts;

namespace SportsClubMini.Services
{
    public class SportClubService : ISportClubService
    {
        private readonly SportsClubDbContext _db;

        public SportClubService(SportsClubDbContext context)
        {
            _db = context;
        }

        public async Task Create(string name, string sport, string city, string address, string description)
        {
            var existingSport = await _db.Sports
                .FirstOrDefaultAsync(s => s.Name == sport);

            if (existingSport is null)
            {
                existingSport = new Sport
                {
                    SportId = Guid.NewGuid(),
                    Name = sport
                };

                _db.Sports.Add(existingSport);
            }

            var club = new SportClub
            {
                ClubId = Guid.NewGuid(),
                Name = name,
                City = city,
                Address = address,
                Description = description,
                Sports = new List<Sport> { existingSport }
            };

            _db.SportClubs.Add(club);
            await _db.SaveChangesAsync();
        }

        public Task<List<SportClub>> GetAll()
        {
            return _db.SportClubs
                .Include(club => club.Sports)
                .OrderBy(club => club.Name)
                .ToListAsync();
        }
    }
}
