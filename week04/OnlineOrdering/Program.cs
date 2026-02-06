using System;
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
    private string Street { get; set; }
    private string City { get; set; }
    private string State { get; set; }
    private string Country { get; set; }
    private string ZipCode { get; set; }
    private bool IsInUSA()
    {
        if (Country == null) return false;
        string c = Country.Trim().ToUpper();
        return c == "USA" || c == "UNITED STATES" || c == "US";
        
    }

    private string GetFullAddress()
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

        Customer customer = new Customer();
        customer.Name = "Archangel Michael";
        customer.Address = address;

        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Quantity = 5 },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99m, Quantity = 10 },
            new Product { Id = 3, Name = "Tablet", Price = 299.99m, Quantity = 7 }
        };

        Order order = new Order { Customer = customer, Products = products };

        decimal shippingCost = 25.00m;
        if (customer.Address.IsInUSA())
        {
            shippingCost = 5.00m;
        }
        else
        {
            shippingCost = 35.00m;
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


