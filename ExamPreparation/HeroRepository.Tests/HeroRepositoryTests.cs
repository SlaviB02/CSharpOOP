using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void HeroConstructorWorks()
    {
        Hero hero = new Hero("David", 15);
        Assert.AreEqual(hero.Name, "David");
        Assert.AreEqual(hero.Level, 15);
    }
    [Test]
    public void TestRepositoryConstructor()
    {
        HeroRepository hero = new HeroRepository();
        Assert.AreEqual(hero.Heroes.Count, 0);
    }
    [Test]
    public void RepositoryCreateNullHero()
    {
        HeroRepository heroes = new HeroRepository();
       Assert.Throws<ArgumentNullException>(()=>heroes.Create(null));
    }
    [Test]
    public void RepositoryCreateAlreadyExistingHero()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("David", 15);
        heroes.Create(hero);
        Assert.Throws<InvalidOperationException>(() => heroes.Create(hero));
    }
    [Test]
    public void RepositroyCreateHero()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("David", 15);
        heroes.Create(hero);
        Assert.AreEqual(heroes.Heroes.Count, 1);
    }
    [Test]
    public void RepositoryRemoveNullHero()
    {
        HeroRepository heroes = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heroes.Remove(null));
    }
    [Test]
    public void RepositroyRemoveHeroProperly()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("David", 15);
        heroes.Create(hero);
        var f=heroes.Remove(hero.Name);
        Assert.AreEqual(f,true);
    }
    [Test]
    public void RepositroyRemoveNonExistingHero()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("David", 15);
        heroes.Create(hero);
        var f = heroes.Remove("Ivan");
        Assert.AreEqual(f, false);
    }
    [Test]
    public void RepositroyHighestLevelHero()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("David", 15);
        heroes.Create(hero);
        heroes.Create(new Hero("Ivan", 10));
        var f = heroes.GetHeroWithHighestLevel();
        Assert.AreEqual(f,hero);
    }
    [Test]
    public void RepositroyGetHeroExisting()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("David", 15);
        heroes.Create(hero);
        var f = heroes.GetHero("David");
        Assert.AreEqual(f, hero);
    }
    [Test]
    public void RepositroyGetHeroNonExisting()
    {
        HeroRepository heroes = new HeroRepository();
        Hero hero = new Hero("David", 15);
        heroes.Create(hero);
        var f = heroes.GetHero("Ivan");
        Assert.AreEqual(f, null);
    }
}
