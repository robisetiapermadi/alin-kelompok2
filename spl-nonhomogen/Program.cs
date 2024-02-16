﻿using System.Runtime.ExceptionServices;

namespace spl_nonhomogen;

class Program
{


  static void PrintMatrix(double[,] matrix)
  {
    int jumlahBaris = matrix.GetLength(0);
    int jumlahKolom = matrix.GetLength(1);

    for (int i = 0; i < jumlahBaris; i++)
    {
      for (int j = 0; j < jumlahKolom; j++)
      {
        Console.Write(matrix[i, j] + "\t");
      }
      Console.WriteLine();
    }
  }

  static double[,] KonversiToMatriks(double[,] persamaan, double[] konstanta, int banyakVariabel)
  {
    int kolom = banyakVariabel + 1;
    int baris = persamaan.GetLength(0);
    double[,] hasil = new double[baris, kolom];

    for (int i = 0; i < baris; i++)
    {
      for (int j = 0; j < kolom; j++)
      {
        if (j == kolom - 1) hasil[i, j] = konstanta[i];
        else hasil[i, j] = persamaan[i, j];

      }
    }
    return hasil;
  }

  static double[,] EliminasiGaussJordan(double[,] matriks)
  {
    int jumlahBaris = matriks.GetLength(0);
    int jumlahKolom = matriks.GetLength(1);

    double[,] matriksReduksi = matriks;


    for (int baris = 0; baris < jumlahBaris; baris++)
    {

      //mendefinisikan baris yang akan menjadi pivot
      int barisPivot = baris;


      // memastikan baris pivot bukan baris terakhir dan elemen diagonal pada baris pivot bukan 0, jika 0 maka akan mengganti pivot ke baris lain 
      while (barisPivot < jumlahBaris && matriksReduksi[barisPivot, baris] == 0)
      {
        barisPivot++;
      }

      //memastikan baris pivot bukan baris terakhir, jika baris terakhir maka sudahi iterasi
      if (barisPivot == jumlahBaris)
      {
        continue;
      }

      if (barisPivot != baris)
      {
        for (int kolom = 0; kolom < jumlahKolom; kolom++)
        {
          double temp = matriksReduksi[baris, kolom];
          matriksReduksi[baris, kolom] = matriksReduksi[barisPivot, kolom];
          matriksReduksi[barisPivot, kolom] = temp;
        }
      }

      double nilaiPivot = matriksReduksi[baris, baris];

      //melakukan transformasi elementer Bi(a) pada baris [pivot], dimana a nya merupakan 1/(elemen diagonal dari baris yang dijadikan pivot)
      for (int kolom = baris; kolom < jumlahKolom; kolom++)
      {
        matriksReduksi[baris, kolom] /= nilaiPivot;
      }

      //Console.WriteLine("Reduksi pada baris ke-{0}", baris + 1);
      //PrintMatrix(matriksReduksi);
      //Console.ReadKey();

      //melakukan transformasi elementer Bij(a) pada baris selain pivot, dimana j nya merupakan baris pivot dengan nilai a nya berupa -(elemen pada baris yang akan direduksi pada kolom yang sejajar dengan elemen diagonal pada baris pivot)
      for (int i = 0; i < jumlahBaris; i++)
      {
        if (i != baris)
        {
          double faktor = matriksReduksi[i, baris];
          for (int j = baris; j < jumlahKolom; j++)
          {
            matriksReduksi[i, j] -= faktor * matriksReduksi[baris, j];
          }
          //Console.WriteLine("Reduksi pada baris selain baris pivot, yaitu baris ke-{1}", baris + 1, i + 1);
          //PrintMatrix(matriksReduksi);
          //Console.ReadKey();
        }
      }



    }

    return matriksReduksi;

  }

  static void Main(string[] args)
  {
    int banyakPersamaan, banyakVariabel;

    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.Write("Masukkan banyak persamaan: ");
    banyakPersamaan = int.Parse(Console.ReadLine());

    Console.Write("Masukkan banyak variable pada setiap persamaan: ");
    banyakVariabel = int.Parse(Console.ReadLine());

    Console.WriteLine("\n-------------------------------------------------------------\n");

    double[,] persamaan = new double[banyakPersamaan, banyakVariabel];
    double[] konstanta = new double[banyakPersamaan];

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

    double[,] matriksAugmented = new double[banyakPersamaan, banyakVariabel + 1];

    matriksAugmented = KonversiToMatriks(persamaan, konstanta, banyakVariabel);

    Console.WriteLine("Matriks Augmented: ");
    PrintMatrix(matriksAugmented);


    double[,] matriksReduksi = EliminasiGaussJordan(matriksAugmented);

    Console.WriteLine("Matriks Reduksi: ");
    PrintMatrix(matriksReduksi);

  }

}
