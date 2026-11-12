namespace CleanCodeShenaningans.DesignPatterns.Creational;


// EN : The Singleton should always be a 'sealed' class to prevent class
// inheritance through external classes and also through nested classes.
public sealed class GameManager
{
    // The Singleton's constructor should always be private to prevent
    // direct construction calls with the `new` operator.
    private GameManager() { }

    private string _status = "Started";

    // The Singleton's instance is stored in a static field. There there are
    // multiple ways to initialize this field, all of them have various pros
    // and cons. In this example we'll show the simplest of these ways,
    // which, however, doesn't work really well in multithreaded program.
    private static GameManager _instance;

    // This is the static method that controls the access to the singleton
    // instance. On the first run, it creates a singleton object and places
    // it into the static field. On subsequent runs, it returns the client
    // existing object stored in the static field.
    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
    }

    public void PrintStatus()
    {
        Console.WriteLine("Status of game: "+ _status);
    }
    public void ChangeStatus(string st)
    {
        _status = st;
        Console.WriteLine("Status of game changed.");
    }
}
