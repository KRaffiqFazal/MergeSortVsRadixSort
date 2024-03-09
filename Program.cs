namespace AlgorithmsAssignment2
{
  internal class Program
  {
    static void Main(string[] args)
    {
      if(args.Length != 2)
      {
        Console.WriteLine("Please provide 2 command line arguments: number of testing values and number of trials.");
        Environment.Exit(0);
      }
      if(!int.TryParse(args[0], out int _numOfValues))
      {
        Console.WriteLine("Please provide integer for number of testing values.");
        Environment.Exit(0);
      }
      if(!int.TryParse(args[0], out int _numOfTrials))
      {
        Console.WriteLine("Please provide integer for number of trials.");
        Environment.Exit(0);
      }

      AlgorithmTester _newTest = new AlgorithmTester(RandomIntegerList.GenerateRandomList(_numOfValues), _numOfTrials);
      List<double> _averages = new List<double>(_newTest.Averages());

      Console.WriteLine("Radix Sort Statistics");
      Console.WriteLine($"The lower bound is: {_averages[0] / 1000000}");
      Console.WriteLine($"The lower-average is: {_averages[1] / 1000000}");
      Console.WriteLine($"The overall mean is:  {_averages[2] / 1000000}");
      Console.WriteLine($"The upper-average is: {_averages[3] / 1000000}");
      Console.WriteLine($"The upper bound is: {_averages[4] / 1000000}");
    }
  }
}
