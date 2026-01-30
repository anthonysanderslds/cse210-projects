public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> product, Customer customer)
    {
        _products = product;
        _customer = customer;
    }

    public double CalculateTotalCost()
    {
         double _totalCost = 0;
        foreach (Product product in _products)
        {
            double cost = 0;
            cost = product.ComputeCost();
            _totalCost += cost;
        }

        if (_customer.LivesInUSA())
        {
            _totalCost += 5;
        }
        else
        {
            _totalCost += 35;
        }

        return _totalCost;
    }
    public string GenerateShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GenerateAddressString()}\n";
    }

    public string GeneratePackingList()
    {
        string _packingLabel = "";
        foreach (Product product in _products)
        {
            string labelHelper = "";
            labelHelper = $"Product ID & Name: {product.GetProductId()} ({product.GetProductName()})\n";
            _packingLabel += labelHelper;
        }
        return _packingLabel;
    }
}