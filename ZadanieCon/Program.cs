namespace zadanie
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("\n Pudełko toString: ");
            ////Console.WriteLine(new Pudelko2(2.5, 9.321, 0.1, UnitOfMeasure.meter).ToString);
            //Console.WriteLine(new Pudelko(2.5, 9.321, 1, UnitOfMeasure.meter).ToString("m"));
            Console.WriteLine("Hello World!");
            Pudelko p = new Pudelko(0.1448, 0.4, 0.6, UnitOfMeasure.meter);
            Console.WriteLine(p.ToString());
            Console.WriteLine(p.ToString("m"));
            Console.WriteLine(p.ToString("cm"));
            Console.WriteLine(p.ToString("mm"));
            Console.WriteLine(p.Objetosc);
            Console.WriteLine(p.Pole);
            Console.WriteLine();
            Console.WriteLine("\n Pudełko toString: ");
   
            Console.WriteLine(new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter).ToString("m"));
            Console.WriteLine(new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter).ToString("cm"));
            Console.WriteLine(new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter).ToString("mm"));
        }
    }
}