using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;


public class PencatatStatusGunungBerapi
{
    static DateTime waktu = DateTime.Now;
    public static string dataStatusGunung;
    public static void Main()
    {
        int pilihMenu;

        while (true)
        {
            Console.Clear();
            DataAwal();
            pilihMenu = Menu();
            MenuChoosed(pilihMenu);
        }

    }

    static int Menu()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("|         Menu Utama         |");
        Console.WriteLine("| 1. Cek Status Gunung       |");
        Console.WriteLine("| 2. History Status Gunung   |");
        Console.WriteLine("| 3. Reset Status Gunung     |");
        Console.WriteLine("| 4. Exit                    |");
        Console.WriteLine("==============================");
        Console.Write("  Pilih : ");
        int pilihMenu = Convert.ToInt32(Console.ReadLine());

        return pilihMenu;
    }

    public static void MenuChoosed(int menuNumber)
    {
        switch (menuNumber)
        {
            case 1:
                {
                    Console.Clear();
                    CheckStatusGunung();
                    break;
                }
            case 2:
                {
                    Console.Clear();
                    InputStatusGunung();
                    break;
                }
            case 3:
                {
                    Console.Clear();
                    ResetStatusGunung();
                    break;
                }
            case 4:
                {
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.WriteLine("Pilihan tidak ada! Silahkan pilih kembali...");
                    break;
                }
        }
    }
    public static void CheckStatusGunung()
    {

        Console.WriteLine("=======================================");
        Console.WriteLine("=      Insert Data Status Gunung      =");
        Console.WriteLine("=======================================");
        Console.WriteLine();
        Console.Write("Berapakah besar magnitudo gempa : ");
        double magnitudoGempa = Convert.ToDouble(Console.ReadLine());

        Console.Write("Apakah ada awan panas (Y/N) : ");
        char awanPanas = Console.ReadKey().KeyChar;

        Console.Write("\nBerapakah suhunya (C) : ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapakah kelembapan udaranya (0-35%) : ");
        double kelembapan = Convert.ToDouble(Console.ReadLine());

        Console.Write("Apakah muncul gas berbahaya (Y/N) : ");
        char gasBerbahaya = Console.ReadKey().KeyChar;

        Console.Write("\nApakah ada Lahar Letusan (Y/N) : ");
        char laharLetusan = Console.ReadKey().KeyChar;

        Console.Write("\nApakah ada Lava (Y/N) : ");
        char lava = Console.ReadKey().KeyChar;

        Console.Write("\nApakah ada Lontaran Batu Pijar (Y/N) : ");
        char batuPijar = Console.ReadKey().KeyChar;

        Console.Write("\nApakah ada hujan abu (Y/N) : ");
        char hujanAbu = Console.ReadKey().KeyChar;
        Console.WriteLine();

        string statusGunung = " ";
        string strMagnitudoGempa = magnitudoGempa.ToString();
        string strSuhu = suhu.ToString();
        string strKelembapan = kelembapan.ToString();
        string strAwanPanas, strGasBerbahaya, strLaharLetusan, strLava, strBatuPijar, strHujanAbu;

        if (awanPanas.ToString().ToUpper() == "N")
        {
            strAwanPanas = "tidak";
        }
        else
        {
            strAwanPanas = "ya";
        }

        if (gasBerbahaya.ToString().ToUpper() == "N")
        {
            strGasBerbahaya = "tidak";
        }
        else
        {
            strGasBerbahaya = "ya";
        }

        if (laharLetusan.ToString().ToUpper() == "N")
        {
            strLaharLetusan = "tidak";
        }
        else
        {
            strLaharLetusan = "ya";
        }

        if (lava.ToString().ToUpper() == "N")
        {
            strLava = "tidak";
        }
        else
        {
            strLava = "ya";
        }

        if (batuPijar.ToString().ToUpper() == "N")
        {
            strBatuPijar = "tidak";
        }
        else
        {
            strBatuPijar = "ya";
        }

        if (hujanAbu.ToString().ToUpper() == "N")
        {
            strHujanAbu = "tidak";
        }
        else
        {
            strHujanAbu = "ya";
        }

        //cek status gunung
        if (magnitudoGempa < 2.9 && awanPanas.ToString().ToUpper() == "N" && suhu >= 0 && suhu <= 32
            && kelembapan >= 15 && kelembapan <= 35 && gasBerbahaya.ToString().ToUpper() == "N"
            && laharLetusan.ToString().ToUpper() == "N" && lava.ToString().ToUpper() == "N" &&
            batuPijar.ToString().ToUpper() == "N" && hujanAbu.ToString().ToUpper() == "N")
        {
            statusGunung = "NORMAL_Level_1";
            Console.WriteLine("Status Gunung Berapi : NORMAL");
            Console.ReadKey();

        }
        else if (magnitudoGempa >= 2.9 && magnitudoGempa <= 3.9 && awanPanas.ToString().ToUpper() == "Y"
            && suhu >= 33 && suhu <= 37 && kelembapan >= 10 && kelembapan <= 14 && gasBerbahaya.ToString().ToUpper() == "Y"
            && laharLetusan.ToString().ToUpper() == "N" && lava.ToString().ToUpper() == "N" &&
            batuPijar.ToString().ToUpper() == "N" && hujanAbu.ToString().ToUpper() == "N")
        {
            statusGunung = "WASPADA_Level_2";
            Console.WriteLine("Perlu disiapkan masker sebanyak penduduk yang ada");
            Console.ReadKey();

        }
        else if (magnitudoGempa >= 4.0 && magnitudoGempa <= 5.2 && awanPanas.ToString().ToUpper() == "Y"
            && suhu >= 38 && suhu <= 40 && kelembapan >= 5 && kelembapan <= 9 && gasBerbahaya.ToString().ToUpper() == "Y"
            && laharLetusan.ToString().ToUpper() == "N" && lava.ToString().ToUpper() == "N" &&
            batuPijar.ToString().ToUpper() == "Y" && hujanAbu.ToString().ToUpper() == "Y")
        {
            statusGunung = "SIAGA_Level_3";
            Console.WriteLine("Status Gunung Berapi : WASPADA");
            Console.WriteLine("Perlu disiapkan masker sebanyak 3 kali lipat dari jumlah penduduk yang ada, alat radio panggil sebanyak desa yang ada, dan evakuasi warga di radius < 6 KM dari gunung");
            Console.ReadKey();

        }
        else if (magnitudoGempa > 5.2 && awanPanas.ToString().ToUpper() == "Y" && suhu > 40
            && kelembapan >= 0 && kelembapan <= 4 && gasBerbahaya.ToString().ToUpper() == "Y"
            && laharLetusan.ToString().ToUpper() == "Y" && lava.ToString().ToUpper() == "Y" &&
          batuPijar.ToString().ToUpper() == "Y" && hujanAbu.ToString().ToUpper() == "Y")
        {
            statusGunung = "AWAS_Level_4";
            Console.WriteLine("Status gunung berapi : AWAS");
            Console.WriteLine("Perlu disiapkan masker sebanyak 6 kali lipat dari jumlah penduduk yang ada, alat radio panggil sebanyak desa yang ada, dan evakuasi warga di radius < 10 KM dari gunung");
            Console.ReadKey();

        }
        else
        {
            Console.WriteLine("Input invalid!!! Silahkan coba lagi! (Tekan Enter)");
            Console.ReadKey();
            Main();
        }
        dataStatusGunung = strMagnitudoGempa + ';' + strAwanPanas + ';' + strSuhu + ';' + strKelembapan + ';' + strGasBerbahaya + ';' + strLaharLetusan
        + ';' + strLava + ';' + strBatuPijar + ';' + strHujanAbu + ';' + statusGunung + ';';
    }

    public static string[] gunung = new string[24];


    public static void DataAwal()
    {
        for (int i = 0; i < 24; i++)
        {
            gunung[i] = " Pencatatan status gunung berapi belum dilakukan ";
        }

    }
    public static void HistoryGunung()
    {
        Console.Clear();
        Console.WriteLine("===================================================================");
        Console.WriteLine("|                       History Status Gunung                     |");
        Console.WriteLine("===================================================================");
        Console.WriteLine("1. Cek Data Keseluruhan History Gunung");
        Console.WriteLine("2. Cek Data History Gunung Berdasarkan Jam Tertentu");
        Console.Write("Pilih : ");
        ; int masukan = int.Parse(Console.ReadLine());
        switch (masukan)
        {
            case 1:
                Console.Clear();
                for (int i = 0; i < 24; i++)
                {
                    Console.WriteLine("Pukul {0} : {1}", i + 1, gunung[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Tekan Enter untuk kembali.");
                Console.ReadLine();
                break;

            case 2:
                Console.Clear();
                Console.Write("Mau cek data jam = ");
                int jam = int.Parse(Console.ReadLine());
                if (jam < 0 && jam > 24)
                {
                    Console.WriteLine("Input invalid!! Tekan Enter untuk melanjutkan!");
                    Console.ReadKey();
                    HistoryGunung();
                }
                else
                {
                    Console.WriteLine("Pukul " + jam + " : " + gunung[jam - 1]);
                    Console.ReadKey();
                }
                break;

        }

        Main();
    }
    public static void InputStatusGunung()
    {
        Console.Clear();
        int i = waktu.Hour;
        i -= 1;
        gunung[i] = dataStatusGunung;
        HistoryGunung();
        Console.ReadLine();
    }

    public static void ResetStatusGunung()
    {

        Console.WriteLine("===================================================================");
        Console.WriteLine("|                        Reset Status Gunung                      |");
        Console.WriteLine("===================================================================\n");

        Console.WriteLine("  Apakah anda yakin akan melakukan reset status gunung?\n  1.Ya\n  2.Tidak");
        Console.Write("Pilih : ");
        int pilih = Convert.ToInt32(Console.ReadLine());

        if (pilih == 1)
        {
            Array.Clear(gunung, 0, 24);
            foreach (var x in gunung)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }

        if (pilih == 2)
        {
            Main();
        }

    }


}
