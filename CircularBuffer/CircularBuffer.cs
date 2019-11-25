using System;

namespace CircularBuffer
{
    public class RingBuffer<T>
    {
        private T[] _ringBuffer;
        private int _itemsAdded;
        public RingBuffer(T[] array)
        {
            _ringBuffer = array;
            _itemsAdded = 0;
        }

        public void Put(T item)
        {

            _ringBuffer[_itemsAdded++] = item;


            if (_itemsAdded > 5)
            {
                _itemsAdded = 0;
            }
        }

        public T Get()
        {
            T defaultValue = default;
            T valueToReturn = default;

            for (var i = 0; i < _ringBuffer.Length; i++)
            {
                if (!_ringBuffer[i].Equals(defaultValue))
                {
                     valueToReturn = _ringBuffer[i];

                    _ringBuffer[i] = defaultValue;

                    break;
                }
            }

            if (valueToReturn.Equals(defaultValue))
            {
                throw new InvalidOperationException("No items in Circular Buffer!");
            }

            return valueToReturn;
        }
    }
}
