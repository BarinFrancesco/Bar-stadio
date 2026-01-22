namespace SalamellazTask
{
    public enum TipoTifosi
    {
        Nessuno,
        Casa,
        Ospiti
    }
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            int nmax = 5;

            Semaphore PostiDisponibili = new Semaphore(nmax, nmax);

            Bar Salamellaz = new Bar();
            Salamellaz.ApriBar();
            Console.WriteLine("Hello, World!");
        }
    }
}