using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class MergeSort : SortingAlgorithmBase
    {
        public override void Sort()
        {
            var arr = (int[])Items.Clone();

            var aux = (int[])Items.Clone();

            Sort(0, Length - 1, arr, aux);

            SortedItems = arr;

        }
        private void Sort(int left, int right, int[] arr, int[] aux)
        {
            if (right <= left) return;
            int mid = left + (right - left) / 2;
            Sort(left, mid, arr, aux);
            Sort(mid + 1, right, arr, aux);
            Merge(left, mid, right, arr, aux);
        }

        private void Merge(int left, int mid, int right, int[] arr, int[] aux)
        {
            for (int k = left; k <= right; k++)
            {
                aux[k] = arr[k];
            }

            int i = left;
            int j = mid + 1;

            for (int k = left; k <= right; k++)
            {
                if (i > mid) arr[k] = aux[j++];
                else if (j > right) arr[k] = aux[i++];
                else if (aux[j] < aux[i]) arr[k] = aux[j++];
                else arr[k] = aux[i++];
            }

           

        }
    }
}
