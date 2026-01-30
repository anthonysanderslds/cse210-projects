using System;

class Program
{
    static void Main(string[] args)
    {
        List<Product> productList1 = new List<Product>();
        List<Product> productList2 = new List<Product>();
        List<Product> productList3 = new List<Product>();

        Address address1 = new Address("123 Main Street", "Columbus", "Ohio", "USA");
        Address address2 = new Address("456 Black Street", "Campo Grande", "Rio de Janeiro", "Brasil");
        Address address3 = new Address("2067 70th Ave", "Osceola", "Wisconsin", "USA");

        Customer customer1 = new Customer("Billy Joe", address1);
        Customer customer2 = new Customer("Jorge da Silva", address2);
        Customer customer3 = new Customer("Buddy McIntyre", address3);

        Product product1 = new Product("Jelly Beans", 1234, 4.99, 2);
        Product product2 = new Product("Reese's Puffs", 5678, 3.29, 1);
        Product product3 = new Product("Watermelon Bubbl'r", 9845, 4.56, 6);
        productList1.Add(product1);
        productList1.Add(product2);
        productList1.Add(product3);

        Product product4 = new Product("Bean Bag", 3245, 15.99, 1);
        Product product5 = new Product("Apple Watch Series 2", 3345, 349.25, 2);
        Product product6 = new Product("Pillow Case", 4498, 23.50, 2);
        productList2.Add(product4);
        productList2.Add(product5);
        productList2.Add(product6);

        Product product7 = new Product("Fat Wood", 1111, 24.99, 4);
        Product product8 = new Product("Matches", 2339, 2.75, 2);
        Product product9 = new Product("Water Bottle", 6798, 5.99, 1);
        productList3.Add(product7);
        productList3.Add(product8);
        productList3.Add(product9);

        Order order1 = new Order(productList1, customer1);
        Order order2 = new Order(productList2, customer2);
        Order order3 = new Order(productList3, customer3);

        Console.WriteLine(new string('~', 40));
        Console.WriteLine($"Order 1:");
        Console.WriteLine($"Customer: {order1.GenerateShippingLabel()}\nPacking List:\n{order1.GeneratePackingList()}\nOrder Total: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine(new string('~', 40));
        Console.WriteLine($"Order 2:");
        Console.WriteLine($"Customer: {order2.GenerateShippingLabel()}\nPacking List:\n{order2.GeneratePackingList()}\nOrder Total: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine(new string('~', 40));
        Console.WriteLine($"Order 3:");
        Console.WriteLine($"Customer: {order3.GenerateShippingLabel()}\nPacking List:\n{order3.GeneratePackingList()}\nOrder Total: ${order3.CalculateTotalCost():F2}");
        Console.WriteLine(new string('~', 40));
    }
}