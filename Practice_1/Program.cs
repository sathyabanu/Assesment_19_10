using System.Numerics;

namespace Practice_1
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Person(string Name, string Address,int Age)
        {
            this.Name = Name;
            this.Address = Address;
            this.Age = Age;
        }
        public Person() { }
    }
    public class PersonImplementation
    {
        public string GetName(IList<Person> person)
        {
            string newstr = "";
            foreach(var item in person)
            {
                newstr += item.Name + " " + item.Address + " ";
            }
            return newstr;
        }
        public double Average(IList<Person> person)
        {
            double sum = 0;
            double count = 0;
            foreach(var item in person)
            {
                count++;
                sum += item.Age;
                
            }
            return sum / count;
        }
        public int Max(IList<Person> person)
        {
            int maxage = 0;
            foreach(var item in person)
            {
             if(item.Age > maxage)
                {
                    maxage = item.Age;
                }
            }
            return maxage;

        }
        static void Main(string[] args)
        {
            IList<Person> p = new List<Person>();
            p.Add(new Person { Name = "Aarya", Address = "A2101", Age = 69 });
            p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
            p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
            p.Add(new Person { Name = "Jennifer", Address = "I1704", Age = 33 });
            PersonImplementation perImp=new PersonImplementation();
           Console.WriteLine( perImp.GetName(p));
           Console.WriteLine(perImp.Average(p));
           Console.WriteLine(perImp.Max(p));
        }
    }
}
