using System;
using System.Linq;

class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public string GetShippingLabel()
    {
        return $"Shipping to: {Name}, {Address.Street}, {Address.City}, {Address.State}, {Address.ZipCode}, {Address.Country}";
    }

}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
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
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }

    public string GetShippingLabel()

    {
        return $"Shipping to: {Customer.Name}, {Customer.Address.Street}, {Customer.Address.City}, {Customer.Address.State}, {Customer.Address.ZipCode}, {Customer.Address.Country}";
    }
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal GetTotalPrice()
    {
        return Price * Quantity;
    }

    public string GetPackingLabel()
    {
        return $"Product: {Name} (ID: {Id}), Quantity: {Quantity}, Total Price: {GetTotalPrice():C2}";
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


