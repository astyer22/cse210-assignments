using System;
using System.Reflection.Metadata.Ecma335;

class Product
{
    public string _productName;
    public int _productID;
    public int _price;
    public int _quantity;

    public void SetProdcutName(string Pname)
    {
        _productName = Pname;
    }

    public void SetProductID(int id)
    {
        _productID = id;
    }

    public void SetPrice(int price)
    {
        _price = price;
    }

    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }

    public int GetProductPrice()
    {
        return _price * _quantity;
    }
}

class Customer 
{
    public string _customerName;
    public Address _address;

    public void SetCustomerName(string Cname)
    {
        _customerName = Cname;
    }

    public bool IsUSACustomer()
    {
          return _address != null && _address.IsUSA();
    }
}

class Address 
{
    public string _streetAddress;
    public string _city;
    public string _state;
    public string _country;

    public string GetFullAddress()
    {
        return $"{_streetAddress} n/, {_city}, {_state} n/, {_country}";
    }

    public bool IsUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states";
    }
}

class Order 
{
    private List<Product> _product;
    private List<Customer> _customer;
    private int _shippingCost;

    public Order()
    {
        _product = new List<Product>();
        _customer = new List<Customer>();
        
    }

    private List<string> ProductList()
    {
        List<string> productList = new List<string>();
        foreach (var product in _product)
        {
            productList.Add(product._productName);
        }
        return productList;
    }

    private List<string> CustomerList()
    {
        List<string> customerList = new List<string>();
        foreach (var customer in _customer)
        {
            customerList.Add(customer._customerName);
        }
        return customerList;
    }

    public void IsDomesticOrder()
    {
        bool isDomestic = false;
        foreach (var customer in _customer)
        {
            if (customer.IsUSACustomer())
            {
                isDomestic = true;
                break;
            }
        }
        _shippingCost = isDomestic ? 35 : 5;
    }

    public void ShippingLabel()
    {
        foreach (var customer in _customer)
        {
            Console.WriteLine($"Customer Name: {customer._customerName}");
            Console.WriteLine($"Address: {customer._address.GetFullAddress()}");
        }
    }

    public void PackingLabel()
    {
        foreach (var product in ProductList())
        {
            Console.WriteLine($"Product: {product}");
        }
    }

    public void AddProduct(Product product)
    {
        _product.Add(product);
    }

    public void AddCustomer(Customer customer)
    {
        _customer.Add(customer);
    }

    public int GerShippingCost()
    {
        return _shippingCost;
    }
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");
    }
}
}