using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_darbas
{
    public class Studentas
    {


        /*
         * begalo idomi uzduotis niekad negalvojau kad universitete taip gali buti 
         * 
         */
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public double vidurkis { get; set; }
        public double mediana { get; set; }
        
        public double elapsedTimeFull;
        public Studentas()
        {
            
        }

        public void printStructure()
        {
            Console.WriteLine(vardas + "    " + pavarde + "               " + Math.Round(vidurkis, 2) + "              " + Math.Round(mediana, 2));
        }
        public double randbalas()
        {

            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(1, 11);
        }
        public void StudentListGenerator(int ammount, Studentas student)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter($"{ammount}.txt"))
            {
                for (int i = 0; i < ammount; i++)
                {
                    string temp = null;
                    temp += "vardas" + i + " ";
                    temp += "pavarde" + i + " ";
                    temp += student.randbalas() + " ";
                    temp += student.randbalas() + " ";
                    temp += student.randbalas() + " ";
                    temp += student.randbalas() + " ";
                    temp += student.randbalas() + " ";
                    temp += student.randbalas() + " ";
                    temp += student.randbalas() + " ";
                    file.WriteLine(temp);
                }

            }
        }


        public void StudentListdifferentiator(int idx, System.IO.StreamWriter vargsiukai, System.IO.StreamWriter kietiakai)
        {

          
            System.IO.StreamReader file =
                                  new System.IO.StreamReader($"{idx}.txt");

         
            Studentas studentas = new Studentas();
            String line;
            while ((line = file.ReadLine()) != null )
            {
                List<string> ssize = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(s => s.Trim())
                     .ToList();


                studentas.vardas = ssize[0];
                studentas.pavarde = ssize[1];
                List<double> vidurkis = new List<double>();

                

                vidurkis.Add(Convert.ToDouble(ssize[2]));
                vidurkis.Add(Convert.ToDouble(ssize[3]));
                vidurkis.Add(Convert.ToDouble(ssize[4]));
                vidurkis.Add(Convert.ToDouble(ssize[5]));
                vidurkis.Add(Convert.ToDouble(ssize[6]));
                vidurkis.Add(Convert.ToDouble(ssize[7]));
                vidurkis.Add(Convert.ToDouble(ssize[8]));
                vidurkis.Sort();
                


                studentas.mediana = vidurkis[3];
                studentas.vidurkis += Convert.ToDouble(ssize[2]);
                studentas.vidurkis += Convert.ToDouble(ssize[3]);
                studentas.vidurkis += Convert.ToDouble(ssize[4]);
                studentas.vidurkis += Convert.ToDouble(ssize[5]);
                studentas.vidurkis += Convert.ToDouble(ssize[6]);
                studentas.vidurkis += Convert.ToDouble(ssize[7]);
                studentas.vidurkis += Convert.ToDouble(ssize[8]);
                studentas.vidurkis /= 7;
                 

                string temp = null;


                temp += ssize[0] + " ";
                temp += ssize[1] + " ";
                temp += ssize[2] + " ";
                temp += ssize[3] + " ";
                temp += ssize[4] + " ";
                temp += ssize[5] + " ";
                temp += ssize[6] + " ";
                temp += ssize[7] + " ";
                temp += ssize[8] + " ";


                if (studentas.vidurkis<5)
                {

                    vargsiukai.WriteLine(temp);

                }
                else if (studentas.vidurkis >= 5)
                {

                    kietiakai.WriteLine(temp);

                }

            }

        }



    }
}
