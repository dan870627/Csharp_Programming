namespace Contagion_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.WriteLine("Enter number of citizens:");
            int people = int.Parse(Console.ReadLine());
            int[] A = new int[people];
            int[] B = new int[people];
            Console.Write("       Id");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0, 3}", i);
                A[i] = i;
                B[i] = i;
            }
            Console.WriteLine();
            Console.Write("Contactee");
            for (int i = B.Length - 1; i > 0; i--)
            {
                int tmp = B[i];
                int rng_index = rng.Next(i);
                B[i] = B[rng_index];
                B[rng_index] = tmp;
            }
            for (int i = 0;i < B.Length; i++)
            {
                Console.Write("{0, 3}", B[i]);
            }
            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine("Enter id of infected citizen:");
            int people_index = int.Parse(Console.ReadLine());
            Console.WriteLine("These citizens are to be self-isolated in the following 14 days:");
            Console.Write(people_index);
            int people_contagion = people_index;
            for (int i = 1;i < A.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[j] == people_contagion)
                    {
                        if (B[j] == people_index)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("{0, 2}", B[j]);
                            people_contagion = B[j];
                        }
                    }
                }
            }
        }
    }
}
