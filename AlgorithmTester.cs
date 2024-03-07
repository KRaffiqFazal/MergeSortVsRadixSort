using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAssignment2
{
  /// <summary>
  /// Purpose of class is to test and evaluate sorting algorithm's time efficiency
  /// </summary>
  class AlgorithmTester
  {
    private int _trialsNeeded;
    private List<double> _results;
    private RadixSort _sortingAlgorithm;

    /// <summary>
    /// Creates an Algorithm tester which will test the Radix sort algorithm for a single list multiple times and return
    /// multiples values for the average lower, median and upper bound.
    /// </summary>
    /// <param name="testingValues">List of values to sort with radix sort.</param>
    /// <param name="numOfTrials">The number of trials the user wishes to test with.</param>
    public AlgorithmTester(List<int> testingValues, int numOfTrials)
    {
      // Efficiency will be divided into BigO, BigOmega and BigTheta, therefore must be divisible by 3 to work out bounds.
      if(numOfTrials % 3 != 0)
      {
        numOfTrials = numOfTrials + 3 - (numOfTrials % 3);
      }
      _trialsNeeded = numOfTrials;
      _sortingAlgorithm = new RadixSort(testingValues);
    }

    /// <summary>
    /// Works out the lower, median and upper bound averages of the sorting algorithm on a given list.
    /// </summary>
    /// <returns>Returns a list of 3 values: lower, median and upper bound.</returns>
    public List<double> Averages()
    {
      List<double> _finalAverages = new List<double>();
      _results = new List<double>();

      // Below loop tests radix sort for a given number of tests that is divisible by 3.
      for(int i = 0; i < _trialsNeeded - 2; i++)
      {
        _results.Add(IndividualTest());
      }
      _sortingAlgorithm.UnsortedList = _sortingAlgorithm.Sort();
      _results.Add(IndividualTest());
      _sortingAlgorithm.UnsortedList.Reverse();
      _results.Add(IndividualTest());


      _results.Sort();

      // Below code splits the now ordered averages into 3 sections to get averages, it also appends first value as lower bound and last value as upper bound.
      double _averageSegment = 0;

      _finalAverages.Add(Math.Round(_results[0], 5));

      for(int i = 1; i <= _trialsNeeded; i++)
      {
        _averageSegment += _results[i - 1];
        if(i % (_trialsNeeded / 3) == 0)
        {
          _finalAverages.Add(Math.Round(( _averageSegment / (_trialsNeeded / 3)), 5));
          _averageSegment = 0;
        }
      }
      _finalAverages.Add(Math.Round(_results[_results.Count - 1], 5));
      return _finalAverages;
    }
    /// <summary>
    /// Times the algorithm in nanoseconds with a stopwatch.
    /// </summary>
    /// <returns>The time it took for the algorithm to sort values.</returns>
    private double IndividualTest()
    {
      Stopwatch _algorithmTimer = new Stopwatch();
      _algorithmTimer.Start();
      _sortingAlgorithm.Sort();
      _algorithmTimer.Stop();
      
      return _algorithmTimer.Elapsed.TotalMilliseconds;
    }
  }
}
