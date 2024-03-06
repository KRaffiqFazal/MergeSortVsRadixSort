namespace AlgorithmsAssignment2
{
  internal class Program
  {
    static void Main(string[] args)
    {
      AlgorithmTester _newTest = new AlgorithmTester(RandomIntegerList.GenerateRandomList(1000), 5);
      _newTest = new AlgorithmTester(RandomIntegerList.GenerateRandomList(1000000), 15);

      List<double> _averages = new List<double>(_newTest.Averages());

      foreach(double average in _averages)
      {
        Console.WriteLine(average);
      }
    }
  }
}
