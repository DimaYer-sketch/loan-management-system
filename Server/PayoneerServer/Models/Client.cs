namespace PayoneerServer.Models
{
    public class Client
    {
        public int Id { get; set; }        // Unique identifier for the client
        public required string Name { get; set; }  // Full name of the client (required)
        public int Age { get; set; }      // Age of the client
    }
}
