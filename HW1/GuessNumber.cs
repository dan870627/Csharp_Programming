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
            bool check = true;

            while (check)
            {
                Console.WriteLine("({0}, {1})?", x, y);

                int guess = int.Parse(Console.ReadLine());
                if (guess <= x || guess >= y)
                {
                    Console.WriteLine("超出範圍, tryagain.");
                }
                if (guess == ans)
                {
                    Console.WriteLine("Bingo!!");
                    check = false;
                }
                else
                {
                    if (guess > x && ans > guess) x = guess;
                    if (guess < y && ans < guess) y = guess;
                }
            }
        }
    }
}
