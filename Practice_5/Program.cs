using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;

namespace Practice_5
{
    public delegate bool IsEligibleforScholorship(Student std);
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public char SportsGrade { get; set; }
        public Delegate IsEligibleforScholorship {  get; set; }
        public static string GetEligibleStudent(List<Student> studentsList, IsEligibleforScholorship isEligible)
        {
            //var eligibleStudents = studentsList.Where(std => isEligible(std))
            //                                  .Select(std => std.Name);
            //    return string .Join(", ",eligibleStudents);
            string res = "";
            foreach (var item in studentsList)
            {
                if (isEligible(item))
                    if (res == "")
                    {
                        res += item.Name;
                    }
                    else
                    {
                        res += ", " + item.Name;
                    }
            }
            return res;
        }
    }
    public class Program
    {
        public static bool ScholarshipEligibility(Student std)
        {
           if( std.Marks > 80 && std.SportsGrade == 'A')
            {
                return true;
            }
           return false;
            
        }
        
        static void Main(string[] args)
        {
            
            List<Student> lstStudents = new List<Student>();
            Student obj1= new Student() { RollNo = 1,Name="Raj",Marks=75,SportsGrade='A' };
            Student obj2= new Student() { RollNo = 2,Name="Rahul",Marks=82,SportsGrade='A' };
            Student obj3= new Student() { RollNo = 3,Name="Kiran",Marks=89,SportsGrade='B' };
            Student obj4= new Student() { RollNo = 4,Name="Sunil",Marks=86,SportsGrade='A' };
            lstStudents.Add(obj1);
            lstStudents.Add(obj2);
            lstStudents.Add(obj3);
            lstStudents.Add(obj4);
            string eligibleStudents = Student.GetEligibleStudent(lstStudents, ScholarshipEligibility);
            Console.WriteLine(eligibleStudents);
        }
    }
}
