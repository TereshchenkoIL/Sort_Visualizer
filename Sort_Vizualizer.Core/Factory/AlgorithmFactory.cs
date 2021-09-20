using Sort_Vizualizer.Core.Base;
using Sort_Vizualizer.Core.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Vizualizer.Core.Factory
{
    public class AlgorithmFactory
    {
        public static SortingAlgorithmBase Create(string type)
        {
            switch (type)
            {
                case "BubbleSort":
                    return new BubbleSort();
                case "QuickSort":
                    return new QuickSort();
                case "InsertionSort":
                    return new InsertionSort();
                case "SelectionSort":
                    return new SelectionSort();
                case "MergeSort":
                    return new MergeSort();
                case "HeapSort":
                    return new HeapSort();
                case "ShellSor":
                    return new ShellSort();
                case "CoctailSort":
                    return new CoctailSort();
                case "GnomeSort":
                    return new GnomeSort();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
