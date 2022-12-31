using ZooData;
using ZooData.Models;

namespace ZooMenu.Models;

internal static class Menu
{
    private static readonly Zoo zoo = new Zoo();

    public static bool MainMenu()
    {
        ShowOptions();
        switch (Console.ReadLine())
        {
            case "1":
                zoo.Add(GetAnimal());
                return true;
            case "2":
                ShowAnimals();
                return true;
            case "3":
                FindAnimals();
                return true;
            case "4":
                RemoveAnimals();
                return true;
            case "5":
                ShowBehaviour();
                return true;
            case "0":
                return false;
            default:
                return true;
        }
    }

    private static void ShowOptions()
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Add Animal");
        Console.WriteLine("2) Show Animals");
        Console.WriteLine("3) Find Animals");
        Console.WriteLine("4) Remove Animal");
        Console.WriteLine("5) Demonstrate object behaviour");
        Console.WriteLine("0) Exit");
        Console.Write("\r\nSelect an option: ");
    }

    private static Animal GetAnimal()
    {
        if (zoo.AnimalsCount >= zoo.MaxCount)
        {
            Console.Clear();
            Console.WriteLine("Max count of animals is 5");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            return null!;
        }

        Animal animal = new Animal();
        Console.Clear();
        animal.Type = ReadAnimalType();
        Console.WriteLine("Animal name: ");
        animal.Name = Console.ReadLine();
        Console.WriteLine("Animal Description: ");
        animal.Description = Console.ReadLine();
        Console.WriteLine("Animal Date of Birth (e.g. 20.12.2022): ");
        animal.BirthDate = Console.ReadLine();
        return animal;
    }

    private static AnimalType ReadAnimalType()
    {
        Console.WriteLine("Choose animal Type:");
        string[] names = Enum.GetNames(typeof(AnimalType));
        for (var index = 0; index < names.Length; index++)
        {
            var name = names[index];
            Console.WriteLine($"{index + 1}) {name}");
        }

        bool isChoice = int.TryParse(Console.ReadLine(), out int choice);
        if (!isChoice || choice < 0 || choice > names.Length)
            return ReadAnimalType();

        return (AnimalType)(choice - 1);
    }

    private static void ShowAnimals()
    {
        Console.Clear();
        Console.WriteLine(zoo.AnimalsCount > 0 ? zoo : "No animals in this zoo yet");
        Console.WriteLine("Press Any Key To Get Back");
        Console.ReadLine();
    }

    private static void FindAnimals()
    {
        Console.Clear();
        Console.WriteLine("Search by name and type:");
        var searchResult = new Zoo(zoo.FindAnimals(Console.ReadLine()));
        Console.Clear();
        Console.WriteLine($"Found {searchResult.Animals.Count}");
        Console.WriteLine(searchResult);
        Console.WriteLine("Press Any Key To Get Back");
        Console.ReadLine();
    }

    private static void ShowBehaviour()
    {
        Console.Clear();
        Animal example = new Animal();
        Console.WriteLine("We have an animal");
        Console.WriteLine(example);
        Console.WriteLine("We can change animal age");
        example.ChangeAge(5);
        Console.WriteLine(example);
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    private static void RemoveAnimals()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Remove animal by: ");
            Console.WriteLine("1) index");
            Console.WriteLine("2) name");
            Console.WriteLine("0) back");
            Animal removed;
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Input animal to remove number");
                    if (int.TryParse(Console.ReadLine(), out int toRemove))
                    {
                        removed = zoo.RemoveAnimalIndex(toRemove);
                        Console.WriteLine($"Removed Animal:\n{removed}");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("It is not a number, did you want to remove by Name?");
                        Console.ReadLine();
                        RemoveAnimals();
                    }

                    break;
                case "2":
                    Console.WriteLine("Input animal to remove name");
                    removed = zoo.RemoveAnimalName(Console.ReadLine());
                    Console.WriteLine($"Removed Animal:\n{removed}");
                    Console.ReadLine();
                    break;
                case "0":
                    return;
                default:
                    continue;
            }

            break;
        }
    }
}