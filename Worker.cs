using Hangfire;

namespace JobTracker
{
    public class Worker
    {
        private readonly ILogger<Worker> _logger;
        
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public void CheckTime()
        {
            Console.WriteLine($"Minutely time is {DateTime.Now}");
        }

        public void CheckTimeDaily()
        {
            Console.WriteLine($"Daily time is {DateTime.Now}");
        }

        public void TimeIs12()
        {
            Console.WriteLine($"Time is 12");
        }
        public void SayHello()
        {
            Console.WriteLine("Hello World!");
        }

        public void TypeSomething(string text)
        {
            Console.WriteLine(text);
        }
        
        public void Multiply(int a, int b)
        {
            Console.WriteLine($"Multiplying {a} and {b}");
            Console.WriteLine($"Result is {a * b}");
        }
        
        [AutomaticRetry(Attempts = 3, DelaysInSeconds = new int[]{2,3,5})]
        public void ErrorTest()
        {
            Console.WriteLine("This is an error test!");
            throw new Exception("This is an error!");
        }
    }
}