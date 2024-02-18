using System;

class Program
{
    const int MAX_ROWS = 100;
    const int MAX_COLS = 100;

    static void Main()
    {
        int[,] matrix1 = new int[MAX_ROWS, MAX_COLS];
        int[,] matrix2 = new int[MAX_ROWS, MAX_COLS];
        int[,] result = new int[MAX_ROWS, MAX_COLS];
        int rows, cols;

        Console.Write("Masukkan jumlah baris: ");
        rows = int.Parse(Console.ReadLine());
        Console.Write("Masukkan jumlah kolom: ");
        cols = int.Parse(Console.ReadLine());

        Console.WriteLine("Masukkan elemen matriks pertama:");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write($"Elemen [{i}][{j}]: ");
                matrix1[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Matrix 1:");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write(matrix1[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Masukkan elemen matriks kedua:");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write($"Elemen [{i}][{j}]: ");
                matrix2[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Matrix 2:");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write(matrix2[i, j] + " ");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        Console.WriteLine("Hasil penjumlahan matriks:");
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


