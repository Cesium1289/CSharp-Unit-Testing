using System;
using FluentAssertions;
using Xunit;
using FakeItEasy;
using Serilog;

namespace Calculator
{
    public class LoggingCalculatorWorkerTests
    {
        [Fact]
        public void LoggingCalculatorWorker_AddIt_Success()
        {         
            var fakeLogger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(fakeLogger);
            int first = 10;
            int second = 20;
            var result  = calc.AddIt(first, second);
            A.CallTo(() => fakeLogger.Information($"Values: {first}, {second} were added. Result was {result}")).MustHaveHappened();
        }

        [Fact]
        public void LoggingCalculatorWorker_SubtractIt_Success()
        {
            var fakeLogger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(fakeLogger);
            int first = 40;
            int second = 20;
            var result = calc.SubtractIt(first, second);  
            A.CallTo(() => fakeLogger.Information($"Values: {second} was subtracted from {first}. Result was {result}")).MustHaveHappened();
        }

        [Fact]
        public void LoggingCalculatorWorker_MultiplyIt_Success()
        {
            var fakeLogger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(fakeLogger);
            int first = 10;
            int second = 20;
            var result = calc.MultiplyIt(first, second);
            A.CallTo(() => fakeLogger.Information($"Values: {first}, {second} were multiplied. Result was {result}")).MustHaveHappened();
        }

        [Fact]
        public void LoggingCalculatorWorker_DivideIt_Success()
        {
            var fakeLogger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(fakeLogger);
            int first = 5;
            int second = 60;
            var result = calc.DivideIt(first, second);
            A.CallTo(() => fakeLogger.Information($"Values: {first} divided by {second}. Result was {result}")).MustHaveHappened();
        }

        [Fact]
        public void LoggingCalculatorWorker_ModIt_Success()
        {
            var fakeLogger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(fakeLogger);
            int first = 7;
            int second = 36;
            var result = calc.ModIt(first, second);
            A.CallTo(() => fakeLogger.Information($"Values: {first} mod {second}. Result was {result}")).MustHaveHappened();
        }

        [Fact]
        public void LoggingCalculatorWorker_DivideIt_ThrowsWhenDenominatorIsZero()
        {
            var calc = new CalculatorWorker();
            Action action = () => calc.DivideIt(8, 0);
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("second");
        }

        [Fact]
        public void LoggingCalculatorWorker_ModIt_ThrowsWhenDenominatorIsZero()
        {
            var calc = new CalculatorWorker();
            Action action = () => calc.ModIt(36, 0);
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("second");
        }

        [Theory,
         InlineData(null),
         InlineData(""),
         InlineData("  ")]
        public void LoggingCalculatorWorker_FooIt_NullOrWhitespaceThrows(string bar)
        {
            var calc = new LoggingCalculatorWorker();
            Action action = () => calc.FooIt(bar);
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("bar");     
        }       
    }
}