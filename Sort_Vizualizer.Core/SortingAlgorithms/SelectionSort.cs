using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class SelectionSort : SortingAlgorithmBase
    {
        public override void Sort()
        {
            var arr = (int[])Items.Clone();

            for(int i = 0; i < Length - 1; i++)
            {
                int indexOfMin = i;
                OnColorItem(i, "Purple");
                OnSleep(100);
                for(int j = i+1; j < Length; j++)
                {
                    OnColorItem(j, "Blue");
                    OnSleep(100);
                    if (arr[j] < arr[indexOfMin])
                    {
                        indexOfMin = j;
                    }
                    OnColorItem(j, "Green");
                    OnSleep(100);
                }
                OnColorItem(indexOfMin, "Red");
                OnSleep(300);
                OnColorItem(i, "Orange");
                OnColorItem(indexOfMin, "Orange");
                Swap(indexOfMin, i, arr);
                OnSleep(300);
            }

            SortedItems = arr;
        }
    }
}
