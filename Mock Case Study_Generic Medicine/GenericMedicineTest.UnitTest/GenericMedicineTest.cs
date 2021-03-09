using GenericMedicine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMedicineTest.UnitTest
{
    [TestFixture]
   public class GenericMedicineTest
    {
        private Program program;

        [SetUp]
        public void SetUp()
        {
            program = new Program();
        }
        [Test]
       
        public void CreateMedicineObjectTest()
        {
            Medicine medicine = new Medicine()
            {
                Id = 1,
                Name = "montelukast",
                GenericMedicineName = "xyz",
                Composition = "mno",
                ExpiryDate = new DateTime(2021, 5, 15),
                PricePerStrip = 200
            };
           
            var result = program.CreateMedicineDetail(medicine.Name, medicine.GenericMedicineName, medicine.Composition, medicine.ExpiryDate, medicine.PricePerStrip);
            Assert.That(result, Is.TypeOf<Medicine>());
        }
   [Test]
 [TestCase("cetrizine", null, "antihistamine", "2021-03-15", 100)]
 [TestCase("cetrizine", "", "antihistamine", "2021-03-15", 100)]
 public void ExceptionMedicineNameTest(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
 {
     Assert.Throws<Exception>(() => program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
 }

 [Test]
 [TestCase("cetrizine", "ctz", "antihistamine", "2021-03-15", 0)]
 [TestCase("cetrizine", "ctz", "antihistamine", "2021-03-15", -55)] 
 public void PricePerStripTest(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
 {
     Assert.Throws<Exception>(() => program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
 }

 [Test]
 [TestCase("cetrizine", "ctz", "antihistamine", "2020-03-15", 1)]
 public void ExpireDateExceptionTest(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
 {
     Assert.Throws<Exception>(() => program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
 }

 
 [Test]
 [TestCase(1, "2021-03-15", "jahan road")]
 public void CheckCartoonObjectCreatedTest(int medicineStripCount, DateTime launchDate, string retailerAddress)
 {
     var medicine = new Medicine()
     {
         Name = "cetrizine",
         GenericMedicineName = "ctz",
         Composition = "antihistamine",
         ExpiryDate = new DateTime(2021, 3, 19),
         PricePerStrip = 1
     };

     var result = program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine);

     Assert.That(result, Is.TypeOf<CartonDetail>());
 }

 [Test]
 [TestCase(0, "2021-03-15", "jahan road")]
 [TestCase(-1, "2021-03-15", "jahan road")]
 public void MedicineCountTest(int medicineStripCount, DateTime launchDate, string retailerAddress)
 {
     var medicine = new Medicine()
     {
         Name = "cetrizine",
         GenericMedicineName = "ctz",
         Composition = "antihistamine",
         ExpiryDate = new DateTime(2021, 3, 16),
         PricePerStrip = 1
     };

     Assert.Throws<Exception>(() => program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
 }

 [Test]
 [TestCase(1, "2020-03-15", "jahan road")]
 public void IsLaunchDateLessThanCurrentDateTest(int medicineStripCount, DateTime launchDate, string retailerAddress)
 {
     var medicine = new Medicine()
     {
         Name = "cetrizine",
         GenericMedicineName = "ctz",
         Composition = "antihistamine",
         ExpiryDate = new DateTime(2021, 5, 15),
         PricePerStrip = 1
     };

     Assert.Throws<Exception>(() => program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
 }

 [Test]
 [TestCase(1, "2021-03-15", "jahan road", null)]
 public void IsMedicineNullTest(int medicineStripCount, DateTime launchDate, string retailerAddress, Medicine medicine)
 {
     var result = program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine);

     Assert.That(result, Is.EqualTo(null));
 }

    }
}

  