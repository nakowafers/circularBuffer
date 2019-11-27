using NUnit.Framework;
using CircularBuffer;

namespace CircularBufferTests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Put_Number_FirstNumberIsInBuffer()
        {
            // arrange
            var array = new int [6];
            var circularBuffer = new RingBuffer<int>(array);

            // act
            circularBuffer.Put(20);

            // assert
            Assert.That(array[0], Is.EqualTo(20));
        }

        [Test]
        public void Put_TwoNumbers_TwoNumbersInBuffer()
        {
            // arrange
            var array = new int[6];
            var circularBuffer = new RingBuffer<int>(array);

            // act
            circularBuffer.Put(20);
            circularBuffer.Put(12);

            // assert
            Assert.That(array[0], Is.EqualTo(20));
            Assert.That(array[1], Is.EqualTo(12));

        }

        [Test]
        public void Put_SevenNumbers_OverwriteFirstNumber()
        {
            // arrange
            var array = new int[6];
            var circularBuffer = new RingBuffer<int>(array);

            // act
            circularBuffer.Put(20);
            circularBuffer.Put(21);
            circularBuffer.Put(22);
            circularBuffer.Put(23);
            circularBuffer.Put(24);
            circularBuffer.Put(25);
            circularBuffer.Put(99);

            // assert
            Assert.That(array[0], Is.EqualTo(99));

        }

        [Test]
        public void Get_Number_ReturnFirstNumber()
        {
            // arrange
            var array = new int[6] { 20, 21, 22, 23, 24, 25 };
            var circularBuffer = new RingBuffer<int>(array);

            // act
            var firstNumber = circularBuffer.Get();

            // assert
            Assert.That(firstNumber, Is.EqualTo(20));

        }

        [Test]
        public void Get_Number_ReturnSecondNumber()
        {
            // arrange
            var array = new int[6];
            var circularBuffer = new RingBuffer<int>(array);

            // act
            circularBuffer.Put(20);
            circularBuffer.Put(21);

            var firstNumber = circularBuffer.Get();
            var secondNumber = circularBuffer.Get();

            // assert
            Assert.That(firstNumber, Is.EqualTo(20));
            Assert.That(secondNumber, Is.EqualTo(21));

        }

        [Test]
        public void Get_DefaultValue_ReturnException()
        {
            // arrange
            var array = new int[6];
            var circularBuffer = new RingBuffer<int>(array);

            // act
            // assert

            Assert.Throws<System.InvalidOperationException>(() => circularBuffer.Get());
            //Assert.That(() => circularBuffer.Get(), Throws.InvalidOperationException);
        }

        [Test]
        public void Get_WhenAddedNumberIsDefaultValue_ReturnsAddedNumber()
        {
            int[] ringBufferArray = new int[6];
            var ringBuffer = new RingBuffer<int>(ringBufferArray);

            ringBuffer.Put(default);
            var returnedValue = ringBuffer.Get();

            Assert.That(returnedValue, Is.EqualTo(0));   
        }

        [Test]
        public void Put_WhenAddingMoreItemsThanBufferSize_ReturnsOldest()
        {
            int[] ringBufferArray = new int[3];
            var ringBuffer = new RingBuffer<int>(ringBufferArray);

            ringBuffer.Put(21);
            ringBuffer.Put(22);
            ringBuffer.Put(23); 
            ringBuffer.Put(24);

            Assert.That(ringBufferArray[0], Is.EqualTo(24));
        }
    }
}