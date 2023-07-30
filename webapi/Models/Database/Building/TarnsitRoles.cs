namespace webapi.Models.Database.Building
{
    public class TransitRoles
    {
        public string Name { get; set; } = string.Empty;
        public string GuardName { get; set; } = string.Empty;
        public UInt32 Mask { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
