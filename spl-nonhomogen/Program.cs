using System.Configuration.Assemblies;

namespace spl_nonhomogen;

class Program
{

  static void Main(string[] args)
  {
    int banyakPersamaan, banyakVariabel;
    Console.OutputEncoding = System.Text.Encoding.UTF8;


    Console.Write("Masukkan banyak persamaan: ");
    banyakPersamaan = int.Parse(Console.ReadLine());

    Console.Write("Masukkan banyak variable pada setiap persamaan: ");
    banyakVariabel = int.Parse(Console.ReadLine());

    Console.WriteLine("\n-------------------------------------------------------------\n");

    int[,] persamaan = new int[banyakPersamaan, banyakVariabel];
    int[] konstanta = new int[banyakPersamaan];

    for (int i = 0; i < banyakPersamaan; i++)
    {
      for (int j = 0; j < banyakVariabel; j++)
      {
        //input koefisien untuk variable ke-j pada persamaan ke-i
        Console.Write($"Masukkan koefisien untuk variabel x");
        Console.Write(char.ConvertFromUtf32(int.Parse("208" + (j + 1), System.Globalization.NumberStyles.HexNumber)));
        Console.Write($" pada persamaan ke-{i + 1}: ");

        persamaan[i, j] = int.Parse(Console.ReadLine());
      }
      //input konstanta untuk persamaan ke-i
      Console.Write($"Masukkan konstanta untuk persamaan ke-{i + 1}: ");
      konstanta[i] = int.Parse(Console.ReadLine());

      Console.WriteLine("\n-------------------------------------------------------------\n");
    }

    for (int i = 0; i < banyakPersamaan; i++)
    {
      for (int j = 0; j < banyakVariabel; j++)
      {
        //output-kan SPL-nya

        Console.Write($"{persamaan[i, j]}x");
        Console.Write(char.ConvertFromUtf32(int.Parse("208" + (j + 1), System.Globalization.NumberStyles.HexNumber)));
        Console.Write(" ");
        if (j == banyakVariabel - 1)
        {
          Console.Write("= {0}", konstanta[i]);
          Console.WriteLine();
        }
        else Console.Write("+ ");
      }
    }




  }

}
