using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("525 S Center St", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("Karina Boyd", addr1);
        Order order1 = new Order(cust1);

        order1. AddProduct(new Product("Laptop", "L001", 88.00m, 1));
        order1. AddProduct(new Product("Mouse", "MOO1", 20.00m, 2));

        Address addr2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Cole Foe", addr2);
        Order order2 = new Order(cust2);

        order2.AddProduct(new Product("Keyboard", "K001", 50.00m, 1));
        order2.AddProduct(new Product("Monitor", "M002", 200.00m, 1));
        order2.AddProduct(new Product("HDMI Cable", "C001", 10.00m, 3));

        Order[] myOrders = { order1, order2 };

        foreach (Order o in myOrders)
        {
            Console.WriteLine(o.GetPackingLabel());
            Console.WriteLine(o.GetShippingLabel());

        Console.WriteLine("Total Price: $" + o.CalculateTotalCost().ToString("F2"));
        Console.WriteLine();
         }
    }
}