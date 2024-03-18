using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer : AgregateRoot
{
    public Customer(CustomerId id, string name, string lastName, string email, PhoneNumber phoneNumber, Adress adress, bool v)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Adress = adress;
    }

    private Customer()
    {

    }

    public CustomerId Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string FullName => $"{Name} {LastName}";

    public string Email { get; private set; } = string.Empty;

    public PhoneNumber PhoneNumber { get; private set; }

    public Adress Adress { get; private set; }

    public bool Active { get; set; }
}
