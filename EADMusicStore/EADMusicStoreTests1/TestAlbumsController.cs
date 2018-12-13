using EADMusicStore.Controllers;
using EADMusicStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net;
using System.Web.Http.Results;

namespace EADMusicStoreTests1
{
    [TestClass]
    public class TestAlbumsController
    {
        [TestMethod]
        public void GetAlbums_ShouldReturnAllAlbums()
        {
            var context = new TestAppContext();
            context.Albums.Add(new Album { Title = "A Copland Celebration, Vol. I", Price = 8.99M });



            var controller = new AlbumsController(context);
            var result = controller.GetAlbums();// as TestAlbumDbSet;

       
            Assert.IsNotNull(result);
            //Assert.IsTrue(result.ToString().StartsWith("A Copland Celebration"));
        }
    }
}
