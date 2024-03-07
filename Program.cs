namespace AlgorithmsAssignment2
{
  internal class Program
  {
    static void Main(string[] args)
    {
      AlgorithmTester _newTest = new AlgorithmTester(RandomIntegerList.GenerateRandomList(10), 9);
      _newTest = new AlgorithmTester(RandomIntegerList.GenerateRandomList(100000), 20);

      List<double> _averages = new List<double>(_newTest.Averages());

      Console.WriteLine("Radix Sort Statistics");
      Console.WriteLine($"The lower bound is: {_averages[0]}");
      Console.WriteLine($"The lower-average is: {_averages[1]}");
      Console.WriteLine($"The overall mean is:  {_averages[2]}");
      Console.WriteLine($"The upper-average is: {_averages[3]}");
      Console.WriteLine($"The upper bound is: {_averages[4]}");
    }
  }
}
