using FluentAssertions;
using InvoiceLibrary;

namespace InvoiceLibraryTests;

public class InvoiceTestsGrade3
{
    [Fact]
    public void GetTotal_ShouldBeZero_WhenEmptyInvoice()
    {
        // Arrange
        var invoice = new Invoice();

        // Act
        var total = invoice.GetTotal();

        // Assert
        total.Should().Be(0);
    }

    [Fact]
    public void AddItem_ShouldAddItemToList()
    {
        // Arrange
        var invoice = new Invoice();

        // Act
        invoice.AddItem("Test Item", 10, 2);

        // Assert
        invoice.Items.Should().ContainSingle(item =>
            item.Name == "Test Item" &&
            item.Price == 10 &&
            item.Quantity == 2
        );
    }

    [Fact]
    public void GetTotal_ShouldReturnSumWithoutDiscount_WhenNoDiscountApplied()
    {
        // Arrange
        var invoice = new Invoice();
        invoice.AddItem("Item A", 10, 2); // 20
        invoice.AddItem("Item B", 15, 1); // 15

        // Act
        var total = invoice.GetTotal();

        // Assert
        total.Should().Be(35);
    }

    [Fact]
    public void GetTotal_ShouldReturnSame_WhenAppliedDiscountIsZero()
    {
        // Arrange
        var invoice = new Invoice();
        invoice.AddItem("Item A", 20, 1); // 20
        invoice.ApplyDiscount(0);

        // Act
        var total = invoice.GetTotal();

        // Assert
        total.Should().Be(20);
    }
}
