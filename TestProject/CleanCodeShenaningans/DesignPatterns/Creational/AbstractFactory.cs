namespace CleanCodeShenaningans.DesignPatterns.Creational;

/// https://refactoring.guru/design-patterns/abstract-factory

public interface IThemeFactory
{
    public abstract IButton CreateButton();
    public abstract ITextBox CreateTextBox();
}

public interface IButton
{
    public abstract string GetButtonType();
    public abstract string GetButtonColor();
}

public interface ITextBox
{
    public abstract string GetTextBoxType();
    public abstract string GetTextBoxColor();
}

public class LightThemeFactory : IThemeFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }
    public ITextBox CreateTextBox()
    {
        return new LightTextBox();
    }
}

public class LightButton : IButton
{
    public string GetButtonType()
    {
        return "Light Button";
    }
    public string GetButtonColor()
    {
        return "White";
    }
}

public class LightTextBox : ITextBox
{
    public string GetTextBoxType()
    {
        return "Light TextBox";
    }
    public string GetTextBoxColor()
    {
        return "White";
    }
}

public class DarkThemeFactory : IThemeFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }
    public ITextBox CreateTextBox()
    {
        return new DarkTextBox();
    }
}

public class DarkButton : IButton
{
    public string GetButtonType()
    {
        return "Dark Button";
    }
    public string GetButtonColor()
    {
        return "Black";
    }
}

public class DarkTextBox : ITextBox
{
    public string GetTextBoxType()
    {
        return "Dark TextBox";
    }
    public string GetTextBoxColor()
    {
        return "Black";
    }
}
