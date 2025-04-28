namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Guess Number");
            Random rng = new Random();
            int x = 0;
            int y = 99;
            int ans = rng.Next(0, 99);
            // Console.WriteLine("ans = {0}", ans);
            bool check = true;

            //Guess result
            int people_guess_count = 0;
            int computer_guess_count_RandomInRange = 0;
            int computer_guess_count_dichotomy = 0;

            // People Guess
            while (check)
            {
                Console.WriteLine("({0}, {1})?", x, y);

                int guess = int.Parse(Console.ReadLine());
                people_guess_count++;
                if ((x == ans && guess == ans + 1) || (y == ans && guess == ans - 1))
                {
                    Console.WriteLine("You loss!");
                    people_guess_count = 99;
                    break;
                }
                if (guess < x || guess > y)
                {
                    Console.WriteLine("out of rang, tryagain.");
                }
                if (guess == ans)
                {
                    Console.WriteLine("Bingo!!");
                    check = false;
                }
                else
                {
                    if (guess > x && ans > guess) x = guess + 1;
                    if (guess < y && ans < guess) y = guess - 1;
                }
            }

            //Computer Guess(Random in rang)
            x = 0;
            y = 99;
            check = true;
            while (check)
            {
                //Console.WriteLine("({0}, {1})?", x, y);

                int guess = rng.Next(x, y);
                computer_guess_count_RandomInRange++;
                if ((x == ans && guess == ans + 1) || (y == ans && guess == ans - 1))
                {
                    computer_guess_count_RandomInRange = 99;
                    break;
                }
                if (guess == ans)
                {
                    check = false;
                }
                else
                {
                    if (guess > x && ans > guess) x = guess + 1;
                    if (guess < y && ans < guess) y = guess - 1;
                }
            }

            //Computer Guess(dichotomy)
            x = 0;
            y = 99;
            check = true;
            while (check)
            {
                //Console.WriteLine("({0}, {1})?", x, y);

                int guess = ((y - x) / 2) + x;
                computer_guess_count_dichotomy++;
                if ((x == ans && guess == ans + 1) || (y == ans && guess == ans - 1))
                {
                    computer_guess_count_dichotomy = 99;
                    break;
                }
                if (guess == ans)
                {
                    check = false;
                }
                else
                {
                    if (guess > x && ans > guess) x = guess + 1;
                    if (guess < y && ans < guess) y = guess - 1;
                }
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~");
            Console.WriteLine("Guess Number result:");
            Console.WriteLine("User: {0}", people_guess_count);
            Console.WriteLine("Computer(RandomInRange): {0}", computer_guess_count_RandomInRange);
            Console.WriteLine("Computer(Dichotomy): {0}", computer_guess_count_dichotomy);

            if (people_guess_count < computer_guess_count_RandomInRange)
            {
                if (people_guess_count < computer_guess_count_dichotomy)
                {
                    Console.WriteLine("People Win!");
                }
                else
                {
                    Console.WriteLine("Computer(Dichotomy) Win!");
                }
            }
            else
            {
                if (computer_guess_count_RandomInRange < computer_guess_count_dichotomy)
                {
                    Console.WriteLine("Computer(RandomInRange) Win!");
                }
                else
                {
                    Console.WriteLine("Computer(Dichotomy) Win!");
                }
            }
        }
    }
}
