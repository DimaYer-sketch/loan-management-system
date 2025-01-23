namespace PayoneerServer.Models
{
    public class LoginRequest
    {
        public required string Username { get; set; } // Username is required
        public required string Password { get; set; } // Password is required
    }
}
