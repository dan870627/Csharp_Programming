namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("猜數字");
            Random rng = new Random();
            int x = 0;
            int y = 99;
            int ans = rng.Next(0, 99);
            Console.WriteLine("ans = {0}", ans);
            bool check = true;

            while (check)
            {
                Console.WriteLine("({0}, {1})?", x, y);

                int guess = int.Parse(Console.ReadLine());
                if (x == ans && guess == ans + 1)
                {
                    Console.WriteLine("You loss!");
                    break;
                }
                if (y == ans && guess == ans - 1)
                {
                    Console.WriteLine("You loss!");
                    break;
                }
                if (guess <= x || guess >= y)
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
        }
    }
}
