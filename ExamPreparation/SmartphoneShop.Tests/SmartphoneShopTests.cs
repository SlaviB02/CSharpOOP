using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
       [Test]
       public void ShopConstructor()
        {
            Shop shop = new Shop(25);
            Assert.AreEqual(shop.Count, 0);
            Assert.AreEqual(shop.Capacity, 25);
        }
        [Test]
        public void ShopCapacityNegativeNumber()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() => shop = new Shop(-5));
        }
        [Test]
        public void AddPhoneProperly()
        {
            Shop shop = new Shop(25);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            shop.Add(smartphone);
            Assert.AreEqual(shop.Count, 1);
        }
        [Test]
        public void AddPhoneNoCapacityLeft()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            Smartphone smartphone1 = new Smartphone("Samsung", 25);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone1));
        }
        [Test]
        public void AddSamePhoneTwice()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }
        [Test]
        public void RemovePhoneProperly()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            Smartphone smartphone1 = new Smartphone("Samsung", 25);
            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Remove("Nokia");
            Assert.AreEqual(shop.Count, 1);
        }
        [Test]
        public void RemoveNotExistingModel()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Samsung"));
        }
        [Test]
        public void TestPhoneProperly()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            shop.Add(smartphone);
            shop.TestPhone("Nokia", 15);
            Assert.AreEqual(smartphone.CurrentBateryCharge, 5);
        }
        [Test]
        public void TestNonExistingPhone()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            shop.Add(smartphone);
            shop.TestPhone("Nokia", 15);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung",15));
        }
        [Test]
        public void TestMoreBatteryNeed()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            shop.Add(smartphone);
            shop.TestPhone("Nokia", 15);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia", 25));
        }
        [Test]
        public void ChargeNonExistingPhone()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            shop.Add(smartphone);
            shop.TestPhone("Nokia", 15);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Samsung"));
        }
        [Test]
        public void ChargePhoneProperly()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Nokia", 20);
            shop.Add(smartphone);
            shop.TestPhone("Nokia", 15);
            shop.ChargePhone("Nokia");
            Assert.AreEqual(smartphone.CurrentBateryCharge, 20);
        }
        [Test]
        public void SmartPhoneConstructor()
        {
            Smartphone smartphone = new Smartphone("Nokia", 20);
            Assert.AreEqual(smartphone.CurrentBateryCharge, 20);
            Assert.AreEqual(smartphone.MaximumBatteryCharge, 20);
            Assert.AreEqual(smartphone.ModelName, "Nokia");
        }
    }
}