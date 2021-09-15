using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class CoctailSort : SortingAlgorithmBase
    {
        public override void Sort()
        {
            var arr = (int[])Items.Clone();

            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        OnColorItem(i, "Orange");
                        OnColorItem(i + 1, "Orange");
                    
                        OnSleep(100);
                        Swap(i, i + 1, arr);
                        OnColorItem(i, "Green");
                        OnColorItem(i + 1, "Green");
                        OnSleep(300);
                    }
                }
                OnColorItem(right, "Purple");
                OnSleep(100);
                right -= 1;
                for (int i = right; i > left; i--)
                {

                    if (arr[i] < arr[i - 1])
                    {
                        OnColorItem(i, "Orange");
                        OnColorItem(i - 1, "Orange");
                        OnSleep(100);
                        Swap(i, i - 1, arr);
                        OnColorItem(i, "Green");
                        OnColorItem(i - 1, "Green");
                        OnSleep(300);
                    }
                }
                OnColorItem(left, "Purple");
                left += 1;



            }
            OnColorItem(left, "Purple");
            SortedItems = arr;
        }
    }
}
