using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void Test_CarConstructor()
            {
                Car car = new Car("Honda", 0);
                Assert.AreEqual(car.CarModel, "Honda");
                Assert.AreEqual(car.NumberOfIssues, 0);
            }
            [Test]
            public void Test_CarIsFixedTrue()
            {
                Car car = new Car("Honda", 0);
                Assert.AreEqual(car.IsFixed,true);
            }
            [Test]
            public void Test_CarIsFixedFalse()
            {
                Car car = new Car("Honda", 5);
                Assert.AreEqual(car.IsFixed,false);
            }
            [Test]
            public void Test_GarageName()
            {
                Garage garage = new Garage("VW", 5);
                Assert.AreEqual(garage.Name, "VW");
            }
            [Test]
            public void Test_GarageMecanics()
            {
                Garage garage = new Garage("VW", 5);
                Assert.AreEqual(garage.MechanicsAvailable, 5);
            }
            [Test]
            public void Test_GarageListCars()
            {
                Garage garage = new Garage("VW", 5);
                Assert.AreEqual(garage.CarsInGarage,0);
            }
            [Test]
            public void Test_NameIsNullGarage()
            {
                Garage garage;
                Assert.Throws<ArgumentNullException>(() => garage = new Garage(null, 5));
            }
            [Test]
            public void Test_NegativeMechanicsGarage()
            {
                Garage garage;
                Assert.Throws<ArgumentException>(() => garage = new Garage("VW", -5));
            }
            [Test]
            public void Test_GarageAddCarProperly()
            {
                Garage garage = new Garage("VW", 5);
                Car car = new Car("Honda", 5);
                garage.AddCar(car);
                Assert.AreEqual(garage.CarsInGarage,1);
            }
            [Test]
            public void Test_GarageAddCarNoMechanics()
            {
                Garage garage = new Garage("VW", 1);
                Car car = new Car("Honda", 5);
                Car car1 = new Car("Golf", 0);
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car1));
            }
            [Test]
            public void Test_GarageFixCarProperly()
            {
                Garage garage = new Garage("VW", 5);
                Car car = new Car("Honda", 5);
                Car car1 = new Car("Golf", 0);
                garage.AddCar(car);
                garage.AddCar(car1);
                Assert.AreEqual(garage.FixCar("Honda"), car);
            }
            [Test]
            public void Test_GarageFixNonExistentCar()
            {
                Garage garage = new Garage("VW", 5);
                Car car = new Car("Honda", 5);
                Car car1 = new Car("Golf", 0);
                garage.AddCar(car);
                garage.AddCar(car1);
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Ford"));
            }
            [Test]
            public void Test_GarageFixCarUpdatesNumberOfIssues()
            {
                Garage garage = new Garage("VW", 5);
                Car car = new Car("Honda", 5);
                Car car1 = new Car("Golf", 0);
                garage.AddCar(car);
                garage.AddCar(car1);
                garage.FixCar("Honda");
                Assert.AreEqual(car.NumberOfIssues,0);
            }
            [Test]
            public void Test_GarageRemoveFixedCarsProperly()
            {
                Garage garage = new Garage("VW", 5);
                Car car = new Car("Honda", 5);
                Car car1 = new Car("Golf", 1);
                garage.AddCar(car);
                garage.AddCar(car1);
                garage.FixCar("Honda");
                garage.RemoveFixedCar();
                Assert.AreEqual(garage.CarsInGarage, 1);
            }
            [Test]
            public void Test_GarageNoFixedCarsForRemoving()
            {
                Garage garage = new Garage("VW", 5);
                Car car = new Car("Honda", 5);
                Car car1 = new Car("Golf", 1);
                garage.AddCar(car);
                garage.AddCar(car1);
               Assert.Throws<InvalidOperationException>(()=> garage.RemoveFixedCar());
                
            }
            [Test]
            public void Test_ReportCars()
            {
                Garage garage = new Garage("VW", 5);
                Car car = new Car("Honda", 5);
                Car car1 = new Car("Golf", 1);
                garage.AddCar(car);
                garage.AddCar(car1);
                garage.FixCar("Honda");
                garage.RemoveFixedCar();
                Assert.AreEqual(garage.Report(), $"There are {garage.CarsInGarage} which are not fixed: {car1.CarModel}.");
            }
        }
    }
}