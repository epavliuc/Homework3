using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IComparable_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Item();
            var b = new Item();
            a.Name = "Bob";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
            a.Name = "Carly";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
            a.Name = "Edward";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));


            Comparison nameA = new Comparison();
            nameA.Name = "Jef";
            Comparison nameB = new Comparison();
            nameB.Name = "Jez";

            if (nameA.CompareByLength(nameB.Name)==0)
            {
                Console.WriteLine("{0} is the same length as {1}", nameA.Name, nameB.Name);
            }else if (nameA.CompareByLength(nameB.Name) == 1)
            {
                Console.WriteLine("{0} is longer than {1}", nameA.Name, nameB.Name);
            }
            else
            {
                Console.WriteLine("{0} is shorter than {1}", nameA.Name, nameB.Name);
            }

            Console.WriteLine("{0} is -result- as {1} ,this is result {2}", nameA.Name, nameB.Name, nameA.CompareByName(nameB.Name));

            Console.Read();
        }
    }
    public class Item : IComparable
    {
        public string Name;

        public int CompareTo(object o)
        {
            Item that = o as Item;
            return this.Name.CompareTo(that.Name);
        }
    }

    //Bonus lab, I feel adventurous
    class Comparison : ICompareByLength,ICompareByName
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int CompareByLength(string b)
        {
            return (this.name.Length.CompareTo(b.Length));
        }


        public int CompareByName(string b)
        {

            return (string.Compare(this.name, b));
        }
    }

    interface ICompareByName
    {
        int CompareByName(string b);
    }

    interface ICompareByLength
    {
        int CompareByLength(string b);
    }
}