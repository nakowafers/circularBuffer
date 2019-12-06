using System;

namespace CircularBuffer
{
    public class RingBuffer<T>
    {
        private T[] _ringBuffer;
        private int _itemsAdded;
        private int _totalItemsInList;
        private int _oldestItemIndex;

        public RingBuffer(T[] array)
        {
            _ringBuffer = array;
            _itemsAdded = 0;
            _totalItemsInList = 0;
            _oldestItemIndex = 0;
        }

        public void Put(T item)
        {
            _ringBuffer[_itemsAdded++] = item;
            _totalItemsInList++;

            if (_itemsAdded == _ringBuffer.Length)
            {
                _itemsAdded = 0;
            }
        }

        public T Get()
        {
            if (_totalItemsInList.Equals(0))
            {
                throw new InvalidOperationException("No items in Circular Buffer!");
            }

            if (_oldestItemIndex >= _ringBuffer.Length)
            {
                _oldestItemIndex = 0;
            }

            int itemPosition = _oldestItemIndex;
            T valueToReturn = _ringBuffer[itemPosition];
            _totalItemsInList--;
            _oldestItemIndex++;

            return valueToReturn;
        }
    }
}
