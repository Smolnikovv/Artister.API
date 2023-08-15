using Artister.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artister.API.Configs
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        public DatabaseSeeder(DatabaseContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            CheckConnection();
            SeedDatabase();
        }
        private void UpdateDatabase()
        {
            var migrations = _context.Database.GetPendingMigrations();
            if(migrations != null && migrations.Any())
            {
                _context.Database.Migrate();
            }
        }
        private void CheckConnection()
        {
            if(!_context.Database.CanConnect())
            {
                CheckDebbuger();
            }
            else
            {
                UpdateDatabase();
            }
        }
        private void CheckDebbuger()
        {
            if(System.Diagnostics.Debugger.IsAttached)
            {
                UpdateDatabase();
            }
            else
            {
                throw new Exception("Can't connect");
            }
        }
        private void SeedDatabase()
        {
            if(_context.Genres.Any())
            {

            }
            if(_context.Subgenres.Any())
            {

            }
            if(_context.Artists.Any())
            {

            }
        }
        private List<Artist> SeedArtist()
        {
            return null;
        }
        private List<Genre> SeedGenre()
        {
            return null;
        }
        private List<Subgenre> SeedSubgenre()
        {
            return null;
        }
    }
}
