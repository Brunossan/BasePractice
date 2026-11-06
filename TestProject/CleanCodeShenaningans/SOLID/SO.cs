namespace CleanCodeShenaningans.SOLID;

public class SoSellingMachine
{
    // SRP: Agora a classe coordena somente o processamento do pedido. O valor dos itens, pagamento e persistência são responsabilidades de outras classes.
    public void ProcessOrder(
        string customerName,
        ISProduct item,
        string paymentMethod)
    {
        if (string.IsNullOrWhiteSpace(customerName) || item == null)
        {
            throw new ArgumentException("Cliente e Item são obrigatórios.");
        }
        new SoPaymentService().ProcessPayment(paymentMethod, item.GetPrice());

        // DIP: a regra de negócio cria e conhece diretamente implementações concretas.
        new SoFileOrderRepository().Save(customerName, item.GetName(), item.GetPrice());
    }
}

public interface ISoProduct
{
    string GetName();
    decimal GetPrice();
}

public class SoWater : ISProduct
{
    public string GetName() => "Water";
    public decimal GetPrice() => 2.00m;
}

public class SoJuice : ISProduct
{
    public string GetName() => "Juice";

    public decimal GetPrice() => 5.00m;
}

public class SoSoda : ISProduct
{
    public string GetName() => "Soda";

    public decimal GetPrice() => 4.50m;
}

public class SoPaymentService
{
    public void ProcessPayment(string paymentMethod, decimal price)
    {
        // OCP: Agora a responsabilidade de criar instâncias de pagamento foi movida para uma factory, mas ainda exige alteração para cada novo método de pagamento.
        new SoPaymentFactory().Create(paymentMethod).Pay(price);
    }
}


public class SoPaymentFactory
{
    public ISoPayment Create(string paymentMethod)
    {
        // OCP: Esta factory tem o objetivo de criar instâncias de pagamento, mas ainda exige alteração para cada novo método de pagamento.
        switch (paymentMethod)
        {
            case "CreditCard":
                return new SoCreditCardPayment();
            case "Pix":
                return new SoPixPayment();
            case "Cash":
                return new SoCashPayment();
            default:
                throw new NotSupportedException("Forma de pagamento não suportada.");
        }
    }
}


public interface ISoPayment
{
    void Pay(decimal amount);

    string GetTrasactionId();
}

public sealed class SoCreditCardPayment : ISoPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cartão: {amount:C}");
    public string GetTrasactionId() => "7418596";
}

public sealed class SoPixPayment : ISoPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Pix: {amount:C}");
    public string GetTrasactionId() => "123456789";
}

public sealed class SoCashPayment : ISoPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cash: {amount:C}");

    // LSP: CashPayment não tem Id, mas a interface IPayment exige.
    public string GetTrasactionId() => throw new NotImplementedException("This does not have Id");

}

public sealed class SoFileOrderRepository
{
    public void Save(string customerName, string flavor, decimal price)
    {
        File.AppendAllText("orders.txt", $"{customerName};{flavor};{price}{Environment.NewLine}");
    }
}
