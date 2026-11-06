namespace CleanCodeShenaningans.SOLID;

public class SolSellingMachine
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
        new SolPaymentService().ProcessPayment(paymentMethod, item.GetPrice());

        // DIP: a regra de negócio cria e conhece diretamente implementações concretas.
        new SolFileOrderRepository().Save(customerName, item.GetName(), item.GetPrice());
    }
}

public interface ISolProduct
{
    string GetName();
    decimal GetPrice();
}

public class SolWater : ISProduct
{
    public string GetName() => "Water";
    public decimal GetPrice() => 2.00m;
}

public class SolJuice : ISProduct
{
    public string GetName() => "Juice";

    public decimal GetPrice() => 5.00m;
}

public class SolSoda : ISProduct
{
    public string GetName() => "Soda";

    public decimal GetPrice() => 4.50m;
}

public class SolPaymentService
{
    public void ProcessPayment(string paymentMethod, decimal price)
    {
        // OCP: Agora a responsabilidade de criar instâncias de pagamento foi movida para uma factory, mas ainda exige alteração para cada novo método de pagamento.
        new SolPaymentFactory().Create(paymentMethod).Pay(price);
    }
}


public class SolPaymentFactory
{
    public ISolPayment Create(string paymentMethod)
    {
        // OCP: Esta factory tem o objetivo de criar instâncias de pagamento, mas ainda exige alteração para cada novo método de pagamento.
        switch (paymentMethod)
        {
            case "CreditCard":
                return new SolCreditCardPayment();
            case "Pix":
                return new SolPixPayment();
            case "Cash":
                return new SolCashPayment();
            default:
                throw new NotSupportedException("Forma de pagamento não suportada.");
        }
    }
}


public interface ISolPayment
{
    void Pay(decimal amount);
}

public interface ISolTransactionPayment : ISolPayment
{
    string GetTrasactionId();
}

public sealed class SolCreditCardPayment : ISolTransactionPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cartão: {amount:C}");
    public string GetTrasactionId() => "7418596";
}

public sealed class SolPixPayment : ISolTransactionPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Pix: {amount:C}");
    public string GetTrasactionId() => "123456789";
}

public sealed class SolCashPayment : ISolPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cash: {amount:C}");

    // LSP: Agora a interface ISolPayment não exige mais um Id, então CashPayment não quebra mais o LSP.
    //public string GetTrasactionId() => throw new NotImplementedException("This does not have Id");

}

public sealed class SolFileOrderRepository
{
    public void Save(string customerName, string flavor, decimal price)
    {
        File.AppendAllText("orders.txt", $"{customerName};{flavor};{price}{Environment.NewLine}");
    }
}