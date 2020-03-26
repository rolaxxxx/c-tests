using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2laboratorinis
{
    class Program
    {
        static void Main(string[] args)
        {
            funkcija1();
            funkcija2();
            funkcija3();
            funkcija4();
            funkcija5();
            funkcija6();
            funkcija7();
            funkcija10();
            funkcija11();
            funkcija12();
            funkcija14();
        }
 static void funkcija1()
        {
         double x = 1.15;
            var y = -2.7 * Math.Pow(x, 3) + 0.23 * Math.Pow(x, 2) - 1.4;
        }
        static void funkcija2()
        {
            double atstumas = 58, sanaudos = 8.5, kaina = 1.16;
            var islaidos = ((sanaudos / 100) * atstumas) * kaina;
        }

 static void funkcija3()
        {
    if (double.TryParse(Console.ReadLine(), out var r1) && double.TryParse(Console.ReadLine(), out var r2))
         {
            Console.WriteLine(1.0 / (r1 + r2));
        }
        }

     static void funkcija4()
        {
            var numbers = Console.ReadLine().Split('.');
     if (numbers.Length == 2 && int.TryParse(numbers[0], out var lt) && int.TryParse(numbers[1], out var ct))
        {
            Console.WriteLine($"{lt} Lt {ct} ct.");
         }
     }
    static void funkcija5()
        {
          Console.WriteLine("Iveskite indelio suma, palukanu norma ir trukme dienomis");
            var numbers = Console.ReadLine().Split(' ');
            if (numbers.Length != 3)
            {
                return;
            }
            double.TryParse(numbers[0], out var suma);
      double.TryParse(numbers[1].Replace("%",""), out var norma);
            double.TryParse(numbers[2], out var laikas);
            norma /= 100; 
            norma /= 365; 

            Console.WriteLine(string.Format("Uzdarbis per {0} dienas: {1}", laikas, suma * (1 + norma * laikas)));
        }
     static void funkcija6()
        {
            Console.WriteLine("Iveskite savo amziu metais.");
        if(double.TryParse(Console.ReadLine(), out var amzius))
         {
                Console.WriteLine($"Jusu amzius dienomis: {amzius * 365}");
          }
        }
        static void funkcija7()
        {
            var numeriai = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            if (numeriai.Length == 2)
            {
                //Console.WriteLine(Math.Max(numbers[0], numbers[1]));
                if (numeriai[0] > numeriai[1])
                {
                    Console.WriteLine(numeriai[0]);
                }
                else
                {
                    Console.WriteLine(numeriai[1]);
                }
            }
        }
        static void funkcija10()
        {
     int i = 3;
    int j = 5;

     Console.WriteLine(10 + j % i++); 
      Console.WriteLine(-i * i - 2 * i + 5);          
      Console.WriteLine((19 + ++i + ++j) / (2 * j + 2)); 
        }
   static void funkcija11()
  {
            Console.WriteLine("Atsakymas = {0}", 1 < 2 + 4); //1<6 = true
        }

  static void funkcija12()
   {
        var greitis = 60.0;
         Console.WriteLine("Atsakymas = {0}", greitis==50); //60 != 50 
    }
        public static T[] ReadArray<T>() where T : struct
        {
            var s = Console.ReadLine().Split(' ');

            switch (Type.GetTypeCode(typeof(T)))
            {
             case TypeCode.Double:
                 return (T[])Convert.ChangeType(s.Select(double.Parse).ToArray(), typeof(T[]));
            case TypeCode.Int32:
                    return (T[])Convert.ChangeType(s.Select(int.Parse).ToArray(), typeof(T[]));
            }
            if(typeof(T) == typeof(Coord))   {
                var numbers = s.Select(double.Parse).ToArray();
      var coords = new List<Coord>();
          for (int i = 0; i < numbers.Length; i+=2)
                {
                    coords.Add(new Coord(numbers[i], numbers[i + 1]));
                }
                return (T[])Convert.ChangeType(coords.ToArray(), typeof(T[]));
            }
            return null;
        }
     struct Coord
        {
            public double x;
            public double y;
            public Coord(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }
    static void funkcija14()
        {
         int i = 5;
          int suma = 15;
            suma += i * i;
        }
    }
}
