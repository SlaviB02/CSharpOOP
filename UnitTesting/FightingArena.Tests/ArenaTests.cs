namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Test_ConstructorArena()
        {
            Arena arena = new Arena();
            Assert.AreEqual(arena.Warriors.Count, 0);
        }
        [Test]
        public void Test_EnrollWarriorArena()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Greg", 40, 40);
            arena.Enroll(warrior);
            Assert.AreEqual(arena.Warriors.Count, 1);
        }
        [Test]
        public void Test_CannotEnrollWarriorAgain()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Greg", 40, 40);
            arena.Enroll(warrior);
            var ex = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
            Assert.AreEqual(ex.Message, "Warrior is already enrolled for the fights!");
        }
        [Test]
        public void Test_FightWorksProperly()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Greg", 40, 40);
            Warrior warrior1 = new Warrior("George", 50, 50);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            arena.Fight("George", "Greg");
            Assert.AreEqual(warrior.HP, 0);
        }
        [Test]
        public void Test_WarriorIsNotEnrolledForFight()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Greg", 40, 40);
            Warrior warrior1 = new Warrior("George", 50, 50);
            arena.Enroll(warrior);
            string missingName = "George";
            var ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("George", "Greg"));
            Assert.AreEqual(ex.Message, $"There is no fighter with name {missingName} enrolled for the fights!");
        }
    }
}
