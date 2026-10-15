using System;
using System.Threading.Tasks;
using TestProject.Exercises;
using TestProject.POC;

namespace TestProject
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var test = new TestAI();

            await test.SendPrompt("Olá! Diga 3 fatos sobre o .NET em português.");
        }
    }
}
