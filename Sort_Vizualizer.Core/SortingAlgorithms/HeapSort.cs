using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class HeapSort : SortingAlgorithmBase
    {
       
        public override void Sort()
        {
            var arr = (int[])Items.Clone();
            BuildHeap(arr);

            int end = Length - 1;

            while(end >= 0)
            {
                OnSleep(300);
                OnColorItem(0, "Orange");
                OnColorItem(end, "Orange");
                OnSleep(100);
                Swap(0, end, arr);
                OnColorItem(0, "Green");
                OnColorItem(end, "Green");
                Sink(0, arr, end);
                end -= 1;
            }

            SortedItems = arr;
        }

        private void Sink(int k, int[] arr, int n )
        {
            while(k < n)
            {
                int j = 2 * k + 1;

                if (j < n - 1 && arr[j] < arr[j + 1]) j++;
                if (j >= n || arr[k] >= arr[j]) break;
                OnColorItem(k, "Orange");
                OnColorItem(j, "Orange");
                OnSleep(300);
                Swap(k, j, arr);
                OnSleep(300);
                OnColorItem(k, "Green");
                OnColorItem(j, "Green");
                k = j;
            }
        }

        private void BuildHeap(int[] arr)
        {
            int index = Length / 2 - 1;

            while(index >= 0)
            {
                OnColorItem(index, "Purple");
                OnSleep(100);
                Sink(index, arr, Length);
                OnColorItem(index, "Green");
                OnSleep(100);
                index--;
            }
        }
    }
}
