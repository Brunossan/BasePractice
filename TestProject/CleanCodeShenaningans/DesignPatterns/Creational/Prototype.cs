namespace CleanCodeShenaningans.DesignPatterns.Creational;

/// example from https://refactoring.guru/design-patterns/prototype

public interface IMonsterPrototype
{
    IMonsterPrototype Clone();
    IMonsterPrototype DeepClone();
    void DisplayInfo();
}

public class Monster : IMonsterPrototype
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Atack Attack { get; set; }
    public Monster(string name, int health, Atack attack)
    {
        Name = name;
        Health = health;
        Attack = attack;
    }
    public IMonsterPrototype Clone()
    {
        return (IMonsterPrototype)this.MemberwiseClone();
    }

    // If the prototype attack must be changed this must be used to avoid changing the original prototype
    public IMonsterPrototype DeepClone()
    {
        var response = (Monster)this.MemberwiseClone();
        response.Attack = new Atack(Attack.Type, Attack.Element);
        return response;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Monster: {Name}, Health: {Health}, Attack: {Attack.Type} ({Attack.Element})");
    }
}

public class Atack
{
    public string Type { get; set; }
    public string Element { get; set; }
    public Atack(string type, string element)
    {
        Type = type;
        Element = element;
    }
}