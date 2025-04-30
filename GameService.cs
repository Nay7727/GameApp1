using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using Services;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
        public GameService(AppDbContext context) => _context = context;

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games
                .Include(g => g.Users)
                .Include(g => g.Genres)
                .ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _context.Games
                .Include(g => g.Users)
                .Include(g => g.Genres)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }

}
