namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            for(; ; )
            {
                Random random = new Random();
                int randomNumber = random.Next(0,9);
                Order order = new Order();
                order.ChangeState(randomNumber%6);
            }
        }
    }
}
