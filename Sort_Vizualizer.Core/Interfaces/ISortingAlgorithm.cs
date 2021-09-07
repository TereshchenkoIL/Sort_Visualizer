using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.Interfaces
{
    public interface ISortingAlgorithm
    {
        int[] Items { get; }

        int[] SortedItems { get;  }

        int Length { get; }

        event Action<int> Sleep;

        event Action<int, string> ColorItem;

        event Action<int, int> ItemsSwapped;
        void Sort();

        void SetItems(int[] arr);
    }
}
