using Lotto.Models.Dtos.LottoDrawings;
using Lotto.Models.LottoDrawings;
using Lotto.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lotto.Tests.Mappers
{
    [TestClass]
    public class ModelToDtoMappersTests
    {
        [TestMethod]
        public void CanMapLottoDrawingToLottoDrawingDto_Success() 
        {
            var lottoDrawings = new List<LottoDrawing>()
            {
                new LottoDrawing("Test", 1, 1, 2022, 1, 1, 1, 1, 1, 1, 1)
            };
            var lottoDrawingsDtos = new List<LottoDrawingsDto>() 
            {
                new LottoDrawingsDto() 
                {
                    Date = new DateTime(2022, 1, 1), 
                    Day = 1, 
                    LottoName = "Test", 
                    Mega = 1, 
                    Megaplier = 1, 
                    Month = 1, 
                    Number1 = 1, Number2 = 1, Number3 = 1, Number4 = 1, Number5 = 1, 
                    WinningNumbers = new List<int>() { 1, 1, 1, 1, 1 }, 
                    Year = 2022
                }
            };

            var result = lottoDrawings.Map();

            var expected = lottoDrawingsDtos[0];
            var actual = result[0];

            Assert.AreEqual(expected.LottoName, actual.LottoName);
            Assert.AreEqual(expected.Number1, actual.Number1);
            Assert.AreEqual(expected.Number2, actual.Number2);
            Assert.AreEqual(expected.Number3, actual.Number3);
            Assert.AreEqual(expected.Number4, actual.Number4);
            Assert.AreEqual(expected.Number5, actual.Number5);
            Assert.AreEqual(expected.Mega, actual.Mega);
            Assert.AreEqual(expected.Megaplier, actual.Megaplier);
            Assert.AreEqual(expected.WinningNumbers[0], actual.WinningNumbers[0]);
            Assert.AreEqual(expected.WinningNumbers[1], actual.WinningNumbers[1]);
            Assert.AreEqual(expected.WinningNumbers[2], actual.WinningNumbers[2]);
            Assert.AreEqual(expected.WinningNumbers[3], actual.WinningNumbers[3]);
            Assert.AreEqual(expected.WinningNumbers[4], actual.WinningNumbers[4]);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.Day, actual.Day);
            Assert.AreEqual(expected.Month, actual.Month);
            Assert.AreEqual(expected.Year, actual.Year);
        }
    }
}
