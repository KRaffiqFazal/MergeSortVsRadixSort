using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAssignment2
{
  class RandomIntegerList
  {
    /// <summary>
    /// Generates a random list of integers of a given size.
    /// </summary>
    /// <param name="size">Size of list with random values to sort.</param>
    /// <returns>A list of unsorted random values of a given size that the user has specified.</returns>
    public static List<int> GenerateRandomList(int size)
    {
      List<int> _randomList = new List<int>();
      Random _randomNumber = new Random();
      for(int i = 1; i <= size; i++)
      {
        _randomList.Add(_randomNumber.Next(-size, size));
      }
      return _randomList;
    }
  }
}
