namespace Core.Entities
{
    public class Store
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public int CustomerId { get; private set; }

        public Store(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
}
