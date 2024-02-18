namespace kombinasi_vektor_dimensi_basis;

class Program
{

  static void PrintSolusi(double[] solusiSet, int banyakVariabel)
  {
    Console.WriteLine("Penyelesaian:");

    for (int i = 0; i < banyakVariabel - 1; i++)
    {
      Console.Write("k");
      Console.Write(char.ConvertFromUtf32(int.Parse("208" + (i + 1), System.Globalization.NumberStyles.HexNumber)));
      Console.Write($" = {solusiSet[i]}, ");
    }

    Console.Write("k");
    Console.Write(char.ConvertFromUtf32(int.Parse("208" + (banyakVariabel), System.Globalization.NumberStyles.HexNumber)));
    Console.WriteLine($" = {solusiSet[banyakVariabel - 1]}, ");
  }

    static void PrintMatrix(double[,] matrix)
  {
    int jumlahBaris = matrix.GetLength(0);
    int jumlahKolom = matrix.GetLength(1);

    for (int i = 0; i < jumlahBaris; i++)
    {
      Console.Write("(");
      for (int j = 0; j < jumlahKolom; j++)
      {
        Console.Write(matrix[i, j] + "\t");
      }
      Console.WriteLine(")");
    }
  }

static int[] HitungRankDariMatriksTereduksi(double[,] matriksTereduksi){
    int jumlahBaris = matriksTereduksi.GetLength(0);
    int jumlahKolom = matriksTereduksi.GetLength(1);

    int[] rank = new int[2];
    
    rank[0] = jumlahBaris;
    rank[1] = jumlahBaris;
    
    int temp = 0;


    //hitung rank(A|B)
    for (int baris=0; baris< jumlahBaris; baris++){
      temp = 0;
      for (int kolom = 0; kolom<jumlahKolom; kolom++){
        if (matriksTereduksi[baris, kolom]!=0) continue;
        
        else if (matriksTereduksi[baris, kolom]==0)temp++;
        
        if (temp==jumlahKolom) rank[0]--;
      }
    }

    //hitung rank(A)
    for (int baris = 0; baris < jumlahBaris; baris++)
    {
      temp = 0;
      for (int kolom = 0; kolom < jumlahKolom-1; kolom++)
      {
        if (matriksTereduksi[baris, kolom] != 0) continue;

        else if (matriksTereduksi[baris, kolom] == 0) temp++;

        if (temp == jumlahKolom-1) rank[1]--;
      }
    }

    return rank;
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


  static double[] EkstrakSolusiSet(double[,] matriksTereduksi)
  {
    int jumlahBaris = matriksTereduksi.GetLength(0);
    int jumlahKolom = matriksTereduksi.GetLength(1);

    double[] solusiSet = new double[jumlahBaris];
    for (int baris = 0; baris < jumlahBaris; baris++)
    {
      solusiSet[baris] = matriksTereduksi[baris, jumlahKolom - 1];
    }

    return solusiSet;
  }

  //fungsi yang mengecek apakah vektorA merupakan kombinasi linear terhadap kumpulanVektor
  static bool CekKombinasiLinear(double[] vektorA, double[,] kumpulanVektor)
  {

    int jumlahBaris;
    int jumlahKolom;
    jumlahBaris = kumpulanVektor.GetLength(1);
    jumlahKolom = kumpulanVektor.GetLength(0);

    double[,] matrix = new double [jumlahBaris, jumlahKolom+1];
    double[,] matrixTereduksi = new double[jumlahBaris, jumlahKolom+1];

    if (vektorA.Length != kumpulanVektor.GetLength(1))
      return false; // Jika dimensi tidak cocok, bukan kombinasi linear

    //mengisi matriks dengan vektor-vektor b dan vektor a sebagai kolom terakhir
    for (int i = 0; i < jumlahBaris; i++){
      for (int j = 0 ; j < jumlahKolom; j++){
        matrix[i, j] = kumpulanVektor[j,i];
      }
      matrix[i, jumlahKolom] = vektorA[i];
    }

    //PrintMatrix(matrix);

    //menggunakan eliminasi Gauss-Jordan untuk mengecek apakah vektor a merupakan kombinasi linear dari vektor b
    matrixTereduksi = EliminasiGaussJordan(matrix);

    //PrintMatrix(matrixTereduksi);

    int rankA, rankB;


    rankA = HitungRankDariMatriksTereduksi(matrixTereduksi)[1];
    rankB = HitungRankDariMatriksTereduksi(matrixTereduksi)[0];

    double[] solusiSet = EkstrakSolusiSet(matrixTereduksi);

   if (rankA == rankB)
    {
      if (rankA < jumlahKolom)
      {
        Console.WriteLine("Karena persamaan terpenuhi, maka vektor yang akan diperiksa merupakan kombinasi linear dari kumpulan vektor. lebih lanjut, ada tak berhingga cara menuliskan vektor sebagai kombinasi linear dari kumpulan vektor tersebut");
      }
      else if (rankA == jumlahKolom)
      {
        Console.WriteLine("Karena persamaan terpenuhi, maka vektor yang akan diperiksa merupakan kombinasi linear dari kumpulan vektor");
        PrintSolusi(solusiSet, jumlahKolom);
      }
      return true;
    }
    else {
      Console.WriteLine("Karena persamaan tidak terpenuhi, maka vektor yang akan diperiksa merupakan bukan kombinasi linear dari kumpulan vektor");
      return false;

    }
    
  }

  static void Main(string[] args)
  {
    //variable a, merupakan vektor yang akan dicek
    //variable b, merupakan himpunan dari beberapa vektor
    double[] a = { 3, 5, 7 }; // Ganti dengan vektor a 
    double[,] b = { 
                    {1, 1, 2 },
                    {1, 0, 1 },
                    {2, 1, 3 }
                  }; // Ganti dengan vektor-vektor


    Console.WriteLine("Berikut untuk kumpulan vektornya: ");
    PrintMatrix(b);

    
    Console.WriteLine("Berikut untuk vektor yang akan diperiksa: ");
    Console.Write("(");
    for(int i =0 ; i<a.Length;i++)Console.Write("{0}\t", i);
    Console.WriteLine(")");

    Console.WriteLine("");


    bool hasilKombinasiLinear = CekKombinasiLinear(a, b);
  }
}
