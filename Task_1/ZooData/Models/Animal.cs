using System.Globalization;

namespace ZooData.Models;

public class Animal
{
    public AnimalType Type = AnimalType.Mammal;
    public string? Name;
    public string? Description;
    private DateTime _birthDate = DateTime.Now;

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

    public int Age => DateTime.Now.Year - _birthDate.Year;

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