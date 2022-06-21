using Lotto.Data.Interface;
using Lotto.Models.LottoDrawings;
using Lotto.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lotto.Tests.Services
{
    [TestClass]
    public class LottoDrawingsServiceTests
    {
        [TestMethod]
        public void CanCreateLottoDrawingService_Success() 
        {
            var repo = new Mock<ILottoRepository>();
            var service = new LottoDrawingsService(repo.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public async Task CanCallGetAllDrawings_Success() 
        {
            var repo = new Mock<ILottoRepository>();
            repo.Setup(r => r.GetAllDrawings()).ReturnsAsync(new List<LottoDrawing>());

            var service = new LottoDrawingsService(repo.Object);

            await service.GetAllDrawings();

            repo.Verify(r => r.GetAllDrawings(), Times.Once());
        }

        [TestMethod]
        public async Task CanCallGetDrawingsContainingNumber_Success()
        {
            var repo = new Mock<ILottoRepository>();
            repo.Setup(r => r.GetDrawingsWithNumber(It.IsAny<int>(), false)).ReturnsAsync(new List<LottoDrawing>());

            var service = new LottoDrawingsService(repo.Object);

            await service.GetDrawingsContainingNumber(It.IsAny<int>(), false);

            repo.Verify(r => r.GetDrawingsWithNumber(It.IsAny<int>(), false), Times.Once());
        }
    }
}
