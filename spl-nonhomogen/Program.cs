namespace spl_nonhomogen;

class Program
{

  static void testFunction()
  {
    Console.WriteLine("asd is your nasdame?");
    var name = Console.ReadLine();
    var currentDate = DateTime.Now;
    Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
    Console.Write($"{Environment.NewLine}Press any key to exit...");
    Console.ReadKey(true);

  }

  static void Main(string[] args)
  {
    
  }
}
