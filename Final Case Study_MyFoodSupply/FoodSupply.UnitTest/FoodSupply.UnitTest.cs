using MyFoodSupply;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupply.UnitTest
{
    public class FoodSupply
    {
        private Program program;

        [SetUp]
        public void SetUp()
        {
            program = new Program();
        }

        // NUnit test cases for Food detail
        [Test]
        [TestCase("abc", 2, "2021-04-08", 100.0)]
        public void FoodDetailTest(string name, int dishType, DateTime expiryDate, double price)
        {
            /*  var foodItem = new FoodDetail()

              {

                  Name = name,

                  ExpiryDate = expiryDate,

                  Price = price,

                  DishType = (FoodDetail.Category)dishType

              };*/
            var result = program.CreateFoodDetail(name, dishType, expiryDate, price);

            Assert.That(result, Is.TypeOf<FoodDetail>());
        }
        [Test]
        [TestCase(null, 1, "2021-04-08", 256.56)]
        [TestCase("", 2, "2021-04-08", 0.01)]
        public void FoodNameisEmpty(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => program.CreateFoodDetail(name, dishType, expiryDate, price));
        }

        [Test]
        [TestCase("abc", 3, "2021-04-08", 0)]
        [TestCase("abc", 2, "2021-04-08", -1)]
        public void FoodPriceisLessThanZero(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => program.CreateFoodDetail(name, dishType, expiryDate, price));
        }

        [Test]
        [TestCase("abc", 1, "2020-04-08", 1)]
        public void ImprobableExpiryDate(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => program.CreateFoodDetail(name, dishType, expiryDate, price));
        }


        [Test]
        [TestCase(1, "2021-04-08", "abc", 100)]
        public void SupplyDetailObjectCreatedTest(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
        {
            var foodDetail = new FoodDetail()
            {
                Name = "abc",
                DishType = (FoodDetail.Category)1,
                Price = 150,
                ExpiryDate = new DateTime(2021, 4, 10),
            };

            var result = program.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, foodDetail);

            Assert.That(result, Is.TypeOf<SupplyDetail>());
        }


        [Test]
        [TestCase(-1, "2021-04-08", "abc", 100)]
        [TestCase(0, "2021-04-08", "abc", 100)]
        public void FoodCountLessThanEqualToZero(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
         {
            var foodDetail = new FoodDetail()
            {
                Name = "abc",
                DishType = (FoodDetail.Category)1,
                Price = 150,
                ExpiryDate = new DateTime(2021, 4, 10),
            };
            Assert.Throws<Exception>(() => program.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, foodDetail));
        }


        [Test]
        [TestCase(1, "2021-01-08", "abc", 100)]
        public void RequestDateLessThanCurrentDateTest(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
        {
            var foodDetail = new FoodDetail()
            {
                Name = "abc",
                DishType = (FoodDetail.Category)1,
                Price = 150,
                ExpiryDate = new DateTime(2021, 4, 10),
            };
            Assert.Throws<Exception>(() => program.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, foodDetail));
        }


        [TestCase(1, "2021-04-08", "abc", 100,null)]
        public void NullFoodObjectTest(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge,FoodDetail foodDetail)
        {
            var result = program.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, foodDetail);
            Assert.That(result, Is.EqualTo(null));
        }

    }
}
