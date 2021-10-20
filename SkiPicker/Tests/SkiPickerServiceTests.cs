using Xunit;
using SkiPicker.Services;
using SkiPicker.Models;
using System;

namespace SkiPicker.UnitTests.Services
{
    public class SkiPickerService_Tests
    {
        public class MockRandom : Random
        {
            int ReturnValue;

            public MockRandom(int returnValue)
            {
                ReturnValue = returnValue;
            }
            public override int Next(int val)
            {
                return ReturnValue;
            }

        }

        [Fact]
        public void CalculateSkiLength_InputIsAge13Height150Classic_ResultIs170()
        {
            int expectedResult = 170;
            var mockRandom = new MockRandom(100);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(13, 150, SkiInfo.SkiTypes.Classic);

            var result = skiService.CalculateSkiLength(info);

            Assert.True(result == expectedResult, "Result should be 180");
        }

        [Fact]
        public void CalculateSkiLength_InputIsAge13Height150Freestyle_ResultIs165()
        {
            int expectedResult = 165;
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(13, 150, SkiInfo.SkiTypes.Freestyle);

            var result = skiService.CalculateSkiLength(info);

            Assert.True(result == expectedResult, "Result should be 180");
        }

        [Fact]
        public void CalculateSkiLength_InputIsAge9Height100Freestyle_ResultIs115()
        {
            int expectedResult = 115;
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(9, 100, SkiInfo.SkiTypes.Freestyle);

            var result = skiService.CalculateSkiLength(info);

            Assert.True(result == expectedResult, "Result should be 115");
        }

        [Fact]
        public void CalculateSkiLength_InputIsAge3Height100Freestyle_ResultIs100()
        {
            int expectedResult = 100;
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(3, 100, SkiInfo.SkiTypes.Freestyle);

            var result = skiService.CalculateSkiLength(info);

            Assert.True(result == expectedResult, "Result should be 100");
        }

        [Fact]
        public void CalculateSkiLength_InputIsAge25Height230Classic_ResultIs207()
        {
            int expectedResult = 207;
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(25, 230, SkiInfo.SkiTypes.Classic);

            var result = skiService.CalculateSkiLength(info);

            Assert.True(result == expectedResult, "Result should be 207");
        }

        [Fact]
        public void CalculateSkiLength_InputIsAge25Height230Freestyle_ResultIs245()
        {
            int expectedResult = 245;
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(25, 230, SkiInfo.SkiTypes.Freestyle);

            var result = skiService.CalculateSkiLength(info);

            Assert.True(result == expectedResult, "Result should be 245");
        }


        [Fact]
        public void CalculateSkiLength_InputIsAge0Height0Freestyle_ResultIs0()
        {
            int expectedResult = 0;
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(0, 0, SkiInfo.SkiTypes.Freestyle);

            var result = skiService.CalculateSkiLength(info);

            Assert.True(result == expectedResult, "Result should be 0");
        }

        [Fact]
        public void CalculateSkiLength__Age3Height100ClassicAndFreestyle_ClassicEqualsFreestyleLength()
        {
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo infoFreestyle = new SkiInfo(3, 100, SkiInfo.SkiTypes.Freestyle);
            SkiInfo infoClassic = new SkiInfo(3, 100, SkiInfo.SkiTypes.Classic);

            var resultFreestyle = skiService.CalculateSkiLength(infoFreestyle);
            var resultClassic = skiService.CalculateSkiLength(infoClassic);

            Assert.True(resultFreestyle == resultClassic, "Result should be 0");
        }

        [Fact]
        public void CalculateSkiLength__Age7Height100ClassicAndFreestyle_ClassicEqualsFreestyleLength()
        {
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo infoFreestyle = new SkiInfo(7, 100, SkiInfo.SkiTypes.Freestyle);
            SkiInfo infoClassic = new SkiInfo(7, 100, SkiInfo.SkiTypes.Classic);

            var resultFreestyle = skiService.CalculateSkiLength(infoFreestyle);
            var resultClassic = skiService.CalculateSkiLength(infoClassic);

            Assert.True(resultFreestyle == resultClassic, "Result should be 0");
        }

        [Fact]
        public void CalculateSkiLength__Age10Height100ClassicAndFreestyle_ClassicNotEqualsFreestyleLength()
        {
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo infoFreestyle = new SkiInfo(10, 100, SkiInfo.SkiTypes.Freestyle);
            SkiInfo infoClassic = new SkiInfo(10, 100, SkiInfo.SkiTypes.Classic);

            var resultFreestyle = skiService.CalculateSkiLength(infoFreestyle);
            var resultClassic = skiService.CalculateSkiLength(infoClassic);

            Assert.True(resultFreestyle != resultClassic, "Result should be 0");
        }

        [Fact]
        public void CalculateSkiLength_InputIsNull_ThrowsError()
        {
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);

            Assert.Throws<ArgumentNullException>(() => skiService.CalculateSkiLength(null));
        }

        [Fact]
        public void CalculateSkiLength_InputIsAgeMinus1_ThrowsError()
        {
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(-1, 150, SkiInfo.SkiTypes.Freestyle);

            Assert.Throws<ArgumentException>(() => skiService.CalculateSkiLength(info));
        }

        [Fact]
        public void CalculateSkiLength_InputIsHeightMinus1_ThrowsError()
        {
            var mockRandom = new MockRandom(5);
            var skiService = new SkiPickerService(null, mockRandom);
            SkiInfo info = new SkiInfo(13, -1, SkiInfo.SkiTypes.Freestyle);

            Assert.Throws<ArgumentException>(() => skiService.CalculateSkiLength(info));
        }
    }
}
