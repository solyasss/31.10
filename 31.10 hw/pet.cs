using System;

namespace Tamagotchi
{
    public delegate void request_handler(string message);
    public delegate void status_handler(string message);
    public delegate void death_handler();

    public class Pet
    {
        private int energy = 100;
        private int ignore_requests = 0;
        private string last_request = string.Empty;
        private readonly Random random = new Random();
        private readonly string[] requests = { "Feed me some delicious food!", "Let's go for a walk!", "Put me to bed!", "Play with me!", "Give me a treat!" };

        public request_handler request_on_handler;
        public status_handler status_on_handler;
        public death_handler death_on_handler;

        public void life_start()
        {
            while (true)
            {
                if (ignore_requests >= 3)
                {
                    energy = 0; // если будет 0 энергии тамагочи умрет
                    death_on_handler?.Invoke();
                    break;
                }
                else
                {
                    generate_request();
                }

                System.Threading.Thread.Sleep(3000); // интервал между запросами
            }
        }

        private void generate_request()
        {
            string request;
            do
            {
                request = requests[random.Next(requests.Length)];
            } while (request == last_request);

            last_request = request;
            request_on_handler?.Invoke(request);
        }

        public void answer_request(bool tamagotchi)
        {
            if (tamagotchi)
            {
                ignore_requests = 0;
                energy = Math.Min(energy + 10, 100);
                status_on_handler?.Invoke(get_pos());
            }
            else
            {
                ignore_requests++;
                energy = Math.Max(energy - 10, 0);
                status_on_handler?.Invoke(":( You ignored me...");

                if (ignore_requests >= 3)
                {
                    energy = 0; 
                    death_on_handler?.Invoke();
                }
                else if (energy == 0)
                {
                    death_on_handler?.Invoke();
                }
            }
        }

        private string get_pos()
        {
            switch (last_request)
            {
                case "Feed me some delicious food!":
                    return "Thank you, that was delicious!";
                case "Let's go for a walk!":
                    return "Hooray! I love walking!";
                case "Put me to bed!":
                    return "Good night! Zzz...";
                case "Play with me!":
                    return "That was fun!";
                case "Give me a treat!":
                    return "Thanks for the treat!";
                default:
                    return "Thank you! I feel better!";
            }
        }

        public int get_energy()
        {
            return energy;
        }
    }
}
