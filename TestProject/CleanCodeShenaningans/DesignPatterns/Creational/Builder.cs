namespace CleanCodeShenaningans.DesignPatterns.Creational;

/// https://refactoring.guru/design-patterns/builder

public interface ICharacterBuilder
{
    void AddItens();
    void AddCharacteristics();
}

public interface ICharacter
{   
    void ShowCharacter();
}

public class Character : ICharacter
{
    private List<string> _items = new List<string>();
    private List<string> _characteristics = new List<string>();
    public void AddItem(string item)
    {
        _items.Add(item);
    }
    public void AddCharacteristic(string characteristic)
    {
        _characteristics.Add(characteristic);
    }
    public void ShowCharacter()
    {
        Console.WriteLine("Character Items: " + string.Join(", ", _items));
        Console.WriteLine("Character Characteristics: " + string.Join(", ", _characteristics));
    }
}

public class FighterBuilder : ICharacterBuilder
{
    private Character _character = new Character();
    public void AddItens()
    {
        _character.AddItem("Sword");
        _character.AddItem("Shield");
    }
    public void AddCharacteristics()
    {
        _character.AddCharacteristic("Brave");
        _character.AddCharacteristic("Dumb");
    }
    public Character GetCharacter()
    {
        return _character;
    }
}