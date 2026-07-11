using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal total = 0;
        foreach (Product p in _products)
        {
            total = total + p.CalculateProductCost();
        }
        if(_customer.IsInUSA())
        {
            total = total +5;
        }
        else
        {
            total = total +35;
        }
        return total;
    }
    public string GetPackingLabel()
    {
        string label = "Packing label for " + _customer.GetName() + ":\n";
        foreach (Product p in _products)
        {
            label = label + "- " + p.GetName() + " (ID: " + p.GetId() + ")\n";
        }
        return label;
    }
    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetName() + "\n" + _customer.GetAddress().GetFullAddress();
    }
}