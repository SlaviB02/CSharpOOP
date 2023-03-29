namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void ConstructorsSetsProperlyFish()
        {
            Fish fish = new Fish("Spas");
            Assert.AreEqual(fish.Name, "Spas");
            Assert.AreEqual(fish.Available, true);
        }
        [Test]
        public void ConstructorsSetsProperlyAquarium()
        {
            Aquarium aquarium = new Aquarium("Aqua", 15);
            Assert.AreEqual(aquarium.Name, "Aqua");
            Assert.AreEqual(aquarium.Capacity, 15);
            Assert.AreEqual(aquarium.Count, 0);
        }
        [Test]
        public void InvalidAquariumName()
        {
            Aquarium aquarium;
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium("", 15));
        }
        [Test]
        public void InvalidAquariumCapacity()
        {
            Aquarium aquarium;
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Aqua", -10));
        }
        [Test]
        public void AddFishProperly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 15);
            Fish fish = new Fish("Spas");
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }
        [Test]
        public void AddFishNoCapacityLeft()
        {
            Aquarium aquarium = new Aquarium("Aqua", 1);
            Fish fish = new Fish("Spas");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Pencho")));
        }
        [Test]
        public void RemoveFishProperly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 15);
            Fish fish = new Fish("Spas");
            aquarium.Add(fish);
            aquarium.RemoveFish("Spas");
            Assert.AreEqual(aquarium.Count, 0);
        }
        [Test]
        public void RemoveNonExistingFish()
        {
            Aquarium aquarium = new Aquarium("Aqua", 15);
            Fish fish = new Fish("Spas");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Ivan"));
        }
        [Test]
        public void SellFishProperly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 15);
            Fish fish = new Fish("Spas");
            aquarium.Add(fish);
           var fi=aquarium.SellFish("Spas");
            Assert.AreEqual(fi, fish);
            Assert.AreEqual(fish.Available, false);

        }
        [Test]
        public void SellNonExistingFish()
        {
            Aquarium aquarium = new Aquarium("Aqua", 15);
            Fish fish = new Fish("Spas");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Ivan"));
        }
        [Test]
        public void AquariumReport()
        {
            Aquarium aquarium = new Aquarium("Aqua", 15);
            Fish fish = new Fish("Spas");
            aquarium.Add(fish);
            string result= $"Fish available at {aquarium.Name}: {fish.Name}";
            Assert.AreEqual(aquarium.Report(), result);
        }
    }
}
