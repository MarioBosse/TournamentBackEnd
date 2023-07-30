namespace webapi.Models.Database.Building
{
    public class TransitUserValue
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UInt32 Roles { get; set; } = 0;
        public string Gender { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public String DoorNumber { get; set; } = String.Empty;
        public String StreetName { get;set; } = String.Empty;
        public String[]? Infos { get; set; }
        public String ProfilePicture { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
