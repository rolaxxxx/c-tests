using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_darbas
{


    /*
     * Si uzduotis padejo pakelti mano kvalifikacija 
     */
    class Program
    {
        static void Main(string[] args)
        {
             Stopwatch stopwatch = new Stopwatch();
           
            stopwatch.Start();
            Studentas generate = new Studentas();
            

            System.IO.StreamWriter Vargsiukai = new System.IO.StreamWriter($"Vargsiukai.txt");
            System.IO.StreamWriter Kietiakai = new System.IO.StreamWriter($"Kietiakai.txt");


            Queue  <Studentas> sarasas = new Queue<Studentas> ();



            System.IO.StreamWriter timerFile = new System.IO.StreamWriter($"V0.5_timer.txt");


            List<Studentas> studentParserList = new List<Studentas>();
            string line;
        
            try {
                System.IO.StreamReader file =
                       new System.IO.StreamReader($"Studentai.txt");
                
                int count = 0;
                while ((line = file.ReadLine()) != null && count <= 100000)
                {
                    List<string> ssize = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(s => s.Trim())
                     .ToList();
                    Studentas tempStudentas = new Studentas();
                    tempStudentas.vardas = ssize[0];
                    tempStudentas.pavarde = ssize[1];
                    List<double> vidurkis = new List<double>();


                  
                    vidurkis.Add(Convert.ToDouble(ssize[2]));
                    vidurkis.Add(Convert.ToDouble(ssize[3]));
                    vidurkis.Add(Convert.ToDouble(ssize[4]));
                    vidurkis.Add(Convert.ToDouble(ssize[5]));
                    vidurkis.Add(Convert.ToDouble(ssize[6]));
                    vidurkis.Add(Convert.ToDouble(ssize[7]));
                    vidurkis.Add(Convert.ToDouble(ssize[8]));
                    vidurkis.Sort();


                    /*
       * Sis kodas pades man rasti geresni darba nes juk svarbu ne kodo stilius o kad veiktu :)
       * 
       */
                    tempStudentas.mediana = vidurkis[3];
                    tempStudentas.vidurkis += Convert.ToDouble(ssize[2]);
                    tempStudentas.vidurkis += Convert.ToDouble(ssize[3]);
                    tempStudentas.vidurkis += Convert.ToDouble(ssize[4]);
                    tempStudentas.vidurkis += Convert.ToDouble(ssize[5]);
                    tempStudentas.vidurkis += Convert.ToDouble(ssize[6]);
                    tempStudentas.vidurkis += Convert.ToDouble(ssize[7]);
                    tempStudentas.vidurkis += Convert.ToDouble(ssize[8]);
                    tempStudentas.vidurkis /=7;
                    count++;
                    sarasas.Enqueue(tempStudentas);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Failas nerastas");
            }
            
            


            Console.WriteLine("Vardas     Pavardė       Galutinis(Vid.)      Mediana");
            Console.WriteLine("-----------------------------------------------------");
            var ordered = sarasas.OrderBy(f => f.vardas);
           
            stopwatch.Stop();
            generate.elapsedTimeFull += stopwatch.Elapsed.TotalSeconds;
            //timerFile.WriteLine("Helloworld " );
            double total_time = stopwatch.Elapsed.TotalSeconds;
            timerFile.WriteLine(" overhead value is  "+total_time.ToString());
            for (int i = 10; i <= 100000; i*=10)
             {
            
                 stopwatch.Restart();
                 generate.StudentListGenerator(i, generate);
                 stopwatch.Stop();


                 timerFile.WriteLine($"{i}" + " Generatoriaus studentu kiekio i faila irasyma ir visos programos greitis " + (stopwatch.Elapsed.TotalSeconds+total_time).ToString());

              }




            stopwatch.Restart();
            for (int i = 10; i <= 100000; i *= 10)
            {
               
                generate.StudentListdifferentiator(i, Vargsiukai, Kietiakai );
               
               // timerFile.WriteLine($"{i}" + " Differentiator  studentu kiekio i faila irasyma ir visos programos greitis " + (stopwatch.Elapsed.TotalSeconds+total_time).ToString());
               // timerFile.WriteLine("sveiki");
            }


            stopwatch.Stop();
            timerFile.WriteLine( " programos veikimo laikas be generavimo  " + (stopwatch.Elapsed.TotalSeconds + total_time).ToString());
            timerFile.Close();
        }
    }
}
