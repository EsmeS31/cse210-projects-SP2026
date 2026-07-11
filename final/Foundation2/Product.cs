public class Product
{
    private string _name;
    private string _productId;
    private decimal _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = price;
        _quantity = quantity;
    }

    public string GetName() {return _name; }
    public string GetId() {return _productId; }

    public decimal CalculateProductCost()
    {
        return _pricePerUnit * _quantity;
    }
}