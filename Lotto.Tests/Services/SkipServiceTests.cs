using Lotto.Data.Implementation;
using Lotto.Data.Interface;
using Lotto.Services.Implementation;
using Lotto.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lotto.Tests.Services
{
    [TestClass]
    public class SkipServiceTests
    {
        [TestMethod]
        public void CanMakeSkipService_Success() 
        {
            ISkipService skipService = new SkipService(new Mock<ILottoDrawingsService>().Object);

            Assert.IsNotNull(skipService);
        }

        [TestMethod]
        public async Task CanGetSkipDataForNumber_Success() 
        {
            ILottoRepository repo = new LottoJSONRepository();
            ILottoDrawingsService drawingsService = new LottoDrawingsService(repo);
            ISkipService skipService = new SkipService(drawingsService);

            var lottoNumber = new Random().Next(1, 71);
            var skipData = await skipService.GetSkipCountForNumber(lottoNumber);

            Assert.IsNotNull(skipData);
            Assert.AreEqual(lottoNumber, skipData.Number);
            Assert.AreNotEqual(0, skipData.TotalMisses);
            Assert.AreNotEqual(0, skipData.AverageSkips);
        }

        [TestMethod]
        public async Task CanGetSkipDataForAllNumbers_Success()
        {
            ILottoRepository repo = new LottoJSONRepository();
            ILottoDrawingsService drawingsService = new LottoDrawingsService(repo);
            ISkipService skipService = new SkipService(drawingsService);

            var skipData = await skipService.GetSkipCountForAllNumbers();

            skipData.OrderBy(s => s.Number);

            Assert.IsNotNull(skipData);
            Assert.IsTrue(skipData.Count > 0);
        }
    }
}
