namespace Milburn_Software2
{
    public class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }

        public Customer(string name, string phone)
        {
            Name = name;
            PhoneNumber = phone;
        }

        public Customer(int customerId, string name, string phone, int addressId)
        {
            CustomerId = customerId;
            Name = name;
            PhoneNumber = phone;
            AddressId = addressId;
        }
    }
}
