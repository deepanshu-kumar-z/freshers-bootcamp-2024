using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine($"Uppercase string: {await RepeatStringUpperCase()}");
        }

        static async Task<string> RepeatStringUpperCase()
        {
            return (await RepeatStringLowerCase()).ToUpper();
        }

        static async Task<string> RepeatStringLowerCase()
        {
            var ch = "a";
            return string.Concat(Enumerable.Repeat(ch, await GetRandomNumber()));
        }

        static Task<int> GetRandomNumber()
        {
            Random rnd = new Random();
            return Task.Run(() => rnd.Next(1, 100));
        }
    }
}
