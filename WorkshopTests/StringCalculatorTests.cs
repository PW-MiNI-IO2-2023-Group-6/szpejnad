using Workshp2023Tests;

namespace WorkshopTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.Calculate("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("0", 0)]
        [InlineData("121", 121)]
        [InlineData("48", 48)]
        public void StringWithNumberReturnsItsValue(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12,12", 24)]
        [InlineData("1,0", 1)]
        //[InlineData("12,-12", 0)]
        //[InlineData("-8,-4", -12)]
        //[InlineData("8,-4", 4)]
        public void TwoNumberWithCommaSeparatorReturnSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n12", 24)]
        [InlineData("1\n0", 1)]
        //[InlineData("12\n-12", 0)]
        //[InlineData("-8\n-4", -12)]
        //[InlineData("8\n-4", 4)]
        public void TwoNumberWithNewLineSeparatorReturnSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n12\n12", 36)]
        [InlineData("1\n0,1", 2)]
        //[InlineData("12,-12,3", 3)]
        //[InlineData("-8,-4\n2\n2", -8)]
        //[InlineData("8\n-4,1,1", 6)]
        public void ManyNumberWithNewLineOrCommaSeparatorReturnSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n12\n12", 36)]
        [InlineData("1001", 0)]
        [InlineData("1002\n1", 1)]
        [InlineData("1000", 1000)]
        [InlineData("1000, 1, 2", 1003)]
        public void NumberBiggerThanThousandIgnored(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n-12\n12")]
        [InlineData("-1001")]
        [InlineData("1002\n-1")]
        [InlineData("-10")]
        [InlineData("1000, -1, 2")]
        [InlineData("1000, -3, 2")]
        public void ThrowErrorIfThereIsNegativeNumber(string str)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Calculate(str));
        }

        [Theory]
        [InlineData("//g\n12g12", 24)]
        [InlineData("//X\n0X1X3", 4)]
        [InlineData("//X\n12", 12)]
        [InlineData("//X\n7X0X0X0X0X0X1", 8)]
        [InlineData("//X\n", 0)]
        public void CodeAtTheBeginningOfStringChangeSeparator(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }
    }
}