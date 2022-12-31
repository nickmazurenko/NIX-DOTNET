using ZooData.Models;

namespace ZooData;

public class Zoo
{
    private List<Animal> _animals = new List<Animal>();
    private readonly int _maxCount;
    private int _animalsCount;

    public Zoo(int count = 5)
    {
        _maxCount = count;
    }

    public Zoo(List<Animal> animals, int count = 5)
    {
        _maxCount = count;
        _animals = new List<Animal>(animals);
    }

    public int MaxCount => _maxCount;

    public int AnimalsCount => _animalsCount;

    public List<Animal> Animals
    {
        get => _animals;
        set
        {
            if (value.Count > 0)
            {
                _animals = value;
                _animalsCount = _animals.Count;
            }
        }
    }

    public Animal? Add(AnimalType type, string name, string description, string birthDate)
    {
        if (_animalsCount >= _maxCount) return null;
        Animal newAnimal = new Animal
        {
            Type = type,
            Name = name,
            Description = description,
            BirthDate = birthDate
        };

        _animals.Add(newAnimal);
        _animalsCount = _animals.Count;

        return newAnimal;
    }

    public Animal Add(Animal newAnimal)
    {
        if (_animalsCount >= _maxCount) return null;

        _animals.Add(newAnimal);
        _animalsCount = _animals.Count;

        return newAnimal;
    }

    public Animal RemoveAnimalIndex(int index)
    {
        var removed = _animals[index];
        _animals.RemoveAt(index);
        _animalsCount = _animals.Count;
        return removed;
    }

    public Animal? RemoveAnimalName(string name)
    {
        int index;
        Animal? removed = null;
        for (index = _animals.Count - 1; index >= 0; index--)
        {
            if (_animals[index].Name == name)
            {
                removed = _animals[index];
                _animals.RemoveAt(index);
            }
        }

        _animalsCount = _animals.Count;
        return removed;
    }

    public List<Animal?> FindAnimals(string query)
    {
        List<Animal?> searchResult = new List<Animal?>();
        int index;
        for (index = 0; index < _animals.Count; index++)
        {
            var animal = _animals[index];
            if (animal.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase) ||
                animal.Type.ToString().Contains(query, StringComparison.InvariantCultureIgnoreCase))
            {
                searchResult.Add(animal);
            }
        }

        return searchResult;
    }

    public override string ToString()
    {
        string animals = "";

        for (var index = 0; index < _animals.Count; index++)
        {
            var animal = _animals[index];
            animals += $"\tAnimal №{index}\n" +
                       $"{animal}\n";
        }

        return animals;
    }
}