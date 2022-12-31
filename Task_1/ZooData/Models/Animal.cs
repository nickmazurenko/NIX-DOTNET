using System.Globalization;

namespace ZooData.Models;

public class Animal
{
    private AnimalType _type = AnimalType.Mammal;
    private string? _name;
    private string? _description;
    private DateTime _birthDate = DateTime.Now;

    public AnimalType Type
    {
        get => _type;
        set => _type = value is AnimalType ? value : AnimalType.Mammal;
    }

    public string? Name
    {
        get => _name;
        set => _name = value is { Length: > 0 } ? value : "unknown";
    }

    public string? Description
    {
        get => _description;
        set => _description = value is { Length: > 0 } ? value : "unknown";
    }

    public string? BirthDate
    {
        get => _birthDate.Year.ToString(CultureInfo.InvariantCulture);
        set
        {
            bool isDate = DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime date);
            if (!isDate)
                date = DateTime.Now;
            _birthDate = DateTime.Now >= date ? date : DateTime.Now;
        }
    }

    private int Age => DateTime.Now.Year - _birthDate.Year;

    public void ChangeAge(int newAge)
    {
        BirthDate = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year - newAge}";
    }

    public override string ToString()
    {
        return
            $"Name: {Name}\n" +
            $"Type: {Type}\n" +
            $"Description:\n" +
            $"\t{Description}\n" +
            $"Date of Birth: {BirthDate}\n" +
            $"Age: {Age}\n";
    }
}