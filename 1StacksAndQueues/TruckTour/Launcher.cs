using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    public class Launcher
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new Queue<Pump>();

            for (int i = 0; i < n; i++)
            {
                int[] pumpArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Pump currentPump = new Pump(pumpArgs[0], pumpArgs[1], i);
                pumps.Enqueue(currentPump);
            }

            Pump startPump = pumps.Peek(); // getting the first pump, it can be set to "null" instead of using Peek()

            while (true)
            {
                Pump currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                startPump = currentPump;
                int gas = currentPump.AmountGas;

                while (gas >= currentPump.DistanceToNextPump)
                {
                    gas -= currentPump.DistanceToNextPump;

                    currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);
                    if (currentPump == startPump)
                    {
                        Console.WriteLine(currentPump.Index);
                        return;
                    }

                    gas += currentPump.AmountGas;
                }
            }
        }
    }
}