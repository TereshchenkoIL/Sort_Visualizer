using Sort_Vizualizer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.Base
{
    abstract class SortingAlgorithmBase : ISortingAlgorithm
    {
        public int[] Items { get; protected set; }

        public int[] SortedItems { get; protected set; }

        public int Length { get; protected set; }

        public event Action<int> Sleep;
        public event Action<int, string> ColorItem;
        public event Action<int, int> ItemsSwapped;

        public virtual void SetItems(int[] arr)
        {
            if(arr == null)
            {
                throw new ArgumentNullException();
            }

            Items = arr;
        }

        public virtual void Sort()
        {
            throw new NotImplementedException();
        }

        protected void Swap(int i, int j, int[] arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            ItemsSwapped?.Invoke(i, j);
        }

        protected virtual void OnSleep(int milliseconds)
        {
            Sleep?.Invoke(milliseconds);
        }

        protected virtual void OnColorItem(int index, string color)
        {
            ColorItem?.Invoke(index, color);
        }
    }
}
