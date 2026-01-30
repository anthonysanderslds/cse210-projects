using System.Reflection.Metadata.Ecma335;

public class Product
{
    private string _productName;
    private int _productId; 
    private double _productPrice;
    private int _productQuantity;

    public Product(string productName, int productId, double price, int quantity)
    {
        _productName = productName;
        _productId = productId;
        _productPrice =  price;
        _productQuantity = quantity;
    }

    public string GetProductName()
    {
        return _productName;
    }

    public int GetProductId()
    {
        return _productId;
    }

    public double ComputeCost()
    {
        double cost  = _productPrice * _productQuantity;
        return cost;
    }
}