namespace Practice_2
{
    public class Program
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //Console.WriteLine(program.Add(1, 2, 3));
            //Console.WriteLine(program.Add(1,2,3));
            int a=int.Parse(Console.ReadLine());
            int b=int.Parse(Console.ReadLine());
            int c=int.Parse(Console.ReadLine());
            double a1=double.Parse(Console.ReadLine());
            double b1=double.Parse(Console.ReadLine());
            double c1=double.Parse(Console.ReadLine());
            Console.WriteLine(a+b+c);
            Console.WriteLine(a1+b1+c);

        }
    }
}
