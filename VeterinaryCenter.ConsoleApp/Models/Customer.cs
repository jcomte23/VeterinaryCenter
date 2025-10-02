namespace VeterinaryCenter.ConsoleApp.Models;

public class Customer
{
    public Guid Id { get; set; } 
    public string Name { get; set; } 
    public string LastName { get; set; }
    public DocumentType DocumentType { get; set; }
    public DateOnly BirthDay { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public List<Pet>? Pets { get; set; }

    public Customer(string name, string lastName , DocumentType documentType, DateOnly birthDay, string phoneNumber, string email, string address )
    {
        Id = Guid.NewGuid();
        Name = name;
        LastName = lastName;
        DocumentType = documentType;
        BirthDay = birthDay;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Pets = [];
    }

	public void AddPet(Pet pet)
	{
		Pets?.Add(pet);
	}
}
