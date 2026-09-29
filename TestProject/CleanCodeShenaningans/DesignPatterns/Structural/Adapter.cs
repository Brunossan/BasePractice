namespace CleanCodeShenaningans.DesignPatterns.Structural;

//https://refactoring.guru/design-patterns/adapter

public class CelsiusClass
{   
    public void IsBoilingWater(double temperature)
    {
        if(temperature >= 100)
        {
            Console.WriteLine($"Is hot");
        }
        else
        {
            Console.WriteLine($"not hot enought");
        }
    }
}

public class FahrenheitClass
{
    public void CheckIfFever(double temperature)
    {
        if (temperature >= 100)
        {
            Console.WriteLine("Checking if the temperature indicates a fever in Fahrenheit or something...");
        }
        else
        {
            Console.WriteLine("Temperature is normal in Fahrenheit or something...");
        }
    }
}

public class FahrenheitClassAdapter
{
    private readonly FahrenheitClass _fahrenheitClass = new FahrenheitClass();

    public void CheckIfFever(double temperature) => _fahrenheitClass.CheckIfFever(((temperature* 9)/5) + 32) ;
}
