using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1laboratorinis
{
    class Program
    {
        static void Main(string[] args)
        {
            Funkcija1("Greitai Prezidento rinkimai!");
            Funkcija1("Auditoriją remontuoja jau 2 savaites!");
            Funkcija3();
            Funkcija4();
            Funkcija5();
            Funkcija6();
            Funkcija7();
            Funkcija8();
            Funkcija9();
            Funkcija10();
            Funkcija11();
            Funkcija12();
            Funkcija13();
        }

        static void Funkcija1(string s)
        {
            Console.WriteLine(s);
        }

        static void Funkcija3()
        {
            var q = "q";
            Console.WriteLine($" Raidė {q} tariama kju");
        }

        static void Funkcija4() {
            Console.WriteLine(@"C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\include");
        }
        static void Funkcija5() {
            var atxt = "Norėčiau daug ką pasakyt, bet tai negali virsti laišku.\n" +
                    "Nebent tik ašara, nebent tik šypsena keistam rudens sapne...\n" +
                    "Nebent virpėjimu keistu ir neužrašomu,  Nebent tyla…\n" +
                    "       /V. Mykolaitis-Putinas/\n";
            Console.WriteLine(atxt);
        }
static void Funkcija6()  {
          Console.WriteLine("input jhhh and qt");
          double.TryParse(Console.ReadLine(), out var jhhh);
          double.TryParse(Console.ReadLine(), out var qt);
            Console.WriteLine($"Ritinio turis: {Math.PI * Math.Pow(jhhh, 2) * qt :0.00}");
      }

        static void Funkcija7()
        {
          Console.WriteLine("Input string");
          var stxt = Console.ReadLine();
         Console.WriteLine("Input double, int");
           double.TryParse(Console.ReadLine(), out var d);
            var itxt = (int)Console.Read();
        }
        static void Funkcija8()
        {
            var stxt = Console.ReadLine();
          Console.WriteLine(stxt);
        }

        static void Funkcija9()
        {
            int a = 0, b = 0; char c = (char)0;
            a = b = c = (char)1;
        }

        static void Funkcija10()
        {
            var nume = new List<float>() { 3.0f, 15.5f, 523.3f, 300.0f, 1200.5f, 5300.3f };
            foreach (var n in nume)
            {
                Console.Write($"{n:.0} ");
            }
        }

        static void Funkcija11()
        {
            Funkcija10();
        }

        static void Funkcija12()
        {
            var txt = "Mūsų\t dienos kaip\t šventės\n" +
                    "Kaip\t žydėjimas\t vyšnios";

            Console.WriteLine(txt);
        }

        static void Funkcija13()
        {
            Console.WriteLine("Filmas “Titanikas” surinko milijonus žiūrovų");
            Console.WriteLine("Filmas \"Titanikas\" surinko milijonus žiūrovų");
        }
    }
}
