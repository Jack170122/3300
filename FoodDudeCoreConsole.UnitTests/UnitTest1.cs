using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FoodDudeCoreConsole.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public FoodItem test_food;
        DateTime initial = new DateTime(2020, 1, 1);

        private string getTextFilePath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));
            return Path.Combine(newPath, @"FoodDudeCoreConsole\bin\Debug\netcoreapp3.0\ExternalRepository.txt");
        }

        [TestMethod]
        public void findTextFile()
        {
            var path = getTextFilePath();
            Console.WriteLine("Path: " + path);
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void setExpirationUnitTest()
        {
            var path = getTextFilePath();
            DateTime answer = new DateTime(2020, 1, 2);
            test_food = new FoodItem("Orange", initial, 1, path);

            Assert.AreEqual(test_food.date_expiration, answer);
        }

        [TestMethod]
        public void setDTEUnitTest()
        {
            var path = getTextFilePath();
            int answer = 100;
            test_food = new FoodItem("Popcorn", initial, 1, path);
            Assert.AreEqual(test_food.days_to_expiration, answer);
        }

        [TestMethod]
        public void setQuantityUnitTest()
        {
            var path = getTextFilePath();
            int answer = -2;
            test_food = new FoodItem("Popcorn", initial, 0, path);
            Assert.AreEqual(test_food.quantity, answer);
        }
        
    }
}
