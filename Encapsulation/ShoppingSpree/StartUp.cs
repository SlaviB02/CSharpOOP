using System;
using System.Linq;
using System.Collections.Generic;
namespace ShoppingSpree
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputPeople = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            for (int i=0;i<inputPeople.Length;i++)
            {
                string[] person = inputPeople[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                Person p = null;
                try
                {
                    p = new Person(person[0], int.Parse(person[1]));
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                people.Add(p);
            }
            
            string[] inputProduct = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            for (int i = 0; i < inputProduct.Length; i++)
            {
                string[] product = inputProduct[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                Product q = null;
                try
                {
                    q = new Product(product[0], int.Parse(product[1]));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                products.Add(q);
            }
            
            while(true)
            {
                string []command = Console.ReadLine().Split(" ");
                if(command[0]=="END")
                {
                    break;
                }
                string name = command[0];
                string product = command[1];
                Person seachedPerson = people.First(x => x.Name == name);
                Product seachedProduct = products.First(x => x.Name == product);
                if(seachedPerson.Money>=seachedProduct.Cost)
                {
                    seachedPerson.Money -= seachedProduct.Cost;
                    Console.WriteLine($"{seachedPerson.Name} bought {seachedProduct.Name}");
                    seachedPerson.BagOfProducts.Add(seachedProduct);
                }
                else
                {
                    Console.WriteLine($"{seachedPerson.Name} can't afford {seachedProduct.Name}");
                }
            }
            foreach(var person in people)
            {
                if(person.BagOfProducts.Count==0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                  
                    List<string> finalArray=new List<string>();
                    foreach (var product in person.BagOfProducts)
                    {
                        finalArray.Add(product.Name);
                    }
                    Console.WriteLine($"{person.Name} - {string.Join(", ",finalArray)}");
                }
            }
           
        }
    }
}
