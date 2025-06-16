namespace InvoiceLibrary;

public class Invoice
{
    public List<InvoiceItem> Items { get; } = [];
    public decimal Discount { get; private set; }

    public void AddItem(string name, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");

        if (price < 0 || quantity <= 0)
            throw new ArgumentException("Invalid price or quantity.");

        Items.Add(new InvoiceItem(name, price, quantity));
    }

    public void ApplyDiscount(decimal percent)
    {
        if (percent is < 0 or > 100)
            throw new ArgumentException("Invalid discount.");

        Discount = percent;
    }

    public decimal GetTotal()
    {
        var total = Items.Sum(i => i.Price * i.Quantity);
        return total * (1 - Discount / 100);
    }
}