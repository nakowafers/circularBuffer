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
    }
}
