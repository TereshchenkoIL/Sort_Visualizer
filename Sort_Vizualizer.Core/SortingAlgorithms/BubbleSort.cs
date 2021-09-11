using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class BubbleSort : SortingAlgorithmBase
    {

        public override void Sort()
        {
            var arr = (int[])Items.Clone(); 

            for(int i = 0; i < Length; i++)
            {
                for(int j = 0; j < Length - i - 1; j++ )
                {
                    OnColorItem(i, "Orange");
                    OnColorItem(j, "Orange");
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(j, j + 1, arr);
                        
                    }
                    OnSleep(300);
                    OnColorItem(i, "Red");
                    OnColorItem(j, "Red");
                }
                OnColorItem(i, "Gray");
            }

            SortedItems = arr;
        }
    }
}
