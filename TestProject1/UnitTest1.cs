using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public Task BasicText()
        {
            //Arrange 
            var mock = new Mock<IFoo>();
            mock.Setup(r => r.Process(It.IsAny<int>(), Operation.doubleVal)).Returns(1);
            mock.Setup(r => r.Process(It.IsAny<int>(), Operation.tripleVal)).Returns(2);
            mock.Setup(r => r.Process(It.IsAny<int>(), Operation.halveVal)).Returns(3);
            mock.Setup(r => r.Process(It.IsAny<int>(), Operation.specialVal)).Returns(4);

            var processor = new Processor(mock.Object);
            var number = 5;

            //Act 
            var x1 = processor.Process(number, Operation.doubleVal);
            var x2 = processor.Process(number, Operation.tripleVal);
            var x3 = processor.Process(number, Operation.halveVal);
            var x4 = processor.Process(number, Operation.specialVal); 

            //Assert 
            Assert.Equal(1, x1);
            Assert.Equal(2, x2);
            Assert.Equal(3, x3);
            Assert.Equal(4, x4);

            return Task.CompletedTask;
        }
    }

    public class Processor
    {
        IFoo _foo;
        public Processor(IFoo foo)
        {
            _foo = foo;
        }
        public decimal Process(int number, Operation operation)
        {
            return _foo.Process(number, operation);
        }
    }

    public interface IFoo
    {
        decimal Process(int number, Operation operation);
    }
    public class Foo : IFoo
    {
        public decimal Process(int number, Operation operation)
        {
            Func<int, decimal> operate  ;

            switch (operation)
            {
                case Operation.doubleVal:
                    operate = doubleVal;
                    break;
                case Operation.tripleVal:
                    operate = tripleVal;
                    break;
                case Operation.halveVal:
                    operate = halveVal;
                    break;
                default:
                    operate = specialVal;
                    break;
            }

            return operate(number);

            decimal doubleVal(int i) => (i * 2);
            decimal tripleVal(int i) => i * 3;
            decimal halveVal(int i) => i / 2;
            decimal specialVal(int i) => i / 2 * 7 + 4 * 3 / 5 / 3;
        }

    }

    public enum Operation
    {
        doubleVal,
        tripleVal,
        halveVal,
        specialVal
    }
}