using System;

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

            //Initialise objects and assign name
            Comparison nameA = new Comparison();
            nameA.Name = "Jef";
            Comparison nameB = new Comparison();
            nameB.Name = "Jez";

            //Compare by length, if string is the same return 0 if longer return 1 else return -1
            if (nameA.CompareByLength(nameB.Name)==0)
            {
                Console.WriteLine("{0} is the same length as {1}", nameA.Name, nameB.Name);
            }
            else if (nameA.CompareByLength(nameB.Name) == 1)
            {
                Console.WriteLine("{0} is longer than {1}", nameA.Name, nameB.Name);
            }
            else
            {
                Console.WriteLine("{0} is shorter than {1}", nameA.Name, nameB.Name);
            }

            //Compare by name, if string are the same return 0
            if (nameA.CompareByName(nameB.Name) == 0)
            {
                Console.WriteLine("{0} is the same as {1}", nameA.Name, nameB.Name);
            }else
            {
                Console.WriteLine("{0} is not the same as {1}", nameA.Name, nameB.Name);
            }


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