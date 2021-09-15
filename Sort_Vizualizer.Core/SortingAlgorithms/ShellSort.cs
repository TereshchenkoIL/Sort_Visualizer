using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class ShellSort : SortingAlgorithmBase
    {
        public override void Sort()
        {
            var arr = (int[])Items.Clone();

            int h = 1;
            while (h < Length / 3) h = 3 * h + 1;

            while(h >= 1)
            {
                for(int i = h; i < Length; i++)
                {
                    for(int j = i; j >= h && arr[j] < arr[j - h]; j -= h)
                    {
                        OnColorItem(j, "Orange");
                        OnColorItem(j - h, "Orange");
                        OnSleep(100);
                        Swap(j, j - h, arr);
                        OnSleep(250);
                        OnColorItem(j, "Green");
                        OnColorItem(j - h, "Green");

                    }
                }
                h = h / 3;
            }

            SortedItems = arr;
        }
    }
}
