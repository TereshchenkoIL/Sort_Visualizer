using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sort_Visualizer.Core.UnitTests.SortingAlgorithmsTests
{
    class SortingAlgorithmsTestData : IEnumerable<int[][]>
    {
        private int[] _result = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public IEnumerator<int[][]> GetEnumerator()
        {
            yield return new int[][]
            {
                 new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                _result
            };
            yield return new int[][]
            {
                 new int[]{12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                _result
            };
            yield return new int[][]
            {
                new int[]{ 4, 10, 2,1, 3, 6, 5, 8, 7, 12, 11, 9 },
                _result
            };
            yield return new int[][]
            {
                new int[]{ 4, 9, 5, 2, 6, 3, 12, 10, 8, 7, 11, 1 },
                _result
            };
            yield return new int[][]
            {
                new int[]{ 8, 9, 4, 6, 12, 2, 11, 7, 5, 3, 1, 10 },
                _result
            };
            yield return new int[][]
            {
                new int[]{ 2, 11, 9, 6, 3, 8,1, 10, 4, 12, 7, 5 },
                _result
            };
            yield return new int[][]
            {
                new int[]{ 1, 10, 11, 2, 9, 5, 6, 8, 12, 3, 7, 4 },
                _result
            };
            yield return new int[][]
           {
                new int[]{ 8, 9, 2, 4, 5, 10, 11, 3, 6, 12, 1, 7 },
                _result
           };
            yield return new int[][]
            {
                new int[]{ 9, 11, 6, 2, 7, 3, 5, 12,1, 10, 8, 4 },
                _result
            };

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
