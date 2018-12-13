using EADMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EADMusicStoreTests1
{
    public class TestAppContext : IApplicationDbContext
    {
        public TestAppContext()
        {
            this.Albums = new TestAlbumDbSet();
        }

        public DbSet<Album> Albums { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Album item) { }
        public void Dispose() { }
    }
}
