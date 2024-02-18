using System;

class Program
{
    const int MAX_ROWS = 2;
    const int MAX_COLS = 2;

    static void Main()
    {
        int[,] matrix = new int[MAX_ROWS, MAX_COLS];
        int[,] result = new int[MAX_ROWS, MAX_COLS];
        int rows, cols;

        Console.Write("Masukkan jumlah baris: ");
        rows = int.Parse(Console.ReadLine());
        Console.Write("Masukkan jumlah kolom: ");
        cols = int.Parse(Console.ReadLine());

        Console.WriteLine("Masukkan elemen matriks :");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write($"Elemen [{i}][{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Matrix :");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        // operasi determinan
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                result[i, j] = (matrix[0][0].matrix[1][1]) - (matrix[0][1].matrix[1][0])
            }
        }
        Console.WriteLine("Hasil determinan matriks:");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}


