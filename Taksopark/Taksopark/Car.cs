using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Taksopark
{
    public class Car
    {
        //protected int maxspeed;
        //protected int numberofpessenger;

        public string model { get; set; }
        public string Fuel { get; set; }
        public double VolumeofEngine { get; set; }
        public double RacingTo100 { get; set; }
        public int FuelConsumption { get; set; }
        public int price { get; set; }
        public virtual int NumberofPessenger { get ; } //{ return numberofpessenger
        public virtual int MaxSpeed { get; } //{ return maxspeed; }


    }
    public class Sedan : Car
    {
        private readonly int maxspeed;
        private readonly int numberofpessenger;
        public override int NumberofPessenger { get { return numberofpessenger; } }
        public override int MaxSpeed { get { return maxspeed; } }
        public Sedan()
        {
            numberofpessenger = 5;
            maxspeed = 140;
        }
    }
    public class Minivan : Car
    {
        private readonly int maxspeed;
        private readonly int numberofpessenger;
        public override int NumberofPessenger { get { return numberofpessenger; } }
        public override int MaxSpeed { get { return maxspeed; } }
        public Minivan()
        {
            numberofpessenger = 7;
            maxspeed = 120;
        }
    }
    public class MicroBus : Car
    {
        private readonly int maxspeed;
        private readonly int numberofpessenger;
        public override int NumberofPessenger { get { return numberofpessenger; } }
        public override int MaxSpeed { get { return maxspeed; } }
        public MicroBus()
        {
            numberofpessenger = 11;
            maxspeed = 100;
        }
    }
    public class Taxopark
    {
        public List<Car> Cars;

        public void Sort(bool Descending)
        {
            IEnumerable<Car> sortedtaksopark;
            if (Descending)
               { sortedtaksopark = Cars.OrderByDescending(FC => FC.FuelConsumption); }
            else
               { sortedtaksopark = Cars.OrderBy(FC => FC.FuelConsumption); }
            Cars = sortedtaksopark.ToList();
        }

        public void GetInfo()
        {
            foreach (var item in Cars)
            {
                Console.WriteLine($"Модель: {item.model},\t Вместимость, чел: {item.NumberofPessenger},\t Топлива: {item.Fuel},\t Расход топлива на 100 км: {item.FuelConsumption},\t Разгон до 100км/ч, сек: {item.RacingTo100},\t Цена: {item.price} $");
            }
                  
        }

    }
}
