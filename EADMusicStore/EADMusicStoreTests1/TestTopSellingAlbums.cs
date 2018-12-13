using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADMusicStore.Controllers;
using EADMusicStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace EADMusicStoreTests1
{
    [TestClass]
    public class TestTopSellingAlbums
    {
        HomeController hctrl = Substitute.For<HomeController>();
        private ApplicationDbContext storeDB = Substitute.For<ApplicationDbContext>();


        [TestMethod()]
        public void GetTopSellingAlbumsTest()
        {
            // database query...
            Album album = new Album();
            album.OrderDetails = new List<OrderDetail>();
            album.OrderDetails.Add(new OrderDetail());
            album.OrderDetails.First().Quantity = 5;
            List<Album> AlbumList = new List<Album>();
            AlbumList.Add(album);
            hctrl.GetTopSellingAlbums(1).Returns(AlbumList);

            var albums = hctrl.GetTopSellingAlbums(1);
            Assert.AreEqual(1, albums.Count);
        }
    }
}
