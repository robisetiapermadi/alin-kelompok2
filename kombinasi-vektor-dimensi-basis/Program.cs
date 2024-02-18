namespace kombinasi_vektor_dimensi_basis;

class Program
{

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

  //fungsi yang mengecek apakah vektorA merupakan kombinasi linear terhadap kumpulanVektor
  static bool CekKombinasiLinear(int[] vektorA, int[][] kumpulanVektor)
  {
    if (vektorA.Length != kumpulanVektor[0].Length)
      return false; // Jika dimensi tidak cocok, bukan kombinasi linear

    double[,] matrix = new int[kumpulanVektor.Length, kumpulanVektor[0].Length + 1];
    int[,] matrixTereduksi = new int[kumpulanVektor.Length, kumpulanVektor[0].Length + 1];

    //mengisi matriks dengan vektor-vektor b dan vektor a sebagai kolom terakhir
    for (int i = 0; i <=kumpulanVektor.Length; i++)
    {
      for (int j = 0; j < kumpulanVektor[i].Length; j++)
      {
        matrix[i, j] = kumpulanVektor[i][j];
      }
      matrix[i, kumpulanVektor[i].Length] = vektorA[i];
    }

    //menggunakan eliminasi Gauss-Jordan untuk mengecek apakah vektor a merupakan kombinasi linear dari vektor b
    matrixTereduksi = EliminasiGaussJordan(matrix);

    //memeriksa apakah semua elemen di kolom terakhir (vektor a) menjadi nol
    for (int i = 0; i < kumpulanVektor.Length; i++)
    {
      if (matrixTereduksi[i, vektorA.Length] != 0)
        return false; // Jika ada elemen non-nol, bukan kombinasi linear
    }

    return true;
  }


  static void Main(string[] args)
  {
    //variable a, merupakan vektor yang akan dicek
    //variable b, merupakan himpunan dari beberapa vektor

    Console.WriteLine("test");

    int[] a = { 1, 2, 3 }; // Ganti dengan vektor a Anda
    int[][] b = {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        }; // Ganti dengan vektor-vektor b Anda

    bool hasilKombinasiLinear = CekKombinasiLinear(a, b);

    Console.WriteLine("Apakah vektor a merupakan kombinasi linear dari sekumpulan vektor b: ");
    Console.WriteLine(hasilKombinasiLinear ? "Ya" : "Tidak");
  }
}
