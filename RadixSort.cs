using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAssignment2
{
  class RadixSort
  {
    public List<int> UnsortedList { get; set; }
    private List<int> _sortedList;
    public RadixSort(List<int> unsortedList)
    {
      UnsortedList = unsortedList;

    }

    public List<int> Sort()
    {
      _sortedList = new List<int>(UnsortedList);
      int _maxValue = GetMaximum();

      for(int _exponent = 1; _maxValue / _exponent > 0; _exponent *= 10)
      {
        CountingSort(_exponent);
      }
      return _sortedList;
    }
    /// <summary>
    /// Runs a counting sort on each digit of each value of the list.
    /// </summary>
    /// <param name="exponent">The digit to be sorted.</param>
    private void CountingSort(int exponent)
    {
      int[] _outputArr = new int[_sortedList.Count];
      int[] _occurences = new int[10];

      // Initialises the occurences of each digit to 0;
      for(int i = 0; i < 10; i++)
      {
        _occurences[i] = 0;
      }

      // Loops through each item in list and updates occurences based on place value.
      for(int i = 0; i < _sortedList.Count; i++)
      {
        _occurences[(_sortedList[i] / exponent) % 10]++;
      }

      // Shifts all values down a place.
      for(int i = 1; i < 10; i++)
      {
        _occurences[i] += _occurences[i - 1];
      }

      // Elements can be sorted based on exponent and are added to output array in correct position.
      for(int i = _sortedList.Count - 1; i >= 0; i--)
      {
        _outputArr[_occurences[(_sortedList[i] / exponent) % 10] - 1] = _sortedList[i];
        _occurences[(_sortedList[i] / exponent) % 10]--;
      }

      // Modifies unsorted list so that it now stores new slightly sorted values.
      for(int i = 0; i < _sortedList.Count; i++)
      {
        _sortedList[i] = _outputArr[i];
      }
    }

    private int GetMaximum()
    {
      // Randomly generated list cannot have negatives, thus can be used as a starting value to get max value in list.
      int _maxValue = -1;
      for(int i = 1; i < _sortedList.Count; i++)
      {
        if(_sortedList[i] > _maxValue)
        {
          _maxValue = _sortedList[i];
        }
      }
      return _maxValue;
    }
  }
}
