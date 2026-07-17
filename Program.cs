namespace Feladatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string uzenet = "hello world";
            string kulcs = "abcdefgijkl";
            string titkos =  _1_feladat.Rejtjelezes(uzenet, kulcs);
            Console.WriteLine($"Rejtjelezett:  {titkos}");
            string vissza = _1_feladat.Visszafejt(titkos, kulcs);
            Console.WriteLine($"Visszafejtett: {vissza}");
        }
    }
}
