using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAssignment2
{
  class RadixSort
  {
    /// <summary>
    /// Sorts a list according to Radix Sort.
    /// </summary>
    /// <param name="sortedList">List to sort.</param>
    /// <returns>Sorted list.</returns>
    public static List<int> Sort(List<int> sortedList)
    {
      int _maxValue = sortedList.Max();
      int _minValue = sortedList.Min();
      int _chosenVal;
      if(_maxValue >= Math.Abs(_minValue))
      {
        _chosenVal = _maxValue;
      }
      else
      {
        _chosenVal = Math.Abs(_minValue);
      }

      for(int _exponent = 1; _chosenVal / _exponent > 0; _exponent *= 10)
      {
        sortedList = CountingSort(_exponent, sortedList);
      }

      sortedList = GetOrdered(sortedList);
      return sortedList;
    }

    private static List<int> GetOrdered(List<int> sortedList) 
    {
      List<int> _negatives = sortedList.Where(item => item < 0).ToList();
      sortedList.RemoveAll(item => item < 0);
      _negatives.Reverse();
      _negatives.AddRange(sortedList);
      return _negatives;
    }
    /// <summary>
    /// Runs a counting sort on each digit of each value of the list.
    /// </summary>
    /// <param name="exponent">The digit to be sorted.</param>
    private static List<int> CountingSort(int exponent, List<int> sortedList)
    {
      int[] _outputArr = new int[sortedList.Count];
      int[] _occurences = new int[10];

      // Loops through each item in list and updates occurences based on place value.
      for(int i = 0; i < sortedList.Count; i++)
      {
        _occurences[Math.Abs((sortedList[i] / exponent) % 10)]++;
      }

      // works out cumulative spread of values.
      for(int i = 1; i < 10; i++)
      {
        _occurences[i] += _occurences[i - 1];
      }

      // Elements can be sorted based on exponent and are added to output array in correct position.
      for(int i = sortedList.Count - 1; i >= 0; i--)
      {
        _outputArr[_occurences[Math.Abs((sortedList[i] / exponent) % 10)] - 1] = sortedList[i];
        _occurences[Math.Abs((sortedList[i] / exponent) % 10)]--;
      }

      return _outputArr.ToList();
    }
  }
}
