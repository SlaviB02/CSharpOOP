namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Test_Constructor()
        {
            Warrior warrior = new Warrior("Petar", 20, 50);
            Assert.AreNotEqual(warrior, null);
        }
        [Test]
        public void Test_EmptyName()
        {
            Warrior warrior;
            var ex = Assert.Throws<ArgumentException>(() =>warrior= new Warrior(null, 20, 50));
                Assert.AreEqual(ex.Message, "Name should not be empty or whitespace!");
        }
        [Test]
        public void Test_NegativeDamage()
        {
            Warrior warrior;
            var ex = Assert.Throws<ArgumentException>(() => warrior = new Warrior("Petar", -20, 50));
            Assert.AreEqual(ex.Message, "Damage value should be positive!");
        }
        [Test]
        public void Test_NegativeHP()
        {
            Warrior warrior;
            var ex = Assert.Throws<ArgumentException>(() => warrior = new Warrior("Petar", 20, -5));
            Assert.AreEqual(ex.Message, "HP should not be negative!");
        }
        [Test]
        public void Test_AttackLowHp()
        {
            Warrior warrior = new Warrior("Petar", 50, 20);
            Warrior warrior1 = new Warrior("Greg", 50, 50);
            var ex = Assert.Throws<InvalidOperationException>(() =>warrior.Attack(warrior1));
            Assert.AreEqual(ex.Message, "Your HP is too low in order to attack other warriors!");
        }
        [Test]
        public void Test_AttackLowHpEnemy()
        {
            const int MIN_ATTACK_HP = 30;
            Warrior warrior = new Warrior("Petar", 50, 50);
            Warrior warrior1 = new Warrior("Greg", 50, 20);
            var ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior1));
            Assert.AreEqual(ex.Message, $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }
        [Test]
        public void Test_AttackEnemyMoreDamage()
        {
            Warrior warrior = new Warrior("Petar", 50, 40);
            Warrior warrior1 = new Warrior("Greg", 50, 50);
            var ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior1));
            Assert.AreEqual(ex.Message, $"You are trying to attack too strong enemy");
        }
        [Test]
        public void Test_AttackEnemyMoreHPThanDamage()
        {
            Warrior warrior = new Warrior("Petar", 50, 50);
            Warrior warrior1 = new Warrior("Greg", 30, 150);
            warrior.Attack(warrior1);
            Assert.AreEqual(warrior1.HP, 100);
        }
        [Test]
        public void Test_AttackDamageMoreThanEnemyHP()
        {
            Warrior warrior = new Warrior("Petar", 50, 50);
            Warrior warrior1 = new Warrior("Greg", 30, 40);
            warrior.Attack(warrior1);
            Assert.AreEqual(warrior1.HP, 0);
        }
    }
}