using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3laboratorinis
{
    class Program
    {        
        static void Main(string[] args)
        {
            Func1();
            Func2();
            Func3();
            Func4();
            Func5();
            Func6();
            Func7();
            Func8();
            Func9();
            Func10();
            Func11();
            Func12();
            Func13();
            Func14();
        }

        static void Func1()
        {
            int n = int.Parse(Console.ReadLine());
            double f = 1;

            for(int i = 1; i <= n; i++)
            {
                f *= i;
            }

            Console.WriteLine(f);
        }

        static void Func2()
        {
            var arr = ReadArray<int>();

            double sum = 0;
            foreach(var n in arr)
            {
                sum += n;
            }

            Console.WriteLine(sum / arr.Length);
        }

        static void Func3()
        {
            int i = 5;
            int n = 1;

            while (i > 0)
            {
                if(n % 2 != 0)
                {
                    Console.WriteLine(n * n);
                    i--;
                }
                
                n++;
            }
        }

        static double Distance(Coord a, Coord b)
        {
            return Math.Sqrt(Math.Pow(a.x-b.x, 2) + Math.Pow(a.y-b.y,2));
        }

        static void Func4()
        {
            // 1.5 2.0 1.5 4.0 4.0 4.0 4.0 2.0
            Console.WriteLine("1. trikampis; 2. staciakampis; 3. trapecijos; ");            

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Iveskite 3 koordinates (x y) pagal laikrodzio rodykle");
                    break;
                case 2:
                    Console.WriteLine("Iveskite 4 koordinates (x y) pagal laikrodzio rodykle");
                    break;
                case 3:
                    Console.WriteLine("Iveskite 5 koordinates (x y) pagal laikrodzio rodykle");                    
                    break;
            }

            double plotas = 0;
            var k = ReadArray<Coord>();
            var l = ReadArray<Coord>().ToList();
            l.Add(l[0]);

            Func<Coord, Coord, double> calc = (a, b) => a.x * b.y - a.y * b.x;

            plotas = 0;
            for (int i = 0; i < l.Count - 1; i++)
            {
                plotas += calc(l[i], l[i + 1]);
            }
            plotas = Math.Abs(plotas / 2);

            Console.WriteLine($"Plotas = {plotas}");
        }

        static void Func5()
        {
            char simbolis = (char)Console.Read();

            if (simbolis >= 0 && simbolis <= 9)
            {
                Console.WriteLine("skaicius");
            }
            else if (simbolis >= 65 && simbolis <= 90)
            {
                Console.WriteLine("didzioji raide");
            }
            else if (simbolis >= 97 && simbolis <= 122)
            {
                Console.WriteLine("mazoji raide");
            }
            else
            {
                Console.WriteLine("ne raide");
            }
        }

        static void Func6()
        {
            int i = 1;
            while (i < 10)
            {
                var j = i * i - 1;
                var k = 2 * j - 1;
                Console.WriteLine($"i={i}, j={j}, k={k}");

                i++;
            }
        }

        static void Func7()
        {
            for(float x = -2; x < 2; x += 0.5f)
            {
                Console.WriteLine($"x = {x}, y = {-2.4 * (x * x) + 5 * x - 3}");
            }
        }

        public static T? ReadNumber<T>() where T : struct
        {
            var s = Console.ReadLine();

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Double:
                    double.TryParse(s, out var d);
                    return (T)Convert.ChangeType(d, typeof(T));
                case TypeCode.Int32:
                    int.TryParse(s, out var i);
                    return (T)Convert.ChangeType(i, typeof(T));
            }

            return null;
        }

        static void Func8()
        {
            char raide = (char)'a';

            while(raide != 'z'+1)
            {
                Console.WriteLine($"{(int)raide} = {raide}");
                raide++;
            }
        }

        static void Func9()
        {
            var skaicius = ReadNumber<int>();

            for(int i=2;i< skaicius; i++)
            {
                if(skaicius % i == 0)
                {
                    Console.WriteLine($"Dalinasi is {i}");
                    Console.WriteLine("ne pirminis");
                    return;
                }
            }

            Console.WriteLine("pirminis");
        }

        static void Func10()
        {
            int n = new Random().Next(1, 10);

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Iveskite skaiciu");
                var spejimas = ReadNumber<int>();

                if(spejimas == n)
                {
                    Console.WriteLine("Atspejote");
                    return;
                }
            }
        }

        static void Func11()
        {
            Console.WriteLine("Iveskite tiksluma");
            var tikslumas = ReadNumber<double>();

            double pi4 = 1;
            bool minus = true;

            double tmp;
            for(double i = 3; true; i += 2)
            {                
                if (minus)
                {
                    tmp = -1 * 1.0 / i;
                }
                else
                {
                    tmp = 1.0 / i;
                }

                pi4 += tmp;
                minus = !minus;

                if(Math.Abs(tmp*4) < tikslumas)
                {
                    Console.WriteLine($"{pi4 * 4}");
                    break;
                }
            }
        }

        static void Func12()
        {
            var nums = ReadArray<int>();

            int didziausiasDaugiklis = 1;
            for (int i = 2; i < Math.Min(nums[0], nums[1]); i++)
            {
                if(nums[0] % i == 0 && nums[1] % i == 0)
                {
                    didziausiasDaugiklis = i;
                }
            }

            Console.WriteLine($"Didziausias bendras daugiklis = {didziausiasDaugiklis}");
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

            if (typeof(T) == typeof(Coord))
            {
                var numbers = s.Select(double.Parse).ToArray();
                var coords = new List<Coord>();
                for (int i = 0; i < numbers.Length; i += 2)
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

        static void Func13()
        {
            var s = Console.ReadLine();
            var dict = new Dictionary<char, int>();

            foreach(var c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict[c] = 1;
                }
            }

            foreach(var symbol in dict.ToList())
            {
                Console.WriteLine($"{symbol.Key} x{symbol.Value}");
            }
        }

        static void Func14()
        {
            int metai = 1323;

            for(int i = 0; i < 3; i++)
            {
                var spejimas = ReadNumber<int>();

                if(spejimas == metai)
                {
                    Console.WriteLine($"Atspejote");
                    return;
                }
            }

            Console.WriteLine($"Neatspejote, {metai}");
        }
    }
}
