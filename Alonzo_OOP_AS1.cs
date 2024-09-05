using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Kind
{
    Dog,
    Cat,
    Lizard,
    Bird
}

public enum Gender 
{
    Male,
    Female
}

public abstract class Pet
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Owner { get; set; }

    public Pet (string name, Gender gender, string owner)
    {
        Name = name;
        Gender = gender;
        Owner = owner;
    }

    public abstract override string ToString();
}
public class Dog : Pet
{
    public string Breed { get; set; }

    public Dog (string name, Gender gender, string owner, string breed)
        : base(name, gender, owner)
    {
        Breed = breed;
    }

    public override string ToString()
    {
        return $"Dog - {Name} ({Gender}), Owner: {Owner}, Breed: {Breed}";
    }
}
public class Cat : Pet
{
    public bool IsLonghaired { get; set; }

    public Cat(string name, Gender gender, string owner, bool isLonghaired)
        : base(name, gender, owner)
    {
        IsLonghaired = isLonghaired;
    }

    public override string ToString()
    {
        string hairType = IsLonghaired ? "Longhaired" : "Shorthaired";
        return $"Cat - {Name} ({Gender}), Owner: {Owner}, Hair Type: {hairType}";
    }
}

public class Lizard : Pet
{
    public bool CanFly { get; set; }

    public Lizard(string name, Gender gender, string owner, bool canFly)
        : base(name, gender, owner)
    {
        CanFly = canFly;
    }

    public override string ToString()
    {
        string flyAbility = CanFly ? "Can fly" : "Cannot fly";
        return $"Lizard - {Name} ({Gender}), Owner: {Owner}, {flyAbility}";
    }
}

public class Bird : Pet
{
    public bool CanFly { get; set; }

    public Bird(string name, Gender gender, string owner, bool canFly)
        : base(name, gender, owner)
    {
        CanFly = canFly;
    }

    public override string ToString()
    {
        string flyAbility = CanFly ? "Can fly" : "Cannot fly";
        return $"Bird - {Name} ({Gender}), Owner: {Owner}, {flyAbility}";
    }
}

public class Dog : Pet, IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

public class Bird : Pet, IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine($"{Name} says: Tweet!");
    }
}


class Program
{
    static void Main()
    {
        List<Pet> petInventory = new List<Pet>();

        Console.WriteLine("Welcome to the Pet Inventory!");

        while (true)
        {
            Console.WriteLine("Kind (Dog, Cat, Lizard, Bird):");
            if (!Enum.TryParse(Console.ReadLine(), true, out Kind kind))
            {
                Console.WriteLine("Invalid kind. Try again.");
                continue;
            }


            Pet newPet = null;

            switch (kind)
            {
                case Kind.Dog:
                    Console.WriteLine("Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Gender (M/F): ");
                    Gender gender = Console.ReadLine().ToUpper() == "M" ? Gender.Male : Gender.Female;
                    Console.WriteLine("Breed: ");
                    string breed = Console.ReadLine();
                    Console.WriteLine("Owner: ");
                    string owner = Console.ReadLine();
                    newPet = new Dog(name, gender, owner, breed);
                    break;

                case Kind.Cat:
                    Console.WriteLine("Name:");
                    string names = Console.ReadLine();
                    Console.WriteLine("Gender (M/F):");
                    Gender genders = Console.ReadLine().ToUpper() == "M" ? Gender.Male : Gender.Female;
                    Console.WriteLine("Is Long Haired? : ");
                    bool isLonghaired = Console.ReadLine().ToLower() == "y";
                    Console.WriteLine("Owner:");
                    string owners = Console.ReadLine();
                    newPet = new Cat(names, genders, owners, isLonghaired);
                    break;

                case Kind.Lizard:
                    Console.WriteLine("Name:");
                    string namess = Console.ReadLine();
                    Console.WriteLine("Gender (M/F):");
                    Gender genderss = Console.ReadLine().ToUpper() == "M" ? Gender.Male : Gender.Female;
                    Console.WriteLine("Owner:");
                    string ownerss = Console.ReadLine();
                    Console.WriteLine("Can Fly? (y/n):");
                    bool canFlyLizard = Console.ReadLine().ToLower() == "y";
                    newPet = new Lizard(namess, genderss, ownerss, canFlyLizard);
                    break;
                case Kind.Bird:
                    Console.WriteLine("Name:");
                    string namesss = Console.ReadLine();
                    Console.WriteLine("Gender (M/F):");
                    Gender gendersss = Console.ReadLine().ToUpper() == "M" ? Gender.Male : Gender.Female;
                    Console.WriteLine("Owner:");
                    string ownersss = Console.ReadLine();
                    Console.WriteLine("Can Fly? (y/n):");
                    bool canFlyBird = Console.ReadLine().ToLower() == "y";
                    newPet = new Bird(namesss, gendersss, ownersss, canFlyBird);
                    break;
            }

            petInventory.Add(newPet);

            Console.WriteLine("Add another pet? (y/n):");
            if (Console.ReadLine().ToLower() != "y")
                break;
        }

        Console.WriteLine("Which type of animal would you like to list? (Dog, Cat, Lizard, Bird, or 'All'):");
        string filter = Console.ReadLine();

        Console.WriteLine("\nAll pets in the inventory:");
        foreach (Pet pet in petInventory)
        {
            if (filter.ToLower() == "all" || pet.GetType().Name.Equals(filter, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"* {pet}");
            }
        }
    }
}
