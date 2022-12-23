using FakeItEasy;
using Xunit;
using FluentAssertions;

namespace Calculator
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_Call_Success()
        {
            ICalculatorWorker worker = A.Fake<ICalculatorWorker>();

            // Inject in constructor
            //var calc = new Calculator(worker);

            // Inject via property
            //var calc = new Calculator(new CalculatorWorker());
            //calc.Worker = worker;

            // Inject via method
            Calculator calc = new Calculator(new CalculatorWorker());
            calc.SetWorker(worker);
            calc.Add(2, 2);          
            A.CallTo(() => worker.AddIt(2, 2)).MustHaveHappenedOnceExactly();
        }


        [Fact]
        public void Calculator_Subtract_Call_Success()
        {
            ICalculatorWorker worker = A.Fake<ICalculatorWorker>();
            Calculator calc = new Calculator(worker);
            calc.Subtract(20, 10);
            A.CallTo(() => worker.SubtractIt(20, 10)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Calculator_Multiply_Call_Success()
        {
            ICalculatorWorker worker = A.Fake<ICalculatorWorker>();
            Calculator calc = new Calculator(worker);
            calc.Multiply(5, 10);
            A.CallTo(() => worker.MultiplyIt(5, 10)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Calculator_Divide_Call_Success()
        {
            ICalculatorWorker worker = A.Fake<ICalculatorWorker>();
            Calculator calc = new Calculator(worker);
            calc.Divide(40, 20);
            A.CallTo(() => worker.DivideIt(40, 20)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Calculator_Mod_Call_Success()
        {
            ICalculatorWorker worker = A.Fake<ICalculatorWorker>();
            Calculator calc = new Calculator(worker);
            calc.Mod(21, 7);
            A.CallTo(() => worker.ModIt(21, 7)).MustHaveHappened();
        }
    }
}
