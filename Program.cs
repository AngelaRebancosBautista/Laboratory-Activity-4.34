using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activity_34
{
    internal class Program
    {
        class Service
        {
            public static List<DateTime> Merge(List<DateTime> line1, List<DateTime> line2)
            {
                return line1.Concat(line2).OrderBy(t => t).ToList();
            }

            public static void AssignPlatforms(List<DateTime> schedule, int turnaround, int platforms)
            {
                List<DateTime> platformEnd = new List<DateTime>();

                foreach (var time in schedule)
                {
                    bool assigned = false;

                    for (int i = 0; i < platformEnd.Count; i++)
                    {
                        if (time >= platformEnd[i].AddMinutes(turnaround))
                        {
                            platformEnd[i] = time;
                            Console.WriteLine($"{time:HH:mm} -> Platform {i + 1}");
                            assigned = true;
                            break;
                        }
                    }

                    if (!assigned)
                    {
                        if (platformEnd.Count < platforms)
                        {
                            platformEnd.Add(time);
                            Console.WriteLine($"{time:HH:mm} -> Platform {platformEnd.Count}");
                        }
                        else
                        {
                            Console.WriteLine($"{time:HH:mm} -> CONFLICT! No free platform.");
                        }
                    }
                }
            }
        }

        static void Main()
        {
            List<DateTime> line1 = new List<DateTime>
        {
            DateTime.Parse("08:00"),
            DateTime.Parse("09:15"),
            DateTime.Parse("10:00")
        };

            List<DateTime> line2 = new List<DateTime>
        {
            DateTime.Parse("08:10"),
            DateTime.Parse("09:00"),
            DateTime.Parse("09:50")
        };

            int turnaround = 15;
            int platforms = 2;

            Console.WriteLine("Merged Timetable");
            var merged = Service.Merge(line1, line2);

            foreach (var t in merged)
                Console.WriteLine(t.ToString("HH:mm"));

            Console.WriteLine("Platform Assignment");
            Service.AssignPlatforms(merged, turnaround, platforms);
        }
    }
}
