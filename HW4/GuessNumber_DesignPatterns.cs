namespace GuessNumber_DesignPatterns
{
    internal class Program
    {
        class Player
        {
            Random rng = new Random();
            public int HumanPlayer()
            {
                int guess_number = int.Parse(Console.ReadLine());
                return guess_number;
            }

            public int NaiveAIPlayer(int x, int y)
            {
                int guess_number = rng.Next(x, y);
                return guess_number;
            }

            public int BinarySearchAI(int x, int y)
            {
                int guess_number = ((y - x) / 2) + x;
                return guess_number;
            }

            public int SuperAI(int x, int y, int mode)
            {                
                int guess_number = 0;
                switch (mode)
                {
                    case 1: guess_number = x; break;
                    case 2: guess_number = y; break;
                }
                return guess_number;
            }
        }
        class Game
        {
            public static string[] Check(int x, int y, int ans_number, int guess_number)
            {
                int front = x;
                int end = y;
                int ans = ans_number;
                int guess = guess_number;
                string message = "";

                if ((front == ans && guess == ans + 1) || (end == ans && guess == ans - 1))
                {
                    message = "You loss!";
                    guess = ans;
                }
                else if (guess < front || guess > end)
                {
                    message = "out of rang, tryagain.";
                }
                else if (guess == ans)
                {
                    message = "Bingo!!";
                }
                else
                {
                    if (guess >= front && ans > guess) front = guess + 1;
                    if (guess <= end && ans < guess) end = guess - 1;
                }

                string[] result = new string[] { front.ToString(), end.ToString(), guess.ToString(), message};

                return result;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("GuessNumber Game");
            Random rng = new Random();
            Player player = new Player();
            int x = 0;
            int y = 99;
            int ans = rng.Next(x, y);
            int guess = 0;
            string message = "";
            int superAI_mode = 0;
            //Console.WriteLine(ans);

            //Player
            int modeplayer = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Who is play this game?");
                Console.WriteLine("1. HumanPlayer");
                Console.WriteLine("2. NaiveAI(Random)");
                Console.WriteLine("3. BinarySearchAI(helf guess)");
                Console.WriteLine("4. SuperAI(front/end start guess)");
                modeplayer = int.Parse(Console.ReadLine());

                if ( modeplayer >= 1 && modeplayer <= 4) validInput = true;
                else Console.WriteLine("out of range, please enter 1~4.");
            }
            
            if (modeplayer == 4)
            {
                superAI_mode = rng.Next(1, 3);
            }
            

            while (ans != guess)
            {
                Console.WriteLine("({0}, {1})?", x, y);

                switch (modeplayer)
                {
                    case 1: guess = player.HumanPlayer(); break;
                    case 2: guess = player.NaiveAIPlayer(x, y); break;
                    case 3: guess = player.BinarySearchAI(x, y); break;
                    case 4: guess = player.SuperAI(x, y, superAI_mode); break;
                }

                if (modeplayer >= 2 && modeplayer <= 4)
                {
                    Console.WriteLine(guess);
                }

                string[] result = Game.Check(x, y, ans, guess);
                x = int.Parse(result[0]);
                y = int.Parse(result[1]);
                guess = int.Parse(result[2]);
                message = result[3];

                if (message != "")
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}
