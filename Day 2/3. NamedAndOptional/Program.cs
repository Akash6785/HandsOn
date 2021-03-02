using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedAndOptional
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COHORT DETAILS");
            
            GetCohortDetails(CohortName:"DF002", mode:"OBL",currentModule: "ASP.NET", GencCount: "22", track:"DOTNET");
            GetCohortDetails(CohortName: "AJ002", mode: "PARC", currentModule: "Spring Boot", GencCount: "22", track: "JAVA");

            Console.WriteLine("ORDER DETAILS");
            OrderDetails(seller:"SOME SELLER",product:"SOME PRODUCT");

            Console.ReadKey();
        }

        public static void GetCohortDetails(string CohortName,string GencCount,string mode,string track,string currentModule)
        {
            Console.WriteLine($"It is {CohortName} with {GencCount} GenCs undergoing training for {track} thru {mode}. The current module of training is {currentModule}");
        }
        public static void OrderDetails(string seller,string product,int quantity=1,bool isReturnable=true)
        {
            Console.WriteLine($"Here is the order detail – {quantity} number of {product} by {seller} is ordered. It’s returnable status is {isReturnable}");
        }
    }
}
