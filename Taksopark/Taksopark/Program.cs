using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Taksopark
{
    class Program
    {
        static void Main(string[] args)
        {

            string CarList;


            try
            {
                using (StreamReader sr = new StreamReader("E:\\Study\\C#\\Taksopark\\Taksopark\\Sedans.json"))
                {
                    CarList=sr.ReadToEnd();
                }

                var Sedans = JsonSerializer.Deserialize<List<Sedan>>(CarList);
                using (StreamReader sr = new StreamReader("E:\\Study\\C#\\Taksopark\\Taksopark\\Minivans.json"))
                {
                    CarList = sr.ReadToEnd();
                }

                var Minivans = JsonSerializer.Deserialize<List<Minivan>>(CarList);
                using (StreamReader sr = new StreamReader("E:\\Study\\C#\\Taksopark\\Taksopark\\Microbuses.json"))
                {
                    CarList = sr.ReadToEnd();
                }

                var Microbuses = JsonSerializer.Deserialize<List<MicroBus>>(CarList);

                Taxopark taksopark = new Taxopark();
                taksopark.Cars = new List<Car>(13);
                Random rng = new Random();
                for (int i = 0; i < 5; i++)
                {
                    taksopark.Cars.Add(Sedans[rng.Next(0, 4)]);
                }
                for (int i = 0; i < 5; i++)
                {
                    taksopark.Cars.Add(Minivans[rng.Next(0, 4)]);
                }
                for (int i = 0; i < 3; i++)
                {
                    taksopark.Cars.Add(Microbuses[rng.Next(0, 4)]);
                }
                taksopark.Sort(true);
                taksopark.GetInfo();

                var Sum = taksopark.Cars.Sum(p => p.price);
                Console.WriteLine();
                Console.WriteLine($"Стоимость машин = {Sum} $");

                while (true)
                {
                    Console.WriteLine("Введите минимальную скорость разгона(не менее 5 секунд, не более 19 секунд)");
                    var min = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите максимальную скорость разгона(не менее 6 секунд, не более 20 секунд)");
                    var max = Convert.ToDouble(Console.ReadLine());


                    if (max < min)
                    {
                        var swap = max;
                        max = min;
                        min = swap;
                    }


                    var car = taksopark.Cars.Where(R100 => R100.RacingTo100 <= max && R100.RacingTo100 >= min).FirstOrDefault();
                    if (car == null)
                    {
                        Console.WriteLine("Данному диапазону транспорт не пренадлежит. Введите ещё раз.");
                    }
                    else
                    {
                        Console.WriteLine(car.model);
                        break;
                    }

                }




            }
            catch (JsonException e)
            {
                Console.WriteLine("JSON не верен");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
