using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MyDU_Recipe_Time_Updater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("File path for recipes.yaml (C:\\recipes.yaml): ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                Console.Write("Amount of time to divide by (old time / {value} = new time): ");
                string str_timeDivisor = Console.ReadLine();
                int timeDivisor = string.IsNullOrEmpty(str_timeDivisor) ? 0 : int.Parse(str_timeDivisor);

                if (timeDivisor > 0)
                {
                    List<string> lines = File.ReadLines(filePath).ToList();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (lines[i].Contains("time"))
                        {
                            string str_time = lines[i].Substring(6);
                            int time = int.Parse(str_time);
                            int new_time = time / timeDivisor;
                            lines[i] = "time: " + new_time;
                        }
                    }

                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("File updated!");
                }
                else
                {
                    Console.WriteLine("Error: Divisor must be greater than 0.");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid file path.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
