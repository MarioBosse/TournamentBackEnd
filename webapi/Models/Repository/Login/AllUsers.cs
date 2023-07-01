namespace webapi.Models.Repository.Login
{
    public class AllUsers
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public bool IsActivated { get; set; } = false;
        public Complements.Address? Address { get; set; } = null;
    }
}
