using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4laboratorinis
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
            Func13_PRO();
        }

        static void Func1()
        {
            var arr = ReadArray<double>();

            int count = 0;
            foreach(var n in arr)
            {
                if (n != 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static void Func2()
        {
            var arr = ReadArray<double>();

            double min = double.MaxValue;

            foreach(var n in arr)
            {
                if(n < min)
                {
                    min = n;
                }
            }

            Console.WriteLine(min);
            Console.WriteLine(arr.Min());
        }

        static void Func3()
        {
            var arr = ReadArray<double>();

            double sum = 0;

            foreach (var n in arr)
            {
                if (n < 0)
                {
                    sum += n;
                }
            }

            Console.WriteLine(sum);
        }

        static void Func4()
        {
            var arr = ReadArray<double>();

            Console.WriteLine((arr.Sum() - arr.Min() - arr.Max())/(arr.Length-2));
            // jei maks ir/ar min skaiciai gali pasikartoti sitas netinka
            // jei bus tik du skaiciai bus dalyba is nulio
        }

        static void Func5()
        {
            var line = Console.ReadLine().Split();

            foreach(var s in line)
            {
                if(double.TryParse(s, out _))
                {
                    Console.WriteLine("Yra ivestas skaicius");
                    break;
                }
            }
        }

        static void Func6()
        {
            var s = Console.ReadLine().Split(' ');
            var dict = new Dictionary<string, int>();

            foreach (var c in s)
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

            foreach (var symbol in dict.ToList())
            {
                if(symbol.Value > 1)
                {
                    Console.WriteLine($"{symbol.Key} x{symbol.Value}");
                }                
            }
        }

        static void Func7()
        {
            var arr = ReadArray<double>();
            Array.Sort(arr);
        }        

        static void Func8()
        {
            Console.WriteLine("Ivestkite masyvo eiluciu skaiciu");
            var n = ReadNumber<int>();

            Console.WriteLine("Ivestkite masyvo stulpeliu skaiciu");
            var m = ReadNumber<int>();

            var sum = new double[m.Value];
            for(int i = 0; i < n; i++)
            {
                var temp = ReadArray<double>();

                sum = sum.Zip(temp, (x, y) => x + y).ToArray();
            }

            foreach(var v in sum)
            {
                Console.Write($"{v} ");
            }
        }

        static void Func9()
        {
            int n = 12;

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{(i == j ? '*' : 'a')} ");
                }

                Console.WriteLine();
            }
        }

        static void Func10()
        {
            int n = 12;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{(i == j || i == (n-1) - j ? '*' : 'a')} ");
                }

                Console.WriteLine();
            }
        }

        static void Func11()
        {
            var arr = ReadArray<double>();

            var mean = arr.Sum() / arr.Length;

            foreach(var n in arr)
            {
                Console.WriteLine($"{n} -> {(n/arr.Length)/mean*100:0.000}%");
            }
        }

        static void Func12()
        {
            Console.WriteLine("Iveskite eiluciu skaiciu");
            int n = ReadNumber<int>().Value;

            int maxIndex = 0;
            double maxSum = 0;

            for(int i = 0; i < n; i++)
            {
                var sum = ReadArray<double>().Sum();

                if(maxSum < sum)
                {
                    maxSum = sum;
                    maxIndex = i + 1;
                }
            }

            Console.WriteLine($"Max suma yra eilutes: {maxIndex}");
        }        

        static void Func13()
        {
            Console.WriteLine("Iveskite eiluciu skaiciu");
            int n = ReadNumber<int>().Value;

            var arr = new double[n, n];

            double sum = 0;

            for(int i = 0; i < n; i++)
            {
                var temp = ReadArray<double>();

                for(int j = 0; j < temp.Length; j++)
                {
                    arr[i, j] = temp[j];
                }

                if(sum == 0)
                {
                    sum = temp.Sum(); 
                }
                else if(sum != temp.Sum()) //check on lines
                {
                    return;
                }
            }

            for (int j = 0; j < n; j++)
            {
                double tempSum = 0;
                for (int i = 0; i < n; i++)
                {
                    tempSum += arr[i,j];
                }

                if (sum != tempSum) //check on columns
                {
                    return;
                }
            }

            double leftToRightSum = 0;
            double rightToLeftSum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == j)
                    {
                        leftToRightSum += arr[i, j];
                    }
                    if(i == (n - 1) - j)
                    {
                        rightToLeftSum += arr[i, j];
                    }
                }
            }

            if(leftToRightSum != sum || rightToLeftSum != sum)
            {
                return;
            }

            Console.WriteLine("Tai yra magiskas kvadratas");
        }

        static void Func13_PRO()
        {
            Console.WriteLine("Iveskite simetriska matrica");

            double[] columnSum = default, lineSum = default, diagonalSum = new double[2];

            int n = 1;
            for(int i = 0; i < n; i++)
            {
                var temp = ReadArray<double>();
                if (i == 0)
                {
                    n = temp.Length;                    
                    lineSum = new double[n];
                    columnSum = new double[n];
                }

                for(int j = 0; j < n; j++)
                {
                    lineSum[i] += temp[j];
                    columnSum[j] += temp[j];

                    if (i == j)
                    {
                        diagonalSum[0] += temp[j];
                    }
                    if (i == (n - 1) - j)
                    {
                        diagonalSum[1] += temp[j];
                    }
                }
            }

            if(columnSum.Concat(lineSum).Concat(diagonalSum).Distinct().Count() == 1)
            {                
                Console.WriteLine("Tai yra magiskas kvadratas");
            }
            else
            {
                Console.WriteLine("Tai nera magiskas kvadratas");
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

            return null;
        }
    }
}
