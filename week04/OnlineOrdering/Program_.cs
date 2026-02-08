using System;
using System.Dynamic;
using System.Linq;

class Customer
{
    private string _name;
    private Address _address;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Address Address
    {
        get { return _address; }
        set { _address = value; }
    }

    public Customer(string name, Address address)
    {
        _name = name; 
        _address = address;
    }

    public string GetShippingLabel()
    {
        return $"Shipping to: {Name}, {Address.Street}, {Address.City}, {Address.State}, {Address.ZipCode}, {Address.Country}";
    }

}

class Address
{
    private string _street;
    public string Street
    { 
        get { return _street; }
        set { _street = value;} 
    }
    private string _city; 
    public string City
    {
        get { return _city; }
        set { _city = value; }
    }
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; } 
    }
    private string _country;
    public string Country
    {
         get { return _country; }
         set { _country = value; }
    }
    private string _zipcode;
    public string ZipCode
    { 
        get { return _zipcode; }
        set { _zipcode = value; } 
    }
    public bool IsInUSA()
    {
        if (Country == null) return false;
        string c = Country.Trim().ToUpper();
        return c == "USA" || c == "UNITED STATES" || c == "US";
        
    }

    public string GetFullAddress()
    {
        return $"{Street}, {City}, {State}, {ZipCode}, {Country}";
    }
}

class Order
{
    private Customer _customer;
    public Customer Customer 
    {
            get { return _customer; }
            set { _customer = value; }
    }
    public List<Product> Products { get; set; }

    public string GetShippingLabel()

    {
        return $"Shipping to: {_customer.Name}, {_customer.Address.Street}, {_customer.Address.City}, {_customer.Address.State}, {_customer.Address.ZipCode}, {_customer.Address.Country}";
    }
}

class Product
{
    private int _id; 
    private string _name;
    private decimal _price;
    private int _quantity;
    
    public int Id 
    { 
        get  { return _id; }
        set  { _id = value; }
    }
    public string Name 
    { 
        get { return _name;} 
        set { _name = value; }
    }
    public decimal Price
    { 
        get { return _price;} 
        set {_price = value; } 
    }
    public int Quantity
    { 
        get { return _quantity; }
        set { _quantity = value;}
    }

    public decimal GetTotalPrice()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"Product: {_name} (ID: {_id}), Quantity: {_quantity}, Total Price: {GetTotalPrice():C2}";
    }


}



class Program
{
    static void Main(string[] args)
    {


        Address address = new Address
        {
            Street = "305 Saint George Street",
            City = "Utah",
            State = "Avenue Smith",
            Country = "USA",
            ZipCode = "896547"
        };

        Address address2 = new Address
        {
            Street = "Oregon Street, Avenue Smith",
            City = "Oregon",
            State = "Missisippi",
            Country = "USA",
            ZipCode = "291955"
        };

        Customer customer = new Customer("Archangel Michael", address);
        Customer customer2 = new Customer("Archangel Gabriel", address2);

        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Quantity = 5 },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99m, Quantity = 10 },
            new Product { Id = 3, Name = "Tablet", Price = 299.99m, Quantity = 7 }
        };

        List<Product> products2 = new List<Product>
        {
            new Product { Id = 4, Name = "Headphones", Price = 199.99m, Quantity = 15 },
            new Product { Id = 5, Name = "Smartwatch", Price = 499.99m, Quantity = 8},
            new Product { Id = 6, Name = "Camera", Price = 1569.99m, Quantity = 2},
        };

        Order order = new Order { Customer = customer, Products = products };
        Order order2 = new Order { Customer = customer2, Products = products2};
        decimal shippingCost = 25.00m;

        if (customer.Address.IsInUSA())
        {
            shippingCost = 5.00m;
        }
        else
        {
            shippingCost = 35.00m;
        }

        decimal shippingCost2 = 25.00m;

        if (customer2.Address.IsInUSA())
        {
            shippingCost2 = 5.00m;
        }
        else
        {
            shippingCost2 = 35.00m;
        }
        
        decimal total2 = products2.Sum(p => p.GetTotalPrice()) + shippingCost2;
        Console.WriteLine($"Total price + shipping: {total2}");
        Console.WriteLine(order2.GetShippingLabel());
        foreach (var product in order2.Products)
        {
            Console.WriteLine(product.GetPackingLabel());
        }


        decimal total = products.Sum(p => p.GetTotalPrice()) + shippingCost;
        Console.WriteLine($"Total price + shipping: {total}");
        Console.WriteLine(order.GetShippingLabel());

        // Print packing labels for each product
        foreach (var product in order.Products)
        {
            string label = product.GetPackingLabel();
            Console.WriteLine(label);
        }
    }
}


