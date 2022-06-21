using Lotto.Data.Implementation;
using Lotto.Data.Interface;
using Lotto.Models.LottoDrawings;
using Lotto.Services.Implementation;
using Lotto.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lotto.Tests.Services
{
    [TestClass]
    public class RelationshipServiceTests
    {
        [TestMethod]
        public void CanCreateRelationshipService_Success() 
        {
            var repo = new Mock<ILottoDrawingsService>();
            var service = new RelationshipService(repo.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public async Task CanGetRelationshipPair_Success() 
        {
            var repo = new Mock<ILottoRepository>();
            repo.Setup(r => r.GetAllDrawings()).ReturnsAsync(new List<LottoDrawing>() {
                new LottoDrawing("test", 1, 1, 2022, 1, 2, 3, 4, 5, 5, 1),
                new LottoDrawing("test", 1, 1, 2022, 1, 2, 13, 14, 15, 15, 1),
                new LottoDrawing("test", 1, 1, 2022, 1, 2, 23, 24, 25, 25, 1),
                new LottoDrawing("test", 1, 1, 2022, 1, 2, 33, 34, 35, 35, 1),
                new LottoDrawing("test", 1, 1, 2022, 1, 2, 43, 44, 45, 45, 1),
            });


            var drawingService = new LottoDrawingsService(repo.Object);
            var service = new RelationshipService(drawingService);

            var input = 1;
            var expected = 2;
            var result = await service.MostPairedWith(input);

            repo.Verify(r => r.GetAllDrawings(), Times.Once());

            Assert.AreEqual(expected, result);
        }
    }
}
