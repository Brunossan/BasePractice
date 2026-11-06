namespace CleanCodeShenaningans.SOLID;

// Exemplo propositalmente ruim para estudar as violações dos princípios SOLID.
public class SellingMachine
{
    // SRP: a classe controla estoque, regras de negócio, pagamento,
    // persistência.
    public void ProcessOrder(
        string customerName,
        string item,
        string paymentMethod)
    {
        if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(item))
        {
            throw new ArgumentException("Cliente e Item são obrigatórios.");
        }

        var price = item switch
        {
            "Water" => 2.00m,
            "Juice" => 5.00m,
            "Soda" => 4.50m,
            _ => throw new ArgumentException("Item não encontrado.")
        };

        // OCP: cada novo meio de pagamento exige alterar este método.
        switch (paymentMethod)
        {
            case "CreditCard":
                new CreditCardPayment().Pay(price);
                break;
            case "Pix":
                new PixPayment().Pay(price);
                break;
            default:
                throw new NotSupportedException("Forma de pagamento não suportada.");
        }

        // DIP: a regra de negócio cria e conhece diretamente implementações concretas.
        new FileOrderRepository().Save(customerName, item, price);
    }
}

public interface IPayment
{
    void Pay(decimal amount);

    string GetTrasactionId();
}

public sealed class CreditCardPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cartão: {amount:C}");
    public string GetTrasactionId() => "7418596" ;
}

public sealed class PixPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Pix: {amount:C}");
    public string GetTrasactionId() => "123456789";
}

public sealed class CashPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Cash: {amount:C}");

    // LSP: CashPayment não tem Id, mas a interface IPayment exige.
    public string GetTrasactionId() => throw new NotImplementedException("This does not have Id");

}

public sealed class FileOrderRepository
{
    public void Save(string customerName, string flavor, decimal price)
    {
        File.AppendAllText("orders.txt", $"{customerName};{flavor};{price}{Environment.NewLine}");
    }
}
