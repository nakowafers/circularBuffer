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

            T valueToReturn = default(T);

            for (var i = 0; i < _ringBuffer.Length; i++)
            {
                if (!_ringBuffer[i].Equals(default(T)))
                {
                     valueToReturn = _ringBuffer[i];

                    _ringBuffer[i] = default(T);

                    break;
                }
            }

            if (valueToReturn.Equals(default(T))){
                throw new InvalidOperationException("No items in Circular Buffer!");
            }

            return valueToReturn;
        }
    }
}
