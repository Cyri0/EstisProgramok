using System;
using System.IO;

namespace kivetelkezeles
{
    class NegativEletException : Exception
    {
        public NegativEletException(string message) {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             KIVÉTEL - Olyan hiba, ami rajtunk kívül áll, de tudunk kezelni (Exception)
            - tömbtúlindexelés
            - felhasználói input
            - fájlok kezelésekor hiba
            - nullával osztás
             */

            try
            {
                StreamReader sr = new StreamReader("alma.txt");
                int[] tomb = new int[2] { 6, 8 };

                Console.WriteLine(tomb[2]);
                Console.WriteLine(sr.ReadLine());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nem található a fájl!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Nincs ilyen indexű elem a tömbben!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
            throw new NegativEletException("A karakter élete nem mehet 0 alá!");
            }
            catch (NegativEletException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Program vége");

        }
    }
}
