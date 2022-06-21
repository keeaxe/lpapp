using Lotto.Data.Implementation;
using Lotto.Data.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Lotto.Tests.Repository
{
    [TestClass]
    public class LottoJSONRepositoryTests
    {
        [TestMethod]
        public void CanLoadLottoJSONRepository_Success() 
        {
            ILottoRepository repo = new LottoJSONRepository();

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public async Task CanLoadAllDrawings_Success() 
        {
            ILottoRepository repo = new LottoJSONRepository();

            var data = await repo.GetAllDrawings();

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        public async Task CanLoadAllDrawingsByYear_Success() 
        {
            ILottoRepository repo = new LottoJSONRepository();

            var data = await repo.GetDrawingsByYear(2021);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count > 0);

            foreach (var drawing in data) 
            {
                Assert.AreEqual(drawing.Year, 2021);
            }
        }

        [TestMethod]
        public async Task CanLoadAllDrawingsByYearAndMonth_Success() 
        {
            ILottoRepository repo = new LottoJSONRepository();

            var data = await repo.GetDrawingsByYearAndMonth(2021, 1);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count > 0);

            foreach (var drawing in data) 
            {
                Assert.AreEqual(drawing.Year, 2021);
                Assert.AreEqual(drawing.Month, 1);
            }
        }
    }
}
