namespace ThreadingLock
{
    internal class Program
    {
        static int mainSum = 0;
        static void Main(string[] args)
        {
            var t1 = new Thread(() => AddSum());
            var t2 = new Thread(() => AddSum());
            var t3 = new Thread(() => AddSum());

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine(mainSum);
        }

        private static object myLock = new object();

        static void AddSum()
        {
            int mySum = 0;

            Random random = new Random();

            for(int i = 0; i < 1000; i++)
            {
                int randomNum = random.Next(1, 10);

                mySum += randomNum;

                lock (myLock)
                {
                    mainSum += randomNum;
                }
            }
            Console.WriteLine(mySum);
        }
    }
}