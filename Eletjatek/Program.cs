using System;
using System.IO;
using System.Threading;

namespace EletjatekEsti
{
    class Eletjatek
    {
        private char[,] palya;
        private char[,] uj_palya;

        private bool jatekMegy;
        public Eletjatek(char[,] palya)
        {
            this.palya = palya;
            this.uj_palya = palya;
        }

        private int szomszedok(int sor, int oszlop)
        {
         int szomszed = 0;
        for (int i = -1; i <= 1; i++)
        {
          for (int j = -1; j <= 1; j++)
            {
              if(i != 0 && j != 0) {
                if (palya[sor + i, oszlop + j] == '@')      szomszed++;
                }
              }
            }
            return szomszed;
        }

        private void teszt(int sor, int oszlop)
        {
            int korulotte = szomszedok(sor, oszlop);
            if(palya[sor, oszlop] == '@')
            { // SEJT
                switch (korulotte)
                {
                    case 0: 
                    case 1: uj_palya[sor, oszlop] = '.'; break;
                    case 2:
                    case 3: break;
                    default: uj_palya[sor, oszlop] = '.'; break;
                }
            }
            else
            { // ÜRES HELY
                if(korulotte == 3)
                {
                    uj_palya[sor, oszlop] = '@';
                }
            }
        }

        public void inditas()
        {
            jatekMegy = true;
            while (jatekMegy)
            {
                Console.Clear();
                rajzolPalya();
                
                for (int sor = 1; sor < palya.GetLength(0)-1; sor++)
                {
                for (int oszlop = 1; oszlop < palya.GetLength(1)-1; oszlop++)
                    {
                    teszt(sor, oszlop);
                    }
                }
                palya = uj_palya;
                Thread.Sleep(500);
            }
        }

        public void rajzolPalya() {
            for (int sor = 0; sor < palya.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < palya.GetLength(1); oszlop++)
                {
                    Console.Write(" " + palya[sor,oszlop]);
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static char[,] olvasFajlbol(string fajlnev, int meret) {
            char[,] beolvasott = new char[meret, meret];
            StreamReader sr = new StreamReader(fajlnev);
            string sor;
            for (int i = 0; i < meret; i++)
            {
                sor = sr.ReadLine();
                for (int j = 0; j < meret; j++)
                {
                    beolvasott[i, j] = sor[j];
                }
            }

            return beolvasott;
        }

        static void Main(string[] args)
        {
            char[,] jatekter = new char[,] {
               //  0    1    2    3    4    5    6    7    8    9
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }, //0
                { '#', '@', '.', '.', '.', '@', '.', '.', '.', '#' }, //1
                { '#', '@', '.', '.', '@', '.', '@', '.', '.', '#' }, //2
                { '#', '.', '@', '@', '.', '.', '.', '.', '.', '#' }, //3
                { '#', '@', '@', '.', '@', '.', '@', '.', '@', '#' }, //4
                { '#', '.', '.', '.', '.', '.', '.', '@', '.', '#' }, //5
                { '#', '.', '.', '@', '.', '@', '.', '.', '.', '#' }, //6
                { '#', '@', '.', '.', '@', '.', '@', '.', '@', '#' }, //7
                { '#', '.', '@', '.', '.', '.', '.', '.', '.', '#' }, //8
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }, //9
            };

            char[,] jatekter2 = olvasFajlbol("jatek.txt", 100);

            Eletjatek jatek = new Eletjatek(jatekter2);
            jatek.inditas();
        }
    }
}
