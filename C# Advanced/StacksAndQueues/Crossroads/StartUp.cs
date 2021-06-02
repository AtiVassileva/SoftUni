using System;
using System.Linq;
using System.Collections.Generic;

namespace Crossroads
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var freeWindowDuration = int.Parse(Console.ReadLine());
            
            var carQueue = new Queue<string>();
            var crash = false;
            var crashedCar = "";
            var hitIndex = -1;
            var totalCarsPassed = 0;

            var command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    var currGreenLight = greenLightDuration;

                    while (currGreenLight > 0 && carQueue.Any())
                    {
                        var currentCar = carQueue.Peek();
                        var carLength = currentCar.Length;

                        currGreenLight -= carLength;

                        if (currGreenLight >= 0)
                        {
                            carQueue.Dequeue();
                            totalCarsPassed++;
                        }
                        else
                        {
                            var left = Math.Abs(currGreenLight);
                            if (left <= freeWindowDuration)
                            {
                                carQueue.Dequeue();
                                totalCarsPassed++;
                            }
                            else
                            {
                                crash = true;
                                crashedCar = currentCar;
                                hitIndex = carLength - left + freeWindowDuration;
                                break;
                            }

                        }
                    }
                }
                else
                {
                    carQueue.Enqueue(command);
                }
                if (crash)
                {
                    break;
                }
            }

            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[hitIndex]}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
        }
    }
}