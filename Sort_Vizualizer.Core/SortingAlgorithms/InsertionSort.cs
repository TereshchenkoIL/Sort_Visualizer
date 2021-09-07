using Sort_Vizualizer.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.SortingAlgorithms
{
    class InsertionSort : SortingAlgorithmBase
    {
        public override void Sort()
        {
            var arr = (int[]) Items.Clone();
            for (int i = 0; i < Length; i++)
            {
                
                OnColorItem(i, "Lime");
                OnSleep(250);
                for (int j = i; j > 0; j--)
                {
                    OnColorItem(i, "Purple");
                    OnSleep(150);
                    if (arr[j] < arr[j - 1])
                    {
                       
                        //    Set_Orange(j, j - 1);
                        OnColorItem(j, "Orange");
                        OnColorItem(j-1, "Orange");
                        Swap(j, j - 1, arr);
                        //      Thread.Sleep(300);
                        OnSleep(300);
                        //       Set_Gray(j - 1);
                        OnColorItem(j-1, "Gray");
                    }
                    //  Set_Gray(j);
                    OnColorItem(j, "Gray");
                }
            }
        }
    }
}
