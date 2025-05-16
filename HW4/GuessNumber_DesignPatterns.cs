namespace GuessNumber_DesignPatterns
{
    public class Player
    {
        static Random rng = new Random();
        static HumanPlayer humanplayer = new HumanPlayer();
        static NaiveAI naiveAI = new NaiveAI();
        static BinarySearchAI binarySearchAI = new BinarySearchAI();
        static SuperAI superAI = new SuperAI();
        int input_value;

        public static int front { get; set; }
        public static int end { get; set; }
        public static int ans { get; set; }
        public int guess_number { get; set; }
        public string? Message { get; set; }
        public static int SuperAI_mode { get; set; }
        public virtual int Input() { return input_value; }


        public void check(int x, int y, int player_mode)
        {
            front = x;
            end = y;
            SuperAI_mode = 0;
            bool IsSuperAI_modeInitialized = false;

            ans = rng.Next(front, end);

            if (player_mode == 4 && !IsSuperAI_modeInitialized)
            {
                SuperAI_mode = rng.Next(1, 3);
                IsSuperAI_modeInitialized = true;
            }

            while (ans != guess_number)
            {
                Console.WriteLine("({0}, {1})?", front, end);

                switch (player_mode)
                {
                    case 1: guess_number = humanplayer.Input(); break;
                    case 2: guess_number = naiveAI.Input(); break;
                    case 3: guess_number = binarySearchAI.Input(); break;
                    case 4: guess_number = superAI.Input(); break;
                }

                if (player_mode >= 2 && player_mode <= 4)
                {
                    Console.WriteLine(guess_number);
                }

                if ((front == ans && guess_number == ans + 1) || (end == ans && guess_number == ans - 1))
                {
                    //Console.WriteLine("You loss!");
                    Message = "You loss!";
                    guess_number = ans;
                }
                else if (guess_number < front || guess_number > end)
                {
                    //Console.WriteLine("out of rang, tryagain.");
                    Message = "out of rang, tryagain.";
                }
                else if (guess_number == ans)
                {
                    //Console.WriteLine("Bingo!!");
                    Message = "Bingo!!";
                }
                else
                {
                    if (guess_number >= front && ans > guess_number) front = guess_number + 1;
                    if (guess_number <= end && ans < guess_number) end = guess_number - 1;
                }
                if (!string.IsNullOrWhiteSpace(Message))
                {
                    Console.WriteLine(Message);
                }
            }
        }
    }

    class HumanPlayer : Player
    {
        public override int Input()
        {
            while (true)
            {
                try
                {
                    int input_value = int.Parse(Console.ReadLine());
                    return input_value;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"This is not integer，please try again!");
                    Console.WriteLine($"ErrorMessage: {e.Message}");
                }
            }
        }
    }

    class NaiveAI : Player
    {
        Random rng = new Random();
        public override int Input()
        {
            return rng.Next(front, end);
        }
    }

    class BinarySearchAI : Player
    {
        public override int Input()
        {
            int input_value = ((end - front) / 2) + front;
            return input_value;
        }
    }

    class SuperAI : Player
    {
        public override int Input()
        {
            switch (SuperAI_mode)
            {
                case 1: guess_number = front; break;
                case 2: guess_number = end; break;
            }
            return guess_number;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            int player_mode = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please select player mode (1-4)?");
                    Console.WriteLine("1. Human");
                    Console.WriteLine("2. NaiveAI");
                    Console.WriteLine("3. BinarySearchAI");
                    Console.WriteLine("4. SuperAI");
                    player_mode = int.Parse(Console.ReadLine());

                    if (player_mode >= 1 && player_mode <= 4)
                    {
                        switch (player_mode)
                        {
                            case 1: Console.WriteLine("select HumanPlayer"); break;
                            case 2: Console.WriteLine("select NaiveAI"); break;
                            case 3: Console.WriteLine("select BinarySearchAI"); break;
                            case 4: Console.WriteLine("select SuperAI"); break;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Select out of rang，please try again!");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("The input format is incorrect, please enter a valid integer！");
                    Console.WriteLine($"ErrorMessage: {e.Message}");
                }
            }

            int x = 0;
            int y = 99;
            player.check(x, y, player_mode);

        }
    }
}
