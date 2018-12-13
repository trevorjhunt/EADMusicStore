using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADMusicStore.Models
{
    public interface IApplicationDbContext : IDisposable
    {

        DbSet<Album> Albums { get; }

        int SaveChanges();
        void MarkAsModified(Album item);

    }
}
