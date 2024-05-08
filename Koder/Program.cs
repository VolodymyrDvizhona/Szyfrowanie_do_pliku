using System;
using System.IO;
namespace Koder
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Wprowadź tekst, który chcesz zaszyfrować :");
            string tekstDoZaszyfrowania = Console.ReadLine();

            Console.Write("Podaj nazwę pliku zaszyfrowanego: ");

            string nazwaCelu = Console.ReadLine(); // podajemy dowolną nazwę pliku '.txt', w którym będzie zaszyfrowany wcześniej podany tekst

            Console.Write("Podaj wartość klucza (od 0 do 255): ");

            byte klucz = Convert.ToByte(Console.ReadLine());

            FileStream zrodlo = null, cel = null;

            try
            {
                cel = new FileStream(nazwaCelu, FileMode.Create);

                foreach (char znak in tekstDoZaszyfrowania)
                {
                    byte zaszyfrowanyZnak = (byte)(znak ^ klucz);
                    cel.WriteByte(zaszyfrowanyZnak);
                }
            }
            finally
            {
                if (cel != null)
                {
                    cel.Close();
                }
            }

            Console.WriteLine("Operacja szyfrowania zakończona");
            Console.ReadKey();
        }
    }
}
