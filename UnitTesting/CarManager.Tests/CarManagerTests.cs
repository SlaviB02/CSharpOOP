namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_ConstructorFuelAmount()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            Assert.AreEqual(car.FuelAmount, 0);
        }
       
        [Test]
        public void Test_ConstructorFuelConsumption()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            Assert.AreEqual(car.FuelConsumption, 5.8);
        }
        [Test]
        public void Test_FuelConsumptionNegative()
        {
            Car car;
            var ex=Assert.Throws<ArgumentException>(() => car = new Car("Honda", "Civic", -5, 25));
            Assert.AreEqual(ex.Message, "Fuel consumption cannot be zero or negative!");
        }
        [Test]
        public void Test_ConstructorFuelCapacity()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            Assert.AreEqual(car.FuelCapacity, 25);
        }
        [Test]
        public void Test_FuelCapacityNegative()
        {
            Car car;
            var ex = Assert.Throws<ArgumentException>(() => car = new Car("Honda", "Civic", 5.8, -5));
            Assert.AreEqual(ex.Message, "Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void Test_ConstructorMake()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            Assert.AreEqual(car.Make, "Honda");
        }
        [Test]
        public void Test_MakeNull()
        {
            Car car;
            var ex = Assert.Throws<ArgumentException>(() => car = new Car(null, "Civic", 5.8, 25));
            Assert.AreEqual(ex.Message, "Make cannot be null or empty!");
        }
        [Test]
        public void Test_ConstructorModel()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            Assert.AreEqual(car.Model, "Civic");
        }
        [Test]
        public void Test_ModelNull()
        {
            Car car;
            var ex = Assert.Throws<ArgumentException>(() => car = new Car("Honda", null, 5.8, 25));
            Assert.AreEqual(ex.Message, "Model cannot be null or empty!");
        }
        [Test]
        public void Test_RefuelWorkingProperly()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            car.Refuel(20);
            Assert.AreEqual(car.FuelAmount, 20);
        }
        [Test]
        public void Test_RefuelNegativeNumber()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            var ex = Assert.Throws<ArgumentException>(() => car.Refuel(-20));
            Assert.AreEqual(ex.Message, "Fuel amount cannot be zero or negative!");
        }
        [Test]
        public void Test_RefuelWithMoreThanCapacity()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            car.Refuel(30);
            Assert.AreEqual(car.FuelAmount, 25);
        }
        [Test]
        public void Test_DriveDistance()
        {
            Car car = new Car("Honda", "Civic", 10, 10);
            car.Refuel(1);
            car.Drive(1);
           
            Assert.AreEqual(0.9, car.FuelAmount);
        }
        [Test]
        public void Test_DriveMoreDistanceThanFuel()
        {
            Car car = new Car("Honda", "Civic", 5.8, 25);
            car.Refuel(25);
            var ex = Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
            Assert.AreEqual(ex.Message, "You don't have enough fuel to drive!");
        }
        
    }
}