using System;

namespace Tamagotchi
{
    public class Program
    {
        private static Pet pet = new Pet(); 

        static void Main()
        {
            pet.request_on_handler = display_pet;
            pet.status_on_handler = display_message;
            pet.death_on_handler = display_death;
            
            pet.life_start();
        }

        static void display_pet(string request)
        {
            Console.Clear();
            Console.WriteLine($"Energy: {pet.get_energy()}%");
            Console.WriteLine("     *****     ");
            Console.WriteLine("   *       *   ");
            Console.WriteLine("  *  O   O  *  ");
            Console.WriteLine(" *     v     * ");
            Console.WriteLine("   *       *   ");
            Console.WriteLine("     *****     ");
            Console.WriteLine();
            Console.WriteLine(request);
            Console.WriteLine("Fulfill the request? Y / N");
            
            var response = Console.ReadKey(true).Key;
            Console.WriteLine();

            if (response == ConsoleKey.Y)
            {
                pet.answer_request(true);
                Console.ForegroundColor = ConsoleColor.Magenta; 
                Console.WriteLine("     *****     ");
                Console.WriteLine("   *       *   ");
                Console.WriteLine("  *  ^   ^  *  ");
                Console.WriteLine(" *     v     * ");
                Console.WriteLine("   *       *   ");
                Console.WriteLine("     *****     ");
                Console.ResetColor();
            }
            else if (response == ConsoleKey.N)
            {
                pet.answer_request(false);
            }
        }

        static void display_message(string message)
        {
            Console.WriteLine(message);
        }

        static void display_death()
        {
            Console.Clear();
            Console.WriteLine($"Energy: {pet.get_energy()}%");
            Console.WriteLine("The Tamagotchi has died...");
        }
    }
}
