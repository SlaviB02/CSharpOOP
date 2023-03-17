using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Constructor_NameIsCorrectlyPlaced()
            {
                Planet planet = new Planet("Sun", 200);
                Assert.AreEqual(planet.Name, "Sun");
            }
            [Test]
           public void Constructor_NameIsNullOrEmtpy()
            {
                Planet planet;
              var ex= Assert.Throws<ArgumentException>(()=>planet=new Planet("",500));
                Assert.That(ex.Message, Is.EqualTo("Invalid planet Name"));
            }
            [Test]
            public void Constructor_BudgetIsCorrectlyPlaced()
            {
                Planet planet = new Planet("Sun", 200);
                Assert.AreEqual(planet.Budget, 200);
            }
            [Test]
            public void Constructor_BudgetCannotBeZero()
            {
                Planet planet;
                var ex = Assert.Throws<ArgumentException>(() => planet = new Planet("Sun", -100));
                Assert.That(ex.Message, Is.EqualTo("Budget cannot drop below Zero!"));
            }
            [Test]
            public void Constructor_ValidWeaponsCollection()
            {
                Planet planet = new Planet("Sun", 200);
                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
            }
            [Test]
            public void Constructor_WeaponNameIsCorrectlyPlaced()
            {
                Weapon weapon = new Weapon("Gun", 200, 5);
                Assert.AreEqual(weapon.Name, "Gun");
            }
            [Test]
            public void Constructor_WeaponPriceIsCorrectlyPlaced()
            {
                Weapon weapon = new Weapon("Gun", 200, 5);
                Assert.AreEqual(weapon.Price, 200);
            }
            [Test]
            public void Constuctor_WeaponPriceIsNegative()
            {
                Weapon weapon;
                var ex = Assert.Throws<ArgumentException>(() => weapon = new Weapon("Gun", -200, 5));
                Assert.That(ex.Message, Is.EqualTo("Price cannot be negative."));
            }
            [Test]
            public void Constructor_WeaponDestructionIsCorrectlyPlaced()
            {
                Weapon weapon = new Weapon("Gun", 200, 5);
                Assert.AreEqual(weapon.DestructionLevel, 5);
            }
            [Test]
            public void Test_WeaponIsAddedToCollection()
            {
                Planet planet = new Planet("Sun", 200);
                Weapon weapon = new Weapon("Gun", 200, 5);
                planet.AddWeapon(weapon);
                Assert.AreEqual(planet.Weapons.Count, 1);
            }
            [Test]
            public void Test_WeaponAlreadyAdded()
            {
                Planet planet = new Planet("Sun", 200);
                Weapon weapon = new Weapon("Gun", 200, 5);
                planet.AddWeapon(weapon);
              var ex=Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
                Assert.That(ex.Message, Is.EqualTo($"There is already a {weapon.Name} weapon."));
            }
            [Test]
            public void Test_ProfitIsCorrectlyAdded()
            {
                Planet planet = new Planet("Sun", 200);
                planet.Profit(200);
                Assert.AreEqual(planet.Budget, 400);
            }
            [Test]
            public void Test_DesctuctionLevelIsReturnedCorrectly()
            {
                Planet planet = new Planet("Sun", 200);
                Weapon weapon1 = new Weapon("Gun", 200, 5);
                Weapon weapon2 = new Weapon("Pistol", 200, 8);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                Assert.AreEqual(planet.MilitaryPowerRatio, 13);
            }
            [Test]
            public void Test_WeaponDestructionLevelIsRaised()
            {
                Weapon weapon= new Weapon("Gun", 200, 5);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(weapon.DestructionLevel, 6);
            }
            [Test]
            public void Weapon_IsNuclear_WorksProperly()
            {
                Weapon weaponNuclear = new Weapon("Nuclear", 1000, 11);

                Assert.That(weaponNuclear.IsNuclear, Is.EqualTo(true));
            }
            [Test]
            public void Test_SpendingFundsWorksProperly()
            {
                Planet planet = new Planet("Sun", 200);
                planet.SpendFunds(100);
                Assert.AreEqual(planet.Budget, 100);
            }
            [Test]
            public void Test_AmountBiggerThanFunds()
            {
                Planet planet = new Planet("Sun", 200);
                var ex = Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(250));
                Assert.That(ex.Message, Is.EqualTo($"Not enough funds to finalize the deal."));
            }
            [Test]
            public void Test_RemoveWeaponWorks()
            {
                Planet planet = new Planet("Sun", 200);
                Weapon weapon1 = new Weapon("Gun", 200, 5);
                Weapon weapon2 = new Weapon("Pistol", 200, 8);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon(weapon1.Name);
                Assert.AreEqual(planet.Weapons.Count, 1);
                Assert.AreEqual(planet.MilitaryPowerRatio, 8);
            }
            [Test]
            public void Test_UpgradeWeaponCorrectly()
            {
                Planet planet = new Planet("Sun", 200);
                Weapon weapon1 = new Weapon("Gun", 200, 5);
                planet.AddWeapon(weapon1);
                planet.UpgradeWeapon(weapon1.Name);
                Assert.AreEqual(planet.MilitaryPowerRatio, 6);
            }
            [Test]
            public void Test_UpgradeWeaponNotExisting()
            {
                Planet planet = new Planet("Sun", 200);
                Weapon weapon1 = new Weapon("Gun", 200, 5);
                planet.AddWeapon(weapon1);
                var ex = Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Nuke"));
                Assert.AreEqual(ex.Message, $"Nuke does not exist in the weapon repository of {planet.Name}");
            }
            [Test]
            public void Test_DestroyOpponent()
            {
                Planet planet = new Planet("Sun", 200);
                Planet opponent = new Planet("Earth", 200);
                Weapon weapon1 = new Weapon("Gun", 200, 5);
                Weapon weapon2 = new Weapon("Pistol", 200, 8);
                planet.AddWeapon(weapon2);
                opponent.AddWeapon(weapon1);
               string res=planet.DestructOpponent(opponent);
                Assert.AreEqual(res, $"{opponent.Name} is destructed!");
            }
            [Test]
            public void Test_OpponentWithMoreMilitaryPower()
            {
                Planet planet = new Planet("Sun", 200);
                Planet opponent = new Planet("Earth", 200);
                Weapon weapon1 = new Weapon("Gun", 200, 9);
                Weapon weapon2 = new Weapon("Pistol", 200, 8);
                planet.AddWeapon(weapon2);
                opponent.AddWeapon(weapon1);
                var ex = Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
                Assert.AreEqual(ex.Message, $"{opponent.Name} is too strong to declare war to!");
            }
        }
    }
}
