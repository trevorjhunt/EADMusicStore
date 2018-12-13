using EADMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADMusicStoreTests1
{
    class TestAlbumDbSet : TestDbSet<Album>
    {
        public override Album Find(params object[] keyValues)
        {
            return this.SingleOrDefault(album => album.AlbumId == (int)keyValues.Single());
        }
    }
}
