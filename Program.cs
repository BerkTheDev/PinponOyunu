using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong
{
    class PinPon
    {
        static int BirinciOyuncuBoyut = 10;
        static int IkinciOyuncuBoyut = 4;
        static int topPozisyonuX = 0;
        static int topPozisyonuY = 0;
        static bool topYonYukari = true; // Determines if the ball direction is up
        static bool topYonSag = false;
        static int birinciOyuncuPozisyon = 0;
        static int IkinciOyuncuPozisyon = 0;
        static int BirinciOyuncuSonuc = 0;
        static int IkinciOyuncuSonuc = 0;
        static Random rastgele = new Random();

        static void Sil()
        {
            Console.Title = "PinPon by Berk";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void BirinciOyuncuOlustur()
        {
            for (int y = birinciOyuncuPozisyon; y < birinciOyuncuPozisyon + BirinciOyuncuBoyut; y++)
            {
                PrintAtPosition(0, y, '|');
                PrintAtPosition(1, y, '|');
            }
        }

        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        static void IkinciOyuncuOlustur()
        {
            for (int y = IkinciOyuncuPozisyon; y < IkinciOyuncuPozisyon + IkinciOyuncuBoyut; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, '|');
                PrintAtPosition(Console.WindowWidth - 2, y, '|');
            }
        }

        static void BelirlenmisPozisyonlar()
        {
            birinciOyuncuPozisyon = Console.WindowHeight / 2 - BirinciOyuncuBoyut / 2;
            IkinciOyuncuPozisyon = Console.WindowHeight / 2 - IkinciOyuncuBoyut / 2;
            TopuEkraninOrtasinaKoy();
        }

        static void TopuEkraninOrtasinaKoy()
        {
            topPozisyonuX = Console.WindowWidth / 2;
            topPozisyonuY = Console.WindowHeight / 2;
        }

        static void TopOlustur()
        {
            PrintAtPosition(topPozisyonuX, topPozisyonuY, '@');
        }

        static void CiktiSonucla()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write("{0}-{1}", BirinciOyuncuSonuc, IkinciOyuncuSonuc);
        }

        static void HareketBirinciOyuncuAsagi()
        {
            if (birinciOyuncuPozisyon < Console.WindowHeight - BirinciOyuncuBoyut)
            {
                birinciOyuncuPozisyon++;
            }
        }

        static void HareketBirinciOyuncuYukari()
        {
            if (birinciOyuncuPozisyon > 0)
            {
                birinciOyuncuPozisyon--;
            }
        }

        static void HareketIkinciOyuncuAsagi()
        {
            if (IkinciOyuncuPozisyon < Console.WindowHeight - IkinciOyuncuBoyut)
            {
                IkinciOyuncuPozisyon++;
            }
        }

        static void HareketIkinciOyuncuYukari()
        {
            if (IkinciOyuncuPozisyon > 0)
            {
                IkinciOyuncuPozisyon--;
            }
        }

        static void IkinciOyuncuYZHareket()
        {
            int rastgelesayi = rastgele.Next(1, 101);
            //if (rastgelesayi == 0)
            //{
            //    HareketIkinciOyuncuYukari();
            //}
            //if (rastgelesayi == 1)
            //{
            //    HareketIkinciOyuncuAsagi();
            //}
            if (rastgelesayi <= 70)
            {
                if (topYonYukari == true)
                {
                    HareketIkinciOyuncuYukari();
                }
                else
                {
                    HareketIkinciOyuncuAsagi();
                }
            }
        }

        private static void TopHareket()
        {
            if (topPozisyonuY == 0)
            {
                topYonYukari = false;
            }
            if (topPozisyonuY == Console.WindowHeight - 1)
            {
                topYonYukari = true;
            }
            if (topPozisyonuX == Console.WindowWidth - 1)
            {
                TopuEkraninOrtasinaKoy();
                topYonSag = false;
                topYonYukari = true;
                BirinciOyuncuSonuc++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Birinci oyuncu kazandı!");
                Console.ReadKey();
            }
            if (topPozisyonuX == 0)
            {
                TopuEkraninOrtasinaKoy();
                topYonSag = true;
                topYonYukari = true;
                IkinciOyuncuSonuc++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Ikinci oyuncu kazandı!");
                Console.ReadKey();
            }

            if (topPozisyonuX < 3)
            {
                if (topPozisyonuY >= birinciOyuncuPozisyon
                    && topPozisyonuY < birinciOyuncuPozisyon + BirinciOyuncuBoyut)
                {
                    topYonSag = true;
                }
            }

            if (topPozisyonuX >= Console.WindowWidth - 3 - 1)
            {
                if (topPozisyonuY >= IkinciOyuncuPozisyon
                    && topPozisyonuY < IkinciOyuncuPozisyon + IkinciOyuncuBoyut)
                {
                    topYonSag = false;
                }
            }

            if (topYonYukari)
            {
                topPozisyonuY--;
            }
            else
            {
                topPozisyonuY++;
            }


            if (topYonSag)
            {
                topPozisyonuX++;
            }
            else
            {
                topPozisyonuX--;
            }
        }

        static void Main(string[] args)
        {
            Sil();
            BelirlenmisPozisyonlar();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        HareketBirinciOyuncuYukari();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        HareketBirinciOyuncuAsagi();
                    }
                }
                IkinciOyuncuYZHareket();
                TopHareket();
                Console.Clear();
                BirinciOyuncuOlustur();
                IkinciOyuncuOlustur();
                TopOlustur();
                CiktiSonucla();
                Thread.Sleep(60);
            }
        }
    }
}