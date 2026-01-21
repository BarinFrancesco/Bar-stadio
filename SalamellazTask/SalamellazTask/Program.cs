namespace SalamellazTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int nmax = 5;

            Semaphore PostiDisponibili = new Semaphore(nmax, nmax);

            
            Console.WriteLine("Hello, World!");
        }
    }
}