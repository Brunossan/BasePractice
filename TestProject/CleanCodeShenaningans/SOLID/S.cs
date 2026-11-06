namespace CleanCodeShenaningans.SOLID;

public class SSellingMachine
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
        new SPaymentService().ProcessPayment(paymentMethod, item.GetPrice());

        // DIP: a regra de negócio cria e conhece diretamente implementações concretas.
        new SFileOrderRepository().Save(customerName, item.GetName(), item.GetPrice());
    }
}

public interface ISProduct
{
    string GetName();
    decimal GetPrice();
}

public class SWater : ISProduct
{
    public string GetName() => "Water";
    public decimal GetPrice() => 2.00m;
}

public class SJuice : ISProduct
{
    public string GetName() => "Juice";

    public decimal GetPrice() => 5.00m;
}

public class SSoda : ISProduct
{
    public string GetName() => "Soda";

    public decimal GetPrice() => 4.50m;
}

public class SPaymentService
{
    public void ProcessPayment(string paymentMethod, decimal price)
    {
        // OCP: cada novo meio de pagamento ainda exige alterar esta classe.
        switch (paymentMethod)
        {
            case "CreditCard":
                new SCreditCardPayment().Pay(price);
                break;
            case "Pix":
                new SPixPayment().Pay(price);
                break;
            default:
                throw new NotSupportedException("Forma de pagamento não suportada.");
        }
    }
}


public interface ISPayment
{
    void Pay(decimal amount);

    string GetTrasactionId();
}

public sealed class SCreditCardPayment : ISPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cartão: {amount:C}");
    public string GetTrasactionId() => "7418596";
}

public sealed class SPixPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Pix: {amount:C}");
    public string GetTrasactionId() => "123456789";
}

public sealed class SCashPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cash: {amount:C}");

    // LSP: CashPayment não tem Id, mas a interface IPayment exige.
    public string GetTrasactionId() => throw new NotImplementedException("This does not have Id");

}

public sealed class SFileOrderRepository
{
    public void Save(string customerName, string flavor, decimal price)
    {
        File.AppendAllText("orders.txt", $"{customerName};{flavor};{price}{Environment.NewLine}");
    }
}
