using System;
using CalcLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

//Nunit HandsOn 1 and 2
namespace UnitTest
{
    [TestFixture]
    class CalculatorTests
    {
        CalcMethods cl;

        [SetUp]
        [Test]
        public void Start()
        {
            cl = new CalcMethods();
            Console.WriteLine("Application Started");
        }
        public void SubTest(int number1, int number2, int expected)
        {

            Assert.AreEqual(expected, cl.Sub(number1, number2));
            //   Assert.AreEqual(expected, cl.Sub(number));

        }
        [TestCase(7, 10, 17)]
        [TestCase(-7, -2, -9)]
        public void AddTest(int number1, int number2, int expected)
        {
            Assert.AreEqual(expected, cl.Add(number1, number2));

        }
        [TestCase(2, 14, 28)]
        [TestCase(4, 2, 8)]
        [TestCase(-4, -2, 8)]
        public void MulTest(int number1, int number2, int expected)
        {
            Assert.AreEqual(expected, cl.Mul(number1, number2));
        }

        [TestCase(7, 1, 7)]
        [TestCase(8, 0, 0)]
        [TestCase(-8, -2, 4)]
        //[TestCase(0, )]
        public void DivTest(int number1, int number2, int expected)
        {

            try
            {
                Assert.AreEqual(expected, cl.Div(number1, number2));
            }
            catch (ArgumentException)
            {
                // Console.WriteLine("Division of by zero");
                Assert.Fail("Division By Zero is Undefined");
            }
        }


        [Test]
        public void TestAddAndClear()
        {
            int res = cl.Add(2, 3);
            Assert.AreEqual(5, res);
            cl.AllClear();
            int result = cl.Result;
            Assert.AreEqual(0, result);
        }

        [TearDown]
        [Test]
        public void CleanUp()
        {
            cl.AllClear();
        }

        /*[TearDown]
               [Test]
               public void End()
               {
                   Console.WriteLine("Application Stopped");
               }
               //[TearDown]
               // [SetUp]
               [TestCase(7,0,7)]
               [TestCase(5,2,3)]*/


    }
}
