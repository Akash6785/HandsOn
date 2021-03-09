using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_CodeAnalysis
{
    class Employee
    {
#pragma warning disable IDE1006 // Naming Styles
        int id { get; set; }
#pragma warning restore IDE1006 // Naming Styles

#pragma warning disable IDE1006 // Naming Styles
        string name { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        public Employee(){
            this.id=10;
            this.name="cts";
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine(i);
            int j = 10;
        }
    }
}
}
