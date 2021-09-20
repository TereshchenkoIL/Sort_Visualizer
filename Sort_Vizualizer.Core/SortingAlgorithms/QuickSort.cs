using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class QuickSort : SortingAlgorithmBase
    {
        public override void Sort()
        {
            var arr = (int[])Items.Clone();

            Sort(0, arr.Length - 1, arr);
            SortedItems = arr;
        }
        private void Sort(int left, int right, int[] arr)
        {
            if (right <= left) return;

            int p = Partition(left, right, arr);
            Sort(left, p, arr);
            Sort(p + 1, right, arr);
        }
        private int Partition(int left, int right, int[] arr)
        {
            int i = left;
            int j = right - 1;
            OnColorItem(left, "Purple");
            while (true)
            {
                while (arr[++i] < arr[left])
                {
                    OnColorItem(i, "Blue");
                    OnSleep(400);
                    OnColorItem(i, "Coral");
                    if (i == right) break;
                }

                while (arr[left] < arr[--j])
                {
                    OnColorItem(j, "Blue");
                    OnSleep(400);
                    OnColorItem(j, "Coral");
                    if (j == left) break;
                }
                OnColorItem(j, "Orange");
                OnColorItem(i, "Orange");
                OnSleep(300);
                if (i >= j) break;

                Swap(i, j, arr);
            }

            Swap(left, j, arr);
            OnSleep(300);
            return j;
        }
    }
}
