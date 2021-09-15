using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class GnomeSort : SortingAlgorithmBase
    {
        public override void Sort()
        {
            var arr = (int[])Items.Clone();

            int index = 0;
            
            while(index < Length)
            {
                OnColorItem(index, "Purple");
                OnSleep(250);

                if (index == 0 || (arr[index - 1] < arr[index]))
                {
                    OnColorItem(index, "Green");
                    OnSleep(100);
                    index++;
                }
                else
                {
                    OnColorItem(index, "Orange");
                    OnColorItem(index -1 , "Orange");
                    OnSleep(300);
                    Swap(index - 1, index, arr);
                    OnColorItem(index, "Green");
                    OnColorItem(index - 1, "Green");
                    OnSleep(100);
                    index--;
                }
              
            }
            SortedItems = arr;

        }
    }
}
