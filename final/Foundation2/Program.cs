using System;
using System.Reflection.Metadata.Ecma335;

class Product
{
    private string _productName;
    private int _productID;
    private int _price;
    private int _quantity;

    public Product(string name, int id, int price, int quantity)
    {
        _productName = name;
        _productID = id;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _productName;
    }

    public int GetTotalCost()
    {
        return _price * _quantity;
    }

    public override string ToString()
    {
        return $"{_productName} (ID: {_productID})";
    }
}

class Customer 
{
    private string _customerName;
    private Address _address;

    public Customer(string name, Address address)
    {
        _customerName = name;
        _address = address;
    }

    public string GetName()
    {
        return _customerName;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public bool IsUSACustomer()
    {
        return _address.IsUSA();
    }

    public override string ToString()
    {
        return _customerName;
    }
}

class Address 
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _streetAddress = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states";
    }

    public override string ToString()
    {
        return $"{_streetAddress}, {_city}, {_state}, {_country}";
    }
}

class Order 
{
    private List<Product> _products;
    private Customer _customer;
    private int _shippingCost;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"Product: {product}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nCustomer Name: {_customer.GetName()}\nAddress: {_customer.GetAddress()}";
    }

    public int CalculateTotalPrice()
    {
        int totalPrice = 0;
        foreach (Product product in _products)
        {
            totalPrice += product.GetTotalCost();
        }
        _shippingCost = _customer.IsUSACustomer() ? 5 : 35;
        totalPrice += _shippingCost;
        return totalPrice;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("1234 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Jon Dune", address1);

        Address address2 = new Address("5678 Elm St", "Los Angeles", "CA", "USA");
        Customer customer2 = new Customer("Eliza Dukes", address2);

        Product product1 = new Product("Laptop", 1, 1000, 2);
        Product product2 = new Product("Mouse", 2, 20, 5);
        Product product3 = new Product("Keyboard", 3, 50, 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}");

        Console.WriteLine("\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}");
    }
}