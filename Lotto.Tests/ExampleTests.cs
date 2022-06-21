using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq; // Mock library
using System;
using System.IO;
using System.Net;

namespace Lotto.Tests
{
    [TestClass]
    public class ExampleTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            var someData = 1;
            var expectedData = 1;

            Console.WriteLine("Debug data =D");
            Assert.AreEqual(expectedData, someData);
        }

        public interface IExample 
        {
            public int Example(int value);
        }

        public class ExampleClass : IExample 
        {
            public int Example(int value) 
            {
                return value;
            }
        }

        [TestMethod]
        public void MoqExampleTest()
        {
            var example = new Mock<IExample>();

            example
                .Setup(e => e.Example(It.IsAny<int>()))
                .Returns(It.IsAny<int>());

            Assert.AreEqual(It.IsAny<int>(), example.Object.Example(It.IsAny<int>()));
        }

        [TestMethod]
        public void MoqExampleTest2()
        {
            var example = new Mock<IExample>();

            int sampleData = 1;

            var expectedData = () => { return 1; };

            example.Setup(e => e.Example(sampleData)).Returns(expectedData);

            Assert.AreEqual(sampleData, example.Object.Example(sampleData));

            example.Verify(e => e.Example(It.IsAny<int>()), Times.Exactly(1));   
        }

        [TestMethod]
        public void DownloadLottoData() 
        {
            // https://www.texaslottery.com/export/sites/lottery/Games/Mega_Millions/Winning_Numbers/megamillions.csv
            using (var client = new WebClient())
            {
                client.DownloadFile("https://www.texaslottery.com/export/sites/lottery/Games/Mega_Millions/Winning_Numbers/megamillions.csv", "lottoDrawings.csv");
            }

            if (File.Exists("C:/data.csv"))
                File.Delete("C:/data.csv");
            File.Copy("lottoDrawings.csv", "C:/data.csv");
        }
    }
}