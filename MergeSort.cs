using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radixsort
{
  public class MergeSort
  {
    public static List<int> MergeSortAsc(List<int> toSort)
    {
      if(IsSorted(toSort))
      {
        return toSort;
      }
      int middle = toSort.Count / 2;
      List<int> left = toSort.Take(middle).ToList();
      List<int> right = toSort.Skip(middle).Take(toSort.Count - middle).ToList();

      left = MergeSortAsc(left);
      right = MergeSortAsc(right);

      return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
      List<int> _merged = new List<int>();

      int _leftIndex = 0;
      int _rightIndex = 0;

      while(_leftIndex < left.Count && _rightIndex < right.Count)
      {
        if(left[_leftIndex] <= right[_rightIndex])
        {
          _merged.Add(left[_leftIndex]);
          _leftIndex++;
        }
        else
        {
          _merged.Add(right[_rightIndex]);
          _rightIndex++;
        }
      }

      while(_leftIndex < left.Count)
      {
        _merged.Add(left[_leftIndex]);
        _leftIndex++;
      }

      while(_rightIndex < right.Count)
      {
        _merged.Add(right[_rightIndex]);
        _rightIndex++;
      }

      return _merged;
    }

    private static bool IsSorted(List<int> toSort)
    {

      if(toSort.Count <= 1)
      {
        return true;
      }

      for(int i = 1; i < toSort.Count; i++)
      {
        if(toSort[i] >= toSort[i - 1])
        {
          return false;
        }
      }

      return true;
    }
  }
}
