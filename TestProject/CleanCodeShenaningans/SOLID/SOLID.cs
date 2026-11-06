using CleanCodeShenaningans.SOLID;

namespace CleanCodeShenaningans.SoliID;

public class SoliSellingMachine
{
    private readonly ISoliPaymentService _paymentService;
    private readonly ISoliFileOrderRepository _fileOrderRepo;

    public SoliSellingMachine(
        ISoliPaymentService soliPaymentService,
        ISoliFileOrderRepository soliFileOrderRepository
        )
    {
        // DIP: A regra de negócio não conhece mais implementações concretas, mas sim abstrações.
        _paymentService = soliPaymentService;
        _fileOrderRepo = soliFileOrderRepository;
    }

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
        _paymentService.ProcessPayment(paymentMethod, item.GetPrice());

        _fileOrderRepo.Save(customerName, item.GetName(), item.GetPrice());
    }
}

public interface ISoliProduct
{
    string GetName();
    decimal GetPrice();
}

public class SoliWater : ISoliProduct
{
    public string GetName() => "Water";
    public decimal GetPrice() => 2.00m;
}

public class SoliJuice : ISoliProduct
{
    public string GetName() => "Juice";

    public decimal GetPrice() => 5.00m;
}

public class SoliSoda : ISoliProduct
{
    public string GetName() => "Soda";

    public decimal GetPrice() => 4.50m;
}


public interface ISoliPaymentService
{
    void ProcessPayment(string paymentMethod, decimal price);
}
public class SoliPaymentService : ISoliPaymentService
{
    public void ProcessPayment(string paymentMethod, decimal price)
    {
        // OCP: Agora a responsabilidade de criar instâncias de pagamento foi movida para uma factory, mas ainda exige alteração para cada novo método de pagamento.
        new SoliPaymentFactory().Create(paymentMethod).Pay(price);
    }
}


public class SoliPaymentFactory
{
    public ISoliPayment Create(string paymentMethod)
    {
        // OCP: Esta factory tem o objetivo de criar instâncias de pagamento, mas ainda exige alteração para cada novo método de pagamento.
        switch (paymentMethod)
        {
            case "CreditCard":
                return new SoliCreditCardPayment();
            case "Pix":
                return new SoliPixPayment();
            case "Cash":
                return new SoliCashPayment();
            default:
                throw new NotSupportedException("Forma de pagamento não suportada.");
        }
    }
}


public interface ISoliPayment
{
    void Pay(decimal amount);
}

public interface ISoliTransactionPayment : ISoliPayment
{
    string GetTrasactionId();
}

public sealed class SoliCreditCardPayment : ISoliTransactionPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cartão: {amount:C}");
    public string GetTrasactionId() => "7418596";
}

public sealed class SoliPixPayment : ISoliTransactionPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Pix: {amount:C}");
    public string GetTrasactionId() => "123456789";
}

public sealed class SoliCashPayment : ISoliPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cash: {amount:C}");

    // LSP: Agora a interface ISoliPayment não exige mais um Id, então CashPayment não quebra mais o LSP.
    //public string GetTrasactionId() => throw new NotImplementedException("This does not have Id");

}

public interface ISoliFileOrderRepository { public void Save(string customerName, string item, decimal price); }

public sealed class SoliFileOrderRepository : ISoliFileOrderRepository
{
    public void Save(string customerName, string item, decimal price)
    {
        File.AppendAllText("orders.txt", $"{customerName};{item};{price}{Environment.NewLine}");
    }
}
