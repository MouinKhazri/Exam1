namespace InvoiceLibrary;

public class InvoiceItem
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public InvoiceItem(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}