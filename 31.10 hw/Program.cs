using System;

namespace Tamagotchi
{
    public class Program
    {
        static void Main()
        {
            Pet pet = new Pet();
            DisplayObserver display_observer = new DisplayObserver(pet);
            EnergyObserver energy_observer = new EnergyObserver(pet);
            IgnoreObserver ignore_observer = new IgnoreObserver(pet);

            pet.life_start();
        }
    }
}